using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP4.Clases.Estrategias;

namespace TP.TP4.Clases.Fabricas.Comparables
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
        public override T Rand()
        {
            SetRand();
            return CrearAlumno();
        }
        protected new void SetTeclado()
        {
            if (Criterio is PorLeg)
                LegTeclado();
            else if (Criterio is PorProm)
                PromTeclado();
            else
                ((_CmpPersonas<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearAlumno();
        }
    }
}
