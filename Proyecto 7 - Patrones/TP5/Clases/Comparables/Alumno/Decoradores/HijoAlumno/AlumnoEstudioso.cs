using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.AlumnoNS;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    public class AlumnoEstudioso : DecoAlumno
    {
        public AlumnoEstudioso(Alumno alu) : base(alu)
        {
        }

        public override int Responder(int preg)
        {
            return preg % 3;
        }
    }
}
