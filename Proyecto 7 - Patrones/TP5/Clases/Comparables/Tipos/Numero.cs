using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Comparables.Tipos
{
    public class Numero : Comparable<Numero>
    {
        public int Valor { get; }

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
    }
}
