using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.Tipos;
using TP.TP7.Clases.Utiles;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Fabricas.Comparables
{
    public class FabNumeros : FabNumeros<Numero> { }
    public class FabNumeros<T> : FabricaDeComparables<T> where T : Numero
    {
        public override Comparador<T>? CrearCriterio()
        {
            return null;
        }
        public override T Rand()
        {
            return (T)new Numero(GenAleatorioDeDatos.NumeroAleatorio(100));
        }
        public override T Input()
        {
            return (T)new Numero(Gen.GetNum(0,100,"Numero: "));
        }
    }
}
