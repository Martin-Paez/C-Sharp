using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Front
{
    public class MenuConsola : MenuFront
    {
        public MenuConsola(string opciones) : base(opciones)
        { }
      
        public override char ElegirOpcion()
        {
            Console.Write(Opciones + "\nOpcion: ");
            char opt = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");
            return opt;
        }
        public override int Interpretar(char opt, int max)
        {
            int i = opt - '0' - 1;
            if (i >= 0 && i < max)
                return i;
            return max;
        }
    }
}
