using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Interfaces.Comparar;
using TP.TP4.Clases.Estrategias;
using TP.TP4.Colecciones.Iteradores;
using TP.TP4.Interfaces.Iterador;

namespace TP.TP4.Clases.Comparables.AlumnoNS
{
    public class Alumno : Persona, Comparable<Alumno>, StrategyComparable<Alumno>
    {
        public virtual int? Leg { get; set; }
        public virtual int? Calif { get; set; }
        protected virtual Comparador<Alumno>? CmpA { get; set; }
        public virtual float? Prom { get; set; }

        public Alumno(string? n, int? d, int? l, float? pr) : base(n, d)
        {
            Prom = pr;
            Leg = l;
            CmpA = new PorDni();
        }
        public virtual new Comparador<Alumno>? GetCmp()
        {
            return CmpA;
        }
        public virtual void SetCmp(Comparador<Alumno>? cmp)
        {
            CmpA = cmp;
        }

        public virtual int Responder(int preg)
        {
            return new Random().Next(1, 3);
        }
        public virtual string MostrarCalif()
        {
            return Nombre + "    " + Calif;
        }
        public virtual bool SosIgual(Alumno a)
        {
            return CmpA!.Comparar(this, a) == 0;
        }
        public virtual bool SosMayor(Alumno a)
        {
            return CmpA!.Comparar(this, a) > 0;
        }
        public virtual bool SosMenor(Alumno a)
        {
            return CmpA!.Comparar(this, a) < 0;
        }
        public override string ToString()
        {
            string s = base.ToString();
            if (string.Compare(s, "") != 0)
                s += " ";
            if (Leg != null)
                s += "Legajo: " + Leg.ToString() + "  ";
            if (Prom != 0)
                s += "Promedio: " + Prom.ToString();
            return s;
        }
    }
}
