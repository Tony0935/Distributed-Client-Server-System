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
    Descripción: Este formulario permite consultar y visualizar las rondas registradas de las batallas.
*/

namespace Videojuego.GUI
{
    public partial class FormConsRondas : Form
    {
        public FormConsRondas()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarRondas();
        }

        private void ConfigurarDataGridView()
        {
            dataGVRondas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGVRondas.Columns.Clear();

            // Configurar titulos de columnas
            dataGVRondas.Columns.Add("ColIdRonda", "Ronda");
            dataGVRondas.Columns.Add("ColIdBatalla", "ID Batalla");
            dataGVRondas.Columns.Add("ColIdJugador1", "ID Jugador 1");
            dataGVRondas.Columns.Add("ColNombreJugador1", "Nombre Jugador 1");
            dataGVRondas.Columns.Add("ColIdJugador2", "ID Jugador 2");
            dataGVRondas.Columns.Add("ColNombreJugador2", "Nombre Jugador 2");
            dataGVRondas.Columns.Add("ColIdCriatura1", "Criatura 1");
            dataGVRondas.Columns.Add("ColIdCriatura2", "Criatura 2");
            dataGVRondas.Columns.Add("ColGanadorRonda", "Ganador de la ronda");

        }

        public void CargarRondas()
        {
            try
            {
                // Obtener Rondas desde la lógica de Acceso a Datos
                RondasEntidad[] Rondas = RondasLN.ConsultarRondas();

                // Verificar si hay Jugadores registradas
                if (Rondas == null || Rondas.Length == 0)
                {
                    return;
                }

                // Agregar cada Ronda al DataGridView
                foreach (RondasEntidad ronda in Rondas)
                {
                    dataGVRondas.Rows.Add(
                        ronda.IdRonda,
                        ronda.IdBatalla,
                        ronda.IdJugador1,                                 // ID jugador 1
                        JugadorLN.ObtenerNombreJugador(ronda.IdJugador1), // Nombre jugador 1
                        ronda.IdJugador2,                                  // ID jugador 2
                        JugadorLN.ObtenerNombreJugador(ronda.IdJugador2), // Nombre jugador 2
                        CriaturasLN.ObtenerNombreCriatura(ronda.IdCriatura1),
                        CriaturasLN.ObtenerNombreCriatura(ronda.IdCriatura2),
                        JugadorLN.ObtenerNombreJugador(ronda.GanadorRonda)
                    );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Rondas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

