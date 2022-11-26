using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces.Iterador;
using TP.TP7.Interfaces.Comparar;
using TP.TP7.Colecciones.Diccionario;
using TP.TP7.Colecciones.Iteradores;

namespace TP.TP7.Colecciones.Iteradores
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
