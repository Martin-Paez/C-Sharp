using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP4.Clases.Utiles
{ 
    public class Tupla<A,B>
    {
        public A X { get; set; }
        public B Y { get; set; }

        public Tupla(A X, B Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
