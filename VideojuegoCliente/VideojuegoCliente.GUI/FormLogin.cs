using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videojuego.GUI;
using VideojuegoCliente.Comunicacion;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Interfaz de inicio de sesión del cliente. Permite seleccionar IP y puerto,
    validar campos, conectarse al servidor mediante ClienteSocket y autenticar al usuario.
*/

namespace VideojuegoCliente.GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            // Selecciona el primer elemento en los ComboBox
            if (cbIP.Items.Count > 0)
                cbIP.SelectedIndex = 0;

            if (cbPuerto.Items.Count > 0)
                cbPuerto.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbIP.Text) || string.IsNullOrWhiteSpace(cbPuerto.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbPuerto.Text, out int puerto))
            {
                MessageBox.Show("El puerto debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteSocket socket = new ClienteSocket();
            Mensaje respuesta = socket.ConectarServidor(cbIP.Text, puerto, txtUsuario.Text, txtPassword.Text);

            if (respuesta == null)
            {
                MessageBox.Show("No se recibió respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si el servidor devuelve OK -> continuar
            if (respuesta.Accion == "OK" || respuesta.Accion == "CONECTADO")
            {
                // Obtener lista de jugadores
                var jugadores = socket.ObtenerJugadores();

                if (jugadores != null)
                {
                    // Buscar el jugador con el usuario que inició sesión
                    var jugadorActual = jugadores.FirstOrDefault(j => string.Equals(j.Usuario, txtUsuario.Text, StringComparison.Ordinal));

                    if (jugadorActual != null)
                    {
                        this.Hide();
                        var menu = new MenuPrincipal(socket, jugadorActual.IdJugador, jugadorActual.Nombre);
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado en la lista.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener datos de jugador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(respuesta.Datos ?? "No se pudo conectar: respuesta del servidor indefinida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}