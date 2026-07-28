
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
            btnRegistrarCri = new Button();
            btnVolver = new Button();
            btnRegistrarJug = new Button();
            SuspendLayout();
            // 
            // btnRegistrarCri
            // 
            btnRegistrarCri.BackColor = Color.DodgerBlue;
            btnRegistrarCri.Cursor = Cursors.No;
            btnRegistrarCri.FlatStyle = FlatStyle.Popup;
            btnRegistrarCri.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarCri.ForeColor = SystemColors.ButtonFace;
            btnRegistrarCri.Location = new Point(88, 145);
            btnRegistrarCri.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarCri.Name = "btnRegistrarCri";
            btnRegistrarCri.Size = new Size(242, 71);
            btnRegistrarCri.TabIndex = 6;
            btnRegistrarCri.Text = "Consultar";
            btnRegistrarCri.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(88, 232);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(242, 71);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarJug
            // 
            btnRegistrarJug.BackColor = Color.DodgerBlue;
            btnRegistrarJug.Cursor = Cursors.No;
            btnRegistrarJug.FlatStyle = FlatStyle.Popup;
            btnRegistrarJug.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnRegistrarJug.ForeColor = SystemColors.ButtonFace;
            btnRegistrarJug.Location = new Point(88, 59);
            btnRegistrarJug.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarJug.Name = "btnRegistrarJug";
            btnRegistrarJug.Size = new Size(242, 71);
            btnRegistrarJug.TabIndex = 4;
            btnRegistrarJug.Text = "Registrar";
            btnRegistrarJug.UseVisualStyleBackColor = false;
            btnRegistrarJug.Click += btnRegistrarJug_Click;
            // 
            // FormSubMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(418, 339);
            Controls.Add(btnRegistrarCri);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarJug);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSubMenu";
            Text = "Submenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegistrarCri;
        private Button btnVolver;
        private Button btnRegistrarJug;
    }
}