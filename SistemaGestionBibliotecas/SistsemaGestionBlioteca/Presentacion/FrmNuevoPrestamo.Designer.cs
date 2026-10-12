namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmNuevoPrestamo
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
            lblLector = new Label();
            cmbLector = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblDias = new Label();
            nudDias = new NumericUpDown();
            lblVence = new Label();
            lblObservacion = new Label();
            txtObservacion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDias).BeginInit();
            SuspendLayout();
            //
            // lblEncabezado
            //
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblEncabezado.ForeColor = Color.FromArgb(20, 20, 30);
            lblEncabezado.Location = new Point(28, 20);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(205, 32);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Nuevo préstamo";
            //
            // lblLector
            //
            lblLector.AutoSize = true;
            lblLector.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLector.Location = new Point(30, 80);
            lblLector.Name = "lblLector";
            lblLector.Size = new Size(46, 19);
            lblLector.TabIndex = 1;
            lblLector.Text = "Lector";
            //
            // cmbLector
            //
            cmbLector.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLector.Font = new Font("Segoe UI", 11F);
            cmbLector.FormattingEnabled = true;
            cmbLector.Location = new Point(30, 102);
            cmbLector.Name = "cmbLector";
            cmbLector.Size = new Size(460, 28);
            cmbLector.TabIndex = 0;
            //
            // lblLibro
            //
            lblLibro.AutoSize = true;
            lblLibro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLibro.Location = new Point(30, 146);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(41, 19);
            lblLibro.TabIndex = 2;
            lblLibro.Text = "Libro";
            //
            // cmbLibro
            //
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.Font = new Font("Segoe UI", 11F);
            cmbLibro.FormattingEnabled = true;
            cmbLibro.Location = new Point(30, 168);
            cmbLibro.Name = "cmbLibro";
            cmbLibro.Size = new Size(460, 28);
            cmbLibro.TabIndex = 1;
            //
            // lblDias
            //
            lblDias.AutoSize = true;
            lblDias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDias.Location = new Point(30, 212);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(101, 19);
            lblDias.TabIndex = 3;
            lblDias.Text = "Plazo (días)";
            //
            // nudDias
            //
            nudDias.Font = new Font("Segoe UI", 11F);
            nudDias.Location = new Point(30, 234);
            nudDias.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudDias.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDias.Name = "nudDias";
            nudDias.Size = new Size(140, 27);
            nudDias.TabIndex = 2;
            nudDias.Value = new decimal(new int[] { 14, 0, 0, 0 });
            nudDias.ValueChanged += nudDias_ValueChanged;
            //
            // lblVence
            //
            lblVence.AutoSize = true;
            lblVence.Font = new Font("Segoe UI", 11F);
            lblVence.ForeColor = Color.FromArgb(75, 95, 130);
            lblVence.Location = new Point(190, 237);
            lblVence.Name = "lblVence";
            lblVence.Size = new Size(110, 20);
            lblVence.TabIndex = 4;
            lblVence.Text = "Vence el --/--/----";
            //
            // lblObservacion
            //
            lblObservacion.AutoSize = true;
            lblObservacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblObservacion.Location = new Point(30, 278);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(89, 19);
            lblObservacion.TabIndex = 5;
            lblObservacion.Text = "Observación";
            //
            // txtObservacion
            //
            txtObservacion.Font = new Font("Segoe UI", 11F);
            txtObservacion.Location = new Point(30, 300);
            txtObservacion.MaxLength = 250;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.PlaceholderText = "Opcional";
            txtObservacion.Size = new Size(460, 27);
            txtObservacion.TabIndex = 3;
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
            btnGuardar.Location = new Point(30, 366);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 46);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Registrar préstamo";
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
            btnCancelar.Location = new Point(270, 366);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(220, 46);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmNuevoPrestamo
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 440);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservacion);
            Controls.Add(lblObservacion);
            Controls.Add(lblVence);
            Controls.Add(nudDias);
            Controls.Add(lblDias);
            Controls.Add(cmbLibro);
            Controls.Add(lblLibro);
            Controls.Add(cmbLector);
            Controls.Add(lblLector);
            Controls.Add(lblEncabezado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNuevoPrestamo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nuevo préstamo";
            Load += FrmNuevoPrestamo_Load;
            ((System.ComponentModel.ISupportInitialize)nudDias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEncabezado;
        private Label lblLector;
        private ComboBox cmbLector;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblDias;
        private NumericUpDown nudDias;
        private Label lblVence;
        private Label lblObservacion;
        private TextBox txtObservacion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
