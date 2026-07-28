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
    Descripción: Este formulario permite consultar y visualizar todos los equipos registrados.
*/

namespace Videojuego.GUI
{
    public partial class FormConsEquipo : Form
    {
        public FormConsEquipo()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarEquipos();
        }

        private void ConfigurarDataGridView()
        {
            dataGVEquipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Limpiar columnas existentes 
            dataGVEquipo.Columns.Clear();

            // Configurar titulos de columnas
            dataGVEquipo.Columns.Add("ColIdEquipo", "ID Equipo");
            dataGVEquipo.Columns.Add("ColJ", "Jugador");
            dataGVEquipo.Columns.Add("ColC1", "Criatura 1");
            dataGVEquipo.Columns.Add("ColC2", "Criatura 2");
            dataGVEquipo.Columns.Add("ColC3", "Criatura 3");
        }

        public void CargarEquipos()
        {
            try
            {
                EquipoEntidad[] equipos = EquipoLN.ConsultarEquipos();

                if (equipos == null || equipos.Length == 0)
                    return;

                dataGVEquipo.Rows.Clear();

                foreach (EquipoEntidad equipo in equipos)
                {
                    dataGVEquipo.Rows.Add(
                        equipo.IdEquipo,
                        JugadorLN.ObtenerNombreJugador(equipo.IdJugador),
                        CriaturasLN.ObtenerNombreCriatura(equipo.IdCriatura1),
                        CriaturasLN.ObtenerNombreCriatura(equipo.IdCriatura2),
                        CriaturasLN.ObtenerNombreCriatura(equipo.IdCriatura3)
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

