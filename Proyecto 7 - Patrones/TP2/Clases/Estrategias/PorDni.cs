using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases.Estrategias
{
    public class PorDni : Comparador<Persona>
    {
        public bool SosIgual(Persona a, Persona b)
        {
            return a.Dni == b.Dni;
        }
        public bool SosMayor(Persona a, Persona b)
        {
            return a.Dni > b.Dni;
        }
        public bool SosMenor(Persona a, Persona b)
        {
            return a.Dni < b.Dni;
        }
    }
}
