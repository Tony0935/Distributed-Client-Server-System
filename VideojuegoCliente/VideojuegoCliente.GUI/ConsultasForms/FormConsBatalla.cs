using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VideojuegoCliente.Comunicacion;
using VideojuegoServidor.Entidades;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Clase: FormConsBatalla
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para consultar las batallas en las que ha participado
    el jugador actual.
*/

namespace VideojuegoCliente.GUI.ConsultasForms
{
    public partial class FormConsBatalla : Form
    {
        private readonly ClienteSocket socket;
        private readonly int idJugadorActual;

        public FormConsBatalla(ClienteSocket socket, int idJugador)
        {
            InitializeComponent();
            this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
            this.idJugadorActual = idJugador;

            ConfigurarDataGridView();
            CargarBatallas();
        }

        private void ConfigurarDataGridView()
        {
            dataGVBatalla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVBatalla.Columns.Clear();

            dataGVBatalla.Columns.Add("ColIdbatalla", "ID Batalla");
            dataGVBatalla.Columns.Add("ColJ1", "Jugador 1");
            dataGVBatalla.Columns.Add("ColJ2", "Jugador 2");
            dataGVBatalla.Columns.Add("ColEq1", "Equipo 1");
            dataGVBatalla.Columns.Add("ColEq2", "Equipo 2");
            dataGVBatalla.Columns.Add("ColGanador", "Ganador");

            dataGVBatalla.ReadOnly = true;
            dataGVBatalla.AllowUserToAddRows = false;
            dataGVBatalla.AllowUserToDeleteRows = false;
            dataGVBatalla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVBatalla.MultiSelect = false;
        }

        private void CargarBatallas()
        {
            try
            {
                List<BatallaEntidad> batallas = socket.ObtenerBatallasJugador(idJugadorActual);
                List<EquipoEntidad> equipos = socket.ObtenerEquipos();
                List<JugadorEntidad> jugadores = socket.ObtenerJugadores();

                dataGVBatalla.Rows.Clear();

                foreach (var batalla in batallas)
                {
                    var equipo1 = equipos.FirstOrDefault(e => e.IdEquipo == batalla.IdEquipo1);
                    var equipo2 = equipos.FirstOrDefault(e => e.IdEquipo == batalla.IdEquipo2);
                    var equipoGanador = equipos.FirstOrDefault(e => e.IdEquipo == batalla.Ganador);

                    string nombreJ1 = equipo1 != null ? ObtenerNombreJugador(jugadores, equipo1.IdJugador) : "Desconocido";
                    string nombreJ2 = equipo2 != null ? ObtenerNombreJugador(jugadores, equipo2.IdJugador) : "Desconocido";
                    string nombreGanador = equipoGanador != null
                        ? ObtenerNombreJugador(jugadores, equipoGanador.IdJugador)
                        : "Desconocido";

                    dataGVBatalla.Rows.Add(
                        batalla.IdBatalla,
                        nombreJ1,
                        nombreJ2,
                        batalla.IdEquipo1,
                        batalla.IdEquipo2,
                        nombreGanador
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar batallas: " + ex.Message);
            }
        }

        private string ObtenerNombreJugador(List<JugadorEntidad> jugadores, int idJugador)
        {
            var jugador = jugadores?.Find(j => j.IdJugador == idJugador);
            return jugador != null ? jugador.Nombre : "Desconocido";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}