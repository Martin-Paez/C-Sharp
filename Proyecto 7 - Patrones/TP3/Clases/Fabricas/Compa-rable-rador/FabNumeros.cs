using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class FabNumeros : FabNumeros<Numero> { }
    public class FabNumeros<T> : FabricaDeComparables<T> where T : Numero
    {
        protected override Comparador<T>? CrearCriterio()
        {
            return null;
        }
        protected override T Rand()
        {
            return (T)new Numero(GenAleatoriosDeDatos.NumeroAleatorio(100));
        }
    }
}
