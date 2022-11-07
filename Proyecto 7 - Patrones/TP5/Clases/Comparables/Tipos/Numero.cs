using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Clases.Comparables.Tipos
{
    public class Numero : Comparable<Numero>, Observable<Observador<Numero>>
    {
        public int _valor;
        public int Valor { get { return _valor; } set { Publicar(); _valor = value; } }
        private List<Observador<Numero>>? Obs;

        public Numero(int v)
        {
            Valor = v;
        }

        public bool SosIgual(Numero n)
        {
            return Valor == n.Valor;
        }

        public bool SosMayor(Numero n)
        {
            return Valor < n.Valor;
        }

        public bool SosMenor(Numero n)
        {
            return Valor > n.Valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }

        public void Publicar()
        {
            if (Obs == null)
                return;
            foreach (Observador<Numero> o in Obs)
                o.RecibirNotificacion();
        }

        public void Suscribir(Observador<Numero> s)
        {
            if (Obs == null)
                Obs = new();
            Obs.Add(s);
        }
    }
}
