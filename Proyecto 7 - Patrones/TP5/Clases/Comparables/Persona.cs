using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Estrategias;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases
{
    public class Persona : Comparable<Persona>, StrategyComparable<Persona>
    {
        public virtual string? Nombre { get { return nombre; } }
        protected string? nombre; 
        public virtual int? Dni { get { return dni; } }
        protected int? dni;
        protected virtual Comparador<Persona>? Cmp { get; set; }

        protected Persona() { }
        public Persona(string? n, int? d)
        {
            nombre = n;
            dni = d;
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

        public virtual Comparador<Persona>? GetCmp()
        {
            return Cmp;
        }

        public virtual void SetCmp(Comparador<Persona>? cmp)
        {
            Cmp = cmp;
        }
    }

}
