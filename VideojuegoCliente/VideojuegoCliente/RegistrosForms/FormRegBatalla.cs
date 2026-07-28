using System;
using System.Windows.Forms;
using Videojuego.Entidades;
using Videojuego.Negocio;
using Videojuego.Negocio.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para el registro de los datos de batalla.
*/

namespace Videojuego.GUI
{
    public partial class FormRegBatalla : Form
    {
        public FormRegBatalla()
        {
            InitializeComponent();
            LlenarComboBoxesFecha();
        }

        // Llena los ComboBoxes de día, mes y año para la selección de la fecha
        private void LlenarComboBoxesFecha()
        {
            // Meses
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                       "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            cbMes.Items.Clear();
            cbMes.Items.AddRange(meses);

            // Años
            cbAnio.Items.Clear();
            int añoActual = DateTime.Now.Year;
            for (int i = añoActual; i >= 1940; i--)
                cbAnio.Items.Add(i.ToString());
            cbAnio.SelectedItem = añoActual.ToString();

            // Actualiza los días al cambiar mes
            cbMes.SelectedIndexChanged += (s, e) => ActualizarDias();

            // Inicializar mes y días por defecto
            cbMes.SelectedIndex = DateTime.Now.Month - 1;
            ActualizarDias();
        }

        // Actualiza el ComboBox de días según el mes seleccionado
        private void ActualizarDias()
        {
            int mes = cbMes.SelectedIndex + 1;
            int dias = 31;

            switch (mes)
            {
                case 2: dias = 28; break;          // Febrero
                case 4:
                case 6:
                case 9:
                case 11:   // Abril, Junio, Septiembre, Noviembre
                    dias = 30;
                    break;
            }

            cbDia.Items.Clear();
            for (int i = 1; i <= dias; i++)
                cbDia.Items.Add(i); 
            cbDia.SelectedIndex = 0;   
        }

        //Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado día, mes y año
                if (cbDia.SelectedIndex < 0 || cbMes.SelectedIndex < 0 || cbAnio.SelectedIndex < 0)
                    throw new Exception("Debe seleccionar día, mes y año para la fecha de la batalla.");

                int dia = int.Parse(cbDia.SelectedItem.ToString());
                int mes = cbMes.SelectedIndex + 1;
                int año = int.Parse(cbAnio.SelectedItem.ToString());
                DateTime fechaBatalla = new DateTime(año, mes, dia);

                BatallaEntidad batalla = ValidacionesBatalla.CrearDesdeCampos(
                    txtIDBatalla.Text.Trim(),
                    txtIDJ1.Text.Trim(),
                    txtIDequipo1.Text.Trim(),
                    txtIDJ2.Text.Trim(),
                    txtIDequipo2.Text.Trim()
                );

                // Sobrescribir la fecha de la batalla con la elegida
                batalla.Fecha = fechaBatalla;

                // Guardar batalla
                BatallaLN.RegistrarBatalla(batalla);

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
