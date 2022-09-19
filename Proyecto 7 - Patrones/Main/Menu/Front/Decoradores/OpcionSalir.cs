using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front;

namespace TP.Main.Menu.Front.Decoradores
{
    public class OpcionSalir : DMenuConsola
    {
        public OpcionSalir(MenuFront mc) : base(mc) 
        { }

        public override int Interpretar(char opt, int max)
        {
            if (opt == 's' || opt == 'S')
                return max-1;
            return m.Interpretar(opt, max);
        }
    }
}
