using tpf;
using WiW.src;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WiW
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                new src.WiW();
            } catch(Exception e)
            {
                MessageBox.Show("No se pudo iniciar el juego. \n \nDetalles : " + e);
            }
        }
    }
}