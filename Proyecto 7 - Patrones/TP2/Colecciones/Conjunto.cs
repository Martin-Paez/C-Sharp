using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Colecciones
{
    public class Conjunto<T> : Coleccion<T> where T : Comparable<T>
    {
        public override void Agregar(T c)
        {
            if (!this.Contiene(c))
                base.Agregar(c);
        }

    }
}
