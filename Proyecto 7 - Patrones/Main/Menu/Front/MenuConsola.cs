using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Front.Interfaces;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Front
{
    public class MenuConsola : IMenuConsola
    {
        public string Opciones { get; set; }

        public MenuConsola(string opciones)
        {
            Opciones = opciones;
        }

        public virtual char ElegirOpcion()
        {
            Console.Write(Opciones + "\nOpcion: ");
            char opt = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");
            return opt;
        }
        public virtual int Interpretar(char opt, int max)
        {
            int i = opt - '0' - 1;
            if (i >= 0 && i < max)
                return i;
            return max;
        }
        public int Run(int max)
        {
            int o;
            while ((o = Interpretar(ElegirOpcion(), max)) == max);
            return o;
        }
    }
}
