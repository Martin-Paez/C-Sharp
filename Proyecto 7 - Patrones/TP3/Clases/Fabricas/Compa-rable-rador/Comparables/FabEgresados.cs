using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Fabricas.Comparables;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas
{
    public class FabEgresados : _FabEgresados<Egresado> { }

    public class _FabEgresados<T> : _CmpAlumnos<T> where T : Egresado
    {
        protected DateTime Egreso;

        protected void EgresoRand()
        {
            Egreso = GenAleatoriosDeDatos.FechaAleatoria();
        }
        public new void SetRand()
        {
            EgresoRand();
            ((_FabAlumnos<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearEgresado();
        }
        protected void EgresoTeclado()
        {
            Egreso = Helper.LeerFecha(DateTime.Parse("01/01/1900"),DateTime.Now,"Fecha de Egreso: ");
        }
        public new void SetTeclado()
        {
            EgresoTeclado();
            ((_FabAlumnos<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearEgresado();
        }
        public T CrearEgresado()
        {
            Egresado a = new(Nombre, Dni, Leg, Prom, Egreso);
            if (Criterio != null)
                a.Cmp = (Comparador<Egresado>)Criterio;
            return (T)(object)a;
        }
        protected override IList<Func<Comparador<T>?>> Comparadores()
        {
            List<Func<Comparador<T>?>> list = (List<Func<Comparador<T>?>>)base.Comparadores();
            list.Add(() => { return new PorEgreso(); });
            return list;
        }
        protected override string CriterioMenu()
        {
            return base.CriterioMenu()
                 + "  5) Egreso  \n";
        }
    }
}
