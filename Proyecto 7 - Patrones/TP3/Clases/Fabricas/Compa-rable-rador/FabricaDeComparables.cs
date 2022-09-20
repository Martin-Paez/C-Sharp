using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Clases.Utiles;
using TP.TP2.Clases.Estrategias;
using System.Runtime.ConstrainedExecution;
using TP.TP3.Clases.Fabricas.Compa_rable_rador;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public abstract class FabricaDeComparables<T> where T : Comparable<T>
    {
        protected static Comparador<T>? Criterio;

        private static object Tipo(Comparador<T>? cmp, StrategyComparable<T>? e = null, bool esCmp = false)
        {
            if (cmp is null && e is not null)
                cmp = e.Cmp;
            if (typeof(T) == typeof(Numero))
                return new FabNumeros();
            Criterio = cmp;
            if (typeof(T) == typeof(Persona))
                return (esCmp) ? new CmpPersonas() : new FabPersonas();
            if (typeof(T) == typeof(Alumno))
                return (esCmp) ? new CmpAlumnos() : new FabAlumnos();
            if (typeof(T) == typeof(Egresado))
                return (esCmp) ? new CmpEgresados() : new FabEgresados();
            if (typeof(T) == typeof(Vendedor))
                return (esCmp) ? new CmpVendedores() : new FabVendedores();

            string err = "No se puede crear " + typeof(T);
            if (cmp == null)
                err += " sin especificar criterio de comparacion ";
            else
                err += ", tipo no soportado";
            throw new Exception(err);
        }
        public static Comparador<T>? CrearCriterio(Comparador<T>? cmp = null, StrategyComparable<T>? e = null)
        {
            return ((FabricaDeComparables<T>)Tipo(cmp, e)).CrearCriterio();
        }
        public static FabricaDeComparables<T> Crear(Comparador<T>? cmp = null, StrategyComparable<T>? e = null, bool soloComparador=false)
        {   
            return (FabricaDeComparables<T>)Tipo(cmp,e,soloComparador);
        }
        public abstract T Rand();
        public abstract T Teclado();
        protected abstract Comparador<T>? CrearCriterio();
    }
}
