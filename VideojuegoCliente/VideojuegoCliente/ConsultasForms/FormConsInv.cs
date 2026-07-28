using System;
using System.Windows.Forms;
using Videojuego.Entidades;
using Videojuego.Negocio;
using Videojuego.Negocio.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario permite consultar y visualizar el inventario de criaturas de cada jugador.
*/

namespace Videojuego.GUI
{
    public partial class FormConsInv : Form
    {
        public FormConsInv()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarComboBoxes();
        }

        private void ConfigurarDataGridView()
        {
            dataGVInv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGVInv.Columns.Clear();

            dataGVInv.Columns.Add("ColIdCriatura", "ID");
            dataGVInv.Columns.Add("ColNombre", "Nombre");
            dataGVInv.Columns.Add("ColTipo", "Tipo");
            dataGVInv.Columns.Add("ColNivel", "Nivel");
            dataGVInv.Columns.Add("ColPoder", "Poder");
            dataGVInv.Columns.Add("ColResistencia", "Resistencia");

            dataGVInv.ReadOnly = true;
            dataGVInv.AllowUserToAddRows = false;
            dataGVInv.AllowUserToDeleteRows = false;
            dataGVInv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVInv.MultiSelect = false;
        }

        private void CargarComboBoxes()
        {
            try
            {
                cmbJugadores.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbJugadores.Items.Clear();

                // Obtener todos los jugadores
                JugadorEntidad[] jugadores = JugadorLN.ConsultarJugadores();

                foreach (var jugador in jugadores)
                    cmbJugadores.Items.Add(jugador); // Agrega el jugador en el ComboBox

                // Mostrar el nombre en el ComboBox 
                cmbJugadores.DisplayMember = "Nombre";
                cmbJugadores.ValueMember = "IdJugador";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jugadores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que se haya seleccionado un jugador
            if (cmbJugadores.SelectedItem is not JugadorEntidad jugadorSeleccionado)
                return;
            // Obtiene el ID del jugador seleccionado
            int idJugador = jugadorSeleccionado.IdJugador;

            try
            {
                InventarioEntidad[] inventario = InventarioLN.ConsultarInventarioPorJugador(idJugador);
                dataGVInv.Rows.Clear();

                foreach (var item in inventario)
                {
                    CriaturasEntidad criatura = CriaturasLN.ConsultarCriaturaPorId(item.IdCriatura);

                    if (criatura != null)
                    {
                        dataGVInv.Rows.Add(
                            criatura.IdCriatura,
                            criatura.Nombre,
                            criatura.Tipo,
                            CriaturasLN.ObtenerNivelCriatura(criatura.Nivel),
                            item.Poder,
                            item.Resistencia,
                            criatura.Costo
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
