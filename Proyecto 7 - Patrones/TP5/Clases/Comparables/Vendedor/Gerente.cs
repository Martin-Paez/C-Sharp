using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP5.Clases.Comparables.XD;
using TP.TP5.Clases.Fabricas.Comparables;
using TP.TP5.Colecciones;
using TP.TP5.Interfaces;
using TP.TP5.Interfaces.Iterador;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Clases.Comparables.VendedorNS
{
    public class Gerente : Enojado<Gerente>, Observador<Vendedor, int>
    {
        private Conjunto<Vendedor> Mejores { get; set; } = new Conjunto<Vendedor>();

        public Gerente(string? n, int? d) : base(n, d)
        {
        }
        public void Cerrar()
        {
            Console.WriteLine("\nMejores vendedores de la jornada:\n"
                              + "---------------------------------\n");
            Iterador<Vendedor> itr = Mejores.crearItr();
            while (itr.Sig())
                Console.WriteLine(itr.Elem());
            Mejores = new();
        }
        public void venta(int monto, Vendedor v)
        {
            if (monto > 5000)
            {
                Mejores.Agregar(v);
                v.AumentaBonus();
            }
        }
        public override void Reaccionar()
        {
            Console.WriteLine("{0} (Gerente): Venga... Venga... PUNCH !! ", Nombre);
        }
        public void RecibirNotificacion(Vendedor v, int monto)
        {
            venta(monto, v);
        }
    }
}
