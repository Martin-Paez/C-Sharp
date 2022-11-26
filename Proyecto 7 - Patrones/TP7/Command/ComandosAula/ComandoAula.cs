using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS;

namespace TP.TP7.Command.ComandosAula
{
    public abstract class ComandoAula
    {
        public Aula Au { get; }
        public ComandoAula(Aula Au)
        {
            this.Au = Au;
        }
    }
}
