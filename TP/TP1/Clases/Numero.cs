using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;

namespace TP.TP1.Clases
{
    public class Numero : Comparable
    {
        private int valor;
        public Numero(int v)
        {
            valor = v;
        }

        public int GetValor()
        {
            return valor;
        }

        public bool SosIgual(Comparable n)
        {
            return valor == ((Numero)n).GetValor();
        }

        public bool SosMayor(Comparable n)
        {
            return valor < ((Numero)n).GetValor();
        }

        public bool SosMenor(Comparable n)
        {
            return valor > ((Numero)n).GetValor();
        }

        public override string ToString()
        {
            return valor.ToString();
        }
    }
}
