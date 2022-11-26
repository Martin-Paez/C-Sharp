using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Estrategias
{
    public class PorCalif : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return (int)a.Calif! - (int)b.Calif!;
        }
        public override string ToString()
        {
            return "Por Calificacion";
        }
    }
}
