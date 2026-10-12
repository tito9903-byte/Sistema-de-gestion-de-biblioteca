using System.ComponentModel;

namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    // Panel blanco con borde fino, usado como contenedor de tarjetas en las pantallas.
    public class PanelTarjeta : Panel
    {
        Color colorBorde = Color.FromArgb(222, 226, 232);


        public PanelTarjeta()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.White;
        }


        [Category("Apariencia")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color del borde de la tarjeta.")]
        public Color ColorBorde
        {
            get { return colorBorde; }
            set
            {
                colorBorde = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen lapiz = new Pen(colorBorde))
            {
                e.Graphics.DrawRectangle(
                    lapiz,
                    0,
                    0,
                    Width - 1,
                    Height - 1
                );
            }
        }
    }
}
