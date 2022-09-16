using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Clases.Utiles;
using TP.TP2.Clases.Estrategias;
using System.Runtime.ConstrainedExecution;

namespace TP.TP3.Clases.Fabricas
{
    public abstract class FabricaDeComparables<T> where T : Comparable<T>
    {
        protected static Comparador<T>? Criterio;

        private static object Tipo(Comparador<T>? cmp)
        {
            if (typeof(T) == typeof(Persona))
                return new FabPersonas();
            Criterio = cmp;
            if (typeof(T) == typeof(Alumno))
                return new FabAlumnos();

            string err = "No se puede crear " + typeof(T);
            if (cmp == null)
                err += " sin especificar criterio de comparacion ";
            else
                err += ", tipo no soportado";
            throw new Exception(err);
        }
        public static T CrearAleatorio(Comparador<T>? cmp = null, StrategyComparable<T>? e = null)
        {
            if (cmp is null && e is not null)
                cmp = e.Cmp;
            return ((FabricaDeComparables<T>)Tipo(cmp)).Rand();
        }
        protected abstract T Rand();
    }
}
