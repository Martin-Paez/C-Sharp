using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP6.Clases.Estrategias;
using TP.TP6.Clases.Utiles;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Interfaces.Oberservar;

namespace TP.TP6.Clases.Comparables.VendedorNS
{
    public class Vendedor : Persona, Comparable<Vendedor>, StrategyComparable<Vendedor>, Observable<Observador<Vendedor, int>, int>
    {
        public double? SueldoBasico { get; set; }
        protected new Comparador<Vendedor>? Cmp { get; set; }
        public Observador<Vendedor, int>? UnicoGerente { get; set; }
        public double Bonus { get { return _bonus; } }
        private double _bonus = 1;

        public Vendedor(string? n, int? d, double? s) : base(n, d)
        {
            SueldoBasico = s;
            Cmp = new PorDni();
        }

        public virtual void Venta(int monto)
        {
            Console.WriteLine("Venta: ${0} | Vendedor: {1}", monto, ToString());
            Publicar(monto);
        }
        public void AumentaBonus()
        {
            _bonus += 0.1;
        }
        public bool SosIgual(Vendedor c)
        {
            return Cmp!.Comparar(this, c) == 0;
        }
        public bool SosMayor(Vendedor c)
        {
            return Cmp!.Comparar(this, c) > 0;
        }
        public bool SosMenor(Vendedor c)
        {
            return Cmp!.Comparar(this, c) < 0;
        }
        public override string ToString()
        {
            return base.ToString() + " Sueldo Basico: " + SueldoBasico.ToString() + " Bonus: " + Bonus.ToString();
        }

        public void Publicar(int venta)
        {
            UnicoGerente!.RecibirNotificacion(this, venta);
        }
        public void Suscribir(Observador<Vendedor, int> g)
        {
            UnicoGerente = g;
        }

        public new Comparador<Vendedor>? GetCmp()
        {
            return Cmp;
        }

        public void SetCmp(Comparador<Vendedor>? cmp)
        {
            Cmp = cmp;
        }
    }
}
