namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class frmMain
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
            panel2 = new Panel();
            panelContenedor = new Panel();
            panelBottom = new Panel();
            btnCerrarSesión = new Button();
            panelButtons = new Panel();
            btnUsuarios = new Button();
            panelMenu = new Panel();
            panel2.SuspendLayout();
            panelBottom.SuspendLayout();
            panelButtons.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(panelContenedor);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(210, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(908, 697);
            panel2.TabIndex = 3;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(3, 2, 3, 2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(908, 697);
            panelContenedor.TabIndex = 1;
           // panelContenedor.Paint += panelContenedor_Paint;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnCerrarSesión);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 603);
            panelBottom.Margin = new Padding(3, 2, 3, 2);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(210, 94);
            panelBottom.TabIndex = 7;
            // 
            // btnCerrarSesión
            // 
            btnCerrarSesión.Dock = DockStyle.Top;
            btnCerrarSesión.FlatAppearance.BorderSize = 0;
            btnCerrarSesión.FlatStyle = FlatStyle.Flat;
            btnCerrarSesión.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnCerrarSesión.ForeColor = SystemColors.ButtonHighlight;
            btnCerrarSesión.Location = new Point(0, 0);
            btnCerrarSesión.Margin = new Padding(3, 2, 3, 2);
            btnCerrarSesión.Name = "btnCerrarSesión";
            btnCerrarSesión.Size = new Size(210, 52);
            btnCerrarSesión.TabIndex = 7;
            btnCerrarSesión.Text = "🔁Cerrar sesión";
            btnCerrarSesión.UseVisualStyleBackColor = true;
            btnCerrarSesión.Click += btnCerrarSesión_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(panelBottom);
            panelButtons.Controls.Add(btnUsuarios);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(0, 0);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(210, 697);
            panelButtons.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnUsuarios.ForeColor = SystemColors.ButtonHighlight;
            btnUsuarios.Location = new Point(0, 0);
            btnUsuarios.Margin = new Padding(3, 2, 3, 2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(210, 52);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "👤 Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.LightSlateGray;
            panelMenu.Controls.Add(panelButtons);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(210, 697);
            panelMenu.TabIndex = 2;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 697);
            Controls.Add(panel2);
            Controls.Add(panelMenu);
            Name = "frmMain";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "frmMain";
            panel2.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panelContenedor;
        private Panel panelBottom;
        private Button btnCerrarSesión;
        private Panel panelButtons;
        private Panel panelMenu;
        private Button btnUsuarios;
    }
}