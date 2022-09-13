using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Estrategias
{
    public class PorNom : Comparador<Alumno>
    {
        public int Comparar(Alumno a, Alumno b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }
    }
}
