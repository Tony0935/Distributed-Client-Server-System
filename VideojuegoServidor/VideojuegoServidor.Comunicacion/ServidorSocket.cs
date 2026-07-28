using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica;

namespace VideojuegoServidor.Comunicacion
{
    public class infoCliente
    {
        public TcpClient conexion { get; set; }
        public string usuario { get; set; }
        public int? IdJugador { get; set; }

        public infoCliente(TcpClient conexion, string usuario, int? idJugador = null)
        {
            this.conexion = conexion;
            this.usuario = usuario;
            this.IdJugador = idJugador;
        }
    }

    public class JugadorEnEspera
    {
        public int IdEquipo { get; set; }
        public DateTime FechaSolicitud { get; set; }
    }

    public class ServidorSocket
    {
        private readonly string IP_SERVIDOR;
        private readonly int PUERTO_SERVIDOR;
        private readonly int MAX_CLIENTES;

        private TcpListener? servidor;
        private Thread hiloEscucha;
        private bool servidorActivo = false;
        private List<infoCliente> clientesConectados = new List<infoCliente>();

        // Eventos para notificar a la interfaz
        public event Action<string>? NuevaBitacora;
        public event Action<string>? ClienteConectado;
        public event Action<string>? ClienteDesconectado;

        // Sistema de espera para batallas
        private static JugadorEnEspera? jugadorEnEspera = null;
        private static readonly object esperaLock = new object();

        public ServidorSocket()
        {
            try
            {
                // Lee configuración desde App.config
                var ipConfig = ConfigurationManager.AppSettings["IP_SERVIDOR"];
                IP_SERVIDOR = (string.IsNullOrWhiteSpace(ipConfig) || !IPAddress.TryParse(ipConfig, out _))
                    ? "127.0.0.1"
                    : ipConfig;

                var puertoConfig = ConfigurationManager.AppSettings["PUERTO_SERVIDOR"];
                PUERTO_SERVIDOR = (!int.TryParse(puertoConfig, out var puerto) || puerto < 1 || puerto > 65535)
                    ? 14100
                    : puerto;

                var maxConfig = ConfigurationManager.AppSettings["MAX_CLIENTES"];
                MAX_CLIENTES = (!int.TryParse(maxConfig, out var max) || max < 1)
                    ? 8
                    : max;
            }
            catch
            {
                IP_SERVIDOR = "127.0.0.1";
                PUERTO_SERVIDOR = 14100;
                MAX_CLIENTES = 8;
            }

            clientesConectados = new List<infoCliente>();
        }

        // ========================================
        // GESTIÓN DEL SERVIDOR
        // ========================================

        public void IniciarServidor()
        {
            try
            {
                // Inicia el servidor TCP
                servidor = new TcpListener(IPAddress.Parse(IP_SERVIDOR), PUERTO_SERVIDOR);
                servidor.Start();
                servidorActivo = true;

                NuevaBitacora?.Invoke($"Servidor iniciado en {IP_SERVIDOR}:{PUERTO_SERVIDOR}");

                // Inicia el hilo para escuchar conexiones entrantes
                hiloEscucha = new Thread(EscucharConexiones) { IsBackground = true };
                hiloEscucha.Start();
            }
            catch (Exception ex)
            {
                NuevaBitacora?.Invoke($"Error al iniciar el servidor: {ex.Message}");
            }
        }

