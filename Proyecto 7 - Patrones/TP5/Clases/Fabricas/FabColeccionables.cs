using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces;
using TP.TP5.Colecciones;
using TP.TP5.Colecciones.Diccionario;
using TP.Main.NSMenu.Fabrica;
using TP.TP5.Clases.Comparables.Tipos;

namespace TP.TP5.Clases.Fabricas
{
    public abstract class FabColeccionables<T> where T : Comparable<T>
    {
        public enum TipoCol{ PILA, COLA, CONJUNTO, DICCIONARIO };

        public static Coleccionable<T> Crear(TipoCol coleccion)
        {
            switch(coleccion)
            {
                case TipoCol.PILA:          return new Pila<T>();
                case TipoCol.COLA:          return new Cola<T>();
                case TipoCol.CONJUNTO:      return new Conjunto<T>();
                case TipoCol.DICCIONARIO:   return new Diccionario<Numero, T>
                                                { keyGen = new SimpleKeyGen() };
            }
            throw new Exception("Tipo de coleccion no soportado: " + coleccion.ToString());
        }
        public static TipoCol Seleccionar()
        {
            Func<TipoCol>[] f = { () => { return TipoCol.PILA; }
                                 ,() => { return TipoCol.COLA; }
                                 ,() => { return TipoCol.CONJUNTO; }
                                 ,() => { return TipoCol.DICCIONARIO; }
                                 };
            return FabMenu.Crear(f,
                          "Colecciones:     \n"
                        + "-----------      \n"
                        + " 1) Pila         \n"
                        + " 2) Cola         \n"
                        + " 3) Conjunto     \n"
                        + " 4) Diccionario  \n"
                        , limpiarConsola: false
                        ).Ejecutar();
        }
        public static Coleccionable<T> PorTeclado()
        {
            return Crear(Seleccionar());
        }
    }
}
