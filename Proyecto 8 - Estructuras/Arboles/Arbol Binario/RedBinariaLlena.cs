using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario
{
    public class RedBinariaLlena<T> : ArbolBinario<T>
    {
        public RedBinariaLlena(T dato) : base(dato) { }

        // Retorna la altura del arbol ó -1 si no es lleno
        public int RetardoReenvio()
        {
            int hi, hd;
            bool izq = this.getHijoIzquierdo() != null;
            bool der = this.getHijoDerecho() != null;
            // hijo unico , o sea, no es lleno
            if (izq != der)
                return -1;
            // es hoja
            if ( ! izq )
                return 0;       
            hd = (this.getHijoDerecho()!).RetardoReenvio();
            // hijo izq no lleno
            if (hd == -1)
                return -1;
            hi = (this.getHijoIzquierdo()!).RetardoReenvio();
            // hijos de diff altura o hijo der no lleno
            if (hi != hd)
                return -1;
            return hi + 1;
        }

        public override void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            throw new NotImplementedException();
        }

        public override void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
            throw new NotImplementedException();
        }

        public void agregarHijoDerecho(RedBinariaLlena<T> hijo)
        {
            base.agregarHijoDerecho(hijo);
        }

        public void agregarHijoIzquierdo(RedBinariaLlena<T> hijo)
        {
            base.agregarHijoIzquierdo(hijo);
        }

        public override RedBinariaLlena<T>? getHijoDerecho()
        {
            return (RedBinariaLlena<T>?)base.getHijoDerecho();
        }

        public override RedBinariaLlena<T>? getHijoIzquierdo()
        {
            return (RedBinariaLlena<T>?)base.getHijoIzquierdo();
        }

    }
}
