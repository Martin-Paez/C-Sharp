using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno
{
    // Hubo que agregar virtual y override por todos lados
    public class DecoAlumno : Alumno, StrategyComparable<Alumno>
    {
        public Alumno Alu { get; set; } = new Alumno("", 0, 0, 0);
        public DecoAlumno(Alumno Alu) : base(Alu.Nombre, Alu.Dni, Alu.Leg, Alu.Prom)
        {
            this.Alu = Alu;
        }

        public  override int? Leg { get { return Alu.Leg; } set { Alu.Leg = value; } }
        public  override int? Calif { get { return Alu.Calif; } set { Alu.Calif = value; } }
        protected  override Comparador<Persona>? Cmp { get { return ((Persona)Alu).GetCmp(); } set { ((Persona)Alu).SetCmp(value); } }
        protected  override Comparador<Alumno>? CmpA { get { return Alu.GetCmp(); } set { Alu.SetCmp(value); } }
        public  override float? Prom { get { return Alu.Prom; } set { Alu.Prom = value; } }
        public  override string? Nombre { get { return Alu.Nombre; } }
        public  override int? Dni { get { return Alu.Dni; } }

        public override Comparador<Persona>? GetCmp()
        {
            return ((Persona)Alu).GetCmp();
        }
        public override void SetCmp(Comparador<Persona>? cmp)
        {
            ((Persona)Alu).SetCmp(cmp);
        }
        public override void SetCmp(Comparador<Alumno>? cmp)
        {
            Alu.SetCmp(cmp);
        }
        Comparador<Alumno>? StrategyComparable<Alumno>.GetCmp()
        {
            return Alu.GetCmp();
        }

        public override bool SosIgual(Persona c)
        {
            return ((Persona)Alu).SosIgual(c);
        }
        public override bool SosIgual(Alumno c)
        {
            return Alu.SosIgual(c);
        }
        public override bool SosMayor(Persona c)
        {
            return ((Persona)Alu).SosMayor(c);
        }
        public override bool SosMayor(Alumno c)
        {
            return Alu.SosMayor(c);
        }
        public override bool SosMenor(Persona c)
        {
            return ((Persona)Alu).SosMenor(c);
        }
        public override bool SosMenor(Alumno c)
        {
            return Alu.SosMenor(c);
        }

        public override string ToString()
        {
            return Alu.ToString();
        }

        public override int Responder(int preg)
        {
            return Alu.Responder(preg);
        }
        public override string MostrarCalif()
        {
            return Alu.MostrarCalif();
        }
    }
}
