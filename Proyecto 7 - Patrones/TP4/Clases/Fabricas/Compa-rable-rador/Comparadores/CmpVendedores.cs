using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP4.Clases.Comparables.VendedorNS;
using TP.TP4.Clases.Estrategias;

namespace TP.TP4.Clases.Fabricas.Comparables
{
    public class CmpVendedores : _CmpVendedores<Vendedor> { }
    public class _CmpVendedores<T> : _FabVendedores<T> where T : Vendedor
    {
        protected double? Bonus = null;
        protected void BonusRand()
        {
            Bonus = new Random().Next(1,3);
        }
        protected new void SetRand()
        {
            if (Criterio is PorSueldoBasico)
                SueldoBasicoRand();
            if (Criterio is PorBonus)
                BonusRand();
            else
                ((_CmpPersonas<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearVendedor();
        }
        protected void BonusTeclado()
        {
            Bonus = Helper.LeerNumero(1,10,"Bonus: ");
        }
        protected new void SetTeclado()
        {
            if (Criterio is PorSueldoBasico)
                SueldoBasicoTeclado();
            else if(Criterio is PorBonus)
                BonusTeclado();
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
