using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class CmpAlumnos : _CmpAlumnos<Alumno> { }
    public class _CmpAlumnos<T> : _FabAlumnos<T> where T : Alumno
    {
        protected new void SetRand()
        {
            if (Criterio is PorLeg)
                LegRand();
            else if (Criterio is PorProm)
                PromRand();
            else 
                ((_CmpPersonas<T>)this).SetRand();
        }
    }
}
