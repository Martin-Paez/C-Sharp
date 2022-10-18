using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Estrategias;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Comparables.AlumnoNS.Proxy
{
    // Hereda de Alumno, leer comentario en el constructor
    public class ProxyAlumno : Alumno
    {
        private Alumno? Alu { get; set; }
        // Es mucho mas barato un protected base constructor que refactorizar codigo 
        // para agregar una interfaz (proxy debe ser usado como un Alumno).
        public ProxyAlumno(string? n, int? d, int? l, float? pr) : base()
        {
            // Simulo una creacion de bajo costo
            Prom = pr;
            Leg = l;
            CmpA = new PorDni();
            nombre = n;
            dni = d;
            Cmp = new PorDni();
        }
        public override int Responder(int preg)
        {
            /*
             * Seria interesante agregar aqui la carga pesada, sobre mi mismo, y no sobre
             * un alumno nuevo.
             */
            if (Alu == null) {
                Console.WriteLine("Creando alumno...");
                Thread.Sleep(500);
                Alu = new(Nombre, dni, Leg, Prom);
                Alu.Calif = this.Calif;
            }
            return Alu.Responder(preg);
        }

        public override int? Leg { get { return (Alu == null) ? Leg : Alu.Leg; } set { if (Alu == null) Leg = value; else Alu.Leg = value; } }
        public override int? Calif { get { return (Alu == null) ? Calif : Alu.Calif; } set { if (Alu == null) Calif = value; else Alu.Calif = value; } }
        protected override Comparador<Alumno>? CmpA { get { return (Alu == null) ? CmpA : Alu.GetCmp(); } set { if (Alu == null) CmpA = value; else Alu.SetCmp(value); } }
        public override float? Prom { get { return (Alu == null) ? Prom : Alu.Prom; } set { if (Alu == null) Prom = value; else Alu.Prom = value; } }
        protected override Comparador<Persona>? Cmp { get { return (Alu == null) ? Cmp : ((Persona)Alu).GetCmp(); } set { if (Alu == null) Cmp = value; else ((Persona)Alu).SetCmp(value); } }

        public override Comparador<Alumno>? GetCmp()
        {
            if (Alu != null)
                return Alu.GetCmp();
            return base.GetCmp();
        }
        public override void SetCmp(Comparador<Alumno>? cmp)
        {
            if (Alu != null)
                Alu.SetCmp(cmp);
            else
                base.SetCmp(cmp);
        }
        public override void SetCmp(Comparador<Persona>? cmp)
        {
            CmpA = cmp;
        }

        public override string MostrarCalif()
        {
            if (Alu != null)
                return Alu.MostrarCalif();
            return base.MostrarCalif();
        }
        public override bool SosIgual(Alumno a)
        {
            if (Alu != null)
                return Alu.SosIgual(a);
            return base.SosIgual(a);
        }
        public override bool SosMayor(Alumno a)
        {
            if (Alu != null)
                return Alu.SosMayor(a);
            return base.SosMayor(a);
        }
        public override bool SosMenor(Alumno a)
        {
            if (Alu != null)
                return Alu.SosMenor(a);
            return base.SosMenor(a);
        }
        public override string ToString()
        {
            if (Alu != null)
                return Alu.ToString();
            return base.ToString();
        }

        // Por si castean el proxy

        public override bool SosIgual(Persona a)
        {
            if (Alu != null)
                return Alu.SosIgual(a);
            return base.SosIgual(a);
        }
        public override bool SosMayor(Persona a)
        {
            if (Alu != null)
                return Alu.SosMayor(a);
            return base.SosMayor(a);
        }
        public override bool SosMenor(Persona a)
        {
            if (Alu != null)
                return Alu.SosMenor(a);
            return base.SosMenor(a);
        }
    }
}
