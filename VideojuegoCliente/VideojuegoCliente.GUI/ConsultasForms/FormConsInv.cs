using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    Descripción: Formulario para consultar el inventario de criaturas de un jugador.
    Solicita al servidor la lista de criaturas asociadas al jugador e informa sus
    características como nivel, poder y resistencia, mostrándolas en un DataGridView.
*/

namespace VideojuegoCliente.GUI.ConsultasForms
{
    public partial class FormConsInv : Form
    {
        private readonly ClienteSocket socket;
        private readonly int idJugadorActual;
        private readonly string nombreJugador;

        public FormConsInv(ClienteSocket socket, string nombreJugador, int idJugador)
        {
            InitializeComponent();
            this.socket = socket;
            this.idJugadorActual = idJugador;
            this.nombreJugador = nombreJugador;

            lblNombreJugador.Text = $"Jugador: {nombreJugador}";

            ConfigurarDataGridView();
            CargarInventario(idJugadorActual);
        }

        // Configura las columnas del DataGridView
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

        private void CargarInventario(int idJugador)
        {
            try
            {
                dataGVInv.Rows.Clear();

                List<InventarioEntidad> inventario = socket.ObtenerInventario(idJugador);
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
                MessageBox.Show("Error al consultar el inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}