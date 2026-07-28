using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 2 
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario actúa como submenú genérico para las entidades del servidor.
*/

namespace Videojuego.GUI
{
    public partial class FormSubMenu : Form
    {
        public FormSubMenu()
        {
            InitializeComponent();
        }

        // Configura los botones del formulario con los textos según la entidad
        public void Configurar(string entidad, EventHandler registrar, EventHandler consultar, EventHandler volver)
        {
            btnRegistrarJug.Text = $"Registrar {entidad}";
            btnRegistrarCri.Text = $"Consultar {entidad}";
            btnVolver.Text = "Volver";

            btnRegistrarJug.Click += registrar;
            btnRegistrarCri.Click += consultar;
            btnVolver.Click += volver;
        }

        private void btnRegistrarJug_Click(object sender, EventArgs e)
        {

        }
    }
}


