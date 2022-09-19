using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Front.Interfaces;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Front.Decoradores
{
    public class DMenuConsola : IMenuConsola
    {
        protected IMenuConsola mc;
        public string Opciones { get { return mc.Opciones;  } set { mc.Opciones = value; } }


        public DMenuConsola(IMenuConsola mc)
        {
            this.mc = mc;
        }

        public virtual char ElegirOpcion()
        {
            return mc.ElegirOpcion();
        }

        public virtual int Interpretar(char opt, int max)
        {
            return mc.Interpretar(opt, max);
        }

        public virtual int Run(int max)
        {
            return mc.Run(max);
        }
    }
}
