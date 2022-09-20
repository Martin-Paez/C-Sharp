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
            Prom = GenAleatoriosDeDatos.NumeroAleatorio(11);
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
        public override T Rand()
        {
            SetRand();
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
