using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Back
{
    public class MenuFunc<T> : Menu<T>
    {
        protected IList<Func<T>> F { get; set; }

        public MenuFunc(IList<Func<T>> f, IMenuFront mf) : base(mf)
        {
            F = f;
        }
        public override T? Ejecutar()
        {
            int i = m.Run(F.Count);
            if (i > -1)
                return F![i]();
            return default;
        }
    }
}
