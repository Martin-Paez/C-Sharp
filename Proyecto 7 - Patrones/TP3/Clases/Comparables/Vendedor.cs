using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP3.Clases.Comparables;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces.Oberservar;

namespace TP.TP3.Clases
{
    public class Vendedor : Persona, Comparable<Vendedor>, StrategyComparable<Vendedor>, Suscribible<Notificable<Vendedor, int>, int>
    {
        public double? SueldoBasico { get; set; }
        public new Comparador<Vendedor>? Cmp { get; set; }
        public Notificable<Vendedor,int>? UnicoGerente { get; set; }
        public double Bonus { get { return _bonus;  } }
        private double _bonus = 1;

        public Vendedor(string? n, int? d, double? s) : base(n, d) 
        {
            this.SueldoBasico = s;
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
        public void Suscribir(Notificable<Vendedor, int> g)
        {
            UnicoGerente = g;
        }
    }
}
