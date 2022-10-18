using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP4.Clases.Estrategias;

namespace TP.TP4.Clases.Fabricas.Comparables
{
    public class CmpStudent : _CmpStudent<DecoAlumno> { }
    public class _CmpStudent<T> : _FabStudent<T> where T : DecoAlumno
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
