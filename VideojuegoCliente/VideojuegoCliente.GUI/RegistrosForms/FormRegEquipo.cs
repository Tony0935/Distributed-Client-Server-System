using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VideojuegoCliente.Comunicacion;
using VideojuegoServidor.Entidades;
using Newtonsoft.Json;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para crear y registrar equipos de 3 criaturas desde el inventario del jugador.
*/

namespace VideojuegoCliente.GUI.RegistrosForms
{
    public partial class FormRegEquipo : Form
    {
        private ClienteSocket cliente;
        private readonly ClienteSocket socket;
        private readonly int idJugadorActual;
        private readonly string nombreJugador;
        private List<CriaturasEntidad> criaturasInventario;

        public FormRegEquipo(ClienteSocket socket, int idJugador, string nombre)
        {
            InitializeComponent();
            this.socket = socket;
            this.idJugadorActual = idJugador;
            this.nombreJugador = nombre;

            CargarInventario();
        }

        private void CargarInventario()
        {
            try
            {
                dataGVInv.Rows.Clear();
                dataGVInv.Columns.Clear();

                dataGVInv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGVInv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGVInv.MultiSelect = true;
                dataGVInv.ReadOnly = true;
                dataGVInv.AllowUserToAddRows = false;
                dataGVInv.AllowUserToDeleteRows = false;

                // Definir columnas
                dataGVInv.Columns.Add("ColIdCriatura", "ID");
                dataGVInv.Columns.Add("ColNombre", "Nombre");
                dataGVInv.Columns.Add("ColTipo", "Tipo");
                dataGVInv.Columns.Add("ColNivel", "Nivel");
                dataGVInv.Columns.Add("ColPoder", "Poder");
                dataGVInv.Columns.Add("ColResistencia", "Resistencia");

                //Obtener datos desde el servidor
                List<InventarioEntidad> inventario = socket.ObtenerInventario(idJugadorActual);
                List<CriaturasEntidad> criaturas = socket.ObtenerCriaturas();

                foreach (var item in inventario)
                {
                    var criatura = criaturas.Find(c => c.IdCriatura == item.IdCriatura);
                    if (criatura != null)
                    {
                        dataGVInv.Rows.Add(
                            criatura.IdCriatura,
                            criatura.Nombre,
                            criatura.Tipo,
                            criatura.Nivel,
                            item.Poder,
                            item.Resistencia
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGVInv.SelectedRows.Count != 3)
                {
                    MessageBox.Show("Debe seleccionar exactamente 3 criaturas para formar un equipo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener las 3 criaturas seleccionadas
                var seleccionadas = dataGVInv.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(r => new CriaturasEntidad
                    {
                        IdCriatura = Convert.ToInt32(r.Cells["ColIdCriatura"].Value),
                        Nombre = r.Cells["ColNombre"].Value.ToString()
                    })
                    .ToList();

                //Obtiene los equipos existentes para generar un nombre incremental
                var equiposExistentes = socket.ObtenerEquipos()
                    .Where(e => e.IdJugador == idJugadorActual)
                    .ToList();

                int numeroEquipo = equiposExistentes.Count + 1;
                string nombreEquipo = $"Equipo {numeroEquipo}";

                //Crea el equipo
                var equipo = new EquipoEntidad
                {
                    IdJugador = idJugadorActual,
                    IdCriatura1 = seleccionadas[0].IdCriatura,
                    IdCriatura2 = seleccionadas[1].IdCriatura,
                    IdCriatura3 = seleccionadas[2].IdCriatura,
                    NombreEquipo = nombreEquipo
                };

                //Registra el equipo usando el método del socket
                string resultado = socket.RegistrarEquipo(equipo);

                if (!resultado.Contains("Error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Equipo '{nombreEquipo}' registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Error al registrar el equipo: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}