using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;

namespace TP.TP1.Colecciones
{
    public class Coleccion : Coleccionable
    {
        private List<Comparable> elementos = new List<Comparable>();
        public void Agregar(Comparable c)
        {
            elementos.Add(c);
        }

        public bool Contiene(Comparable c)
        {
            foreach (Comparable e in elementos)
                if (e.SosIgual(c))
                    return true;
            return false;
        }

        public int Cuantos()
        {
            return elementos.Count;
        }

        public Comparable? Maximo()
        {
            if (elementos.Count < 1)
                return null;
            Comparable n = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (n.SosMayor(elementos[i]))
                    n = elementos[i];
            }
            return n;
        }

        public Comparable? Minimo()
        {
            if (elementos.Count < 1)
                return null;
            Comparable? n = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                Comparable? b = elementos[i];
                if (n.SosMenor(elementos[i]))
                    n = elementos[i];
            }
            return n;
        }
    }
}
