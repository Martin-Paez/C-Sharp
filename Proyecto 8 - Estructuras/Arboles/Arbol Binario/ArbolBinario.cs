using System;
using System.Collections.Generic;
using System.Numerics;

namespace TP1_Arbol_Binario
{
	public class ArbolBinario<T>
	{
		private T dato;
		protected ArbolBinario<T>? hijoIzquierdo;
		protected ArbolBinario<T>? hijoDerecho;

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
			this.dato = dato;
		}
		public T getDatoRaiz() {
			return this.dato;
		}
		public virtual ArbolBinario<T>? getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
		public virtual ArbolBinario<T>? getHijoDerecho() {
			return this.hijoDerecho;
		}
		public virtual void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo = hijo;
		}
		public virtual void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho = hijo;
		}
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo = null;
		}
		public void eliminarHijoDerecho() {
			this.hijoDerecho = null;
		}
		public bool esHoja() {
			return this.hijoIzquierdo == null && this.hijoDerecho == null;
		}
        public void inorden()
        {
            // hijo izquierdo recursivamente
            if (this.hijoIzquierdo != null)
				this.hijoIzquierdo.inorden();

            // se procesa raiz
            Console.Write(this.dato + " ");
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.inorden();
		}
		// TODO dato == null
        public bool incluye(T e)
        {
			if (this.dato == null)
				throw new Exception("Dato es null, averiguar si esto es valido");

            if (this.dato.Equals(e))
                return true;

			bool ok = false;
            if (this.hijoIzquierdo != null)
                ok = this.hijoIzquierdo.incluye(e);

            if (!ok && this.hijoDerecho != null)
                ok = this.hijoDerecho.incluye(e);

			return ok;
        }
        public void preorden() {
			// se procesa raiz
			Console.Write(this.dato + " ");

			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.preorden();
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.preorden();
		}
		public void postorden() {
			// hijo izquierdo recursivamente
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.postorden();
			
			// hijo derecho recursivamente
			if(this.hijoDerecho != null)
				this.hijoDerecho.postorden();
			
			// se procesa raiz
			Console.Write(this.dato + " ");
		}
		public void recorridoPorNiveles() {
            Queue<ArbolBinario<T>> c = new Queue<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            c.Enqueue(this);
            while (c.Count != 0)
            {
                arbolAux = c.Dequeue();

                 Console.Write(arbolAux.dato + " ");

                if (arbolAux.hijoIzquierdo != null)
					c.Enqueue(arbolAux.hijoIzquierdo);

                if (arbolAux.hijoDerecho != null)
                    c.Enqueue(arbolAux.hijoDerecho);
            }
        }
		public int ContarHojas() {
			int a = 0;
			if (this.hijoIzquierdo != null)
				a = this.hijoIzquierdo.ContarHojas();
			if (this.hijoDerecho != null)
				a += this.hijoDerecho.ContarHojas();
			if (a == 0)
				return 1;
			return a;
		}
		public int altura()
		{
			int i=0, d=0;
			if ( this.hijoIzquierdo != null )
				i = this.hijoIzquierdo.altura() + 1;
			if ( this.hijoDerecho != null )
				d = this.hijoDerecho.altura() + 1;
			if (i < d) 
				return d;
			return i;
		}
		public void recorridoEntreNiveles(int n, int m)
		{
			entreNiveles(n, m, (x) => Console.Write(x.dato + " "));
		}
        public void entreNiveles(int n,int m, Action<ArbolBinario<T>> f) {
				if (n < 0)
					throw new Exception("n debe ser mayor o igual a 0");
				if (m < n)
					throw new Exception("m debe ser mayor o igual a n");

				Queue<ArbolBinario<T>> c = new Queue<ArbolBinario<T>>();
				ArbolBinario<T> arbolAux;
				int nivelParaEncolar = 0;
				int nodosCheckeadosDelNivel = 1;
			
				c.Enqueue(this);
				while (c.Count != 0)
				{
					// Si todos los nodos del nivel ya fueron chequeados
					if (nodosCheckeadosDelNivel >= Math.Pow(2, nivelParaEncolar))
					{
						nivelParaEncolar++;
						nodosCheckeadosDelNivel = 0;
					}

					/* Siempre se cumple que : se Desencola el primer nodo de un nivel
					 * despues de haber terminado de chequear el ultimo de dicho nivel.
					 */
					arbolAux = c.Dequeue();
					// Si ya encole completo el primer nivel a mostrar
					if (nivelParaEncolar > n)
						f(arbolAux);

					// Me quedan niveles por encolar
					if (nivelParaEncolar <= m)
					{
						if (arbolAux.hijoIzquierdo != null)
							c.Enqueue(arbolAux.hijoIzquierdo);

						if (arbolAux.hijoDerecho != null)
							c.Enqueue(arbolAux.hijoDerecho);

						nodosCheckeadosDelNivel += 2;
					}
				}

				// Si no habian nodos suficientes para completar el nivel m
				if (nivelParaEncolar != ++m)
				throw new Exception("el arbol no tiene tantos niveles");
        }
	}
}
