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
    public abstract class Menu<T,M> where M : Delegate
    {
        public IMenuFront mf { get; set; }
        public abstract IList<M> F { get; set; }

        public Menu(IMenuFront mf)
        {
            this.mf = mf;
        }
        public abstract T? Ejecutar();
    }
}
