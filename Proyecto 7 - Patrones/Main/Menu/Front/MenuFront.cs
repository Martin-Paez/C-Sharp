using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Front
{
    public abstract class MenuFront : IMenuFront
    {
        public string Opciones { get; set; }

        public MenuFront(string opciones)
        {
            Opciones = opciones;
        }

        public virtual int GetOpcionValida(int max)
        {
            int o;
            while ((o = Interpretar(ElegirOpcion(), max)) == max) ;
            return o;
        }

        public abstract int Interpretar(char opt, int max);
        public abstract char ElegirOpcion();
    }
}
