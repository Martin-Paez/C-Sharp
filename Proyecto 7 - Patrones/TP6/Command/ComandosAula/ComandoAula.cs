using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.AlumnoNS;

namespace TP.TP6.Command.ComandosAula
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
