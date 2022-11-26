using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Clases.Estrategias
{
    public class PorLeg : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return (int)a.Leg! - (int)b.Leg!;
        }
        public override string ToString()
        {
            return "Por Legajo";
        }
    }
}
