using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Back
{
    public abstract class Menu<T>
    {
        public IMenuFront m { get; set; }
        public Menu(IMenuFront mf)
        {
            this.m = mf;
        }
        public abstract T? Ejecutar();
    }
}
