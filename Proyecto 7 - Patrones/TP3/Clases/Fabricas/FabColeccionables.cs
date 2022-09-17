﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces;
using TP.TP3.Colecciones;
using TP.TP3.Colecciones.Diccionario;
using TP.Main.NSMenu.Fabrica;

namespace TP.TP3.Clases.Fabricas
{
    public abstract class FabColeccionables<T> where T : Comparable<T>
    {
        public static Coleccionable<T> PorTeclado()
        {
            //TODO , no hace falta que sea ref f
            Func<Coleccionable<T>>[] f = { () => { return new Pila<T>(); }
                                              ,() => { return new Cola<T>(); }
                                              ,() => { return new Conjunto<T>(); }
                                              ,() => { return new Diccionario<Numero,T> {
                                                                    keyGen = new SimpleKeyGen() };
                                                     }
                                              };
            Coleccionable<T>? o = FabMenu.Crear(f
                                            , "Colecciones:     \n"
                                            + "-----------      \n"
                                            + " 1) Pila         \n"
                                            + " 2) Cola         \n"
                                            + " 3) Conjunto     \n"
                                            + " 4) Diccionario  \n"
                                            + " s)Salir         \n"
                                            , limpiarConsola : false
                                          ).Ejecutar();
            if (o is null)
                throw new Exception("Tipo no soportado. No se puede fabricar un " + typeof(T));
            return o;
        }
    }
}
