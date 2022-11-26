using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Iterador;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Colecciones.Diccionario;
using TP.TP6.Colecciones.Iteradores;

namespace TP.TP6.Colecciones.Iteradores
{
    public class ItrElemDic<K, T> : ListItr<ClaveValor<K, T>>, Iterador<T> where T : Comparable<T> where K : Comparable<K>
    {
        public ItrElemDic(List<ClaveValor<K, T>> elems) : base(elems)
        {
        }
        public new T Elem()
        {
            return base.Elem().Y;
        }
    }
}
