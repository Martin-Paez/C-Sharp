using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Decoradores;

namespace TP.Main.NSMenu.Front
{
    public class MenuCmdLimpia : MenuConsola
    {
        public MenuCmdLimpia(string Opciones) : base(Opciones) { }
        public override char Mostrar()
        {
            Console.Clear();
            char opt = base.Mostrar();
            Console.Clear();
            return opt;
        }
    }
}
