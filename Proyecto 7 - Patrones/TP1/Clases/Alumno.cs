using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;

namespace TP.TP1.Clases
{
    public class Alumno : Persona
    {
        private int? leg;
        private int prom;
        private static bool legCmp = false;

        public Alumno(string n, int? d, int? l, int p) : base(n, d)
        {
            prom = p;
            leg = l;
        }

        public int? GetLegajo()
        {
            return leg;
        }

        public int GetProm()
        {
            return prom;
        }

        public void SetCmpPorLegajo(bool cmp)
        {
            legCmp = cmp;
        }

        public bool GetCmpPorLegajo()
        {
            return legCmp;
        }

        public override bool SosIgual(Comparable a)
        {
            if (legCmp)
                return GetLegajo() == ((Alumno)a).GetLegajo();
            return base.SosIgual(a);
        }

        public override bool SosMayor(Comparable a)
        {
            if (legCmp)
                return GetLegajo() > ((Alumno)a).GetLegajo();
            return base.SosMayor(a);
        }

        public override bool SosMenor(Comparable a)
        {
            if (legCmp)
                return GetLegajo() < ((Alumno)a).GetLegajo();
            return base.SosMenor(a);
        }

        public override string ToString()
        {
            string s = base.ToString();
            if (leg != null)
                s += " Legajo: " + GetLegajo().ToString();
            return s;
        }
    }
}
