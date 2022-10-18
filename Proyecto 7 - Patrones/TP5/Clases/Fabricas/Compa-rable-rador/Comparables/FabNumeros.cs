﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.Tipos;
using TP.TP5.Clases.Utiles;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Fabricas.Comparables
{
    public class FabNumeros : FabNumeros<Numero> { }
    public class FabNumeros<T> : FabricaDeComparables<T> where T : Numero
    {
        protected override Comparador<T>? CrearCriterio()
        {
            return null;
        }
        public override T Rand()
        {
            return (T)new Numero(GenAleatorioDeDatos.NumeroAleatorio(100));
        }
        public override T Teclado()
        {
            return (T)new Numero(Helper.LeerNumero(0,100,"Numero: "));
        }
    }
}