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
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para consultar los equipos registrados por el jugador actual.
    Muestra los equipos con sus criaturas asociadas, obteniendo la información desde
    el servidor.
*/

namespace VideojuegoCliente.GUI.ConsultasForms
{
    public partial class FormConsEquipo : Form
    {
        private readonly ClienteSocket cliente;
        private readonly int idJugadorActual;

        public FormConsEquipo(ClienteSocket cliente, int idJugadorActual)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.idJugadorActual = idJugadorActual;
            ConfigurarDataGridView();
            CargarEquipos();
        }


        private void ConfigurarDataGridView()
        {
            dataGVEquipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVEquipo.Columns.Clear();

            dataGVEquipo.Columns.Add("ColIdEquipo", "ID Equipo");
            dataGVEquipo.Columns.Add("ColNombreEquipo", "Nombre del Equipo");
            dataGVEquipo.Columns.Add("ColJugador", "Jugador");
            dataGVEquipo.Columns.Add("ColC1", "Criatura 1");
            dataGVEquipo.Columns.Add("ColC2", "Criatura 2");
            dataGVEquipo.Columns.Add("ColC3", "Criatura 3");
        }

        private void CargarEquipos()
        {
            try
            {
                var equipos = cliente.ObtenerEquipos();
                if (equipos == null || equipos.Count == 0) return;

                // Filtrar sólo equipos del jugador actual
                equipos = equipos.Where(e => e.IdJugador == idJugadorActual).ToList();

                var criaturas = cliente.ObtenerCriaturas();
                var dictCriaturas = criaturas.ToDictionary(c => c.IdCriatura, c => c.Nombre);

                dataGVEquipo.Rows.Clear();

                foreach (var equipo in equipos)
                {
                    dictCriaturas.TryGetValue(equipo.IdCriatura1, out string c1);
                    dictCriaturas.TryGetValue(equipo.IdCriatura2, out string c2);
                    dictCriaturas.TryGetValue(equipo.IdCriatura3, out string c3);

                    dataGVEquipo.Rows.Add(
                        equipo.IdEquipo,
                        equipo.NombreEquipo ?? $"Equipo {equipo.IdEquipo}",
                        dictCriaturas.TryGetValue(equipo.IdJugador, out var nombreJugador) ? nombreJugador : "Tú",
                        c1 ?? "Desconocido",
                        c2 ?? "Desconocido",
                        c3 ?? "Desconocido"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
