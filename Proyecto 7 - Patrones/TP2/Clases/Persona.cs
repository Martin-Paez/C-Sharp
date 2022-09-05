using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Clases
{
    public class Persona : Comparable<Persona>
    {
        public string Nombre { get; }
        public int? Dni { get; }

        public Persona(string n, int? d)
        {
            Nombre = n;
            Dni = d;
        }

        public virtual bool SosIgual(Persona p)
        {
            return this.Dni == p.Dni;
        }

        public virtual bool SosMayor(Persona p)
        {
            return this.Dni < p.Dni;
        }

        public virtual bool SosMenor(Persona p)
        {
            return this.Dni > p.Dni;
        }

        public override string ToString()
        {
            string s = Nombre;
            if (Dni != null)
                s += " DNI: " + Dni.ToString();
            return s;
        }

    }

}
