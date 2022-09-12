using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Clases;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases
{
    public class Egresado : Alumno, Comparable<Egresado>, StrategyComparable<Egresado>
    {
        public DateTime Egreso { get; }
        public new Comparador<Egresado> Cmp { get; set; }
        public Egresado(string n, int? d, int? l, float pr, DateTime egreso) : base(n, d, l, pr)
        {
            this.Egreso = egreso;
            Cmp = base.Cmp;
        }
        public bool SosIgual(Egresado c)
        {
            return Cmp!.SosIgual(this, c);
        }
        public bool SosMayor(Egresado c)
        {
            return Cmp!.SosMayor(this, c);
        }
        public bool SosMenor(Egresado c)
        {
            return Cmp!.SosMenor(this, c);
        }
        public override string ToString()
        {
            return base.ToString() + " Fecha de Egreso: " + Egreso.ToString("d");
        }
    }
}
