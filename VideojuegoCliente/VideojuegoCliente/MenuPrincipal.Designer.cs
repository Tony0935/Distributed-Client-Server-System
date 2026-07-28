namespace Videojuego.GUI
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGestionCriatura = new Button();
            btnGestionJugador = new Button();
            btnRegistrarInventario = new Button();
            btnRegistrarEquipos = new Button();
            btnRegistrarBatalla = new Button();
            btnConsultarRondas = new Button();
            btnTopGanadores = new Button();
            SuspendLayout();
            // 
            // btnGestionCriatura
            // 
            btnGestionCriatura.BackColor = Color.RosyBrown;
            btnGestionCriatura.Cursor = Cursors.No;
            btnGestionCriatura.FlatStyle = FlatStyle.Popup;
            btnGestionCriatura.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnGestionCriatura.ForeColor = SystemColors.ButtonFace;
            btnGestionCriatura.Location = new Point(77, 48);
            btnGestionCriatura.Name = "btnGestionCriatura";
            btnGestionCriatura.Size = new Size(212, 53);
            btnGestionCriatura.TabIndex = 0;
            btnGestionCriatura.Text = "Criaturas";
            btnGestionCriatura.UseVisualStyleBackColor = false;
            btnGestionCriatura.Click += btn_GestionCriatura_Click;
            // 
            // btnGestionJugador
            // 
            btnGestionJugador.BackColor = Color.RosyBrown;
            btnGestionJugador.Cursor = Cursors.No;
            btnGestionJugador.FlatStyle = FlatStyle.Popup;
            btnGestionJugador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnGestionJugador.ForeColor = SystemColors.ButtonFace;
            btnGestionJugador.Location = new Point(77, 107);
            btnGestionJugador.Name = "btnGestionJugador";
            btnGestionJugador.Size = new Size(212, 53);
            btnGestionJugador.TabIndex = 1;
            btnGestionJugador.Text = "Jugadores";
            btnGestionJugador.UseVisualStyleBackColor = false;
            btnGestionJugador.Click += btnGestionJugador_Click;
            // 
            // btnRegistrarInventario
            // 
            btnRegistrarInventario.BackColor = Color.RosyBrown;
            btnRegistrarInventario.Cursor = Cursors.No;
            btnRegistrarInventario.FlatStyle = FlatStyle.Popup;
            btnRegistrarInventario.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarInventario.ForeColor = SystemColors.ButtonFace;
            btnRegistrarInventario.Location = new Point(77, 166);
            btnRegistrarInventario.Name = "btnRegistrarInventario";
            btnRegistrarInventario.Size = new Size(212, 53);
            btnRegistrarInventario.TabIndex = 2;
            btnRegistrarInventario.Text = "Inventario";
            btnRegistrarInventario.UseVisualStyleBackColor = false;
            btnRegistrarInventario.Click += btnRegistrarInventario_Click;
            // 
            // btnRegistrarEquipos
            // 
            btnRegistrarEquipos.BackColor = Color.RosyBrown;
            btnRegistrarEquipos.Cursor = Cursors.No;
            btnRegistrarEquipos.FlatStyle = FlatStyle.Popup;
            btnRegistrarEquipos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarEquipos.ForeColor = SystemColors.ButtonFace;
            btnRegistrarEquipos.Location = new Point(77, 225);
            btnRegistrarEquipos.Name = "btnRegistrarEquipos";
            btnRegistrarEquipos.Size = new Size(212, 53);
            btnRegistrarEquipos.TabIndex = 3;
            btnRegistrarEquipos.Text = "Equipos";
            btnRegistrarEquipos.UseVisualStyleBackColor = false;
            btnRegistrarEquipos.Click += btnRegistrarEquipos_Click;
            // 
            // btnRegistrarBatalla
            // 
            btnRegistrarBatalla.BackColor = Color.RosyBrown;
            btnRegistrarBatalla.Cursor = Cursors.No;
            btnRegistrarBatalla.FlatStyle = FlatStyle.Popup;
            btnRegistrarBatalla.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarBatalla.ForeColor = SystemColors.ButtonFace;
            btnRegistrarBatalla.Location = new Point(77, 284);
            btnRegistrarBatalla.Name = "btnRegistrarBatalla";
            btnRegistrarBatalla.Size = new Size(212, 53);
            btnRegistrarBatalla.TabIndex = 4;
            btnRegistrarBatalla.Text = "Batalla";
            btnRegistrarBatalla.UseVisualStyleBackColor = false;
            btnRegistrarBatalla.Click += btnRegistrarBatalla_Click;
            // 
            // btnConsultarRondas
            // 
            btnConsultarRondas.BackColor = Color.RosyBrown;
            btnConsultarRondas.Cursor = Cursors.No;
            btnConsultarRondas.FlatStyle = FlatStyle.Popup;
            btnConsultarRondas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnConsultarRondas.ForeColor = SystemColors.ButtonFace;
            btnConsultarRondas.Location = new Point(77, 343);
            btnConsultarRondas.Name = "btnConsultarRondas";
            btnConsultarRondas.Size = new Size(212, 53);
            btnConsultarRondas.TabIndex = 5;
            btnConsultarRondas.Text = "Rondas de Batalla";
            btnConsultarRondas.UseVisualStyleBackColor = false;
            btnConsultarRondas.Click += btnRegistrarRondas_Click;
            // 
            // btnTopGanadores
            // 
            btnTopGanadores.BackColor = Color.RosyBrown;
            btnTopGanadores.Cursor = Cursors.No;
            btnTopGanadores.FlatStyle = FlatStyle.Popup;
            btnTopGanadores.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnTopGanadores.ForeColor = SystemColors.ButtonFace;
            btnTopGanadores.Location = new Point(77, 402);
            btnTopGanadores.Name = "btnTopGanadores";
            btnTopGanadores.Size = new Size(212, 53);
            btnTopGanadores.TabIndex = 6;
            btnTopGanadores.Text = "Top 10 Ganadores";
            btnTopGanadores.UseVisualStyleBackColor = false;
            btnTopGanadores.Click += btnTopGanadores_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(355, 507);
            Controls.Add(btnTopGanadores);
            Controls.Add(btnConsultarRondas);
            Controls.Add(btnRegistrarBatalla);
            Controls.Add(btnRegistrarEquipos);
            Controls.Add(btnRegistrarInventario);
            Controls.Add(btnGestionJugador);
            Controls.Add(btnGestionCriatura);
            ForeColor = SystemColors.ActiveCaption;
            Name = "MenuPrincipal";
            Text = "Menu Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGestionCriatura;
        private Button btnGestionJugador;
        private Button btnRegistrarInventario;
        private Button btnRegistrarEquipos;
        private Button btnRegistrarBatalla;
        private Button btnConsultarRondas;
        private Button btnTopGanadores;
    }
}