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
    public class FabPersonas : _FabPersonas<Persona> {}
    public class CmpPersonas : _CmpPersonas<Persona> {}
    public class FabAlumnos : _FabAlumnos<Alumno> {}
    public class ComAlumnos : _CmpAlumnos<Alumno> {}

    public class _FabPersonas<T> : FabricaDeComparables<T> where T : Persona
    {
        protected int? Dni = null;
        protected string? Nombre = null;

        public void DniRand()
        {
            Dni = GenAleatoriosDeDatos.DniAleatorio();
        }
        public void NombreRand()
        {
            Nombre = GenAleatoriosDeDatos.NombreAleatorio();
        }
        public virtual void SetRand()
        {
            DniRand();
            NombreRand();
        }
        protected override T Rand()
        {
            SetRand();
            return (T) new Persona(Nombre, Dni);
        }
    }
    public class _CmpPersonas<T> : _FabPersonas<T> where T : Persona
    {
        public override void SetRand()
        {
            DniRand();
        }
    }
    public class _FabAlumnos<T> : _CmpPersonas<T> where T : Alumno
    {
        protected int? Leg = null;
        protected float? Prom = null;

        protected void PromRand()
        {
            Prom = 10;//GenAleatoriosDeDatos.NumeroAleatorio(11);
        }
        protected void LegRand()
        {
            Leg = GenAleatoriosDeDatos.NumeroAleatorio(10000);
        }
        public new void SetRand()
        {
            LegRand();
            PromRand();
            ((_FabPersonas<T>)this).SetRand();
        }
        protected override T Rand()
        {
            SetRand();
            Alumno a = new(Nombre, Dni, Leg, Prom);
            if ( Criterio != null )
                a.Cmp = (Comparador<Alumno>) Criterio;
            return (T) (object) a;
        }
    }
    public class _CmpAlumnos<T> : _FabAlumnos<T> where T : Alumno
    {
        protected new void SetRand()
        {
            if (Criterio is PorLeg)
                LegRand();
            else if (Criterio is PorProm)
                PromRand();
            else if (Criterio is PorNom)
                NombreRand();
            else if (Criterio is PorDni)
                ((_CmpPersonas<T>)this).SetRand();
        }
    }
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
