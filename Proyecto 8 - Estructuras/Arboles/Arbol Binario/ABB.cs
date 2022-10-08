using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Arboles.Arbol_Binario
{
    public class ABB<T> : ArbolBinario<T> where T : IComparable<T>
    {
        protected override ArbolBinario<T>? HijoIzquierdo
        {
            get { return Hijos[0]; }
            set { Hijos[0] = (value == null) ? null : new ABB<T>(value.Dato); }
        }
        protected override ArbolBinario<T>? HijoDerecho
        {
            get { return Hijos[1]; }
            set { Hijos[1] = (value == null) ? null : new ABB<T>(value.Dato); }
        }
        protected ABB<T>?[] Hijos = {null, null};

        public ABB(T dato) : base(dato)
        {
        }
        public override void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
            throw new NotImplementedException();
        }
        public override void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            throw new NotImplementedException();
        }
        public virtual void Agregar(T e)
        {
            int i = (Dato.CompareTo(e) > 0) ? 0 : 1;
            if (Hijos[i] == null)
                Hijos[i] = new(e);
            else
                Hijos[i]!.Agregar(e);
        }
    }
}
