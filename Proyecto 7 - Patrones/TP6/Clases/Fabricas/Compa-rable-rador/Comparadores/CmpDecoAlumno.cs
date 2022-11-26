using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP6.Clases.Estrategias;

namespace TP.TP6.Clases.Fabricas.Comparables
{
    public class CmpDecoAlumno : _CmpDecoAlumno<DecoAlumno> { }
    public class _CmpDecoAlumno<T> : _FabDecoAlumno<T> where T : DecoAlumno
    {
        public override T Rand()
        {
            SetRand();
            return CrearStudent();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearStudent();
        }
    }
}
