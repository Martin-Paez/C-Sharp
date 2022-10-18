using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.ImpIAlumno
{
    public interface IPersona : Comparable<Persona>, StrategyComparable<Persona>
    {
        public string? Nombre { get; }
        public int? Dni { get; }
        protected Comparador<Persona>? Cmp { get; set; }
    }

    public interface IAlumno :  IPersona, Comparable<Alumno>, StrategyComparable<Alumno>
    {
        public int? Leg { get; set; }
        public int? Calif { get; set; }
        protected Comparador<Alumno>? CmpA { get; set; }
        public float? Prom { get; set; }

        public int Responder(int preg);
        public string MostrarCalif();
        public string ToString();
    }
}
