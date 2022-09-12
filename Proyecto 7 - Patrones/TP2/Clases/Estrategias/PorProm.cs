using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases.Estrategias
{
    public class PorProm : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return (int)a.Prom - (int)b.Prom;
        }
    }
}
