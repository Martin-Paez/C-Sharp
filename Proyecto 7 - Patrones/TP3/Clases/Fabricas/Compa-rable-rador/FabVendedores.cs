﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class FabVendedores : _FabVendedores<Vendedor> { }
    public class _FabVendedores<T> : _CmpPersonas<T> where T : Vendedor
    {
        protected double? SueldoBasico = null;

        protected void SueldoBasicoRand()
        {
            SueldoBasico = GenAleatoriosDeDatos.NumeroAleatorio(800000);
        }
        public new void SetRand()
        {
            SueldoBasicoRand();
            ((_FabPersonas<T>)this).SetRand();
        }
        protected override T Rand()
        {
            SetRand();
            Vendedor v = new(Nombre, Dni, SueldoBasico);
            if (Criterio != null)
                v.Cmp = (Comparador<Vendedor>)Criterio;
            return (T)(object)v;
        }
        protected override IList<Func<Comparador<T>>> Comparadores()
        {
            List<Func<Comparador<T>>> list = (List<Func<Comparador<T>>>)base.Comparadores();
            list.Add(() => { return new PorBonus(); });
            list.Add(() => { return new PorSueldoBasico(); });
            return list;
        }
        protected override string CriterioMenu()
        {
            return base.CriterioMenu()
                 + "  3) Bonus  \n"
                 + "  4) Sueldo Basico\n";
        }
    }
}