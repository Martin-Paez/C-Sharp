using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class FabAlumnos : _FabAlumnos<Alumno> { }

    public class _FabAlumnos<T> : _CmpPersonas<T> where T : Alumno
    {
        protected int? Leg = null;
        protected float? Prom = null;

        protected void PromRand()
        {
            Prom = GenAleatorioDeDatos.NumeroAleatorio(11);
        }
        protected void LegRand()
        {
            Leg = GenAleatorioDeDatos.NumeroAleatorio(10000);
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
            Prom = Helper.LeerNumero(1,10,"Promerdio: ");
        }
        protected void LegTeclado()
        {
            Leg = Helper.LeerNumero(0, 99999999, "Legajo: ");
        }
        public new void SetTeclado()
        {
            LegTeclado();
            PromTeclado();
            ((_FabPersonas<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearAlumno();
        }
        public T CrearAlumno()
        {
            Alumno a = new(Nombre, Dni, Leg, Prom);
            if (Criterio != null)
                a.Cmp = (Comparador<Alumno>)Criterio;
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
