using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Back
{
    public class MenuFunc<T> : Menu<T,Func<T?>>
    {
        public override IList<Func<T?>> F { get; set; }

        public MenuFunc(IList<Func<T?>> f, IMenuFront mf) : base(mf)
        {
            F = f;
        }
        public override T? Ejecutar()
        {
            return F[mf.GetOpcionValida(F.Count)]();
        }
    }
}
