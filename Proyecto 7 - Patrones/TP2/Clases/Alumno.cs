using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Clases
{
    public class Alumno : Persona, Comparable<Alumno>
    {
        public int? Leg { get; }
        public int Prom { get; }
        public Comparador<Alumno> CmpA { get; set; }

        public Alumno(string n, int? d, int? l, int pr) : base(n, d)
        {
            Prom = pr;
            Leg = l;
            CmpA = new PorDni();
        }   

        public bool SosIgual(Alumno a)
        {
            return CmpA.SosIgual(this,a);
        }
            
        public bool SosMayor(Alumno a)
        {
            return CmpA.SosMayor(this,a);
        }

        public bool SosMenor(Alumno a)
        {
            return CmpA.SosMenor(this,a);
        }

        public override string ToString()
        {
            string s = base.ToString();
            if (Leg != null)
                s += " Legajo: " + Leg.ToString();
            return s;
        }
    }

}
