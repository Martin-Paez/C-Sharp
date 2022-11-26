using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Clases.Utiles;
using TP.TP2.Clases.Estrategias;
using System.Runtime.ConstrainedExecution;
using TP.TP6.Clases.Fabricas.Compa_rable_rador;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.VendedorNS;
using TP.TP6.Clases.Comparables.Tipos;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP6.Clases.Comparables.AlumnoNS.Composite;
using TP.TP6.Clases.Fabricas.Compa_rable_rador.Comparables;

namespace TP.TP6.Clases.Fabricas.Comparables
{
    public abstract class FabricaDeComparables<T> where T : Comparable<T>
    {
        protected static Comparador<T>? Criterio;

        private static object Tipo(Comparador<T>? cmp, StrategyComparable<T>? e = null, bool esCmp = false)
        {
            if (cmp is null && e is not null)
                cmp = e.GetCmp();
            if (typeof(T) == typeof(Numero))
                return new FabNumeros();
            Criterio = cmp;
            if (typeof(T) == typeof(Persona))
                return (esCmp) ? new CmpPersonas() : new FabPersonas();
            if (typeof(T) == typeof(Alumno))
                return (esCmp) ? new CmpAlumnos() : new FabAlumnos();
            if (typeof(T) == typeof(AlumnoEstudioso))
                return (esCmp) ? new CmpAlumnosEstudiosos() : new FabAlumnosEstudiosos();
            if (typeof(T) == typeof(DecoAlumno))
                return (esCmp) ? new CmpDecoAlumno() : new FabDecoAlumno();
            if (typeof(T) == typeof(CompositeAlumno<DecoAlumno>))
                return (esCmp) ? new CmpAlumnos() : new FabCompositeAlumno();
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
        private static FabricaDeComparables<T> Crear(Comparador<T>? cmp = null, StrategyComparable<T>? e = null, bool soloComparador=false)
        {   
            return (FabricaDeComparables<T>)Tipo(cmp,e,soloComparador);
        }
        public static T Rand(Comparador<T>? cmp = null, StrategyComparable<T>? e = null, bool soloComparador = false)
        {
            return Crear(cmp, e, soloComparador).Rand();
        }
        public static T Teclado(Comparador<T>? cmp = null, StrategyComparable<T>? e = null, bool soloComparador = false)
        {
            return Crear(cmp, e, soloComparador).Teclado();
        }
        public abstract T Rand();
        public abstract T Teclado();
        public abstract Comparador<T>? CrearCriterio();
    }
}
