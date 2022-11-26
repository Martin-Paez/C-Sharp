using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP6.Clases.Estrategias;
using TP.TP6.Clases.Utiles;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Clases.Fabricas.Comparables
{
    public class FabAlumnosEstudiosos : _FabAlumnosEstudiosos<AlumnoEstudioso> { }

    public class _FabAlumnosEstudiosos<T> : _CmpAlumnos<T> where T : AlumnoEstudioso
    {
        public new void SetRand()
        {
            ((_FabAlumnos<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearAlumnoEstudioso();
        }
        public new void SetTeclado()
        {
            ((_FabAlumnos<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearAlumnoEstudioso();
        }
        public T CrearAlumnoEstudioso()
        {
            Alumno a = new(Nombre, Dni, Leg, Prom);
            if (Criterio != null)
                a.SetCmp((Comparador<Alumno>)Criterio);
            a = new AlumnoEstudioso(a);
            return (T)(object)a;
        }
        protected override IList<Func<Comparador<T>?>> Comparadores()
        { 
            List<Func<Comparador<T>?>> list = (List<Func<Comparador<T>?>>)base.Comparadores();
            list.Add(() => { return new PorCalif(); });
            return list;
        }
        protected override string CriterioMenu()
        {
            return base.CriterioMenu()
                 + "  5) Calificacion \n";
        }
    }
}
