using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videojuego.Entidades;
using Videojuego.Negocio;
using Videojuego.Negocio.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario permite consultar y visualizar todas las batallas registradas.
*/

namespace Videojuego.GUI
{
    public partial class FormConsBatalla : Form
    {
        public FormConsBatalla()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarBatallas();
        }

        private void ConfigurarDataGridView()
        {
            dataGVBatalla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Limpiar columnas existentes 
            dataGVBatalla.Columns.Clear();

            // Configurar titulos de columnas
            dataGVBatalla.Columns.Add("ColIdbatalla", "ID Batalla");
            dataGVBatalla.Columns.Add("ColJ1", "Jugador 1");
            dataGVBatalla.Columns.Add("ColJ2", "Jugador 2");
            dataGVBatalla.Columns.Add("ColEq1", "Equipo 1");
            dataGVBatalla.Columns.Add("ColEq2", "Equipo 2");
            dataGVBatalla.Columns.Add("ColGanador", "Ganador");
        }

        public void CargarBatallas()
        {
            try
            {
                BatallaEntidad[] batallas = BatallaLN.ConsultarBatallas();

                if (batallas == null || batallas.Length == 0)
                    return;

                dataGVBatalla.Rows.Clear();

                foreach (BatallaEntidad batalla in batallas)
                {
                    dataGVBatalla.Rows.Add(
                        batalla.IdBatalla,
                        JugadorLN.ObtenerNombreJugador(batalla.IdJugador1),
                        JugadorLN.ObtenerNombreJugador(batalla.IdJugador2),
                        $" {batalla.IdEquipo1}",
                        $" {batalla.IdEquipo2}",
                        JugadorLN.ObtenerNombreJugador(batalla.Ganador)
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar batallas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
