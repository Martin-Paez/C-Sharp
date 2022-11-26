using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Clases.Comparables.AlumnoNS.Composite;
using TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP7.Clases.Fabricas.Comparables;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Fabricas.Compa_rable_rador.Comparables
{
    public class FabCompositeAlumno : FabricaDeComparables<CompositeAlumno<DecoAlumno>> 
    {
        public override CompositeAlumno<DecoAlumno> Rand()
        {
            List<DecoAlumno> alumnos = new();
            for (int i = 0; i < 5; i++)
            {
                DecoAlumno a = FabricaDeComparables<DecoAlumno>.Rand();
                if (Criterio != null)
                    a.SetCmp((Comparador<Alumno>)Criterio);
                alumnos.Add(a);
            }
            return new CompositeAlumno<DecoAlumno>(alumnos);
        }
        public override CompositeAlumno<DecoAlumno> Input()
        {
            List<DecoAlumno> alumnos = new();
            for (int i = 0; i < 5; i++)
            {
                DecoAlumno a = FabricaDeComparables<DecoAlumno>.Input();
                if (Criterio != null)
                    a.SetCmp((Comparador<Alumno>)Criterio);
                alumnos.Add(a);
            }
            return new CompositeAlumno<DecoAlumno>(alumnos);
        }
        public override Comparador<Alumno>? CrearCriterio()
        {
            FabAlumnos a = new FabAlumnos();
            return a.CrearCriterio();
        }
    }
}
