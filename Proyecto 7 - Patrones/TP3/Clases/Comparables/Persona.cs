using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases
{
    public class Persona : Comparable<Persona>, StrategyComparable<Persona>
    {
        public string? Nombre { get; }
        public int? Dni { get; }
        public virtual Comparador<Persona>? Cmp { get; set; }

        public Persona(string? n, int? d)
        {
            Nombre = n;
            Dni = d;
            Cmp = new PorDni();
        }

        public virtual bool SosIgual(Persona p)
        {
            return Cmp!.Comparar(this, p) == 0;
        }

        public virtual bool SosMayor(Persona p)
        {
            return Cmp!.Comparar(this, p) < 0;
        }

        public virtual bool SosMenor(Persona p)
        {
            return Cmp!.Comparar(this, p) > 0;
        }

        public override string ToString()
        {
            string s = (Nombre==null)?"":Nombre;
            if (String.Compare(Nombre, "") != 0)
                s += " ";
            if (Dni != null)
                s += "DNI: " + Dni.ToString();
            return s;
        }

    }

}
