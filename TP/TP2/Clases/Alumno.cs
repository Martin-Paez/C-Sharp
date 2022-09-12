using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;
using TP.TP2.Clases.Estrategias;

namespace TP.TP2.Clases
{
    public class Alumno : Persona, Comparable<Alumno>, StrategyComparable<Alumno>
    {
        public int? Leg { get; }
        public virtual Comparador<Alumno> Cmp { get; set; }
        public float Prom { 
            get 
            {
                return _prom;
            }
            set
            {
                if (value < 0 || value > 10)
                    throw new Exception();
                _prom = (float) Math.Round(value,1);
            }
        }
        private float _prom;
        public Alumno(string n, int? d, int? l, float pr) : base(n, d)
        {
            Prom = pr;
            Leg = l;
            Cmp = new PorDni();
        }
        public virtual bool SosIgual(Alumno a)
        {
            return Cmp.SosIgual(this,a);
        }
        public virtual bool SosMayor(Alumno a)
        {
            return Cmp.SosMayor(this,a);
        }   
        public virtual bool SosMenor(Alumno a)
        {
            return Cmp.SosMenor(this,a);
        }
        public override string ToString()
        {
            string s = base.ToString();
            if (String.Compare(s, "") != 0)
                s += " ";
            if (Leg != null)
                s += "Legajo: " + Leg.ToString() + "  ";
            if (Prom != 0)
                s += "Promedio: " + Prom.ToString();
            return s;
        }
    }
}
