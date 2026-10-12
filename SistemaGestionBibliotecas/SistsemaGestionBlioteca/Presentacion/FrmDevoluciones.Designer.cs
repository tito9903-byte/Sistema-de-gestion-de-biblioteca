namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmDevoluciones
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
            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloCelda = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFecha1 = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFecha2 = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloMulta = new DataGridViewCellStyle();
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaHoy = new Controles.TarjetaResumen();
            tarjetaConRetraso = new Controles.TarjetaResumen();
            tarjetaMultas = new Controles.TarjetaResumen();
            txtBuscar = new TextBox();
            tlpContenido = new TableLayoutPanel();
            dgvDevoluciones = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            colFechaPrestamo = new DataGridViewTextBoxColumn();
            colFechaDevolucion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colMulta = new DataGridViewTextBoxColumn();
            panelBotones = new FlowLayoutPanel();
            btnRegistrarDevolucion = new Button();
            btnCalcularMulta = new Button();
            btnVerHistorial = new Button();
            btnActualizar = new Button();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevoluciones).BeginInit();
            panelBotones.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(panelEncabezado, 0, 0);
            tlpPrincipal.Controls.Add(tlpTarjetas, 0, 1);
            tlpPrincipal.Controls.Add(txtBuscar, 0, 2);
            tlpPrincipal.Controls.Add(tlpContenido, 0, 3);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 4;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(1098, 732);
            tlpPrincipal.TabIndex = 0;
            //
            // panelEncabezado
            //
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Fill;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Margin = new Padding(0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(1098, 88);
            panelEncabezado.TabIndex = 0;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 100, 130);
            lblSubtitulo.Location = new Point(4, 56);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(430, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestiona las devoluciones de libros y consulta el estado de los préstamos.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Devoluciones";
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 3;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpTarjetas.Controls.Add(tarjetaHoy, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaConRetraso, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaMultas, 2, 0);
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.Location = new Point(0, 88);
            tlpTarjetas.Margin = new Padding(0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Padding = new Padding(0, 0, 0, 16);
            tlpTarjetas.RowCount = 1;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTarjetas.Size = new Size(1098, 140);
            tlpTarjetas.TabIndex = 1;
            //
            // tarjetaHoy
            //
            tarjetaHoy.BackColor = Color.White;
            tarjetaHoy.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaHoy.ColorCirculo = Color.FromArgb(209, 230, 252);
            tarjetaHoy.ColorValor = Color.FromArgb(21, 85, 170);
            tarjetaHoy.Descripcion = "Libros devueltos en el día de hoy";
            tarjetaHoy.Dock = DockStyle.Fill;
            tarjetaHoy.Icono = "";
            tarjetaHoy.Location = new Point(0, 0);
            tarjetaHoy.Margin = new Padding(0, 0, 16, 0);
            tarjetaHoy.Name = "tarjetaHoy";
            tarjetaHoy.Size = new Size(350, 124);
            tarjetaHoy.TabIndex = 0;
            tarjetaHoy.Titulo = "Devoluciones hoy";
            tarjetaHoy.Valor = "0";
            //
            // tarjetaConRetraso
            //
            tarjetaConRetraso.BackColor = Color.White;
            tarjetaConRetraso.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaConRetraso.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaConRetraso.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaConRetraso.Descripcion = "Devoluciones fuera de plazo";
            tarjetaConRetraso.Dock = DockStyle.Fill;
            tarjetaConRetraso.Icono = "";
            tarjetaConRetraso.Location = new Point(366, 0);
            tarjetaConRetraso.Margin = new Padding(0, 0, 16, 0);
            tarjetaConRetraso.Name = "tarjetaConRetraso";
            tarjetaConRetraso.Size = new Size(350, 124);
            tarjetaConRetraso.TabIndex = 1;
            tarjetaConRetraso.Titulo = "Con retraso";
            tarjetaConRetraso.Valor = "0";
            //
            // tarjetaMultas
            //
            tarjetaMultas.BackColor = Color.White;
            tarjetaMultas.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaMultas.ColorCirculo = Color.FromArgb(252, 206, 206);
            tarjetaMultas.ColorValor = Color.FromArgb(185, 20, 40);
            tarjetaMultas.Descripcion = "Total en multas por cobrar";
            tarjetaMultas.Dock = DockStyle.Fill;
            tarjetaMultas.Icono = "$";
            tarjetaMultas.Location = new Point(732, 0);
            tarjetaMultas.Margin = new Padding(0);
            tarjetaMultas.Name = "tarjetaMultas";
            tarjetaMultas.Size = new Size(366, 124);
            tarjetaMultas.TabIndex = 2;
            tarjetaMultas.Titulo = "Multas pendientes";
            tarjetaMultas.Valor = "$0.00";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(0, 228);
            txtBuscar.Margin = new Padding(0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, libro o código de devolución...";
            txtBuscar.Size = new Size(1098, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // tlpContenido
            //
            tlpContenido.BackColor = Color.Transparent;
            tlpContenido.ColumnCount = 2;
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 216F));
            tlpContenido.Controls.Add(dgvDevoluciones, 0, 0);
            tlpContenido.Controls.Add(panelBotones, 1, 0);
            tlpContenido.Dock = DockStyle.Fill;
            tlpContenido.Location = new Point(0, 272);
            tlpContenido.Margin = new Padding(0);
            tlpContenido.Name = "tlpContenido";
            tlpContenido.RowCount = 1;
            tlpContenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpContenido.Size = new Size(1098, 460);
            tlpContenido.TabIndex = 2;
            //
            // dgvDevoluciones
            //
            dgvDevoluciones.AllowUserToAddRows = false;
            dgvDevoluciones.AllowUserToDeleteRows = false;
            dgvDevoluciones.AllowUserToResizeRows = false;
            dgvDevoluciones.AutoGenerateColumns = false;
            dgvDevoluciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevoluciones.BackgroundColor = Color.White;
            dgvDevoluciones.BorderStyle = BorderStyle.FixedSingle;
            dgvDevoluciones.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDevoluciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.False;
            dgvDevoluciones.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvDevoluciones.ColumnHeadersHeight = 36;
            dgvDevoluciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDevoluciones.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colUsuario, colLibro, colFechaPrestamo, colFechaDevolucion, colEstado, colMulta });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(30, 120, 255);
            estiloCelda.SelectionForeColor = Color.White;
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvDevoluciones.DefaultCellStyle = estiloCelda;
            dgvDevoluciones.Dock = DockStyle.Fill;
            dgvDevoluciones.EnableHeadersVisualStyles = false;
            dgvDevoluciones.GridColor = Color.FromArgb(120, 120, 120);
            dgvDevoluciones.Location = new Point(0, 0);
            dgvDevoluciones.Margin = new Padding(0, 0, 16, 0);
            dgvDevoluciones.MultiSelect = false;
            dgvDevoluciones.Name = "dgvDevoluciones";
            dgvDevoluciones.ReadOnly = true;
            dgvDevoluciones.RowHeadersVisible = false;
            dgvDevoluciones.RowTemplate.Height = 32;
            dgvDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevoluciones.Size = new Size(866, 460);
            dgvDevoluciones.TabIndex = 0;
            dgvDevoluciones.CellFormatting += dgvDevoluciones_CellFormatting;
            //
            // colCodigo
            //
            colCodigo.DataPropertyName = "codigo";
            colCodigo.FillWeight = 10F;
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            //
            // colUsuario
            //
            colUsuario.DataPropertyName = "usuario";
            colUsuario.FillWeight = 15F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            //
            // colLibro
            //
            colLibro.DataPropertyName = "libro";
            colLibro.FillWeight = 21F;
            colLibro.HeaderText = "Libro";
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            //
            // colFechaPrestamo
            //
            estiloFecha1.Format = "dd/MM/yyyy";
            colFechaPrestamo.DataPropertyName = "fecha_prestamo";
            colFechaPrestamo.DefaultCellStyle = estiloFecha1;
            colFechaPrestamo.FillWeight = 14F;
            colFechaPrestamo.HeaderText = "Fecha préstamo";
            colFechaPrestamo.Name = "colFechaPrestamo";
            colFechaPrestamo.ReadOnly = true;
            //
            // colFechaDevolucion
            //
            estiloFecha2.Format = "dd/MM/yyyy";
            colFechaDevolucion.DataPropertyName = "fecha_devolucion";
            colFechaDevolucion.DefaultCellStyle = estiloFecha2;
            colFechaDevolucion.FillWeight = 16F;
            colFechaDevolucion.HeaderText = "Devolución real";
            colFechaDevolucion.Name = "colFechaDevolucion";
            colFechaDevolucion.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "estado";
            colEstado.FillWeight = 13F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colMulta
            //
            estiloMulta.Format = "'$'0.00";
            colMulta.DataPropertyName = "multa";
            colMulta.DefaultCellStyle = estiloMulta;
            colMulta.FillWeight = 9F;
            colMulta.HeaderText = "Multa";
            colMulta.Name = "colMulta";
            colMulta.ReadOnly = true;
            //
            // panelBotones
            //
            panelBotones.Controls.Add(btnRegistrarDevolucion);
            panelBotones.Controls.Add(btnCalcularMulta);
            panelBotones.Controls.Add(btnVerHistorial);
            panelBotones.Controls.Add(btnActualizar);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.FlowDirection = FlowDirection.TopDown;
            panelBotones.Location = new Point(882, 0);
            panelBotones.Margin = new Padding(0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(216, 460);
            panelBotones.TabIndex = 1;
            panelBotones.WrapContents = false;
            //
            // btnRegistrarDevolucion
            //
            btnRegistrarDevolucion.BackColor = Color.FromArgb(0, 120, 235);
            btnRegistrarDevolucion.Cursor = Cursors.Hand;
            btnRegistrarDevolucion.FlatAppearance.BorderSize = 0;
            btnRegistrarDevolucion.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnRegistrarDevolucion.FlatStyle = FlatStyle.Flat;
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 10.5F);
            btnRegistrarDevolucion.ForeColor = Color.White;
            btnRegistrarDevolucion.Location = new Point(0, 0);
            btnRegistrarDevolucion.Margin = new Padding(0, 0, 0, 12);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(216, 56);
            btnRegistrarDevolucion.TabIndex = 0;
            btnRegistrarDevolucion.Text = "＋   Registrar devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            //
            // btnCalcularMulta
            //
            btnCalcularMulta.BackColor = Color.FromArgb(255, 205, 150);
            btnCalcularMulta.Cursor = Cursors.Hand;
            btnCalcularMulta.FlatAppearance.BorderSize = 0;
            btnCalcularMulta.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 218, 175);
            btnCalcularMulta.FlatStyle = FlatStyle.Flat;
            btnCalcularMulta.Font = new Font("Segoe UI", 10.5F);
            btnCalcularMulta.ForeColor = Color.Black;
            btnCalcularMulta.Location = new Point(0, 68);
            btnCalcularMulta.Margin = new Padding(0, 0, 0, 12);
            btnCalcularMulta.Name = "btnCalcularMulta";
            btnCalcularMulta.Size = new Size(216, 56);
            btnCalcularMulta.TabIndex = 1;
            btnCalcularMulta.Text = "🧮   Calcular multa";
            btnCalcularMulta.UseVisualStyleBackColor = false;
            btnCalcularMulta.Click += btnCalcularMulta_Click;
            //
            // btnVerHistorial
            //
            btnVerHistorial.BackColor = Color.FromArgb(190, 218, 248);
            btnVerHistorial.Cursor = Cursors.Hand;
            btnVerHistorial.FlatAppearance.BorderSize = 0;
            btnVerHistorial.FlatAppearance.MouseOverBackColor = Color.FromArgb(208, 229, 252);
            btnVerHistorial.FlatStyle = FlatStyle.Flat;
            btnVerHistorial.Font = new Font("Segoe UI", 10.5F);
            btnVerHistorial.ForeColor = Color.Black;
            btnVerHistorial.Location = new Point(0, 136);
            btnVerHistorial.Margin = new Padding(0, 0, 0, 12);
            btnVerHistorial.Name = "btnVerHistorial";
            btnVerHistorial.Size = new Size(216, 56);
            btnVerHistorial.TabIndex = 2;
            btnVerHistorial.Text = "📄   Ver historial";
            btnVerHistorial.UseVisualStyleBackColor = false;
            btnVerHistorial.Click += btnVerHistorial_Click;
            //
            // btnActualizar
            //
            btnActualizar.BackColor = Color.FromArgb(200, 208, 220);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 222, 232);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10.5F);
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.Location = new Point(0, 204);
            btnActualizar.Margin = new Padding(0, 0, 0, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(216, 56);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "🔄   Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            //
            // FrmDevoluciones
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmDevoluciones";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmDevoluciones";
            Load += FrmDevoluciones_Load;
            tlpPrincipal.ResumeLayout(false);
            tlpPrincipal.PerformLayout();
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDevoluciones).EndInit();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaHoy;
        private Controles.TarjetaResumen tarjetaConRetraso;
        private Controles.TarjetaResumen tarjetaMultas;
        private TextBox txtBuscar;
        private TableLayoutPanel tlpContenido;
        private DataGridView dgvDevoluciones;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colFechaPrestamo;
        private DataGridViewTextBoxColumn colFechaDevolucion;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colMulta;
        private FlowLayoutPanel panelBotones;
        private Button btnRegistrarDevolucion;
        private Button btnCalcularMulta;
        private Button btnVerHistorial;
        private Button btnActualizar;
    }
}
