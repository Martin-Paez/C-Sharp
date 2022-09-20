using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases
{
    public class Vendedor : Persona, Comparable<Vendedor>, StrategyComparable<Vendedor>
    {
        public double? SueldoBasico { get; set; }
        public new Comparador<Vendedor>? Cmp { get; set; }
        private double _bonus = 1;
        public double Bonus { get { return _bonus;  } }
        public Vendedor(string? n, int? d, double? s) : base(n, d) 
        {
            this.SueldoBasico = s;
            Cmp = new PorBonus();
        }
        public void Venta(int monto)
        {
            Console.WriteLine("Venta: ${0}", monto);
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
    }
}
