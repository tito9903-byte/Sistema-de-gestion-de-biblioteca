namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    partial class TarjetaAccion
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIcono = new Label();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            SuspendLayout();
            //
            // lblIcono
            //
            lblIcono.BackColor = Color.Transparent;
            lblIcono.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcono.ForeColor = Color.FromArgb(21, 85, 170);
            lblIcono.Location = new Point(16, 16);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(56, 56);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "";
            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 25, 25);
            lblTitulo.Location = new Point(88, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(52, 22);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(80, 90, 105);
            lblDescripcion.Location = new Point(89, 44);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(74, 17);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            //
            // TarjetaAccion
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 242, 252);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Controls.Add(lblIcono);
            Name = "TarjetaAccion";
            Size = new Size(300, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIcono;
        private Label lblTitulo;
        private Label lblDescripcion;
    }
}
