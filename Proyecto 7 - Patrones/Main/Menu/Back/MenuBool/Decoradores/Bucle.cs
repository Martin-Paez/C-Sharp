using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back.NSMenuBool;
using TP.Main.NSMenu.Back;

namespace TP.Main.Menu.Back.Decoradores
{
    public class Bucle : MenuBool
    {
        public Menu<bool> mb { get; set; }

        public Bucle(Menu<bool> m) : base(m.m)
        {
            mb = m;
        }
        public override bool Ejecutar()
        {
            while (mb.Ejecutar());
            return true;
        }
    }
}
