using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmLibros : Form
    {
        LibroDAO libroDAO = new LibroDAO();

        bool puedeAdministrar;


        // puedeAdministrar = true para Administrador y Bibliotecario.
        // Con false (rol Usuario) solo se puede consultar.
        public FrmLibros(bool puedeAdministrar)
        {
            InitializeComponent();

            this.puedeAdministrar = puedeAdministrar;
        }


        private void FrmLibros_Load(
            object? sender,
            EventArgs e)
        {
            btnNuevo.Visible = puedeAdministrar;
            btnEditar.Visible = puedeAdministrar;
            btnEliminar.Visible = puedeAdministrar;

            CargarResumen();
            CargarLibros();
        }


        private void CargarResumen()
        {
            try
            {
                LibroDAO.ResumenLibros resumen =
                    libroDAO.ObtenerResumen();

                tarjetaTotal.Valor =
                    resumen.Total.ToString("N0");

                tarjetaDisponibles.Valor =
                    resumen.Disponibles.ToString("N0");

                tarjetaPrestados.Valor =
                    resumen.Prestados.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el resumen.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void CargarLibros()
        {
            try
            {
                dgvLibros.DataSource =
                    libroDAO.ListarLibros(txtBuscar.Text.Trim());

                dgvLibros.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los libros.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private DataRowView? ObtenerLibroSeleccionado()
        {
            if (dgvLibros.CurrentRow == null ||
                !dgvLibros.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Seleccione un libro.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            return dgvLibros.CurrentRow.DataBoundItem as DataRowView;
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            CargarLibros();
        }


        private void btnNuevo_Click(
            object? sender,
            EventArgs e)
        {
            FrmRegistroLibro formulario =
                new FrmRegistroLibro();

            if (formulario.ShowDialog() ==
                DialogResult.OK)
            {
                CargarResumen();
                CargarLibros();
            }
        }


        private void btnEditar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? libro =
                ObtenerLibroSeleccionado();

            if (libro == null)
                return;


            FrmRegistroLibro formulario =
                new FrmRegistroLibro(
                    Convert.ToInt32(libro["id_libro"])
                );

            if (formulario.ShowDialog() ==
                DialogResult.OK)
            {
                CargarResumen();
                CargarLibros();
            }
        }


        private void btnEliminar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? libro =
                ObtenerLibroSeleccionado();

            if (libro == null)
                return;


            int idLibro =
                Convert.ToInt32(libro["id_libro"]);

            string titulo =
                libro["titulo"].ToString() ?? "";


            try
            {
                // Con préstamos o reservas no se borra: se desactiva.
                if (libroDAO.TieneHistorial(idLibro))
                {
                    DialogResult desactivar =
                        MessageBox.Show(
                            "El libro \"" + titulo + "\" tiene préstamos o reservas " +
                            "registrados y no puede eliminarse.\n\n" +
                            "¿Desea marcarlo como Inactivo?",
                            "Eliminar libro",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                    if (desactivar == DialogResult.Yes)
                    {
                        libroDAO.CambiarEstado(idLibro, false);

                        CargarResumen();
                        CargarLibros();
                    }

                    return;
                }


                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Seguro que desea eliminar el libro \"" + titulo + "\"?",
                        "Eliminar libro",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (respuesta != DialogResult.Yes)
                    return;


                if (libroDAO.EliminarLibro(idLibro))
                {
                    MessageBox.Show(
                        "Libro eliminado correctamente.",
                        "Libros",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CargarResumen();
                    CargarLibros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el libro.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnVerDetalle_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? libro =
                ObtenerLibroSeleccionado();

            if (libro == null)
                return;


            string isbn =
                libro["isbn"] == DBNull.Value
                    ? "-"
                    : libro["isbn"].ToString() ?? "-";

            string editorial =
                libro["editorial"] == DBNull.Value
                    ? "-"
                    : libro["editorial"].ToString() ?? "-";


            MessageBox.Show(
                "Código: " + libro["codigo"] + "\n" +
                "Título: " + libro["titulo"] + "\n" +
                "Autor: " + libro["autor"] + "\n" +
                "Categoría: " + libro["categoria"] + "\n" +
                "Año: " + libro["anio_publicacion"] + "\n" +
                "ISBN: " + isbn + "\n" +
                "Editorial: " + editorial + "\n" +
                "Ejemplares disponibles: " + libro["ejemplares_disponibles"] +
                " de " + libro["ejemplares_total"] + "\n" +
                "Estado: " + libro["estado"],
                "Detalle del libro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
