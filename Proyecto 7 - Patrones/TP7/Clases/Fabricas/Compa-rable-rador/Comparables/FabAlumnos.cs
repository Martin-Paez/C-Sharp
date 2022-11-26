using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP7.ChainOR;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP7.Clases.Estrategias;
using TP.TP7.Clases.Utiles;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Fabricas.Comparables
{
    public class FabAlumnos : _FabAlumnos<Alumno> { }

    public class _FabAlumnos<T> : _CmpPersonas<T> where T : Alumno
    {
        protected int? Leg = null;
        protected float? Prom = null;

        protected void PromRand()
        {
            Prom = Gen.RandNum(1,11);
        }
        protected void LegRand()
        {
            Leg = Gen.RandNum(1, 10000);
        }
        public new void SetRand()
        {
            LegRand();
            PromRand();
            ((_FabPersonas<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearAlumno();
        }
        protected void PromTeclado()
        {
            Prom = Gen.GetNum(1,10,"Promerdio: ");
        }
        protected void LegTeclado()
        {
            Leg = Gen.GetNum(0, 99999999, "Legajo: ");
        }
        public new void SetTeclado()
        {
            LegTeclado();
            PromTeclado();
            ((_FabPersonas<T>)this).SetTeclado();
        }
        public override T Input()
        {
            SetTeclado();
            return CrearAlumno();
        }
        public T CrearAlumno()
        {
            Alumno a = new(Nombre, Dni, Leg, Prom);
            if (Criterio != null)
                a.SetCmp((Comparador<Alumno>)Criterio);
            return (T)(object)a;
        }
        protected override IList<Func<Comparador<T>?>> Comparadores()
        { 
            List<Func<Comparador<T>?>> list = (List<Func<Comparador<T>?>>)base.Comparadores();
            list.Add(() => { return new PorLeg(); });
            list.Add(() => { return new PorProm(); });
            return list;
        }
        protected override string CriterioMenu()
        {
            return base.CriterioMenu()
                 + "  3) Legajo  \n"
                 + "  4) Pormedio\n";
        }
    }
}