        public void DetenerServidor()
        {
            try
            {
                servidorActivo = false;
                NuevaBitacora?.Invoke("Iniciando proceso de detención del servidor...");

                // Crear una copia de la lista para evitar problemas de concurrencia
                List<infoCliente> clientesParaCerrar;
                lock (clientesConectados)
                {
                    clientesParaCerrar = new List<infoCliente>(clientesConectados);
                }

                // Notificar y cerrar cada cliente
                foreach (var cliente in clientesParaCerrar)
                {
                    try
                    {
                        // Enviar mensaje de desconexión
                        using (var stream = cliente.conexion.GetStream())
                        using (var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                        {
                            var mensajeDesconexion = new Mensaje("DESCONECTAR", "SERVIDOR", "El servidor se ha cerrado.");
                            string json = JsonConvert.SerializeObject(mensajeDesconexion);
                            writer.WriteLine(json);
                            writer.Flush();
                        }

                        // Dar tiempo para que el mensaje se envíe
                        Thread.Sleep(100);

                        // Cerrar la conexión
                        cliente.conexion.Close();
                        NuevaBitacora?.Invoke($"Cliente {cliente.usuario} desconectado");
                    }
                    catch (Exception ex)
                    {
                        NuevaBitacora?.Invoke($"Error al cerrar conexión de {cliente.usuario}: {ex.Message}");
                    }
                }

                // Limpiar la lista de clientes
                lock (clientesConectados)
                {
                    clientesConectados.Clear();
                }

                // Detener el servidor TCP
                if (servidor != null)
                {
                    servidor.Stop();
                    NuevaBitacora?.Invoke("Servidor TCP detenido");
                }

                // Dar tiempo al hilo de escucha para terminar
                if (hiloEscucha != null && hiloEscucha.IsAlive)
                {
                    if (!hiloEscucha.Join(2000)) // Esperar máximo 2 segundos
                    {
                        NuevaBitacora?.Invoke("El hilo de escucha no terminó a tiempo");
                    }
                }

                NuevaBitacora?.Invoke("Servidor detenido correctamente");
            }
            catch (Exception ex)
            {
                NuevaBitacora?.Invoke($"Error al detener servidor: {ex.Message}");
            }
        }

        // ========================================
        // GESTIÓN DE CONEXIONES
        // ========================================

        private void EscucharConexiones()
        {
            try
            {
                while (servidorActivo)
                {
                    TcpClient Cliente = servidor!.AcceptTcpClient();

                    if (clientesConectados.Count >= MAX_CLIENTES)
                    {
                        NuevaBitacora?.Invoke($"Conexión rechazada. Límite alcanzado: {MAX_CLIENTES}");
                        Cliente.Close();
                        continue;
                    }
                    //Inicia el hilo para atender al cliente
                    Thread hiloCliente = new Thread(() => AtenderCliente(Cliente)) { IsBackground = true };
                    hiloCliente.Start();
                }
            }
            catch (Exception ex)
            {
                if (servidorActivo) 
                    NuevaBitacora?.Invoke($"Error al escuchar conexiones: {ex.Message}");
            }
        }

        private void AtenderCliente(TcpClient cliente)
        {
            string nombreCliente = "Desconocido";
            infoCliente? infoC = null;

            try
            {
                using (var stream = cliente.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true))
                using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true) { AutoFlush = true })
                {
                    // Autenticación inicial
                    if (!AutenticarCliente(reader, writer, cliente, out nombreCliente, out infoC))
                        return;

                    while (cliente.Connected && servidorActivo)
                    {
                        try
                        {
                            // Verificar si el cliente sigue conectado
                            if (!cliente.Connected || !stream.CanRead)
                            {
                                NuevaBitacora?.Invoke($"[{nombreCliente}] Conexión cerrada por el cliente");
                                break;
                            }

                            string? mensajeJson = reader.ReadLine();

                            if (string.IsNullOrEmpty(mensajeJson))
                            {
                                NuevaBitacora?.Invoke($"[{nombreCliente}] Mensaje vacío recibido, cerrando conexión");
                                break;
                            }

                            NuevaBitacora?.Invoke($"[{nombreCliente}] Mensaje recibido");

                            Mensaje? mensaje = JsonConvert.DeserializeObject<Mensaje>(mensajeJson);

                            if (mensaje != null)
                            {
                                // Si el cliente envía DESCONECTAR cierra la conexión
                                if (mensaje.Accion == "DESCONECTAR")
                                {
                                    NuevaBitacora?.Invoke($"[{nombreCliente}] Solicitud de desconexión");
                                    EnviarMensaje(writer, new Mensaje("DESCONECTAR", "JUGADOR", "Desconectado correctamente"));
                                    break;
                                }

                                Mensaje respuesta = ProcesarMensaje(mensaje);
                                EnviarMensaje(writer, respuesta);

                                NuevaBitacora?.Invoke($"[{nombreCliente}] Respuesta enviada: {respuesta.Accion}");
                            }
                        }
                        catch (System.IO.IOException ioEx) //Maneja las desconexiones inesperadas
                        {
                            NuevaBitacora?.Invoke($"[{nombreCliente}] IOException: {ioEx.Message}");
                            break;
                        }
                        catch (Exception ex) //otros errores
                        {
                            NuevaBitacora?.Invoke($"[{nombreCliente}] Error procesando mensaje: {ex.Message}");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NuevaBitacora?.Invoke($"[{nombreCliente}] Error en AtenderCliente: {ex.Message}");
            }
            finally
            {
                // Remover cliente de la lista
                if (infoC != null)
                {
                    lock (clientesConectados)
                    {
                        clientesConectados.Remove(infoC);
                    }
                }

                try
                {
                    cliente.Close();
                }
                catch (Exception ex)
                {
                    NuevaBitacora?.Invoke($"[{nombreCliente}] Error al cerrar conexión: {ex.Message}");
                }

                NuevaBitacora?.Invoke($"Cliente desconectado: {nombreCliente}");
                ClienteDesconectado?.Invoke(nombreCliente);
            }
        }

        // ========================================
        // AUTENTICACIÓN
        // ========================================

        private bool AutenticarCliente(StreamReader reader, StreamWriter writer, TcpClient cliente, out string nombreCliente, out infoCliente? infoC)
        {
            nombreCliente = "Desconocido";
            infoC = null;

            try
            {
                string? mensajeInicioJson = reader.ReadLine();
                if (string.IsNullOrEmpty(mensajeInicioJson))
                    return false;

                Mensaje? mensajeInicio = JsonConvert.DeserializeObject<Mensaje>(mensajeInicioJson);

                if (mensajeInicio?.Accion == "CONECTAR" && mensajeInicio.Tipo == "JUGADOR")
                {
                    var datosLogin = JsonConvert.DeserializeObject<LoginDTO>(mensajeInicio.Datos);

                    if (datosLogin != null)
                    {
                        // Validar y obtener jugador 
                        JugadorEntidad? jugador = JugadorLN.ValidarYObtenerJugador(datosLogin.Usuario, datosLogin.Password);

                        if (jugador != null)
                        {
                            // Verificar si ya hay una sesión con ese usuario
                            lock (clientesConectados)
                            {
                                bool yaConectado = clientesConectados
                                    .Any(c => string.Equals(c.usuario, jugador.Usuario, StringComparison.OrdinalIgnoreCase));

                                if (yaConectado)
                                {
                                    EnviarMensaje(writer, new Mensaje("ERROR", "JUGADOR", "Usuario ya conectado en otra sesión."));
                                    return false;
                                }
                            }

                            nombreCliente = jugador.Usuario;
                            infoC = new infoCliente(cliente, nombreCliente, jugador.IdJugador);
                            lock (clientesConectados) { clientesConectados.Add(infoC); }

                            NuevaBitacora?.Invoke($"Cliente conectado: {nombreCliente} (ID: {jugador.IdJugador})");
                            ClienteConectado?.Invoke(nombreCliente);

                            EnviarMensaje(writer, new Mensaje("OK", "JUGADOR", $"Bienvenido {nombreCliente}"));
                            return true;
                        }
                        else
                        {
                            EnviarMensaje(writer, new Mensaje("ERROR", "JUGADOR", "Credenciales inválidas"));
                            return false;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                NuevaBitacora?.Invoke($"Error en autenticación: {ex.Message}");
                return false;
            }
        }

        // ========================================
        // PROCESAMIENTO DE MENSAJES
        // ========================================

        private Mensaje ProcesarMensaje(Mensaje mensaje)
        {
            try
            {
                return mensaje.Tipo switch
                {
                    "CRIATURA" => ProcesarCriatura(mensaje),
                    "INVENTARIO" => ProcesarInventario(mensaje),
                    "EQUIPO" => ProcesarEquipo(mensaje),
                    "BATALLA" => ProcesarBatalla(mensaje),
                    "RONDA" => ProcesarRonda(mensaje),
                    "JUGADOR" => ProcesarJugador(mensaje),
                    _ => new Mensaje("ERROR", "DESCONOCIDO", $"Tipo de mensaje no reconocido: {mensaje.Tipo}")
                };
            }
            catch (Exception ex)
            {
                return new Mensaje("ERROR", "EXCEPCION", ex.Message);
            }
        }

        // ========================================
        // PROCESADORES POR ENTIDAD
        // ========================================

        private Mensaje ProcesarCriatura(Mensaje mensaje)
        {
            if (mensaje.Accion == "OBTENER")
            {
                var criaturas = CriaturasLN.ConsultarCriaturas();
                return new Mensaje("OBTENER", "CRIATURA", JsonConvert.SerializeObject(criaturas));
            }

            return new Mensaje("ERROR", "CRIATURA", "Acción no reconocida");
        }

        private Mensaje ProcesarInventario(Mensaje mensaje)
        {
            switch (mensaje.Accion)
            {
                case "COMPRAR":
                    var inv = JsonConvert.DeserializeObject<InventarioEntidad>(mensaje.Datos);
                    if (inv == null)
                        return new Mensaje("ERROR", "INVENTARIO", "Datos inválidos");

                    string resultado = InventarioLN.ComprarCriatura(inv.IdJugador, inv.IdCriatura);
                    return new Mensaje("OK", "INVENTARIO", resultado);

                case "OBTENER":
                    if (int.TryParse(mensaje.Datos, out int idJugador))
                    {
                        var inventario = InventarioLN.ConsultarInventarioPorJugador(idJugador);
                        return new Mensaje("OBTENER", "INVENTARIO", JsonConvert.SerializeObject(inventario));
                    }
                    else
                    {
                        var inventario = InventarioLN.ConsultarInventario();
                        return new Mensaje("OBTENER", "INVENTARIO", JsonConvert.SerializeObject(inventario));
                    }

                case "OBTENER_TIENDA":
                    int idJug = int.Parse(mensaje.Datos);
                    var criaturasDisp = InventarioLN.CriaturasDispJugador(idJug);
                    return new Mensaje("OBTENER_TIENDA", "INVENTARIO", JsonConvert.SerializeObject(criaturasDisp));

                default:
                    return new Mensaje("ERROR", "INVENTARIO", "Acción no reconocida");
            }
        }

        private Mensaje ProcesarEquipo(Mensaje mensaje)
        {
            switch (mensaje.Accion)
            {
                case "REGISTRAR":
                    var equipo = JsonConvert.DeserializeObject<EquipoEntidad>(mensaje.Datos);
                    EquipoLN.RegistrarEquipo(equipo);
                    return new Mensaje("REGISTRAR", "EQUIPO", "Equipo registrado correctamente");

                case "OBTENER":
                    var equipos = EquipoLN.ConsultarEquipos();
                    return new Mensaje("OBTENER", "EQUIPO", JsonConvert.SerializeObject(equipos));

                default:
                    return new Mensaje("ERROR", "EQUIPO", "Acción no reconocida");
            }
        }

        private Mensaje ProcesarBatalla(Mensaje mensaje)
        {
            switch (mensaje.Accion)
            {
                case "INICIAR":
                    try
                    {
                        var datos = JsonConvert.DeserializeObject<BatallaEntidad>(mensaje.Datos);
                        if (datos == null)
                            return new Mensaje("ERROR", "BATALLA", "Datos de batalla inválidos");

                        lock (esperaLock)
                        {
                            if (jugadorEnEspera == null)
                            {
                                jugadorEnEspera = new JugadorEnEspera
                                {
                                    IdEquipo = datos.IdEquipo1,
                                    FechaSolicitud = DateTime.Now
                                };

                                return new Mensaje("ESPERA", "BATALLA", "Esperando a otro jugador...");
                            }
                            else
                            {
                                // Crear la batalla entre ambos jugadores
                                var batalla = new BatallaEntidad
                                {
                                    IdEquipo1 = jugadorEnEspera.IdEquipo,
                                    IdEquipo2 = datos.IdEquipo1,
                                    Fecha = DateTime.Now
                                };

                                // Registrar la batalla y obtener el mensaje de resultado (ganador, etc.)
                                string resultado = BatallaLN.RegistrarBatalla(batalla);

                                // limpiar la espera
                                jugadorEnEspera = null;

                                // Enviar JSON con el mensaje + la batalla
                                var respuesta = new
                                {
                                    Mensaje = resultado,
                                    Batalla = batalla
                                };

                                return new Mensaje("INICIADA", "BATALLA", JsonConvert.SerializeObject(respuesta));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new Mensaje("ERROR", "BATALLA", $"Error al iniciar la batalla: {ex.Message}");
                    }

                case "OBTENER_JUGADOR":
                    int idJugador = int.Parse(mensaje.Datos);
                    var batallas = BatallaLN.ConsultarBatallasPorJugador(idJugador);
                    return new Mensaje("OBTENER_JUGADOR", "BATALLA", JsonConvert.SerializeObject(batallas));

                case "OBTENER":
                    var todasBatallas = BatallaLN.ConsultarBatallas();
                    return new Mensaje("OBTENER", "BATALLA", JsonConvert.SerializeObject(todasBatallas));

                default:
                    return new Mensaje("ERROR", "BATALLA", "Acción no reconocida");
            }
        }

        private Mensaje ProcesarRonda(Mensaje mensaje)
        {
            if (mensaje.Accion == "OBTENER")
            {
                var rondas = RondasLN.ConsultarRondas();
                return new Mensaje("OBTENER", "RONDA", JsonConvert.SerializeObject(rondas));
            }

            return new Mensaje("ERROR", "RONDA", "Acción no reconocida");
        }

        private Mensaje ProcesarJugador(Mensaje mensaje)
        {
            switch (mensaje.Accion)
            {
                case "OBTENER":
                    var jugadores = JugadorLN.ConsultarJugadores();
                    return new Mensaje("OK", "JUGADOR", JsonConvert.SerializeObject(jugadores));

                case "OBTENER_TOP10":
                    var top10 = JugadorLN.ConsultarTop10Ganadores();
                    return new Mensaje("OK", "JUGADOR", JsonConvert.SerializeObject(top10));

                case "CONSULTAR":
                    int idJugador = int.Parse(mensaje.Datos);
                    var jugador = JugadorLN.ConsultarJugadorPorId(idJugador);
                    return new Mensaje("CONSULTAR", "JUGADOR", JsonConvert.SerializeObject(jugador));

                case "DESCONECTAR":
                    return new Mensaje("DESCONECTAR", "JUGADOR", "Desconectado correctamente");

                default:
                    return new Mensaje("ERROR", "JUGADOR", "Acción no reconocida");
            }
        }

        // ========================================
        // MÉTODOS AUXILIARES
        // ========================================

        // Enviar mensaje a un cliente específico
        private void EnviarMensaje(TcpClient cliente, Mensaje mensaje)
        {
            using (var stream = cliente.GetStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
            {
                EnviarMensaje(writer, mensaje);
            }
        }

        // Enviar mensaje
        private void EnviarMensaje(StreamWriter writer, Mensaje mensaje)
        {
            string json = JsonConvert.SerializeObject(mensaje);
            writer.WriteLine(json);
            writer.Flush();
        }
    }
}