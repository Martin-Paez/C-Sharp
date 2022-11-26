using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP6.Adapter;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP6.Clases.Comparables.NS.Decoradores.HijoAlumno;
using TP.TP6.Clases.Estrategias;
using TP.TP6.Clases.Utiles;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Clases.Fabricas.Comparables
{
    public class FabDecoAlumno : _FabDecoAlumno<DecoAlumno> { }

    public class _FabDecoAlumno<T> : _FabAlumnos<T> where T : DecoAlumno
    {
        public override T Rand()
        {
            SetRand();
            return CrearStudent();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearStudent();
        }
        public T CrearStudent()
        {
            Alumno a = new Alumno(Nombre, Dni, Leg, Prom);
            if (Criterio != null)
                a.SetCmp((Comparador<Alumno>)Criterio);
            a = new MostrarLegajo(a);
            a = new NotaConLetras(a);
            a = new MostrarEstado(a);
            a = new MostrarMarco(a);
            a = new Enumerar(a);
            return (T)(object)a;
        }
    }
}
