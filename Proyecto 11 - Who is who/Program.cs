using tpf;

namespace WiW
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Backend game = new();
            try {
                Application.Run(new FormUser(game));
            } catch (Exception) {
                Application.Run(new Inicio(game));
            }
        }
        public static void Run(Backend game)
        {// Carpeta bloqueada, no precisa try catch
            new FormUser(game);
        }
    }
}