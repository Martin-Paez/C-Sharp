using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;

namespace TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    public class MostrarLegajo : DecoAlumno
    {
        public MostrarLegajo(AlumnoNS.Alumno Alu) : base(Alu)
        {
        }
        public override string MostrarCalif()
        {
            string s = base.MostrarCalif();
            int i;
            for (i = s.Length-1; i > 0 ; i--)
                if (Char.IsLetter(s[i-1]))
                    break;
            return s.Substring(0, i+1) + "(" + Alu.Leg + ")" + s.Substring(i);
        }
    }
}
