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
            btnTienda = new Button();
            btnRegistrarEquipos = new Button();
            btnRegistrarBatalla = new Button();
            btnConsultarRondas = new Button();
            btnTopGanadores = new Button();
            btnDesconectar = new Button();
            SuspendLayout();
            // 
            // btnTienda
            // 
            btnTienda.BackColor = Color.RosyBrown;
            btnTienda.Cursor = Cursors.No;
            btnTienda.FlatStyle = FlatStyle.Popup;
            btnTienda.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnTienda.ForeColor = SystemColors.ButtonFace;
            btnTienda.Location = new Point(78, 29);
            btnTienda.Name = "btnTienda";
            btnTienda.Size = new Size(212, 53);
            btnTienda.TabIndex = 2;
            btnTienda.Text = "Tienda de criaturas";
            btnTienda.UseVisualStyleBackColor = false;
            btnTienda.Click += btnRegistrarInventario_Click;
            // 
            // btnRegistrarEquipos
            // 
            btnRegistrarEquipos.BackColor = Color.RosyBrown;
            btnRegistrarEquipos.Cursor = Cursors.No;
            btnRegistrarEquipos.FlatStyle = FlatStyle.Popup;
            btnRegistrarEquipos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarEquipos.ForeColor = SystemColors.ButtonFace;
            btnRegistrarEquipos.Location = new Point(78, 88);
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
            btnRegistrarBatalla.Location = new Point(78, 147);
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
            btnConsultarRondas.Location = new Point(78, 206);
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
            btnTopGanadores.Location = new Point(78, 265);
            btnTopGanadores.Name = "btnTopGanadores";
            btnTopGanadores.Size = new Size(212, 53);
            btnTopGanadores.TabIndex = 6;
            btnTopGanadores.Text = "Top 10 Ganadores";
            btnTopGanadores.UseVisualStyleBackColor = false;
            btnTopGanadores.Click += btnTopGanadores_Click;
            // 
            // btnDesconectar
            // 
            btnDesconectar.BackColor = Color.Crimson;
            btnDesconectar.Cursor = Cursors.No;
            btnDesconectar.FlatStyle = FlatStyle.Popup;
            btnDesconectar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnDesconectar.ForeColor = SystemColors.ButtonFace;
            btnDesconectar.Location = new Point(78, 324);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(212, 53);
            btnDesconectar.TabIndex = 7;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = false;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(355, 393);
            Controls.Add(btnDesconectar);
            Controls.Add(btnTopGanadores);
            Controls.Add(btnConsultarRondas);
            Controls.Add(btnRegistrarBatalla);
            Controls.Add(btnRegistrarEquipos);
            Controls.Add(btnTienda);
            ForeColor = SystemColors.ActiveCaption;
            Name = "MenuPrincipal";
            Text = "Menu Principal";
            ResumeLayout(false);
        }

        #endregion
        private Button btnRegistrarEquipos;
        private Button btnRegistrarBatalla;
        private Button btnConsultarRondas;
        private Button btnTopGanadores;
        private Button btnDesconectar;
        private Button btnTienda;
    }
}