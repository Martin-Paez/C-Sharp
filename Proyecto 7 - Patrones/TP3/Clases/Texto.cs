using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP3.Clases
{
    public class Texto : Comparable<Texto>
    {
        private string texto;
        public Texto(string texto)
        {
            this.texto = texto;
        }

        public bool SosIgual(Texto c)
        {
            return String.Compare(texto, c.texto) == 0;
        }

        public bool SosMayor(Texto c)
        {
            return String.Compare(texto, c.texto) > 0;
        }

        public bool SosMenor(Texto c)
        {
            return String.Compare(texto, c.texto) < 0;
        }
    }
}
