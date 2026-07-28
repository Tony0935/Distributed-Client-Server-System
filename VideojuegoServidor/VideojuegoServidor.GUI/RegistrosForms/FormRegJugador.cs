using System;
using System.Windows.Forms;
using VideojuegoServidor.Entidades;
using VideojuegoServidor.GUI;
using VideojuegoServidor.Logica;
using VideojuegoServidor.Logica.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2 
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Formulario para el registro de los datos del jugador.
*/

namespace Videojuego.GUI
{
    public partial class FormRegJugador : Form
    {
        public FormRegJugador()
        {
            InitializeComponent();
            InicializarComboBoxFecha();
        }

        private void InicializarComboBoxFecha()
        {
            // Llenar meses
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                               "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            cbMes.Items.Clear();
            foreach (var mes in meses)
                cbMes.Items.Add(mes);

            cbMes.SelectedIndexChanged += CbMes_SelectedIndexChanged;

            // Llenar años
            cbAnio.Items.Clear();
            for (int i = 2015; i >= 1940; i--)
                cbAnio.Items.Add(i.ToString());

            cbAnio.SelectedItem = "2000"; // Año por defecto

            // Inicializar días
            ActualizarDias();
        }

        private void CbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDias();
        }

        //Actaliza los días de acuerdo con el mes seleccionado
        private void ActualizarDias()
        {
            int mes = cbMes.SelectedIndex + 1;
            int dias = 31;

            switch (mes)
            {
                case 2:
                    dias = 28; // Febrero siempre 28 días
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    dias = 30; // Abril, Junio, Septiembre, Noviembre
                    break;
            }

            cbDia.Items.Clear();
            for (int i = 1; i <= dias; i++)
                cbDia.Items.Add(i.ToString());

            cbDia.SelectedIndex = 0;
        }

        //Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDia.SelectedItem == null || cbMes.SelectedItem == null || cbAnio.SelectedItem == null)
                    throw new Exception("Debe seleccionar día, mes y año.");

                int dia = int.Parse(cbDia.SelectedItem.ToString());
                int mes = cbMes.SelectedIndex + 1;
                int anio = int.Parse(cbAnio.SelectedItem.ToString());
                DateTime fechaNacimiento = new DateTime(anio, mes, dia);

                JugadorEntidad jugador = ValidacionesJugador.CrearDesdeCampos(
                    txtNombre.Text.Trim(),
                    txtUsuario.Text.Trim(),
                    txtPwrd.Text.Trim(),
                    fechaNacimiento
                );

                //Registra el jugador desde la logica de negocio
                JugadorLN.RegistrarJugador(jugador);

                //Agrega el registro en la bitacora
                BitacoraLog.Registrar("Registro de jugador", $"Jugador '{jugador.Nombre}");

                MessageBox.Show("Jugador registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbMes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
