using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;

namespace TP.TP3.Clases.Fabricas
{
    public class FabNumeros : FabNumeros<Numero> { }
    public class FabNumeros<T> : FabricaDeComparables<T> where T : Numero
    {
        protected override T Rand()
        {
            return (T) new Numero(GenAleatoriosDeDatos.NumeroAleatorio(100));
        }
    }
}
    