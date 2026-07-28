using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using VideojuegoServidor.Entidades;

namespace VideojuegoCliente.Comunicacion
{
    public class ClienteSocket
    {
        private TcpClient cliente = null!;
        private StreamReader reader = null!;
        private StreamWriter writer = null!;
        private Thread? hiloEscucha; // Hilo para escuchar

        public bool EstaConectado { get; private set; } = false;
        public JugadorEntidad? JugadorConectado { get; private set; } = null;

        public event Action? ServidorDesconectado; //Evento para notificar desconexión del servidor

        public ClienteSocket() { }

        // ========================================
        // CONEXIÓN Y DESCONEXIÓN
        // ========================================

        public Mensaje ConectarServidor(string ip, int puerto, string usuario, string password)
        {
            try
            {
                cliente = new TcpClient();
                cliente.Connect(ip, puerto);

                var stream = cliente.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                var datosLogin = new { Usuario = usuario, Password = password };
                Mensaje mensajeInicio = new Mensaje("CONECTAR", "JUGADOR", JsonConvert.SerializeObject(datosLogin));

                string mensajeJson = JsonConvert.SerializeObject(mensajeInicio).Replace("\r", "").Replace("\n", "");
                writer.WriteLine(mensajeJson);

                string? respuestaInicioJson = reader.ReadLine();
                if (string.IsNullOrEmpty(respuestaInicioJson))
                {
                    Desconectar();
                    return new Mensaje("ERROR", "CONEXION", "No se recibió respuesta del servidor.");
                }

                Mensaje? respuestaInicio = JsonConvert.DeserializeObject<Mensaje>(respuestaInicioJson);
                if (respuestaInicio != null && (respuestaInicio.Accion == "OK" || respuestaInicio.Accion == "CONECTADO"))
                {
                    EstaConectado = true;
                    IniciarEscucha();
                }

                return respuestaInicio ?? new Mensaje("ERROR", "JUGADOR", "Respuesta nula del servidor.");
            }
            catch (SocketException)
            {
                return new Mensaje("ERROR", "CONEXION",
                    "No se pudo conectar al servidor. Verifica que el servidor esté disponible.");
            }
            catch (Exception ex)
            {
                return new Mensaje("ERROR", "EXCEPCION",
                    $"Ocurrió un error inesperado al intentar conectar: {ex.Message}");
            }

        }

        public void Desconectar()
        {
            try
            {
                reader?.Close();
                writer?.Close();
                cliente?.Close();
            }
            catch { }
            finally
            {
                EstaConectado = false;
            }
        }

        //Método para escuchar mensajes del servidor en segundo plano
        private void IniciarEscucha()
        {
            hiloEscucha = new Thread(() =>
            {
                try
                {
                    while (EstaConectado && cliente != null && cliente.Connected)
                    {
                        try
                        {
                            // Verificar si el socket sigue conectado
                            if (cliente.Client.Poll(1000, SelectMode.SelectRead) && cliente.Available == 0)
                                break;

                            // Procesar mensaje recibido
                            if (cliente.GetStream().DataAvailable)
                            {
                                string? mensaje = reader?.ReadLine();
                                if (string.IsNullOrEmpty(mensaje))
                                    break;

                                try
                                {
                                    Mensaje? msg = JsonConvert.DeserializeObject<Mensaje>(mensaje);
                                    if (msg?.Accion == "DESCONECTAR" && msg.Tipo == "SERVIDOR")
                                        break;
                                }
                                catch
                                {
                                }
                            }

                            Thread.Sleep(100); // Pausa para reducir uso de CPU
                        }
                        catch
                        {
                            break; // Cualquier error interno rompe el bucle de escucha
                        }
                    }
                }
                finally
                {
                    EstaConectado = false;

                    // Notificar al cliente que el servidor se desconectó
                    try
                    {
                        ServidorDesconectado?.Invoke();
                    }
                    catch
                    {
                    }
                }
            })
            {
                IsBackground = true, // Hilo en segundo plano
                Name = "HiloEscuchaCliente"
            };

            hiloEscucha.Start();
        }

        // ========================================
        // COMUNICACIÓN BASE
        // ========================================

        public Mensaje EnviarYRecibirMensaje(Mensaje mensaje)
        {
            if (!EstaConectado || writer == null || reader == null)
                return new Mensaje("ERROR", "CONEXION", "Cliente no conectado.");

            try
            {
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                writer.WriteLine(mensajeJson);

                string? respuestaJson = reader.ReadLine();

                if (string.IsNullOrEmpty(respuestaJson))
                    return new Mensaje("ERROR", "CONEXION", "No se recibió respuesta del servidor.");

                Mensaje? respuesta = JsonConvert.DeserializeObject<Mensaje>(respuestaJson);
                return respuesta ?? new Mensaje("ERROR", "DESERIALIZACION", "Respuesta no válida.");
            }
            catch (Exception ex)
            {
                return new Mensaje("ERROR", "EXCEPCION", ex.Message);
            }
        }

        public void Enviar(string json)
        {
            if (!EstaConectado || writer == null) return;
            try { writer.WriteLine(json); } catch { }
        }

        // ========================================
        // OPERACIONES - JUGADOR
        // ========================================

        public List<JugadorEntidad> ObtenerJugadores()
        {
            Mensaje mensaje = new Mensaje("OBTENER", "JUGADOR", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<JugadorEntidad>>(respuesta.Datos);

            return new List<JugadorEntidad>();
        }

        public int ObtenerCristalesJugador(int idJugador)
        {
            Mensaje mensaje = new Mensaje("CONSULTAR", "JUGADOR", idJugador.ToString());
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && respuesta.Accion == "CONSULTAR")
            {
                JugadorEntidad? jugador = Deserializar<JugadorEntidad>(respuesta.Datos);
                return jugador?.Cristales ?? 0;
            }

            return 0;
        }

