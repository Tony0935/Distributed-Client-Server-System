using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Videojuego.GUI;
using VideojuegoServidor.AccesoDatos;
using VideojuegoServidor.Comunicacion;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario de administración del servidor. Inicializa la bitácora y la lista
    de clientes, prueba la conexión a la base de datos, inicia/detiene el ServidorSocket,
    muestra eventos y mensajes del servidor en la bitácora, lleva el control de clientes
    conectados y ofrece accesos a los formularios de gestión (jugador, criatura).
*/

namespace VideojuegoServidor.GUI
{
    public partial class FormServidor : Form
    {
        private bool conexionActiva = false; // Estado de conexión BD
        private ServidorSocket servidor;
        private bool servidorActivo = false; // Estado del servidor

        public FormServidor()
        {
            InitializeComponent();
            InicializarBitacora();
            InicializarClientes();
            ProbarConexionBD();
        }

        // Inicializa las columnas de la bitácora
        private void InicializarBitacora()
        {
            BitacoraLog.Bitacora = dgvBitacora;
            dgvBitacora.Columns.Clear();
            dgvBitacora.Columns.Add("FechaHora", "Fecha y Hora");
            dgvBitacora.Columns.Add("Accion", "Acción");
            dgvBitacora.Columns.Add("Resultado", "Resultado");
        }

        // Inicializa las columnas de los clientes conectados
        private void InicializarClientes()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Usuario", "Usuario");
            dgvClientes.Columns.Add("Estado", "Estado");
            dgvClientes.Columns.Add("HoraConexion", "Hora de Conexión");
        }

        //Prueba la conexión con la base de datos SQL
        private void ProbarConexionBD()
        {
            string resultado;
            string accion = conexionActiva ? "Desconexión BD" : "Conexión BD";
            if (ConexionBD.ProbarConexion())
            {
                conexionActiva = true;
                resultado = "Conexión exitosa";
            }
            else
            {
                resultado = "Error al conectar";
            }
            dgvBitacora.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), accion, resultado);
        }

        // Inicia el formulario
        private void FormServidor_Load(object sender, EventArgs e)
        {
            servidor = new ServidorSocket();

            // Mostrar mensajes en la bitácora
            servidor.NuevaBitacora += (msg) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                        dgvBitacora.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Servidor", msg)
                    ));
                }
                else
                {
                    dgvBitacora.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Servidor", msg);
                }
            };

            // Mostrar clientes conectados
            servidor.ClienteConectado += Servidor_ClienteConectado;
            servidor.ClienteDesconectado += Servidor_ClienteDesconectado;
        }

        // Cliente conectado
        private void Servidor_ClienteConectado(string nombre)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Servidor_ClienteConectado), nombre);
                return;
            }

            dgvClientes.Rows.Add(nombre, "Conectado", DateTime.Now.ToString("HH:mm:ss"));
            ActualizarUsuariosConectados();
        }

        // Cliente desconectado
        private void Servidor_ClienteDesconectado(string nombre)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Servidor_ClienteDesconectado), nombre);
                return;
            }

            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (fila.Cells[0].Value?.ToString() == nombre)
                {
                    fila.Cells[1].Value = "Desconectado";
                    return;
                }
            }
            ActualizarUsuariosConectados();
        }

        // Actualiza el contador de usuarios conectados
        private void ActualizarUsuariosConectados()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ActualizarUsuariosConectados));
                return;
            }

            int conectados = 0;

            // Contar cuántos clientes están en estado "Conectado"
            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (fila.Cells["Estado"].Value?.ToString() == "Conectado")
                {
                    conectados++;
                }
            }

            lblUsuariosCon.Text = $"Usuarios conectados: {conectados}/8";
        }

        // Cambia el color del botón de conexión
        private void EstadoConexion(bool activa)
        {
            if (activa)
            {
                btnConexionClientes.Text = "Terminar conexión";
                btnConexionClientes.BackColor = Color.Crimson;
            }
            else
            {
                btnConexionClientes.Text = "Establecer conexión";
                btnConexionClientes.BackColor = Color.ForestGreen;
            }
        }

        // Botón para iniciar o detener el servidor
        private void btnConexionClientes_Click(object sender, EventArgs e)
        {
            if (!servidorActivo)
            {
                servidor.IniciarServidor();
                servidorActivo = true;
                EstadoConexion(true);
            }
            else
            {
                servidor.DetenerServidor(); 
                servidorActivo = false;
                EstadoConexion(false);
                dgvBitacora.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Servidor", "Servidor detenido");
                dgvClientes.Rows.Clear();
                ActualizarUsuariosConectados();
            }
        }

        //Botones de gestión de jugadores
        private void btnGestionJugador_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Jugador",
                (s, args) =>
                {
                    var formRegistro = new FormRegJugador();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsJugador();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        //Botón de gestión de criaturas
        private void btnGestionCriatura_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Criatura",
                (s, args) =>
                {
                    var formRegistro = new FormRegCriatura();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsCriatura();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }
    }
}
