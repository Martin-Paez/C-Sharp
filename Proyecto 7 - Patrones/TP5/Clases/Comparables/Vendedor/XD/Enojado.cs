using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Clases.Comparables.XD
{
    public abstract class Enojado<T> : Persona, Notificable<T>
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