        public List<JugadorEntidad> ObtenerTop10()
        {
            Mensaje mensaje = new Mensaje("OBTENER_TOP10", "JUGADOR", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<JugadorEntidad>>(respuesta.Datos);

            return new List<JugadorEntidad>();
        }

        // ========================================
        // OPERACIONES - CRIATURA
        // ========================================

        public List<CriaturasEntidad> ObtenerCriaturas()
        {
            Mensaje mensaje = new Mensaje("OBTENER", "CRIATURA", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<CriaturasEntidad>>(respuesta.Datos);

            return new List<CriaturasEntidad>();
        }

        public List<CriaturasEntidad> CriaturasDispJugador(int idJugador)
        {
            Mensaje mensaje = new Mensaje("OBTENER_TIENDA", "INVENTARIO", idJugador.ToString());
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER_TIENDA"))
                return Deserializar<List<CriaturasEntidad>>(respuesta.Datos);

            return new List<CriaturasEntidad>();
        }

        // ========================================
        // OPERACIONES - INVENTARIO
        // ========================================

        public string ComprarCriatura(int idJugador, int idCriatura)
        {
            InventarioEntidad inv = new InventarioEntidad { IdJugador = idJugador, IdCriatura = idCriatura };
            string json = JsonConvert.SerializeObject(inv);
            Mensaje mensaje = new Mensaje("COMPRAR", "INVENTARIO", json);
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && respuesta.Accion != "ERROR" && respuesta.Accion != "EXCEPCION")
                return respuesta.Datos ?? "OK";

            return respuesta?.Datos ?? "Error: La compra no fue procesada correctamente.";
        }

        public List<InventarioEntidad> ObtenerInventario(int idJugador)
        {
            Mensaje mensaje = new Mensaje("OBTENER", "INVENTARIO", idJugador.ToString());
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<InventarioEntidad>>(respuesta.Datos);

            return new List<InventarioEntidad>();
        }

        public List<InventarioEntidad> ObtenerTodoInventario()
        {
            Mensaje mensaje = new Mensaje("OBTENER", "INVENTARIO", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<InventarioEntidad>>(respuesta.Datos);

            return new List<InventarioEntidad>();
        }

        // ========================================
        // OPERACIONES - EQUIPO
        // ========================================

        public string RegistrarEquipo(EquipoEntidad equipo)
        {
            string json = JsonConvert.SerializeObject(equipo);
            Mensaje mensaje = new Mensaje("REGISTRAR", "EQUIPO", json);
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && respuesta.Accion != "ERROR" && respuesta.Accion != "EXCEPCION")
                return respuesta.Datos ?? "Equipo registrado";

            return respuesta?.Datos ?? "Error al registrar equipo";
        }

        public List<EquipoEntidad> ObtenerEquipos()
        {
            Mensaje mensaje = new Mensaje("OBTENER", "EQUIPO", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<EquipoEntidad>>(respuesta.Datos);

            return new List<EquipoEntidad>();
        }

        // ========================================
        // OPERACIONES - BATALLA
        // ========================================

        public string RegistrarBatalla(BatallaEntidad batalla)
        {
            string json = JsonConvert.SerializeObject(batalla);
            Mensaje mensaje = new Mensaje("INICIAR", "BATALLA", json);
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta == null)
                return "Error: No se recibió respuesta del servidor.";

            if (respuesta.Accion == "ESPERA")
                return "Esperando a otro jugador...";

            if (respuesta.Accion == "INICIADA")
            {
                try
                {
                    // Deserializa el JSON 
                    var datos = JsonConvert.DeserializeObject<dynamic>(respuesta.Datos);
                    string mensajeResultado = datos?.Mensaje ?? "Batalla registrada correctamente.";

                    return mensajeResultado;
                }
                catch
                {
                    return respuesta.Datos ?? "Batalla registrada.";
                }
            }
            return respuesta.Datos ?? "Error: No se pudo registrar la batalla.";
        }

        public List<BatallaEntidad> ObtenerBatallasJugador(int idJugador)
        {
            Mensaje mensaje = new Mensaje("OBTENER_JUGADOR", "BATALLA", idJugador.ToString());
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER_JUGADOR"))
                return Deserializar<List<BatallaEntidad>>(respuesta.Datos);

            return new List<BatallaEntidad>();
        }

        // ========================================
        // OPERACIONES - RONDA
        // ========================================

        public List<RondasEntidad> ObtenerRondas()
        {
            Mensaje mensaje = new Mensaje("OBTENER", "RONDA", "");
            Mensaje respuesta = EnviarYRecibirMensaje(mensaje);

            if (respuesta != null && (respuesta.Accion == "OK" || respuesta.Accion == "OBTENER"))
                return Deserializar<List<RondasEntidad>>(respuesta.Datos);

            return new List<RondasEntidad>();
        }

        // ========================================
        // MÉTODOS AUXILIARES
        // ========================================

        //Método para deserializar JSON
        private ObjetoT Deserializar<ObjetoT>(string? json) where ObjetoT : class, new()
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                    return new ObjetoT();

                return JsonConvert.DeserializeObject<ObjetoT>(json) ?? new ObjetoT();
            }
            catch
            {
                return new ObjetoT();
            }
        }
    }
}