using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Clases;

namespace TP.TP3.Clases.Utiles
{
    public abstract class FabricaDeComparables<T> where T:Comparable<T>
    {
        private static Object GetFabricaConcreta()
        {
            if (typeof(T) == typeof(Alumno))
                return null!;
            else if (typeof(T) == typeof(Numero))
                return new FabricaDeNumeros();

            throw new Exception("No se puede crear " + typeof(T) + ", tipo no soportado");
        }
        public static T CrearAleatorio(int max)
        {
            return ((FabricaDeComparables<T>)GetFabricaConcreta()).FabricarAleatorio(max);
        }
        public static T CrearPorTeclado(int cant)
        {
            return ((FabricaDeComparables<T>)GetFabricaConcreta()).FabricarPorTeclado(cant);
        }
        protected abstract T FabricarAleatorio(int max);
        protected abstract T FabricarPorTeclado(int cant);
    }

    public class FabricaDeNumeros : FabricaDeComparables<Numero>
    {
        protected override Numero FabricarAleatorio(int max)
        {
            return new Numero((new GenAleatoriosDeDatos()).NumeroAleatorio(max).Valor);
        }
        protected override Numero FabricarPorTeclado(int cant)
        {
            throw new NotImplementedException();
        }
    }
}
