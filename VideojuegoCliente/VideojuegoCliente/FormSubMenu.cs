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
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario actúa como submenú genérico para las entidades del juego.
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
            btnRegistrar.Text = $"Registrar {entidad}";
            btnConsultar.Text = $"Consultar {entidad}";
            btnVolver.Text = "Volver";

            btnRegistrar.Click += registrar;
            btnConsultar.Click += consultar;
            btnVolver.Click += volver;
        }
    }
}



