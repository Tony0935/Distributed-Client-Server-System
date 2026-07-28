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
    Descripción: Este formulario permite consultar y visualizar el Top 10 de jugadores con más victorias.
*/

namespace Videojuego.GUI
{

    public partial class FormConsTop : Form
    {
        public FormConsTop()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarTop10();
        }

        private void ConfigurarDataGridView()
        {
            dataGVTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGVTop.Columns.Clear();

            // Configurar títulos de columnas para Top 10
            // Según documento: "El control debe mostrar todas las propiedades de la clase Jugador (6 columnas)"
            dataGVTop.Columns.Add("ColIdJugador", "ID");
            dataGVTop.Columns.Add("ColNombre", "Nombre");
            dataGVTop.Columns.Add("ColFechaNacimiento", "Fecha Nacimiento");
            dataGVTop.Columns.Add("ColNivel", "Nivel");
            dataGVTop.Columns.Add("ColCristales", "Cristales");
            dataGVTop.Columns.Add("ColBatallasGanadas", "Batallas Ganadas");

            // Configurar propiedades del DataGridView
            dataGVTop.ReadOnly = true;
            dataGVTop.AllowUserToAddRows = false;
            dataGVTop.AllowUserToDeleteRows = false;
            dataGVTop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGVTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void CargarTop10()
        {
            try
            {
                // Limpiar filas existentes
                dataGVTop.Rows.Clear();

                // Obtener Top 10
                JugadorEntidad[] top10 = Top10LN.ObtenerTop10Ganadores();

                // Verificar si hay jugadores
                if (top10 == null || top10.Length == 0)
                {
                    return;
                }

                // Agregar cada jugador al DataGridView
                int posicion = 1;
                foreach (JugadorEntidad jugador in top10)
                {
                    dataGVTop.Rows.Add(
                        jugador.IdJugador,                                                  
                        jugador.Nombre,                                                    
                        jugador.FechaNacimiento.ToString("dd/MM/yyyy"),                      
                        JugadorLN.ObtenerNivelJugador(jugador.Nivel),  
                        jugador.Cristales.ToString() + " cristales",                         
                        jugador.BatallasGanadas.ToString() + " batallas"                     
                    );
                    posicion++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Top 10: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

