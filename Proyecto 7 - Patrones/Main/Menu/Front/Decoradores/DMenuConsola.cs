using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Front.Decoradores
{
    public class DMenuConsola : MenuFront
    {
        protected MenuFront m;

        public DMenuConsola(MenuFront mf) : base (mf.Opciones)
        {
            m = mf;
        }

        public override char ElegirOpcion()
        {
            return m.ElegirOpcion();
        }

        public override int Interpretar(char opt, int max)
        {
            return m.Interpretar(opt, max);
        }
    }
}
