namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmInicio
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
            DataGridViewCellStyle estiloFecha = new DataGridViewCellStyle();
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaLibros = new Controles.TarjetaResumen();
            tarjetaUsuarios = new Controles.TarjetaResumen();
            tarjetaPrestamos = new Controles.TarjetaResumen();
            tarjetaReservas = new Controles.TarjetaResumen();
            tlpInferior = new TableLayoutPanel();
            panelActividad = new Controles.PanelTarjeta();
            dgvActividad = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewTextBoxColumn();
            panelTituloActividad = new Panel();
            lnkVerTodas = new LinkLabel();
            lblActividad = new Label();
            panelAcciones = new Controles.PanelTarjeta();
            tlpAcciones = new TableLayoutPanel();
            tarjetaRegistrarLibro = new Controles.TarjetaAccion();
            tarjetaNuevoPrestamo = new Controles.TarjetaAccion();
            tarjetaNuevaReserva = new Controles.TarjetaAccion();
            lblAcciones = new Label();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpInferior.SuspendLayout();
            panelActividad.SuspendLayout();
            panelTituloActividad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActividad).BeginInit();
            panelAcciones.SuspendLayout();
            tlpAcciones.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(panelEncabezado, 0, 0);
            tlpPrincipal.Controls.Add(tlpTarjetas, 0, 1);
            tlpPrincipal.Controls.Add(tlpInferior, 0, 2);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 3;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(1012, 684);
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
            panelEncabezado.Size = new Size(1012, 88);
            panelEncabezado.TabIndex = 0;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 100, 130);
            lblSubtitulo.Location = new Point(4, 56);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(618, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Bienvenido al Sistema de Gestión de Biblioteca. Aquí puedes ver un resumen de la actividad y acceder a las funciones principales.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(213, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel principal";
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 4;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.Controls.Add(tarjetaLibros, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaUsuarios, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaPrestamos, 2, 0);
            tlpTarjetas.Controls.Add(tarjetaReservas, 3, 0);
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.Location = new Point(0, 88);
            tlpTarjetas.Margin = new Padding(0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Padding = new Padding(0, 0, 0, 16);
            tlpTarjetas.RowCount = 1;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTarjetas.Size = new Size(1012, 140);
            tlpTarjetas.TabIndex = 1;
            //
            // tarjetaLibros
            //
            tarjetaLibros.BackColor = Color.White;
            tarjetaLibros.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaLibros.ColorCirculo = Color.FromArgb(209, 230, 252);
            tarjetaLibros.ColorValor = Color.FromArgb(21, 85, 170);
            tarjetaLibros.Descripcion = "Libros registrados en el sistema";
            tarjetaLibros.Dock = DockStyle.Fill;
            tarjetaLibros.Icono = "";
            tarjetaLibros.Location = new Point(0, 0);
            tarjetaLibros.Margin = new Padding(0, 0, 16, 0);
            tarjetaLibros.Name = "tarjetaLibros";
            tarjetaLibros.Size = new Size(237, 124);
            tarjetaLibros.TabIndex = 0;
            tarjetaLibros.Titulo = "Total de libros";
            tarjetaLibros.Valor = "0";
            //
            // tarjetaUsuarios
            //
            tarjetaUsuarios.BackColor = Color.White;
            tarjetaUsuarios.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaUsuarios.ColorCirculo = Color.FromArgb(203, 232, 208);
            tarjetaUsuarios.ColorValor = Color.FromArgb(24, 110, 40);
            tarjetaUsuarios.Descripcion = "Usuarios activos";
            tarjetaUsuarios.Dock = DockStyle.Fill;
            tarjetaUsuarios.Icono = "";
            tarjetaUsuarios.Location = new Point(253, 0);
            tarjetaUsuarios.Margin = new Padding(0, 0, 16, 0);
            tarjetaUsuarios.Name = "tarjetaUsuarios";
            tarjetaUsuarios.Size = new Size(237, 124);
            tarjetaUsuarios.TabIndex = 1;
            tarjetaUsuarios.Titulo = "Usuarios registrados";
            tarjetaUsuarios.Valor = "0";
            //
            // tarjetaPrestamos
            //
            tarjetaPrestamos.BackColor = Color.White;
            tarjetaPrestamos.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaPrestamos.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaPrestamos.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaPrestamos.Descripcion = "Libros actualmente prestados";
            tarjetaPrestamos.Dock = DockStyle.Fill;
            tarjetaPrestamos.Icono = "";
            tarjetaPrestamos.Location = new Point(506, 0);
            tarjetaPrestamos.Margin = new Padding(0, 0, 16, 0);
            tarjetaPrestamos.Name = "tarjetaPrestamos";
            tarjetaPrestamos.Size = new Size(237, 124);
            tarjetaPrestamos.TabIndex = 2;
            tarjetaPrestamos.Titulo = "Préstamos activos";
            tarjetaPrestamos.Valor = "0";
            //
            // tarjetaReservas
            //
            tarjetaReservas.BackColor = Color.White;
            tarjetaReservas.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaReservas.ColorCirculo = Color.FromArgb(252, 206, 206);
            tarjetaReservas.ColorValor = Color.FromArgb(185, 20, 40);
            tarjetaReservas.Descripcion = "Reservas en espera";
            tarjetaReservas.Dock = DockStyle.Fill;
            tarjetaReservas.Icono = "";
            tarjetaReservas.Location = new Point(759, 0);
            tarjetaReservas.Margin = new Padding(0);
            tarjetaReservas.Name = "tarjetaReservas";
            tarjetaReservas.Size = new Size(253, 124);
            tarjetaReservas.TabIndex = 3;
            tarjetaReservas.Titulo = "Reservas pendientes";
            tarjetaReservas.Valor = "0";
            //
            // tlpInferior
            //
            tlpInferior.BackColor = Color.Transparent;
            tlpInferior.ColumnCount = 2;
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpInferior.Controls.Add(panelActividad, 0, 0);
            tlpInferior.Controls.Add(panelAcciones, 1, 0);
            tlpInferior.Dock = DockStyle.Fill;
            tlpInferior.Location = new Point(0, 228);
            tlpInferior.Margin = new Padding(0);
            tlpInferior.Name = "tlpInferior";
            tlpInferior.RowCount = 1;
            tlpInferior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInferior.Size = new Size(1012, 456);
            tlpInferior.TabIndex = 2;
            //
            // panelActividad
            //
            panelActividad.BackColor = Color.White;
            panelActividad.ColorBorde = Color.FromArgb(222, 226, 232);
            panelActividad.Controls.Add(dgvActividad);
            panelActividad.Controls.Add(panelTituloActividad);
            panelActividad.Dock = DockStyle.Fill;
            panelActividad.Location = new Point(0, 0);
            panelActividad.Margin = new Padding(0, 0, 16, 0);
            panelActividad.Name = "panelActividad";
            panelActividad.Padding = new Padding(20, 16, 20, 20);
            panelActividad.Size = new Size(662, 456);
            panelActividad.TabIndex = 0;
            //
            // dgvActividad
            //
            dgvActividad.AllowUserToAddRows = false;
            dgvActividad.AllowUserToDeleteRows = false;
            dgvActividad.AllowUserToResizeRows = false;
            dgvActividad.AutoGenerateColumns = false;
            dgvActividad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActividad.BackgroundColor = Color.White;
            dgvActividad.BorderStyle = BorderStyle.FixedSingle;
            dgvActividad.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvActividad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.True;
            dgvActividad.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvActividad.ColumnHeadersHeight = 34;
            dgvActividad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvActividad.Columns.AddRange(new DataGridViewColumn[] { colFecha, colTipo, colUsuario, colDetalle });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(30, 120, 255);
            estiloCelda.SelectionForeColor = Color.White;
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvActividad.DefaultCellStyle = estiloCelda;
            dgvActividad.Dock = DockStyle.Fill;
            dgvActividad.EnableHeadersVisualStyles = false;
            dgvActividad.GridColor = Color.FromArgb(120, 120, 120);
            dgvActividad.Location = new Point(20, 60);
            dgvActividad.MultiSelect = false;
            dgvActividad.Name = "dgvActividad";
            dgvActividad.ReadOnly = true;
            dgvActividad.RowHeadersVisible = false;
            dgvActividad.RowTemplate.Height = 30;
            dgvActividad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividad.Size = new Size(622, 376);
            dgvActividad.TabIndex = 2;
            //
            // colFecha
            //
            estiloFecha.Format = "dd/MM/yyyy HH:mm";
            colFecha.DataPropertyName = "fecha";
            colFecha.DefaultCellStyle = estiloFecha;
            colFecha.FillWeight = 24F;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            //
            // colTipo
            //
            colTipo.DataPropertyName = "tipo";
            colTipo.FillWeight = 16F;
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            //
            // colUsuario
            //
            colUsuario.DataPropertyName = "usuario";
            colUsuario.FillWeight = 24F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            //
            // colDetalle
            //
            colDetalle.DataPropertyName = "detalle";
            colDetalle.FillWeight = 36F;
            colDetalle.HeaderText = "Detalle";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            //
            // lnkVerTodas
            //
            lnkVerTodas.Dock = DockStyle.Right;
            lnkVerTodas.Font = new Font("Segoe UI", 10.5F);
            lnkVerTodas.LinkColor = Color.FromArgb(0, 70, 190);
            lnkVerTodas.Location = new Point(532, 0);
            lnkVerTodas.Name = "lnkVerTodas";
            lnkVerTodas.Size = new Size(90, 44);
            lnkVerTodas.TabIndex = 1;
            lnkVerTodas.TabStop = true;
            lnkVerTodas.Text = "Ver todas";
            lnkVerTodas.TextAlign = ContentAlignment.MiddleRight;
            lnkVerTodas.LinkClicked += lnkVerTodas_LinkClicked;
            //
            // lblActividad
            //
            lblActividad.Dock = DockStyle.Fill;
            lblActividad.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblActividad.ForeColor = Color.FromArgb(20, 20, 30);
            lblActividad.Location = new Point(0, 0);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(532, 44);
            lblActividad.TabIndex = 0;
            lblActividad.Text = "Actividad reciente";
            lblActividad.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelTituloActividad
            //
            panelTituloActividad.Controls.Add(lblActividad);
            panelTituloActividad.Controls.Add(lnkVerTodas);
            panelTituloActividad.Dock = DockStyle.Top;
            panelTituloActividad.Location = new Point(20, 16);
            panelTituloActividad.Name = "panelTituloActividad";
            panelTituloActividad.Size = new Size(622, 44);
            panelTituloActividad.TabIndex = 3;
            //
            // panelAcciones
            //
            panelAcciones.BackColor = Color.White;
            panelAcciones.ColorBorde = Color.FromArgb(222, 226, 232);
            panelAcciones.Controls.Add(tlpAcciones);
            panelAcciones.Controls.Add(lblAcciones);
            panelAcciones.Dock = DockStyle.Fill;
            panelAcciones.Location = new Point(678, 0);
            panelAcciones.Margin = new Padding(0);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Padding = new Padding(20, 16, 20, 20);
            panelAcciones.Size = new Size(334, 456);
            panelAcciones.TabIndex = 1;
            //
            // tlpAcciones
            //
            tlpAcciones.BackColor = Color.Transparent;
            tlpAcciones.ColumnCount = 1;
            tlpAcciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAcciones.Controls.Add(tarjetaRegistrarLibro, 0, 0);
            tlpAcciones.Controls.Add(tarjetaNuevoPrestamo, 0, 1);
            tlpAcciones.Controls.Add(tarjetaNuevaReserva, 0, 2);
            tlpAcciones.Dock = DockStyle.Fill;
            tlpAcciones.Location = new Point(20, 60);
            tlpAcciones.Margin = new Padding(0);
            tlpAcciones.Name = "tlpAcciones";
            tlpAcciones.RowCount = 3;
            tlpAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));
            tlpAcciones.Size = new Size(294, 376);
            tlpAcciones.TabIndex = 1;
            //
            // tarjetaRegistrarLibro
            //
            tarjetaRegistrarLibro.BackColor = Color.FromArgb(232, 242, 252);
            tarjetaRegistrarLibro.ColorBorde = Color.FromArgb(180, 210, 240);
            tarjetaRegistrarLibro.ColorCuadro = Color.FromArgb(190, 220, 250);
            tarjetaRegistrarLibro.ColorIcono = Color.FromArgb(21, 85, 170);
            tarjetaRegistrarLibro.Descripcion = "Agregar un nuevo libro al sistema";
            tarjetaRegistrarLibro.Dock = DockStyle.Fill;
            tarjetaRegistrarLibro.Icono = "";
            tarjetaRegistrarLibro.Location = new Point(0, 0);
            tarjetaRegistrarLibro.Margin = new Padding(0, 0, 0, 12);
            tarjetaRegistrarLibro.Name = "tarjetaRegistrarLibro";
            tarjetaRegistrarLibro.Size = new Size(294, 113);
            tarjetaRegistrarLibro.TabIndex = 0;
            tarjetaRegistrarLibro.Titulo = "Registrar libro";
            tarjetaRegistrarLibro.Click += tarjetaRegistrarLibro_Click;
            //
            // tarjetaNuevoPrestamo
            //
            tarjetaNuevoPrestamo.BackColor = Color.FromArgb(230, 243, 232);
            tarjetaNuevoPrestamo.ColorBorde = Color.FromArgb(170, 214, 178);
            tarjetaNuevoPrestamo.ColorCuadro = Color.FromArgb(170, 222, 178);
            tarjetaNuevoPrestamo.ColorIcono = Color.FromArgb(24, 100, 40);
            tarjetaNuevoPrestamo.Descripcion = "Registrar un préstamo de libro";
            tarjetaNuevoPrestamo.Dock = DockStyle.Fill;
            tarjetaNuevoPrestamo.Icono = "";
            tarjetaNuevoPrestamo.Location = new Point(0, 125);
            tarjetaNuevoPrestamo.Margin = new Padding(0, 0, 0, 12);
            tarjetaNuevoPrestamo.Name = "tarjetaNuevoPrestamo";
            tarjetaNuevoPrestamo.Size = new Size(294, 113);
            tarjetaNuevoPrestamo.TabIndex = 1;
            tarjetaNuevoPrestamo.Titulo = "Nuevo préstamo";
            tarjetaNuevoPrestamo.Click += tarjetaNuevoPrestamo_Click;
            //
            // tarjetaNuevaReserva
            //
            tarjetaNuevaReserva.BackColor = Color.FromArgb(253, 238, 222);
            tarjetaNuevaReserva.ColorBorde = Color.FromArgb(240, 205, 165);
            tarjetaNuevaReserva.ColorCuadro = Color.FromArgb(250, 206, 160);
            tarjetaNuevaReserva.ColorIcono = Color.FromArgb(120, 60, 10);
            tarjetaNuevaReserva.Descripcion = "Registrar una reserva de libro";
            tarjetaNuevaReserva.Dock = DockStyle.Fill;
            tarjetaNuevaReserva.Icono = "";
            tarjetaNuevaReserva.Location = new Point(0, 250);
            tarjetaNuevaReserva.Margin = new Padding(0);
            tarjetaNuevaReserva.Name = "tarjetaNuevaReserva";
            tarjetaNuevaReserva.Size = new Size(294, 126);
            tarjetaNuevaReserva.TabIndex = 2;
            tarjetaNuevaReserva.Titulo = "Nueva reserva";
            tarjetaNuevaReserva.Click += tarjetaNuevaReserva_Click;
            //
            // lblAcciones
            //
            lblAcciones.Dock = DockStyle.Top;
            lblAcciones.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAcciones.ForeColor = Color.FromArgb(20, 20, 30);
            lblAcciones.Location = new Point(20, 16);
            lblAcciones.Name = "lblAcciones";
            lblAcciones.Size = new Size(294, 44);
            lblAcciones.TabIndex = 0;
            lblAcciones.Text = "Acciones rápidas";
            lblAcciones.TextAlign = ContentAlignment.MiddleLeft;
            //
            // FrmInicio
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInicio";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmInicio";
            Load += FrmInicio_Load;
            tlpPrincipal.ResumeLayout(false);
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpInferior.ResumeLayout(false);
            panelTituloActividad.ResumeLayout(false);
            panelActividad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActividad).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            tlpAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaLibros;
        private Controles.TarjetaResumen tarjetaUsuarios;
        private Controles.TarjetaResumen tarjetaPrestamos;
        private Controles.TarjetaResumen tarjetaReservas;
        private TableLayoutPanel tlpInferior;
        private Controles.PanelTarjeta panelActividad;
        private Panel panelTituloActividad;
        private Label lblActividad;
        private LinkLabel lnkVerTodas;
        private DataGridView dgvActividad;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colDetalle;
        private Controles.PanelTarjeta panelAcciones;
        private Label lblAcciones;
        private TableLayoutPanel tlpAcciones;
        private Controles.TarjetaAccion tarjetaRegistrarLibro;
        private Controles.TarjetaAccion tarjetaNuevoPrestamo;
        private Controles.TarjetaAccion tarjetaNuevaReserva;
    }
}
