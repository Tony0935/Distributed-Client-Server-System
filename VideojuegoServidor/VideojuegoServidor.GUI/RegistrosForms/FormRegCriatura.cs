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
using VideojuegoServidor.GUI;
using VideojuegoServidor.Logica;
using VideojuegoServidor.Logica.Validaciones;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario permite registrar los datos de las criaturas.

*/

namespace Videojuego.GUI
{
    public partial class FormRegCriatura : Form
    {
        public FormRegCriatura()
        {
            InitializeComponent();
        }

        //Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CriaturasEntidad criatura = ValidacionesCriatura.CrearDesdeCampos(
                    txtNombre.Text.Trim(),
                    (string)cmbTipo.SelectedItem,
                    (string)cmbNivel.SelectedItem,
                    txtPoder.Text.Trim(),
                    txtResistencia.Text.Trim(),
                    txtCosto.Text.Trim()
                );

                // Registrar la criatura en la logica de negocio
                CriaturasLN.RegistrarCriatura(criatura);

                //Agrega el registro en la bitacora
                BitacoraLog.Registrar("Registro de criatura", $"Criatura '{criatura.Nombre}");

                MessageBox.Show("Criatura registrada correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

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