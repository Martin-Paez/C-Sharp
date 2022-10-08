using System;
using System.Collections.Generic;
using System.Numerics;
using TP1_Arbol_Binario.Arboles;

namespace TP1_Arbol_Binario
{
	public class ArbolBinario<T>
	{
		public T Dato { get; set; }
		protected virtual ArbolBinario<T>? HijoIzquierdo { get; set; }
		protected virtual ArbolBinario<T>? HijoDerecho { get; set; }

        public static ArbolBinario<T> Crear(List<T> datos)
		{
			if (datos.Count == 0)
				throw new Exception("No hay elementos");
			int i = 0;
			ArbolBinario<T> tree = new ArbolBinario<T>(datos[i++]);
			ArbolBinario<T> o = tree;
            Queue<ArbolBinario<T>> q = new();
			q.Enqueue(tree);
			while (i < datos.Count)
			{
				tree = q.Dequeue();
				if (i < datos.Count)
				{
					tree.agregarHijoIzquierdo(new ArbolBinario<T>(datos[i++]));
					q.Enqueue(tree.getHijoIzquierdo()!);
				}
				if (i < datos.Count)
				{
					tree.agregarHijoDerecho(new ArbolBinario<T>(datos[i++]));
					q.Enqueue(tree.getHijoDerecho()!);
				}
			}
			return o;
		}
		public ArbolBinario(T dato) {
			this.Dato = dato;
		}
		public T getDatoRaiz() {
			return this.Dato;
		}
		public virtual ArbolBinario<T>? getHijoIzquierdo() {
			return this.HijoIzquierdo;
		}
		public virtual ArbolBinario<T>? getHijoDerecho() {
			return this.HijoDerecho;
		}
		public virtual void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.HijoIzquierdo = hijo;
		}
		public virtual void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.HijoDerecho = hijo;
		}
		public void eliminarHijoIzquierdo() {
			this.HijoIzquierdo = null;
		}
		public void eliminarHijoDerecho() {
			this.HijoDerecho = null;
		}
		public bool esHoja() {
			return this.HijoIzquierdo == null && this.HijoDerecho == null;
		}
        public void inorden()
        {
            // hijo izquierdo recursivamente
            if (this.HijoIzquierdo != null)
				this.HijoIzquierdo.inorden();

            // se procesa raiz
            Console.Write(this.Dato + " ");
			
			// hijo derecho recursivamente
			if(this.HijoDerecho != null)
				this.HijoDerecho.inorden();
		}
		// TODO dato == null
        public bool incluye(T e)
        {
			if (this.Dato == null)
				throw new Exception("Dato es null, averiguar si esto es valido");

            if (this.Dato.Equals(e))
                return true;

			bool ok = false;
            if (this.HijoIzquierdo != null)
                ok = this.HijoIzquierdo.incluye(e);

            if (!ok && this.HijoDerecho != null)
                ok = this.HijoDerecho.incluye(e);

			return ok;
        }
        public void preorden() {
			// se procesa raiz
			Console.Write(this.Dato + " ");

			// hijo izquierdo recursivamente
			if(this.HijoIzquierdo != null)
				this.HijoIzquierdo.preorden();
			
			// hijo derecho recursivamente
			if(this.HijoDerecho != null)
				this.HijoDerecho.preorden();
		}
		public void postorden() {
			// hijo izquierdo recursivamente
			if(this.HijoIzquierdo != null)
				this.HijoIzquierdo.postorden();
			
			// hijo derecho recursivamente
			if(this.HijoDerecho != null)
				this.HijoDerecho.postorden();
			
			// se procesa raiz
			Console.Write(this.Dato + " ");
		}
		public void recorridoPorNiveles() {
            Queue<ArbolBinario<T>> c = new Queue<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            c.Enqueue(this);
            while (c.Count != 0)
            {
                arbolAux = c.Dequeue();

                 Console.Write(arbolAux.Dato + " ");

                if (arbolAux.HijoIzquierdo != null)
					c.Enqueue(arbolAux.HijoIzquierdo);

                if (arbolAux.HijoDerecho != null)
                    c.Enqueue(arbolAux.HijoDerecho);
            }
        }
		public int ContarHojas() {
			int a = 0;
			if (this.HijoIzquierdo != null)
				a = this.HijoIzquierdo.ContarHojas();
			if (this.HijoDerecho != null)
				a += this.HijoDerecho.ContarHojas();
			if (a == 0)
				return 1;
			return a;
		}
		public int altura()
		{
			int i=0, d=0;
			if ( this.HijoIzquierdo != null )
				i = this.HijoIzquierdo.altura() + 1;
			if ( this.HijoDerecho != null )
				d = this.HijoDerecho.altura() + 1;
			if (i < d) 
				return d;
			return i;
		}
		public void recorridoEntreNiveles(int n, int m)
		{
			entreNiveles(n, m, (x) => Console.Write(x.Dato + " "));
		}
        public void entreNiveles(int n,int m, Action<ArbolBinario<T>> f) {
            if (n < 0)
                throw new Exception("n debe ser mayor o igual a 0");
            if (m < n)
                throw new Exception("m debe ser mayor o igual a n");

            Queue<ArbolBinario<T>?> c = new();
            ArbolBinario<T>? e;
            c.Enqueue(this);
            c.Enqueue(null);
            int nivel = 0;
            while (c.Count > 1 && nivel <= m)
            {
                if ((e = c.Dequeue()) == null)
                {
                    nivel++;
                    c.Enqueue(null);
                }
                else
                {
					if (nivel >= n)
						f(e);
                    if (e.HijoIzquierdo != null)
                        c.Enqueue(e.HijoIzquierdo);
                    if (e.HijoDerecho!= null)
                        c.Enqueue(e.HijoDerecho);
                }
            }

            // Si no habian nodos suficientes para completar el nivel m
            if (nivel < m)
				throw new Exception("el arbol no tiene tantos niveles");
        }
        public override string ToString()
        {
            string o = "Nivel 0 : \n  ";
            int n = 0;
            Queue<ArbolBinario<T>?> q = new();
            ArbolBinario<T>? t;
            q.Enqueue(this);
            q.Enqueue(null);
            do
            {
                if ((t = q.Dequeue()) == null)
                {
                    if (q.Peek() == null)
                    {
                        o += " | ";
                        q.Dequeue();
                    }
                    else
                    {
                        o += "\n\nNivel " + (++n).ToString() + " :\n  ";
                        q.Enqueue(null);
                    }
                }
                else
                {
                    o += " " + t.Dato.ToString();
					int h = 0;
					if (t.HijoIzquierdo != null) {
						q.Enqueue(t.HijoIzquierdo);
						h++;
					}
					if (t.HijoDerecho != null) {
						q.Enqueue(t.HijoDerecho);
						h++;
					}
					if (h > 0)
					{
						q.Enqueue(null);
						q.Enqueue(null);
					}
					else
						o += "*";
                }
            }
            while (q.Count > 1);
            return o + "\n";
        }
    }
}
