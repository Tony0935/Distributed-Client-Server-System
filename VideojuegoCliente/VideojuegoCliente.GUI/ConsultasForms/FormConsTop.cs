using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideojuegoCliente.Comunicacion;
using VideojuegoServidor.Entidades;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para consultar el Top 10 de jugadores con más batallas ganadas.
    Solicita los datos al servidor mediante el socket del cliente y los muestra en un DataGridView.
*/

namespace VideojuegoCliente.GUI.ConsultasForms
{
    public partial class FormConsTop : Form
    {
        private readonly ClienteSocket socket;

        public FormConsTop(ClienteSocket socket)
        {
            InitializeComponent();
            this.socket = socket ?? throw new ArgumentNullException(nameof(socket));

            ConfigurarDataGridView();
            CargarTop10();
        }

        private void ConfigurarDataGridView()
        {
            dataGVTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVTop.Columns.Clear();

            dataGVTop.Columns.Add("ColIdJugador", "ID");
            dataGVTop.Columns.Add("ColNombre", "Nombre");
            dataGVTop.Columns.Add("ColFechaNacimiento", "Fecha Nacimiento");
            dataGVTop.Columns.Add("ColNivel", "Nivel");
            dataGVTop.Columns.Add("ColCristales", "Cristales");
            dataGVTop.Columns.Add("ColBatallasGanadas", "Batallas Ganadas");

            dataGVTop.ReadOnly = true;
            dataGVTop.AllowUserToAddRows = false;
            dataGVTop.AllowUserToDeleteRows = false;
            dataGVTop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void CargarTop10()
        {
            try
            {
                dataGVTop.Rows.Clear();

                // Obtener Top 10 desde el servidor
                List<JugadorEntidad> top10 = socket.ObtenerTop10();

                if (top10 == null || top10.Count == 0)
                    return;

                foreach (JugadorEntidad jugador in top10)
                {
                    dataGVTop.Rows.Add(
                        jugador.IdJugador,
                        jugador.Nombre,
                        jugador.FechaNacimiento.ToString("dd/MM/yyyy"),
                        jugador.Nivel, // o usa un método para formatear si quieres
                        $"{jugador.Cristales} cristales",
                        $"{jugador.BatallasGanadas} batallas"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Top 10: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}