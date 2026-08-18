namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            dgvUsuarios = new DataGridView();
            pnlRight = new Panel();
            btnActivarDesactivar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            pnlTop = new Panel();
            txtBuscar = new TextBox();
            pnlBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlRight.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ColumnHeadersHeight = 35;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(11, 13);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(689, 347);
            dgvUsuarios.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnActivarDesactivar);
            pnlRight.Controls.Add(btnEliminar);
            pnlRight.Controls.Add(btnEditar);
            pnlRight.Controls.Add(btnNuevo);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(711, 60);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(9, 11, 9, 11);
            pnlRight.Size = new Size(159, 373);
            pnlRight.TabIndex = 1;
            // 
            // btnActivarDesactivar
            // 
            btnActivarDesactivar.BackColor = Color.LightSteelBlue;
            btnActivarDesactivar.Cursor = Cursors.Hand;
            btnActivarDesactivar.FlatStyle = FlatStyle.Flat;
            btnActivarDesactivar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnActivarDesactivar.Location = new Point(10, 165);
            btnActivarDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnActivarDesactivar.Name = "btnActivarDesactivar";
            btnActivarDesactivar.Size = new Size(138, 64);
            btnActivarDesactivar.TabIndex = 3;
            btnActivarDesactivar.Text = "🔄 Activar /\r\nDesactivar";
            btnActivarDesactivar.UseVisualStyleBackColor = false;
            btnActivarDesactivar.Click += btnActivarDesactivar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Salmon;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEliminar.Location = new Point(10, 115);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(138, 51);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.DodgerBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEditar.Location = new Point(10, 64);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(138, 51);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏️ Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = SystemColors.Highlight;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevo.Location = new Point(10, 13);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(138, 51);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "➕ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(txtBuscar);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(14, 13, 14, 11);
            pnlTop.Size = new Size(870, 60);
            pnlTop.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Location = new Point(14, 13);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, nombre o rol...";
            txtBuscar.Size = new Size(842, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(dgvUsuarios);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 60);
            pnlBody.Margin = new Padding(3, 4, 3, 4);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(11, 13, 11, 13);
            pnlBody.Size = new Size(711, 373);
            pnlBody.TabIndex = 3;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(870, 433);
            Controls.Add(pnlBody);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmUsuarios";
            Text = "Administración de Usuarios";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlRight.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion


        private DataGridView dgvUsuarios;

        private Panel pnlRight;

        private Button btnNuevo;
        private Button btnActivarDesactivar;
        private Button btnEliminar;
        private Button btnEditar;

        private Panel pnlTop;
        private TextBox txtBuscar;

        private Panel pnlBody;
    }
}