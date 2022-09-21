using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Heap
{
    public class Heap<T> where T : IComparable<T>
    {
        private T[] datos;
        private int size = 0;
        private int esMaxHeap = -1;

        public Heap(T[] datos, int size, bool esMaxHeap)
        {
            this.datos = datos;
            if (esMaxHeap)
                this.esMaxHeap = 1;
            this.size = size;
            for (int j = (size + 1) / 2; j > 0; j--)
                FiltrarAbajo(j);
        }
        public bool EsVacia()
        {
            if (datos.Length == 0)
                return true;

            return false;
        }
        public bool Agregar(T elem)
        {
            if (datos.Length == size)
                return false;
            datos[size++] = elem;
            FiltrarArriba(size);
            return true;
        }
        public void FiltrarArriba(int i)
        {
            if (size < 2)
                return;
            int padre = 0;
            do
            {
                padre = i / 2 - 1;
                int hijo = i - 1;
                int her = i % 2 == 0 ? hijo + 1 : hijo - 1;
                if (her < size && datos[her].CompareTo(datos[hijo]) * esMaxHeap > 0)
                    --hijo;
                if (datos[hijo].CompareTo(datos[padre]) * esMaxHeap > 0)
                {
                    T swap = datos[hijo];
                    datos[hijo] = datos[padre];
                    datos[padre] = swap;
                }
                i = padre + 1;
            }
            while (padre > 0);
        }
        public T Eliminar()
        {
            T e = datos[0];
            datos[0] = datos[size - 1];
            size--;
            FiltrarAbajo(1);
            return e;
        }
        public void FiltrarAbajo(int i)
        {
            if (size < 2)
                return;
            int padre = 0;
            do
            {
                padre = i - 1;
                int hijo = padre * 2;
                int der = hijo + 1;
                if (hijo >= size)
                    break;
                if (der < size && datos[der].CompareTo(datos[hijo]) * esMaxHeap > 0)
                    ++hijo;
                if (datos[hijo].CompareTo(datos[padre]) * esMaxHeap > 0)
                {
                    T swap = datos[hijo];
                    datos[hijo] = datos[padre];
                    datos[padre] = swap;
                }
                i = hijo + 1;
            }
            while (true);
        }
        public T? Tope()
        {
            if (size == 0)
                return default;
            return datos[0];
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
                s += datos[i].ToString() + ", ";
            return s;
        }
    }
}
