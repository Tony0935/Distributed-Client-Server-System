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
    Descripción: Este formulario permite registrar los datos de los equipos.
*/

namespace Videojuego.GUI
{
    public partial class FormRegEquipo : Form
    {
        public FormRegEquipo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EquipoEntidad equipo = ValidacionesEquipo.CrearDesdeCampos(
                    txtEquipo.Text.Trim(),
                    txtIDJ1.Text.Trim(),
                    txtIDCriatura1.Text.Trim(),
                    txtIDCriatura2.Text.Trim(),
                    txtIDCriatura3.Text.Trim()
                );

                // Guardar usando lógica de negocio
                EquipoLN.RegistrarEquipo(equipo);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
