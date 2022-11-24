using tpf;
using WiW.src;
using WiW.src.Game;
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
                new Wiw();
            } catch(Exception e)
            {
                MessageBox.Show("No se pudo iniciar el juego. \n \n DETALLES : \n \n " + e);
            }
        }
    }
}