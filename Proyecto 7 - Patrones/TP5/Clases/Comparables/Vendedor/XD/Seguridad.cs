using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.XD;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Clases.Comparables
{
    public class Seguridad : Enojado<Seguridad>
    {
        public Seguridad(string? n, int? d) : base(n, d)
        {
        }
        public override void Reaccionar()
        {
            Console.WriteLine("{0} (Empleado de seguridad): Hey!! ¿ Donde esta mi parte ?!!", Nombre);
        }
    }
}
