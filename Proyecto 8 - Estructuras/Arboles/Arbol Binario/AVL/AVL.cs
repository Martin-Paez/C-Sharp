using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Arboles.Arbol_Binario
{
    public class AVL<T> : ArbolBinario<T> where T : IComparable<T>
    {
        public virtual AVL<T>?[] Hijos { get; set; } = { null, null }; 
        public const int IZQ = 0;
        public const int DER = 1;
        protected override ArbolBinario<T>? HijoIzquierdo
        {
            get { return Hijos[0]; }
            set { Hijos[0] = (value == null) ? null : new AVL<T>(value.Dato); }
        }
        protected override ArbolBinario<T>? HijoDerecho
        {
            get { return Hijos[1]; }
            set { Hijos[1] = (value == null) ? null : new AVL<T>(value.Dato); }
        }
        public int AlturaH { get; set; } = 0;

        public AVL(T dato) : base(dato)
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

        public AVL<T> Agregar(T e) 
        {
            int i = (e.CompareTo(Dato) > 0) ? DER : IZQ;
            if (Hijos[i] == null)
            {
                Hijos[i] = new(e);
                AlturaH = 1;// No podria ser abuelo, hubiese estado desvalanceado 
                return this;   
            }
            Hijos[i] = Hijos[i]!.Agregar(e);
            int a = Hijos[i]!.AlturaH;
            int ii = (i == IZQ) ? DER : IZQ;
            int b = (Hijos[ii]==null)?-1:Hijos[ii]!.AlturaH;
            if (Math.Abs(a - b) > 1)
            {
                if (i == IZQ)
                    if (e.CompareTo(Hijos[IZQ]!.Dato) > 0)
                        return rotacionDoble(IZQ);
                    else
                        return rotacionSimple(IZQ);
                else
                    if (e.CompareTo(Hijos[DER]!.Dato) < 0)
                    return rotacionDoble(DER);
                else
                    return rotacionSimple(DER);
            }
            else
                AlturaH++;
            return this;
        }
        public AVL<T> rotacionSimple(int lado)
        {
            int h = (lado + 1) % 2;
            AVL<T> hd = Hijos[lado]!;
            AVL<T> ni = Hijos[lado]!.Hijos[h]!;
            Hijos[lado]!.Hijos[h] = this;
            Hijos[lado] = ni;
            int ai = (Hijos[lado] == null) ? -1 : Hijos[lado]!.AlturaH;
            int ad = (Hijos[h] == null) ? -1 : Hijos[h]!.AlturaH;
            AlturaH = (ai > ad) ? ++ai : ++ad;
            ad = (hd.Hijos[lado] == null) ? -1 : hd.Hijos[lado]!.AlturaH;
            hd.AlturaH = (AlturaH > ai) ? AlturaH + 1 : ++ad;
            return hd;
        }
        public AVL<T> rotacionDoble(int hijo)
        {
            Hijos[hijo] = Hijos[hijo]!.rotacionSimple((hijo+1)%2);
            return rotacionSimple(hijo);
        }
        public AVL<T> min()
        {
            if (this.getHijoIzquierdo() == null)
                return this;
            else
                return ((AVL<T>)this.getHijoIzquierdo()!).min();
        }
    }
}
