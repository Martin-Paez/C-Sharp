﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Colecciones
{
    public class Cola<T> : Coleccion<T> where T : Comparable<T>
    {
    }
}
