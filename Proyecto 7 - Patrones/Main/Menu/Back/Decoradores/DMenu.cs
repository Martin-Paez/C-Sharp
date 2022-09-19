using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Back.Decoradores
{
    public abstract class DMenu<T,M> : Menu<T,M> where M : Delegate
    {
        public Menu<T, M> m { get; set; }
        public override IList<M> F { get { return m.F; } set { m.F = value; } }

        protected DMenu(Menu<T,M> m) : base(m.mf) 
        {
            this.m = m;
        }
    }
}
