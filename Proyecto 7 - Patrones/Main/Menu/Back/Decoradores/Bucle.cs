using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Back;

namespace TP.Main.Menu.Back.Decoradores
{
    public class Bucle<T, M> : DMenu<T, M> where M : Delegate
    {
        public T Fin { get; set; }

        public Bucle(Menu<T, M> m, T fin, M finDelBucle) : base(m)
        {
            Fin = fin;
            try
            {
                F.Add(finDelBucle);
            } catch (Exception)
            {
                F = new List<M>(F);
                F.Add(finDelBucle);
            }
        }
        public override T? Ejecutar()
        {
            T? o;
            while (Fin!.Equals(o = m.Ejecutar()) == false);
            return o;
        }
    }
}
