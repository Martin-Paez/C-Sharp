using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Front.Interfaces;
using TP.Main.NSMenu.Decoradores;
using TP.Main.NSMenu.Front;

namespace TP.Main.Menu.Front.Decoradores
{
    public class ConsolaLimpia : DMenuConsola
    {
        public ConsolaLimpia(IMenuConsola m) : base(m) { }
        public override char ElegirOpcion()
        {
            Console.Clear();
            char opt = mc.ElegirOpcion();
            Console.Clear();
            return opt;
        }
    }
}
