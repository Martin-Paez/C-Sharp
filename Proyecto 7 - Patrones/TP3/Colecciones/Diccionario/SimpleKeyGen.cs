﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases;
using TP.TP3.Interfaces;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces.Iterador;

namespace TP.TP3.Colecciones.Diccionario
{
    public class SimpleKeyGen : KeyGen<Numero>
    {
        private int semilla = 0;
        public Numero getK()
        {
            return new Numero(++semilla);
        }
    }
}
