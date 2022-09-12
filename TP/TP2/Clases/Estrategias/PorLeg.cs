using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases.Estrategias
{
    public class PorLeg : Comparador<Alumno>
    {
        public bool SosIgual(Alumno a, Alumno b)
        {
            return a.Leg == b.Leg;
        }

        public bool SosMayor(Alumno a, Alumno b)
        {
            return a.Leg > b.Leg;
        }

        public bool SosMenor(Alumno a, Alumno b)
        {
            return a.Leg < b.Leg;
        }
    }
}
