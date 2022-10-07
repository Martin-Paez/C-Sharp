using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP4.Interfaces.Comparar;

namespace TP.TP4.Clases.Comparables.AlumnoNS
{
    public class Egresado : Alumno, Comparable<Egresado>, StrategyComparable<Egresado>
    {
        public DateTime Egreso { get; }
        protected Comparador<Egresado>? CmpE { get; set; }
        public Egresado(string? n, int? d, int? l, float? pr, DateTime egreso) : base(n, d, l, pr)
        {
            Egreso = egreso;
            CmpE = base.Cmp;
        }
        public bool SosIgual(Egresado c)
        {
            return CmpE!.Comparar(this, c) == 0;
        }
        public bool SosMayor(Egresado c)
        {
            return CmpE!.Comparar(this, c) > 0;
        }
        public bool SosMenor(Egresado c)
        {
            return CmpE!.Comparar(this, c) < 0;
        }
        public override string ToString()
        {
            return base.ToString() + " Fecha de Egreso: " + Egreso.ToString("d");
        }

        Comparador<Egresado>? StrategyComparable<Egresado>.GetCmp()
        {
            return CmpE;
        }

        public void SetCmp(Comparador<Egresado>? cmp)
        {
            CmpE = cmp;
        }
    }
}
