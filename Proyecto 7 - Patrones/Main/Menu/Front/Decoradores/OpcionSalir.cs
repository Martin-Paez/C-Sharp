using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Front.Interfaces;
using TP.Main.NSMenu.Front;

namespace TP.Main.Menu.Front.Decoradores
{
    public class OpcionSalir : DMenuConsola
    {
        public OpcionSalir(IMenuConsola mc) : base(mc)
        {
            mc.Opciones += " s) Salir        \n";
        }
        public override int Interpretar(char opt, int max)
        {
            if (opt == 's' || opt == 'S')
                return -1;
            return mc.Interpretar(opt, max);
        }
    }
}
