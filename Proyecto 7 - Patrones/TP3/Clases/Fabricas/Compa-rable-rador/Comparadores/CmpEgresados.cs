using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Fabricas.Comparables;

namespace TP.TP3.Clases.Fabricas.Compa_rable_rador
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
        protected new void SetTeclado()
        {
            if (Criterio is PorEgreso)
                EgresoTeclado();
            else
                ((_CmpAlumnos<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearEgresado();
        }
    }
}
