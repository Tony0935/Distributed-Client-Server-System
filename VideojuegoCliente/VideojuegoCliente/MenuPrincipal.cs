using System;
using System.Windows.Forms;
using Videojuego.GUI;

/*
    UNED - Tercer cuatrimestre
    Curso: Programación Avanzada
    Proyecto 1 - Videojuego de Batallas de Criaturas
    Estudiante: Anthony Jafet Mendoza Rivas
    Descripción: Este formulario es el menú principal del proyecto, 
    permite navegar a los submenús de gestión de entidades y consultar el top de ganadores.
*/

namespace Videojuego.GUI
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        //Botones del submenú de Entidades
        private void btn_GestionCriatura_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Criatura",
                (s, args) =>
                {
                    var formRegistro = new FormRegCriatura();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsCriatura();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        private void btnGestionJugador_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Jugador",
                (s, args) =>
                {
                    var formRegistro = new FormRegJugador();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsJugador();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        private void btnRegistrarInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Inventario",
                (s, args) =>
                {
                    var formRegistro = new FormRegInv();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsInv();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        private void btnRegistrarEquipos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Equipos",
                (s, args) =>
                {
                    var formRegistro = new FormRegEquipo();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsEquipo();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        private void btnRegistrarBatalla_Click(object sender, EventArgs e)
        {
            this.Hide();
            var subMenu = new FormSubMenu();
            subMenu.Configurar(
                "Batalla",
                (s, args) =>
                {
                    var formRegistro = new FormRegBatalla();
                    formRegistro.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formRegistro.Show();
                },
                (s, args) =>
                {
                    var formConsulta = new FormConsBatalla();
                    formConsulta.FormClosed += (fs, fe) => subMenu.Show();
                    subMenu.Hide();
                    formConsulta.Show();
                },
                (s, args) => { subMenu.Close(); this.Show(); }
            );
            subMenu.FormClosed += (s, args) => this.Show();
            subMenu.Show();
        }

        private void btnRegistrarRondas_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formConsulta = new FormConsRondas();
            formConsulta.FormClosed += (fs, fe) => this.Show();
            formConsulta.Show();
        }

        private void btnTopGanadores_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formTopJugadores = new FormConsTop();
            formTopJugadores.FormClosed += (s, args) => this.Show();
            formTopJugadores.Show();
        }
    }
}
