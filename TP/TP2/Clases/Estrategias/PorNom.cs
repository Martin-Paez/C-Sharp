using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases.Estrategias
{
    public class PorNom : Comparador<Alumno>
    {
        public bool SosIgual(Alumno a, Alumno b)
        {
            return string.Compare(a.Nombre, b.Nombre) == 0;
        }

        public bool SosMayor(Alumno a, Alumno b)
        {
            return string.Compare(a.Nombre, b.Nombre) > 0;
        }

        public bool SosMenor(Alumno a, Alumno b)
        {
            return string.Compare(a.Nombre, b.Nombre) < 0;
        }
    }

}
