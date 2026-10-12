namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmReservas
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
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaActivas = new Controles.TarjetaResumen();
            tarjetaPorVencer = new Controles.TarjetaResumen();
            tarjetaCanceladas = new Controles.TarjetaResumen();
            txtBuscar = new TextBox();
            tlpContenido = new TableLayoutPanel();
            dgvReservas = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            colFechaReserva = new DataGridViewTextBoxColumn();
            colVence = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colPrioridad = new DataGridViewTextBoxColumn();
            panelBotones = new FlowLayoutPanel();
            btnNuevaReserva = new Button();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            btnNotificar = new Button();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
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
            lblSubtitulo.Size = new Size(640, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestiona las reservas de libros del sistema. Aquí puedes crear, confirmar, cancelar reservas y notificar a los usuarios.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(137, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reservas";
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 3;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpTarjetas.Controls.Add(tarjetaActivas, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaPorVencer, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaCanceladas, 2, 0);
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
            // tarjetaActivas
            //
            tarjetaActivas.BackColor = Color.White;
            tarjetaActivas.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaActivas.ColorCirculo = Color.FromArgb(209, 230, 252);
            tarjetaActivas.ColorValor = Color.FromArgb(21, 85, 170);
            tarjetaActivas.Descripcion = "Reservas vigentes en el sistema";
            tarjetaActivas.Dock = DockStyle.Fill;
            tarjetaActivas.Icono = "";
            tarjetaActivas.Location = new Point(0, 0);
            tarjetaActivas.Margin = new Padding(0, 0, 16, 0);
            tarjetaActivas.Name = "tarjetaActivas";
            tarjetaActivas.Size = new Size(350, 124);
            tarjetaActivas.TabIndex = 0;
            tarjetaActivas.Titulo = "Reservas activas";
            tarjetaActivas.Valor = "0";
            //
            // tarjetaPorVencer
            //
            tarjetaPorVencer.BackColor = Color.White;
            tarjetaPorVencer.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaPorVencer.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaPorVencer.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaPorVencer.Descripcion = "Vencen en los próximos 3 días";
            tarjetaPorVencer.Dock = DockStyle.Fill;
            tarjetaPorVencer.Icono = "";
            tarjetaPorVencer.Location = new Point(366, 0);
            tarjetaPorVencer.Margin = new Padding(0, 0, 16, 0);
            tarjetaPorVencer.Name = "tarjetaPorVencer";
            tarjetaPorVencer.Size = new Size(350, 124);
            tarjetaPorVencer.TabIndex = 1;
            tarjetaPorVencer.Titulo = "Por vencer";
            tarjetaPorVencer.Valor = "0";
            //
            // tarjetaCanceladas
            //
            tarjetaCanceladas.BackColor = Color.White;
            tarjetaCanceladas.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaCanceladas.ColorCirculo = Color.FromArgb(252, 206, 206);
            tarjetaCanceladas.ColorValor = Color.FromArgb(185, 20, 40);
            tarjetaCanceladas.Descripcion = "Reservas canceladas";
            tarjetaCanceladas.Dock = DockStyle.Fill;
            tarjetaCanceladas.Icono = "";
            tarjetaCanceladas.Location = new Point(732, 0);
            tarjetaCanceladas.Margin = new Padding(0);
            tarjetaCanceladas.Name = "tarjetaCanceladas";
            tarjetaCanceladas.Size = new Size(366, 124);
            tarjetaCanceladas.TabIndex = 2;
            tarjetaCanceladas.Titulo = "Canceladas";
            tarjetaCanceladas.Valor = "0";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(0, 228);
            txtBuscar.Margin = new Padding(0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, libro o estado de reserva...";
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
            tlpContenido.Controls.Add(dgvReservas, 0, 0);
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
            // dgvReservas
            //
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AllowUserToResizeRows = false;
            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.BorderStyle = BorderStyle.FixedSingle;
            dgvReservas.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvReservas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.False;
            dgvReservas.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvReservas.ColumnHeadersHeight = 36;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReservas.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colUsuario, colLibro, colFechaReserva, colVence, colEstado, colPrioridad });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(30, 120, 255);
            estiloCelda.SelectionForeColor = Color.White;
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvReservas.DefaultCellStyle = estiloCelda;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.GridColor = Color.FromArgb(120, 120, 120);
            dgvReservas.Location = new Point(0, 0);
            dgvReservas.Margin = new Padding(0, 0, 16, 0);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.RowTemplate.Height = 32;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(866, 460);
            dgvReservas.TabIndex = 0;
            dgvReservas.CellFormatting += dgvReservas_CellFormatting;
            //
            // colCodigo
            //
            colCodigo.DataPropertyName = "codigo";
            colCodigo.FillWeight = 9F;
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            //
            // colUsuario
            //
            colUsuario.DataPropertyName = "usuario";
            colUsuario.FillWeight = 14F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            //
            // colLibro
            //
            colLibro.DataPropertyName = "libro";
            colLibro.FillWeight = 22F;
            colLibro.HeaderText = "Libro";
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            //
            // colFechaReserva
            //
            estiloFecha1.Format = "dd/MM/yyyy HH:mm";
            colFechaReserva.DataPropertyName = "fecha_reserva";
            colFechaReserva.DefaultCellStyle = estiloFecha1;
            colFechaReserva.FillWeight = 17F;
            colFechaReserva.HeaderText = "Fecha reserva";
            colFechaReserva.Name = "colFechaReserva";
            colFechaReserva.ReadOnly = true;
            //
            // colVence
            //
            estiloFecha2.Format = "dd/MM/yyyy";
            colVence.DataPropertyName = "fecha_vencimiento";
            colVence.DefaultCellStyle = estiloFecha2;
            colVence.FillWeight = 12F;
            colVence.HeaderText = "Vence";
            colVence.Name = "colVence";
            colVence.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "estado";
            colEstado.FillWeight = 13F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colPrioridad
            //
            colPrioridad.DataPropertyName = "prioridad";
            colPrioridad.FillWeight = 10F;
            colPrioridad.HeaderText = "Prioridad";
            colPrioridad.Name = "colPrioridad";
            colPrioridad.ReadOnly = true;
            //
            // panelBotones
            //
            panelBotones.Controls.Add(btnNuevaReserva);
            panelBotones.Controls.Add(btnConfirmar);
            panelBotones.Controls.Add(btnCancelar);
            panelBotones.Controls.Add(btnNotificar);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.FlowDirection = FlowDirection.TopDown;
            panelBotones.Location = new Point(882, 0);
            panelBotones.Margin = new Padding(0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(216, 460);
            panelBotones.TabIndex = 1;
            panelBotones.WrapContents = false;
            //
            // btnNuevaReserva
            //
            btnNuevaReserva.BackColor = Color.FromArgb(0, 120, 235);
            btnNuevaReserva.Cursor = Cursors.Hand;
            btnNuevaReserva.FlatAppearance.BorderSize = 0;
            btnNuevaReserva.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnNuevaReserva.Font = new Font("Segoe UI", 10.5F);
            btnNuevaReserva.ForeColor = Color.White;
            btnNuevaReserva.Location = new Point(0, 0);
            btnNuevaReserva.Margin = new Padding(0, 0, 0, 12);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(216, 52);
            btnNuevaReserva.TabIndex = 0;
            btnNuevaReserva.Text = "＋   Nueva reserva";
            btnNuevaReserva.UseVisualStyleBackColor = false;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            //
            // btnConfirmar
            //
            btnConfirmar.BackColor = Color.FromArgb(165, 214, 170);
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 226, 190);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 10.5F);
            btnConfirmar.ForeColor = Color.Black;
            btnConfirmar.Location = new Point(0, 64);
            btnConfirmar.Margin = new Padding(0, 0, 0, 12);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(216, 52);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "✔   Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(250, 130, 120);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(252, 150, 140);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10.5F);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(0, 128);
            btnCancelar.Margin = new Padding(0, 0, 0, 12);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(216, 52);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "✖   Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // btnNotificar
            //
            btnNotificar.BackColor = Color.FromArgb(176, 196, 222);
            btnNotificar.Cursor = Cursors.Hand;
            btnNotificar.FlatAppearance.BorderSize = 0;
            btnNotificar.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 212, 232);
            btnNotificar.FlatStyle = FlatStyle.Flat;
            btnNotificar.Font = new Font("Segoe UI", 10.5F);
            btnNotificar.ForeColor = Color.Black;
            btnNotificar.Location = new Point(0, 192);
            btnNotificar.Margin = new Padding(0, 0, 0, 12);
            btnNotificar.Name = "btnNotificar";
            btnNotificar.Size = new Size(216, 52);
            btnNotificar.TabIndex = 3;
            btnNotificar.Text = "✉   Notificar";
            btnNotificar.UseVisualStyleBackColor = false;
            btnNotificar.Click += btnNotificar_Click;
            //
            // FrmReservas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReservas";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmReservas";
            Load += FrmReservas_Load;
            tlpPrincipal.ResumeLayout(false);
            tlpPrincipal.PerformLayout();
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaActivas;
        private Controles.TarjetaResumen tarjetaPorVencer;
        private Controles.TarjetaResumen tarjetaCanceladas;
        private TextBox txtBuscar;
        private TableLayoutPanel tlpContenido;
        private DataGridView dgvReservas;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colFechaReserva;
        private DataGridViewTextBoxColumn colVence;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colPrioridad;
        private FlowLayoutPanel panelBotones;
        private Button btnNuevaReserva;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Button btnNotificar;
    }
}
