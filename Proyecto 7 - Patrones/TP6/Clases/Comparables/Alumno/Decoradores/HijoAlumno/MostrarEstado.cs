using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;

namespace TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    public class MostrarEstado : DecoAlumno
    {
        public MostrarEstado(Alumno Alu) : base(Alu)
        {
        }
        public override string MostrarCalif()
        {
            string s = "PROMOCION";
            if (Alu.Leg < 4)
                s = "DESAPROBADO";
            else if (Alu.Leg < 7)
                s = "APROBADO";
            return base.MostrarCalif() + " (" + s + ")";
        }
    }
}
