using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class CmpVendedores : _CmpVendedores<Vendedor> { }
    public class _CmpVendedores<T> : _FabVendedores<T> where T : Vendedor
    {
        protected new void SetRand()
        {
            if (Criterio is PorSueldoBasico)
                SueldoBasicoRand();
            else
                ((_CmpPersonas<T>)this).SetRand();
        }
        protected new void SetTeclado()
        {
            if (Criterio is PorSueldoBasico)
                SueldoBasicoTeclado();
            else
                ((_CmpPersonas<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearVendedor();
        }
    }
}
