using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.Logica;
using VideojuegoServidor.Logica.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario permite consultar y visualizar todos los jugadores registrados.
*/

namespace Videojuego.GUI
{
    public partial class FormConsJugador : Form
    {
        public FormConsJugador()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarJugadores();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes 
            dataGVJugadores.Columns.Clear();

            // Configurar titulos de columnas
            dataGVJugadores.Columns.Add("ColIdJugador", "ID");
            dataGVJugadores.Columns.Add("ColNombre", "Nombre");
            dataGVJugadores.Columns.Add("ColFechaN", "Fecha de Nacimiento");
            dataGVJugadores.Columns.Add("ColNivel", "Nivel");
            dataGVJugadores.Columns.Add("ColCristales", "Cristales");
            dataGVJugadores.Columns.Add("ColUsuario", "Usuario");
            dataGVJugadores.Columns.Add("ColPassword", "Contraseña");
        }

        public void CargarJugadores()
        {
            try
            {
                JugadorEntidad[] jugadores = JugadorLN.ConsultarJugadores();

                if (jugadores == null || jugadores.Length == 0)
                    return;

                dataGVJugadores.Rows.Clear();

                foreach (JugadorEntidad jugador in jugadores)
                {
                    dataGVJugadores.Rows.Add(
                        jugador.IdJugador,
                        jugador.Nombre,
                        jugador.FechaNacimiento.ToShortDateString(),
                        JugadorLN.ObtenerNivelJugador(jugador.Nivel),
                        jugador.Cristales,
                        jugador.Usuario,
                        jugador.Password
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jugadores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
