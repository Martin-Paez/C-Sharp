﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP4.Clases.Comparables.XD
{
    public class Cliente : Enojado<Cliente>
    {
        public Cliente(string? n, int? d) : base(n, d)
        {
        }
        public override void Reaccionar()
        {
            Console.WriteLine("{0} (cliente): Aca son todos empleados municipales !!", Nombre);
        }
    }
}
