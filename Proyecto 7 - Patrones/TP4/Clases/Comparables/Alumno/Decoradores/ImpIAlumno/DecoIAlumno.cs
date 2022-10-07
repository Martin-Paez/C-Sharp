using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Interfaces.Comparar;

namespace TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.ImpIAlumno
{
    public class DecoIAlumno : IAlumno
    {
        public Alumno Alu { get; set; }
        public DecoIAlumno(Alumno Alu)
        {
            this.Alu = Alu;
        }

        public int? Leg { get { return Alu.Leg; } set { Alu.Leg = value; } }
        public int? Calif { get { return Alu.Calif; } set { Alu.Calif = value; } }
        Comparador<Alumno>? IAlumno.CmpA { get { return Alu.GetCmp(); } set { Alu.SetCmp(value); } }
        public float? Prom { get { return Alu.Prom; } set { Alu.Prom = value; } }
        public string? Nombre { get { return Alu.Nombre; } }
        public int? Dni { get { return Alu.Dni; } }
        Comparador<Persona>? IPersona.Cmp { get { return ((Persona)Alu).GetCmp(); } set { ((Persona)Alu).SetCmp(value); } }

        public Comparador<Persona>? GetCmp()
        {
            return ((Persona)Alu).GetCmp();
        }
        public void SetCmp(Comparador<Persona>? cmp)
        {
            ((Persona)Alu).SetCmp(cmp);
        }
        public void SetCmp(Comparador<Alumno>? cmp)
        {
            Alu.SetCmp(cmp);
        }
        Comparador<Alumno>? StrategyComparable<Alumno>.GetCmp()
        {
            return Alu.GetCmp();
        }

        public bool SosIgual(Persona c)
        {
            return ((Persona)Alu).SosIgual(c);
        }
        public bool SosIgual(Alumno c)
        {
            return Alu.SosIgual(c);
        }
        public bool SosMayor(Persona c)
        {
            return ((Persona)Alu).SosMayor(c);
        }
        public bool SosMayor(Alumno c)
        {
            return Alu.SosMayor(c);
        }
        public bool SosMenor(Persona c)
        {
            return ((Persona)Alu).SosMenor(c);
        }
        public bool SosMenor(Alumno c)
        {
            return Alu.SosMenor(c);
        }

        public override string ToString()
        {
            return Alu.ToString();
        }

        public int Responder(int preg)
        {
            return Alu.Responder(preg);
        }
        public string MostrarCalif()
        {
            return Alu.MostrarCalif();
        }
    }
}
