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
    Descripción: Formulario para registrar batallas desde el cliente.
*/

namespace VideojuegoCliente.GUI.RegistrosForms
{
    public partial class FormRegBatalla : Form
    {
        private readonly ClienteSocket socket;
        private readonly int idJugadorActual;
        private readonly string nombreJugador;
        private List<EquipoEntidad> equiposJugador;

        public FormRegBatalla(ClienteSocket socket, int idJugador, string nombreJugador)
        {
            InitializeComponent();
            this.socket = socket;
            this.idJugadorActual = idJugador;
            this.nombreJugador = nombreJugador;

            ConfigurarDataGridView();
            CargarEquiposJugador();
        }

        //Configura las columnas del DataGridView
        private void ConfigurarDataGridView()
        {
            dataGVEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVEquipos.MultiSelect = false;
            dataGVEquipos.ReadOnly = true;

            dataGVEquipos.Columns.Clear();
            dataGVEquipos.Columns.Add("ColIdEquipo", "ID Equipo");
            dataGVEquipos.Columns.Add("ColNombreEquipo", "Nombre del Equipo");
            dataGVEquipos.Columns.Add("ColC1", "Criatura 1");
            dataGVEquipos.Columns.Add("ColC2", "Criatura 2");
            dataGVEquipos.Columns.Add("ColC3", "Criatura 3");
        }

        //Carga los equipos del jugador actual
        private void CargarEquiposJugador()
        {
            try
            {
                var equipos = socket.ObtenerEquipos();
                if (equipos == null || equipos.Count == 0)
                {
                    MessageBox.Show("No hay equipos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Filtra los equipos del jugador actual
                equiposJugador = equipos.Where(e => e.IdJugador == idJugadorActual).ToList();

                if (equiposJugador.Count == 0)
                {
                    MessageBox.Show("No tienes equipos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var criaturas = socket.ObtenerCriaturas();
                var dictCriaturas = criaturas.ToDictionary(c => c.IdCriatura, c => c.Nombre);

                dataGVEquipos.Rows.Clear();

                foreach (var equipo in equiposJugador)
                {
                    string c1 = dictCriaturas.ContainsKey(equipo.IdCriatura1) ? dictCriaturas[equipo.IdCriatura1] : "Desconocido";
                    string c2 = dictCriaturas.ContainsKey(equipo.IdCriatura2) ? dictCriaturas[equipo.IdCriatura2] : "Desconocido";
                    string c3 = dictCriaturas.ContainsKey(equipo.IdCriatura3) ? dictCriaturas[equipo.IdCriatura3] : "Desconocido";

                    dataGVEquipos.Rows.Add(
                        equipo.IdEquipo,
                        equipo.NombreEquipo ?? $"Equipo {equipo.IdEquipo}",
                        c1, c2, c3
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Botón para iniciar la batalla
        private void btnIniciarBatalla_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGVEquipos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un equipo para iniciar la batalla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEquipoSeleccionado = Convert.ToInt32(dataGVEquipos.SelectedRows[0].Cells["ColIdEquipo"].Value);
                var equipoSeleccionado = equiposJugador.FirstOrDefault(eq => eq.IdEquipo == idEquipoSeleccionado);

                if (equipoSeleccionado == null)
                {
                    MessageBox.Show("No se pudo identificar el equipo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crea la batalla con IdEquipo1 y Fecha
                BatallaEntidad batalla = new BatallaEntidad
                {
                    IdEquipo1 = equipoSeleccionado.IdEquipo,
                    Fecha = DateTime.Now
                };

                // Envia la batalla al servidor
                string resultado = socket.RegistrarBatalla(batalla);

                if (resultado.Contains("espera", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Esperando a otro jugador para iniciar la batalla...", "En espera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado, "Resultado de la Batalla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar batalla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}