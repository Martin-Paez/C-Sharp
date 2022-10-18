using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;

namespace TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    public class NotaConLetras : DecoAlumno
    {
        private string[] notas = { "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE"
                                 , "OCHO", "NUEVE", "DIEZ"};

        public NotaConLetras(Alumno a) : base(a) 
        {
            Alu = a;
        }

        public override string MostrarCalif()
        {
            return base.MostrarCalif() + " (" + ((Calif != null)? notas[(int)Calif-1] : "") + ")";
        }
    }
}