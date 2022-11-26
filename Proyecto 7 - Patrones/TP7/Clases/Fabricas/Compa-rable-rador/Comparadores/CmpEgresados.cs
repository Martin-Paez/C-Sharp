using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Clases.Estrategias;
using TP.TP7.Clases.Fabricas.Comparables;

namespace TP.TP7.Clases.Fabricas.Compa_rable_rador
{
    public class CmpEgresados : _CmpEgresados<Egresado> { }
    public class _CmpEgresados<T> : _FabEgresados<T> where T : Egresado
    {
        protected new void SetRand()
        {
            if (Criterio is PorEgreso)
                EgresoRand();
            else
                ((_CmpAlumnos<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearEgresado();
        }
        protected new void SetTeclado()
        {
            if (Criterio is PorEgreso)
                EgresoTeclado();
            else
                ((_CmpAlumnos<T>)this).SetTeclado();
        }
        public override T Input()
        {
            SetTeclado();
            return CrearEgresado();
        }
    }
}
