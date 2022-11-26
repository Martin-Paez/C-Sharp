﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Colecciones
{
    public class Conjunto<T>: Coleccion<T> where T: Comparable<T>
    {
        public override void Agregar(T c)
        {
            if ( ! Contiene(c) )
                base.Agregar(c);
        }
    }
}
