using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.AlumnoNS;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Estrategias
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
