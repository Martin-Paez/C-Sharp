using System;
using System.Collections.Generic;

namespace TP1_Arbol_Binario.Arboles
{
    public class ArbolGeneral<T> where T : IComparable<T>
    {

        private T Dato;
        public List<ArbolGeneral<T>> Hijos { get; } = new List<ArbolGeneral<T>>();

        public ArbolGeneral(T dato)
        {
            Dato = dato;
        }
        public T GetDatoRaiz()
        {
            return Dato;
        }
        public void AgregarHijo(ArbolGeneral<T> hijo)
        {
            Hijos.Add(hijo);
        }
        public void EliminarHijo(ArbolGeneral<T> hijo)
        {
            Hijos.Remove(hijo);
        }
        public bool EsHoja()
        {
            return Hijos.Count == 0;
        }
        public int Altura()
        {
            if (EsHoja())
                return 0;
            int aux, max = 0;
            foreach (ArbolGeneral<T> hijo in Hijos)
            {
                aux = hijo.Altura() + 1;
                if (aux > max)
                    max = aux;
            }
            return max;
        }
        public int Nivel(T dato)
        {
            if (Dato.CompareTo(dato) == 0)
                return 0;
            foreach (ArbolGeneral<T> arbol in Hijos)
            {
                int n = arbol.Nivel(dato);
                if (n != -1)
                    return n + 1;
            }
            return -1;
        }
        public int Ancho(int n)
        {
            int max = 0, nodos = 0;
            Queue<ArbolGeneral<T>?> c = new();
            ArbolGeneral<T>? e;
            c.Enqueue(this);
            c.Enqueue(null);
            int nivel = 0;
            while (c.Count > 1)
            {
                if ((e = c.Dequeue()) == null)
                {
                    if (nodos == n)
                        return nivel;
                    nivel++;
                    if (max < nodos)
                        max = nodos;
                    nodos = 0;
                    c.Enqueue(null);
                }
                else
                {
                    nodos++;
                    foreach (ArbolGeneral<T> hijo in e.Hijos)
                        c.Enqueue(hijo);
                }
            }
            return max < nodos ? nodos : max;
        }
        public int MinHoja(int cant)
        {
            if (Hijos.Count == 0)
                return cant;
            cant /= Hijos.Count;
            int min = cant;
            foreach (ArbolGeneral<T> hijo in Hijos)
            {
                int aux = hijo.MinHoja(cant);
                min = (aux < min) ? aux : min;
            }
            return min;
        }
        public int SumHojas(int cant, T buscada)
        {
            if (Hijos.Count == 0)
                return (Dato.CompareTo(buscada)==0)?cant:0;
            cant /= Hijos.Count;
            int sum = 0;
            foreach (ArbolGeneral<T> hijo in Hijos)
            {
                sum += hijo.SumHojas(cant, buscada);
            }
            return sum;
        }
        public override string ToString()
        {
            string o = "Nivel 0 : \n  ";
            int n = 0;
            Queue<ArbolGeneral<T>?> q = new();
            ArbolGeneral<T>? t; 
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
                    if (t.Hijos.Count > 0)
                    {
                        foreach (ArbolGeneral<T> hijo in t.Hijos)
                            q.Enqueue(hijo);
                        q.Enqueue(null);
                        q.Enqueue(null);
                    } else
                        o += "*";
                }
            }
            while (q.Count > 1);
            return o+"\n";
        }
    }
}
