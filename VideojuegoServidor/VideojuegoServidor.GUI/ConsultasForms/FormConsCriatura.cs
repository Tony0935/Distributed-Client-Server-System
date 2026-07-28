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
    Descripción: Este formulario permite consultar y visualizar todas las criaturas registradas.
*/


namespace Videojuego.GUI
{
    public partial class FormConsCriatura : Form
    {
        public FormConsCriatura()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarCriaturas();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes 
            dataGVCriaturas.Columns.Clear();

            // Configurar titulos de columnas
            dataGVCriaturas.Columns.Add("ColIdCriatura", "ID");
            dataGVCriaturas.Columns.Add("ColNombre", "Nombre");
            dataGVCriaturas.Columns.Add("ColTipo", "Tipo");
            dataGVCriaturas.Columns.Add("ColNivel", "Nivel");
            dataGVCriaturas.Columns.Add("ColPoder", "Poder");
            dataGVCriaturas.Columns.Add("ColResistencia", "Resistencia");
            dataGVCriaturas.Columns.Add("ColCosto", "Costo");
        }

        public void CargarCriaturas()
        {
            try
            {
                CriaturasEntidad[] criaturas = CriaturasLN.ConsultarCriaturas();

                if (criaturas == null || criaturas.Length == 0)
                    return;

                dataGVCriaturas.Rows.Clear();

                foreach (CriaturasEntidad criatura in criaturas)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar criaturas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}




