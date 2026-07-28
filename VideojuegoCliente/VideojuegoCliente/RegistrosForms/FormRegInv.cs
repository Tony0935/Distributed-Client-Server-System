using System;
using System.Windows.Forms;

using Videojuego.Entidades;
using Videojuego.Negocio;
using Videojuego.Negocio.Validaciones;

namespace Videojuego.GUI
{
    public partial class FormRegInv : Form
    {
        public FormRegInv()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarComboBoxes();
        }

        private void ConfigurarDataGridView()
        {
            dataGVCriaturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVCriaturas.Columns.Clear();

            dataGVCriaturas.Columns.Add("ColIdCriatura", "ID");
            dataGVCriaturas.Columns.Add("ColNombre", "Nombre");
            dataGVCriaturas.Columns.Add("ColTipo", "Tipo");
            dataGVCriaturas.Columns.Add("ColNivel", "Nivel");
            dataGVCriaturas.Columns.Add("ColPoder", "Poder");
            dataGVCriaturas.Columns.Add("ColResistencia", "Resistencia");
            dataGVCriaturas.Columns.Add("ColCosto", "Costo");

            dataGVCriaturas.ReadOnly = true;
            dataGVCriaturas.AllowUserToAddRows = false;
            dataGVCriaturas.AllowUserToDeleteRows = false;
            dataGVCriaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVCriaturas.MultiSelect = false;

            dataGVCriaturas.SelectionChanged += DataGVCriaturas_SelectionChanged;
        }

        // Carga los jugadores en el ComboBox
        private void CargarComboBoxes()
        {
            try
            {
                cmbJugadores.Items.Clear();
                JugadorEntidad[] jugadores = JugadorLN.ConsultarJugadores();

                foreach (var jugador in jugadores)
                    cmbJugadores.Items.Add(jugador); // Agrega el jugador en el ComboBox

                // Mostrar el nombre en el ComboBox 
                cmbJugadores.DisplayMember = "Nombre";
                cmbJugadores.ValueMember = "IdJugador";

                if (cmbJugadores.Items.Count > 0)
                {
                    cmbJugadores.SelectedIndex = 0;
                    ActualizarCristalesJugador();
                }
                else
                {
                    dataGVCriaturas.Rows.Clear();
                    btnComprar.Enabled = false;
                }

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbJugadores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ActualizarInterfaz();
        }

        // Actualiza el DataGridView con las criaturas disponibles para comprar
        private void ActualizarGrid()
        {
            try
            {
                dataGVCriaturas.Rows.Clear();

                if (cmbJugadores.SelectedItem is not JugadorEntidad jugadorSeleccionado)
                {
                    btnComprar.Enabled = false;
                    return;
                }

                // Obtiene todas las criaturas y el inventario
                CriaturasEntidad[] todas = CriaturasLN.ConsultarCriaturas();
                InventarioEntidad[] inventarioGlobal = InventarioLN.ConsultarInventario();

                foreach (var criatura in todas)
                {
                    bool yaComprada = false;

                    // Revisa si la criatura ya fue comprada por cualquier jugador
                    foreach (var inv in inventarioGlobal)
                    {
                        if (criatura.IdCriatura == inv.IdCriatura)
                        {
                            yaComprada = true;
                            break;
                        }
                    }

                    if (!yaComprada)
                    {
                        dataGVCriaturas.Rows.Add(
                            criatura.IdCriatura,
                            criatura.Nombre,
                            criatura.Tipo,
                            CriaturasLN.ObtenerNivelCriatura(criatura.Nivel),
                            criatura.Poder,
                            criatura.Resistencia,
                            criatura.Costo + " cristales"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar grid: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza el label de cristales del jugador seleccionado
        private void ActualizarCristalesJugador()
        {
            if (cmbJugadores.SelectedItem is not JugadorEntidad jugadorSeleccionado)
            {
                lblCristales.Text = "0";
                return;
            }

            int cristales = InventarioLN.ObtenerCristalesJugador(jugadorSeleccionado.IdJugador);
            lblCristales.Text = cristales.ToString();
        }

        // Verifica si la compra es posible
        private void VerificarDisponibilidad()
        {
            if (cmbJugadores.SelectedItem is not JugadorEntidad jugadorSeleccionado || dataGVCriaturas.SelectedRows.Count == 0)
            {
                btnComprar.Enabled = false;
                return;
            }

            // Obtiene los IDs para la validación
            int idJugador = jugadorSeleccionado.IdJugador;
            int idCriatura = Convert.ToInt32(dataGVCriaturas.SelectedRows[0].Cells["ColIdCriatura"].Value);

            try
            {
                // Intenta validar la compra, si regresa la excepción, la compra no está disponible
                ValidacionesInventario.ValidarCompra(idJugador, idCriatura);
                btnComprar.Enabled = true;
            }
            catch
            {
                btnComprar.Enabled = false; // Deshabilita el botón si no es posible comprar
            }
        }

        //Botón para comprar la criatura seleccionada
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (cmbJugadores.SelectedItem is not JugadorEntidad jugadorSeleccionado || dataGVCriaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un jugador y una criatura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idJugador = jugadorSeleccionado.IdJugador;
            int idCriatura = Convert.ToInt32(dataGVCriaturas.SelectedRows[0].Cells["ColIdCriatura"].Value);

            // Solicita la compra, si regresa la confirmación, se actualiza la interfaz
            string resultado = InventarioLN.ComprarCriatura(idJugador, idCriatura);

            if (resultado == "Compra exitosa")
                ActualizarInterfaz();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGVCriaturas_SelectionChanged(object sender, EventArgs e)
        {
            VerificarDisponibilidad();
        }

        private void ActualizarInterfaz()
        {
            // Actualizar cristales
            ActualizarCristalesJugador();

            // Actualizar grid para remover la criatura comprada
            ActualizarGrid();
        }
    }
}
