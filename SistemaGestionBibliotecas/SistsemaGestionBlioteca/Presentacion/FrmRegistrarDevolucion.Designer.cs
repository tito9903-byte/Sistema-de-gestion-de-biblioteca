namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmRegistrarDevolucion
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
            lblEncabezado = new Label();
            lblPrestamo = new Label();
            cmbPrestamo = new ComboBox();
            panelResumen = new Controles.PanelTarjeta();
            lblMulta = new Label();
            lblRetraso = new Label();
            lblVence = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            panelResumen.SuspendLayout();
            SuspendLayout();
            //
            // lblEncabezado
            //
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblEncabezado.ForeColor = Color.FromArgb(20, 20, 30);
            lblEncabezado.Location = new Point(28, 20);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(260, 32);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Registrar devolución";
            //
            // lblPrestamo
            //
            lblPrestamo.AutoSize = true;
            lblPrestamo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrestamo.Location = new Point(30, 80);
            lblPrestamo.Name = "lblPrestamo";
            lblPrestamo.Size = new Size(64, 19);
            lblPrestamo.TabIndex = 1;
            lblPrestamo.Text = "Préstamo";
            //
            // cmbPrestamo
            //
            cmbPrestamo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrestamo.Font = new Font("Segoe UI", 11F);
            cmbPrestamo.FormattingEnabled = true;
            cmbPrestamo.Location = new Point(30, 102);
            cmbPrestamo.Name = "cmbPrestamo";
            cmbPrestamo.Size = new Size(460, 28);
            cmbPrestamo.TabIndex = 0;
            cmbPrestamo.SelectedIndexChanged += cmbPrestamo_SelectedIndexChanged;
            //
            // panelResumen
            //
            panelResumen.BackColor = Color.White;
            panelResumen.ColorBorde = Color.FromArgb(222, 226, 232);
            panelResumen.Controls.Add(lblMulta);
            panelResumen.Controls.Add(lblRetraso);
            panelResumen.Controls.Add(lblVence);
            panelResumen.Location = new Point(30, 156);
            panelResumen.Name = "panelResumen";
            panelResumen.Size = new Size(460, 120);
            panelResumen.TabIndex = 1;
            //
            // lblVence
            //
            lblVence.AutoSize = true;
            lblVence.Font = new Font("Segoe UI", 11F);
            lblVence.Location = new Point(18, 16);
            lblVence.Name = "lblVence";
            lblVence.Size = new Size(110, 20);
            lblVence.TabIndex = 0;
            lblVence.Text = "Fecha límite: -";
            //
            // lblRetraso
            //
            lblRetraso.AutoSize = true;
            lblRetraso.Font = new Font("Segoe UI", 11F);
            lblRetraso.Location = new Point(18, 48);
            lblRetraso.Name = "lblRetraso";
            lblRetraso.Size = new Size(124, 20);
            lblRetraso.TabIndex = 1;
            lblRetraso.Text = "Días de retraso: -";
            //
            // lblMulta
            //
            lblMulta.AutoSize = true;
            lblMulta.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblMulta.Location = new Point(18, 80);
            lblMulta.Name = "lblMulta";
            lblMulta.Size = new Size(71, 23);
            lblMulta.TabIndex = 2;
            lblMulta.Text = "Multa: -";
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(0, 120, 235);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 312);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 46);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Registrar devolución";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(176, 196, 222);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 212, 232);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(270, 312);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(220, 46);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmRegistrarDevolucion
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 384);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(panelResumen);
            Controls.Add(cmbPrestamo);
            Controls.Add(lblPrestamo);
            Controls.Add(lblEncabezado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistrarDevolucion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar devolución";
            Load += FrmRegistrarDevolucion_Load;
            panelResumen.ResumeLayout(false);
            panelResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEncabezado;
        private Label lblPrestamo;
        private ComboBox cmbPrestamo;
        private Controles.PanelTarjeta panelResumen;
        private Label lblVence;
        private Label lblRetraso;
        private Label lblMulta;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
