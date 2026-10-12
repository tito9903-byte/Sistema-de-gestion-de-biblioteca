using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    // Tarjeta de acción rápida: cuadro con icono, título, descripción y flecha. Es clicable.
    public partial class TarjetaAccion : UserControl
    {
        int alturaDiseno;
        int[] topsOriginales = Array.Empty<int>();

        Color colorCuadro = Color.FromArgb(190, 220, 250);
        Color colorBorde = Color.FromArgb(180, 210, 240);


        public TarjetaAccion()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );

            // Posiciones de diseño, para centrar verticalmente el contenido al redimensionar.
            alturaDiseno = Height;
            topsOriginales = Controls.Cast<Control>().Select(c => c.Top).ToArray();

            // Los clics sobre los textos también cuentan como clic en la tarjeta.
            Cursor = Cursors.Hand;

            foreach (Control control in Controls)
            {
                control.Cursor = Cursors.Hand;
                control.Click += (s, e) => OnClick(e);
            }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Título de la acción.")]
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Texto descriptivo de la acción.")]
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
        [Description("Color del icono.")]
        public Color ColorIcono
        {
            get { return lblIcono.ForeColor; }
            set { lblIcono.ForeColor = value; }
        }


        [Category("Tarjeta")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color del cuadro redondeado detrás del icono.")]
        public Color ColorCuadro
        {
            get { return colorCuadro; }
            set
            {
                colorCuadro = value;
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


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (topsOriginales.Length == 0)
                return;

            int desplazamiento = (Height - alturaDiseno) / 2;

            for (int i = 0; i < topsOriginales.Length; i++)
            {
                Controls[i].Top = topsOriginales[i] + desplazamiento;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle cuadro = lblIcono.Bounds;

            using (GraphicsPath ruta = RectanguloRedondeado(cuadro, 10))
            using (SolidBrush pincel = new SolidBrush(colorCuadro))
            {
                e.Graphics.FillPath(pincel, ruta);
            }

            // Flecha ">" a la derecha, centrada verticalmente.
            int centroY = Height / 2;

            using (Pen flecha = new Pen(Color.FromArgb(40, 40, 40), 2.5F))
            {
                flecha.StartCap = LineCap.Round;
                flecha.EndCap = LineCap.Round;
                flecha.LineJoin = LineJoin.Round;

                e.Graphics.DrawLines(
                    flecha,
                    new Point[]
                    {
                        new Point(Width - 30, centroY - 8),
                        new Point(Width - 21, centroY),
                        new Point(Width - 30, centroY + 8)
                    }
                );
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


        private static GraphicsPath RectanguloRedondeado(
            Rectangle area,
            int radio)
        {
            int d = radio * 2;

            GraphicsPath ruta = new GraphicsPath();

            ruta.AddArc(area.X, area.Y, d, d, 180, 90);
            ruta.AddArc(area.Right - d, area.Y, d, d, 270, 90);
            ruta.AddArc(area.Right - d, area.Bottom - d, d, d, 0, 90);
            ruta.AddArc(area.X, area.Bottom - d, d, d, 90, 90);
            ruta.CloseFigure();

            return ruta;
        }
    }
}
