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
            dgvUsuarios.Location = new Point(10, 10);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(602, 260);
            dgvUsuarios.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnActivarDesactivar);
            pnlRight.Controls.Add(btnEliminar);
            pnlRight.Controls.Add(btnEditar);
            pnlRight.Controls.Add(btnNuevo);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(622, 45);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(8);
            pnlRight.Size = new Size(139, 280);
            pnlRight.TabIndex = 1;
            // 
            // btnActivarDesactivar
            // 
            btnActivarDesactivar.BackColor = Color.LightSteelBlue;
            btnActivarDesactivar.Cursor = Cursors.Hand;
            btnActivarDesactivar.FlatStyle = FlatStyle.Flat;
            btnActivarDesactivar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnActivarDesactivar.Location = new Point(9, 124);
            btnActivarDesactivar.Name = "btnActivarDesactivar";
            btnActivarDesactivar.Size = new Size(121, 48);
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
            btnEliminar.Location = new Point(9, 86);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(121, 38);
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
            btnEditar.Location = new Point(9, 48);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(121, 38);
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
            btnNuevo.Location = new Point(9, 10);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(121, 38);
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
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(12, 10, 12, 8);
            pnlTop.Size = new Size(761, 45);
            pnlTop.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Location = new Point(12, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, nombre o rol...";
            txtBuscar.Size = new Size(737, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(dgvUsuarios);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 45);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10);
            pnlBody.Size = new Size(622, 280);
            pnlBody.TabIndex = 3;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(761, 325);
            Controls.Add(pnlBody);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
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