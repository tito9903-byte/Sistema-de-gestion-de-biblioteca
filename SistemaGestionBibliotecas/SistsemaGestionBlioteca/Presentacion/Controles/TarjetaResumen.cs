using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    // Tarjeta de resumen: círculo con icono, título, número grande y descripción.
    public partial class TarjetaResumen : UserControl
    {
        Color colorCirculo = Color.FromArgb(209, 230, 252);
        Color colorBorde = Color.FromArgb(222, 226, 232);


        public TarjetaResumen()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Texto pequeño sobre el número.")]
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Número o valor grande de la tarjeta.")]
        public string Valor
        {
            get { return lblValor.Text; }
            set { lblValor.Text = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Texto descriptivo debajo del valor.")]
        public string Descripcion
        {
            get { return lblDescripcion.Text; }
            set { lblDescripcion.Text = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Carácter de la fuente Segoe MDL2 Assets usado como icono.")]
        public string Icono
        {
            get { return lblIcono.Text; }
            set { lblIcono.Text = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color del valor y del icono.")]
        public Color ColorValor
        {
            get { return lblValor.ForeColor; }
            set
            {
                lblValor.ForeColor = value;
                lblIcono.ForeColor = value;
            }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color de relleno del círculo del icono.")]
        public Color ColorCirculo
        {
            get { return colorCirculo; }
            set
            {
                colorCirculo = value;
                Invalidate();
            }
        }


        [Category("Tarjeta")]
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

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush pincel = new SolidBrush(colorCirculo))
            {
                e.Graphics.FillEllipse(pincel, lblIcono.Bounds);
            }

            e.Graphics.SmoothingMode = SmoothingMode.None;

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
