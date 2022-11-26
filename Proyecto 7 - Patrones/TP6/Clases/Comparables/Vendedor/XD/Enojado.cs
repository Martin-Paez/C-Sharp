using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Oberservar;

namespace TP.TP6.Clases.Comparables.XD
{
    public abstract class Enojado<T> : Persona, Observador<T>
    {
        public Enojado(string? n, int? d) : base(n, d)
        {
        }

        public void RecibirNotificacion()
        {
            Reaccionar();
        }
        public abstract void Reaccionar();
    }
}
