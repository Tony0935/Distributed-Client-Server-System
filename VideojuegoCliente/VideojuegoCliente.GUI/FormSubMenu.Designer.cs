
namespace Videojuego.GUI
{
    partial class FormSubMenu
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
            btnConsultar = new Button();
            btnVolver = new Button();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.DarkTurquoise;
            btnConsultar.Cursor = Cursors.No;
            btnConsultar.FlatStyle = FlatStyle.Popup;
            btnConsultar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnConsultar.ForeColor = SystemColors.ButtonFace;
            btnConsultar.Location = new Point(77, 109);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(212, 53);
            btnConsultar.TabIndex = 6;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(77, 174);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(212, 53);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = SystemColors.Highlight;
            btnRegistrar.Cursor = Cursors.No;
            btnRegistrar.FlatStyle = FlatStyle.Popup;
            btnRegistrar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrar.ForeColor = SystemColors.ButtonFace;
            btnRegistrar.Location = new Point(77, 44);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(212, 53);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // FormSubMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(366, 254);
            Controls.Add(btnConsultar);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Name = "FormSubMenu";
            Text = "Submenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnConsultar;
        private Button btnVolver;
        private Button btnRegistrar;
    }
}