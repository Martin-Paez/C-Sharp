using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP4.Interfaces.Comparar;

namespace TP.TP4.Clases.Estrategias
{
    public class PorProm : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return (int)a.Prom! - (int)b.Prom!;
        }
        public override string ToString()
        {
            return "Por Promedio";
        }
    }
}
