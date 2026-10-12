using System.Runtime.InteropServices;

namespace SistemaDeGestionDeBiblioteca
{
    // Ventana sobre la que se centran los avisos y los cuadros de diálogo:
    // la ventana activa de la aplicación (no el centro de la pantalla).
    public static class Centrado
    {
        public static Form? Ventana()
        {
            Form? activa = Form.ActiveForm;

            if (activa != null && activa.Visible)
                return activa;

            return Application.OpenForms
                .Cast<Form>()
                .LastOrDefault(f => f.Visible && f.TopLevel);
        }
    }


    // Reemplaza a System.Windows.Forms.MessageBox dentro de la aplicación
    // (al estar en un espacio de nombres más cercano, tiene prioridad).
    // Windows centra un MessageBox en el monitor, no sobre su ventana
    // propietaria; por eso se engancha la apertura del aviso (hook CBT) y se
    // mueve al centro de la ventana de la aplicación.
    public static class MessageBox
    {
        private delegate IntPtr HookProc(int codigo, IntPtr wParam, IntPtr lParam);

        private const int WH_CBT = 5;
        private const int HCBT_ACTIVATE = 5;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(
            int tipo, HookProc proc, IntPtr modulo, uint hilo);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(
            IntPtr hook, int codigo, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr ventana, out RECT rect);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(
            IntPtr ventana, int x, int y, int ancho, int alto, bool repintar);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();


        private static DialogResult Mostrar(
            Func<IWin32Window?, DialogResult> mostrar)
        {
            Form? propietario = Centrado.Ventana();

            IntPtr hook = IntPtr.Zero;

            HookProc proc = (codigo, wParam, lParam) =>
            {
                if (codigo == HCBT_ACTIVATE && propietario != null)
                {
                    CentrarSobre(wParam, propietario);

                    UnhookWindowsHookEx(hook);
                    hook = IntPtr.Zero;
                }

                return CallNextHookEx(hook, codigo, wParam, lParam);
            };

            hook = SetWindowsHookEx(WH_CBT, proc, IntPtr.Zero, GetCurrentThreadId());

            try
            {
                return mostrar(propietario);
            }
            finally
            {
                if (hook != IntPtr.Zero)
                    UnhookWindowsHookEx(hook);

                GC.KeepAlive(proc);
            }
        }


        private static void CentrarSobre(IntPtr aviso, Form propietario)
        {
            if (!GetWindowRect(aviso, out RECT r))
                return;

            int ancho = r.Right - r.Left;
            int alto = r.Bottom - r.Top;

            Rectangle area = propietario.Bounds;

            int x = area.Left + (area.Width - ancho) / 2;
            int y = area.Top + (area.Height - alto) / 2;

            MoveWindow(aviso, x, y, ancho, alto, true);
        }


        public static DialogResult Show(string texto)
        {
            return Mostrar(p =>
                System.Windows.Forms.MessageBox.Show(p, texto));
        }


        public static DialogResult Show(string texto, string titulo)
        {
            return Mostrar(p =>
                System.Windows.Forms.MessageBox.Show(p, texto, titulo));
        }


        public static DialogResult Show(
            string texto,
            string titulo,
            MessageBoxButtons botones)
        {
            return Mostrar(p =>
                System.Windows.Forms.MessageBox.Show(
                    p, texto, titulo, botones));
        }


        public static DialogResult Show(
            string texto,
            string titulo,
            MessageBoxButtons botones,
            MessageBoxIcon icono)
        {
            return Mostrar(p =>
                System.Windows.Forms.MessageBox.Show(
                    p, texto, titulo, botones, icono));
        }


        public static DialogResult Show(
            string texto,
            string titulo,
            MessageBoxButtons botones,
            MessageBoxIcon icono,
            MessageBoxDefaultButton botonPorDefecto)
        {
            return Mostrar(p =>
                System.Windows.Forms.MessageBox.Show(
                    p, texto, titulo, botones, icono, botonPorDefecto));
        }
    }
}
