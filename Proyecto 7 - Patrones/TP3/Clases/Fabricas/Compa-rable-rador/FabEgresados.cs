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
            int dia,mes,anio;
            dia = GenAleatoriosDeDatos.NumeroAleatorio(31);
            mes = GenAleatoriosDeDatos.NumeroAleatorio(12);
            anio = GenAleatoriosDeDatos.NumeroAleatorio(DateTime.Now.Year,1900);
            string fecha = anio.ToString();
            fecha += (mes < 10) ? "0" : "";
            fecha += mes.ToString();
            fecha += (dia < 10) ? "0" : "";
            fecha += dia.ToString();
            DateTime.TryParseExact(fecha, "yyyyMMdd"
                         , CultureInfo.InvariantCulture
                         , DateTimeStyles.None, out Egreso);
        }
        public new void SetRand()
        {
            EgresoRand();
            ((_FabAlumnos<T>)this).SetRand();
        }
        protected override T Rand()
        {
            SetRand();
            Egresado a = new(Nombre, Dni, Leg, Prom, Egreso);
            if (Criterio != null)
                a.Cmp = (Comparador<Egresado>)Criterio;
            return (T)(object)a;
        }
        protected override IList<Func<Comparador<T>>> Comparadores()
        {
            List<Func<Comparador<T>>> list = (List<Func<Comparador<T>>>)base.Comparadores();
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
