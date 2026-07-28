using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;
using VideojuegoCliente.Comunicacion;
using VideojuegoCliente.GUI;
using VideojuegoCliente.GUI.ConsultasForms;
using VideojuegoCliente.GUI.RegistrosForms;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario es el menú principal del proyecto, 
    permite navegar a los submenús de gestión de entidades y consultar el top de ganadores.
*/

namespace Videojuego.GUI
{
    public partial class MenuPrincipal : Form
    {
        private readonly ClienteSocket socket;
        private readonly string nombreJugador;
        private readonly int idJugadorActual;

        private bool desconexionPorServidor = false;

        public MenuPrincipal(ClienteSocket socket, int idJugadorActual, string nombreJugador)
        {
            InitializeComponent();
            this.socket = socket;
            this.idJugadorActual = idJugadorActual;
            this.nombreJugador = nombreJugador;

            //Mostrar nombre del jugador
            this.Text = $"Menú Principal - {nombreJugador}";

            //Evento de desconexión
            this.socket.ServidorDesconectado += ServidorDesconectado;
        }

        //Maneja la desconexión del servidor
        private void ServidorDesconectado()
        {
            try
            {
                if (IsDisposed)
                    return;

                if (InvokeRequired)
                {
                    try
                    {
                        if (!IsDisposed && IsHandleCreated)
                            Invoke(new Action(ServidorDesconectado));
                    }
                    catch (ObjectDisposedException) { }
                    return;
                }

                desconexionPorServidor = true;

                MessageBox.Show("El servidor se ha desconectado. Se volverá al inicio de sesión.",
                    "Conexión perdida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cerrar todos los formularios abiertos excepto el actual y el login
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form != this && !(form is FormLogin) && !form.IsDisposed)
                        form.Close();
                }

                // Cerrar este formulario y abrir el login
                if (!IsDisposed)
                    Close();

                var login = new FormLogin();
                login.Show();
            }
            catch { }
        }

        //Botones del submenú 
        private void btnRegistrarInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Inventario",
                (s, args) =>
                {
                    var formRegistro = new FormRegInv(socket, idJugadorActual, nombreJugador);
                    formRegistro.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsInv(socket, nombreJugador, idJugadorActual);
                    formConsulta.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) =>
                {
                    subMenu.Close();
                    if (!this.IsDisposed)
                        this.Show();
                }
            );
            subMenu.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed)
                    this.Show();
            };
            subMenu.Show();
        }
        private void btnRegistrarEquipos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Equipos",
                (s, args) =>
                {
                    var formRegistro = new FormRegEquipo(socket, idJugadorActual, nombreJugador);
                    formRegistro.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsEquipo(socket, idJugadorActual);
                    formConsulta.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) =>
                {
                    subMenu.Close();
                    if (!this.IsDisposed)
                        this.Show();
                }
            );
            subMenu.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed)
                    this.Show();
            };
            subMenu.Show();
        }
        private void btnRegistrarBatalla_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Batalla",
                (s, args) =>
                {
                    var formRegistro = new FormRegBatalla(socket, idJugadorActual, nombreJugador);
                    formRegistro.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsBatalla(socket, idJugadorActual);
                    formConsulta.FormClosed += (fs, fe) =>
                    {
                        if (!subMenu.IsDisposed)
                            subMenu.Show();
                    };
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) =>
                {
                    subMenu.Close();
                    if (!this.IsDisposed)
                        this.Show();
                }
            );
            subMenu.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed)
                    this.Show();
            };
            subMenu.Show();
        }

        private void btnRegistrarRondas_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formConsulta = new FormConsRondas(socket, idJugadorActual);
            formConsulta.FormClosed += (fs, fe) =>
            {
                if (!this.IsDisposed)
                    this.Show();
            };
            formConsulta.Show();
        }

        private void btnTopGanadores_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formTopJugadores = new FormConsTop(socket);
            formTopJugadores.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed)
                    this.Show();
            };
            formTopJugadores.Show();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (socket != null && socket.EstaConectado)
                {
                    //Desuscribirse del evento antes de desconectar
                    socket.ServidorDesconectado -= ServidorDesconectado;

                    var mensaje = new Mensaje("DESCONECTAR", "JUGADOR", nombreJugador);
                    string json = JsonConvert.SerializeObject(mensaje);
                    socket.Enviar(json);

                    socket.Desconectar();
                }

                this.Close();
                var login = new FormLogin();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desconectarse: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}