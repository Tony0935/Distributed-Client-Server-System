using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VideojuegoCliente.Comunicacion;
using VideojuegoServidor.Entidades;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para registrar compras de criaturas en el cliente.
*/

namespace VideojuegoCliente.GUI.RegistrosForms
{
    public partial class FormRegInv : Form
    {
        private readonly ClienteSocket socket;
        private readonly int idJugadorActual;
        private readonly string nombreJugador;

        public FormRegInv(ClienteSocket socket, int idJugadorActual, string nombreJugador)
        {
            InitializeComponent();
            this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
            this.idJugadorActual = idJugadorActual;
            this.nombreJugador = nombreJugador;

            lblNombreJugador.Text = $"Jugador: {nombreJugador}";
            ConfigurarDataGridView();
            CargarDatosJugador();
        }

        // Configura las columnas del DataGridView
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
            dataGVCriaturas.ClearSelection();
        }

        // Carga los datos del jugador actual
        private void CargarDatosJugador()
        {
            try
            {
                // Cargar los cristales actuales
                int cristales = socket.ObtenerCristalesJugador(idJugadorActual);
                lblCristales.Text = cristales.ToString();

                // Cargar criaturas disponibles en la tienda para este jugador
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del jugador: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid()
        {
            try
            {
                dataGVCriaturas.Rows.Clear();

                List<CriaturasEntidad> criaturasDisponibles = socket.CriaturasDispJugador(idJugadorActual);

                foreach (var c in criaturasDisponibles)
                {
                    dataGVCriaturas.Rows.Add(
                        c.IdCriatura,
                        c.Nombre,
                        c.Tipo,
                        c.Nivel,
                        c.Poder,
                        c.Resistencia,
                        $"{c.Costo} cristales"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar criaturas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dataGVCriaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una criatura.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCriatura = Convert.ToInt32(dataGVCriaturas.SelectedRows[0].Cells["ColIdCriatura"].Value);

            try
            {
                string resultado = socket.ComprarCriatura(idJugadorActual, idCriatura);

                if (resultado.Contains("OK", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Compra exitosa.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarInterfaz();
                }
                else
                {
                    MessageBox.Show("No se pudo completar la compra: " + resultado, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarInterfaz()
        {
            try
            {
                // Actualizar los cristales luego de la compra
                int cristalesActualizados = socket.ObtenerCristalesJugador(idJugadorActual);
                lblCristales.Text = cristalesActualizados.ToString();

                // Actualizar la lista de criaturas disponibles
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar interfaz: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}