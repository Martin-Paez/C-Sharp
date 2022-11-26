using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;

namespace TP.TP7.Clases.Comparables.NS.Decoradores.HijoAlumno
{
    public class Enumerar : DecoAlumno
    {
        public static int Line { get; set; } = 1;
        public Enumerar(AlumnoNS.Alumno Alu) : base(Alu)
        {
        }
        public override string MostrarCalif()
        {
            string s = base.MostrarCalif();
            int i;
            for (i= 1; i <= s.Length; i++)
                if (Char.IsLetter(s, i-1))
                    break;
            return s.Substring(0,i-1) + Line++ + ") " + s.Substring(i-1);
        }
    }
}
