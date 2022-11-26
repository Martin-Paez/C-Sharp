using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;

namespace TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    public class MostrarMarco : DecoAlumno
    {
        public MostrarMarco(Alumno Alu) : base(Alu)
        {
        }
        public override string MostrarCalif()
        {
            string s = "*   " + base.MostrarCalif() + "   *";
            string ss = "";
            for (int i = 0; i < s.Length + 4; i++)
            {
                ss = "*" + ss;
            }
            s = ss + "\n" + s + "\n" + ss;
            return s;
        }
    }
}
