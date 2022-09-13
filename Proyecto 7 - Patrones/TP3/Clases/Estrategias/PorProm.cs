using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Estrategias
{
    public class PorProm : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return (int)a.Prom - (int)b.Prom;
        }
    }
}
