using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP7.Clases.Estrategias;

namespace TP.TP7.Clases.Fabricas.Comparables
{
    public class CmpDecoAlumno : _CmpDecoAlumno<DecoAlumno> { }
    public class _CmpDecoAlumno<T> : _FabDecoAlumno<T> where T : DecoAlumno
    {
        public override T Rand()
        {
            SetRand();
            return CrearStudent();
        }
        public override T Input()
        {
            SetTeclado();
            return CrearStudent();
        }
    }
}
