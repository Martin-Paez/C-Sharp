using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Estrategias
{
    public class PorDni : Comparador<Persona>
    {
        public int Comparar(Persona a, Persona b)
        {
            return (int)a.Dni! - (int)b.Dni!;
        }
        public override string ToString()
        {
            return "Por DNI";
        }
    }
}
