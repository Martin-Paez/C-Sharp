﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Estrategias
{
    public class PorNom : Comparador<Persona>
    {
        public int Comparar(Persona a, Persona b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }
        public override string ToString()
        {
            return "Por Nombre";
        }
    }
}
