using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Clases
{
    public class PorDni : SComparador<Alumno>
    {
        public bool SosIgual(Alumno a, Alumno b)
        {
            return a.Dni == b.Dni;
        }

        public bool SosMayor(Alumno a, Alumno b)
        {
            return a.Dni > b.Dni;
        }

        public bool SosMenor(Alumno a, Alumno b)
        {
            return a.Dni < b.Dni;
        }
    }

    public class PorLeg : SComparador<Alumno>
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

    public class PorNom : SComparador<Alumno>
    {
        public bool SosIgual(Alumno a, Alumno b)
        {
            return String.Compare(a.Nombre, b.Nombre) == 0;
        }

        public bool SosMayor(Alumno a, Alumno b)
        {
            return String.Compare(a.Nombre, b.Nombre) > 0;
        }

        public bool SosMenor(Alumno a, Alumno b)
        {
            return String.Compare(a.Nombre, b.Nombre) < 0;
        }
    }

    public class PorProm : SComparador<Alumno>
    {
        public bool SosIgual(Alumno a, Alumno b)
        {
            return a.Prom == b.Prom;
        }

        public bool SosMayor(Alumno a, Alumno b)
        {
            return a.Prom > b.Prom;
        }

        public bool SosMenor(Alumno a, Alumno b)
        {
            return a.Prom < b.Prom;
        }
    }
}
