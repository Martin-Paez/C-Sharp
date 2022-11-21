using tpf;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WiW
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Backend game = null!;
            try
            {
                game = new Backend();
            } catch(Exception)
            {
                MessageBox.Show("No se pudo iniciar el juego");
            }
            if (game != null)
                Application.Run(FacesForm.NewGame(game));
        }
        public static void NewGame()
        {
            FacesForm.Call().Restart();
        }
    }
}