using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Clases.Comparables.AlumnoNS.Composite
{
    public class CompositeAlumno<T> : Alumno where T:Alumno // No tiene sentido crear un IAlumno
    {
        private List<T> Alumnos;
        public override int? Leg { get { throw new NotImplementedException(); } }
        private bool calificado = false;
        public override int? Calif { 
            set {
                foreach (Alumno a in Alumnos)
                    a.Calif = value;
                calificado = true;
            } 
            get
            {
                if (calificado)
                    return Alumnos[0].Calif;
                return null;
            }
        }
        protected override Comparador<Alumno>? CmpA { get; set; }
        public override float? Prom { get { throw new NotImplementedException(); } }
        public CompositeAlumno(List<T> alumnos)
        {
            Alumnos = alumnos;
        }
        public override int Responder(int preg)
        {
            Dictionary<int,int> r = new();
            foreach (Alumno a in Alumnos)
            {
                int n = a.Responder(preg);
                if (r.ContainsKey(n))
                    r[n]++;
                else
                    r[n] = 1;
            }
            int mx = -1;
            foreach (KeyValuePair<int,int> n in r)
            {
                if (mx < n.Value)
                    mx = n.Value;
            }
            return mx;
        }
        public override string MostrarCalif()
        {
            string c = "GRUPO DE ALUMNOS:\n\n";
            foreach (Alumno a in Alumnos)
                c += a.MostrarCalif() + "\n";
            return c.Substring(0,c.Length-1);
        }
        public override bool SosIgual(Alumno a)
        {
            foreach (Alumno i in Alumnos)
                if (i.SosIgual(a))
                    return true;
            return false;
        }
        public override bool SosMayor(Alumno a)
        {
            foreach (Alumno i in Alumnos)
                if (i.SosMenor(a))
                    return false;
            return true;
        }
        public override bool SosMenor(Alumno a)
        {
            foreach (Alumno i in Alumnos)
                if (i.SosMayor(a))
                    return false;
            return true;
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
