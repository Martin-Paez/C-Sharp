using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.VendedorNS;
using TP.TP5.Clases.Utiles;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Clases.Comparables.XD
{
    public class VendedorPauperrimo : Vendedor, Suscribible<Notificable<Cliente>>, Suscribible<Notificable<Seguridad>>
                                              , Suscribible<Notificable<Gerente>>
    {
        private List<Notificable<Cliente>> histericos = new();
        private List<Notificable<Gerente>> negreros = new();
        private List<Notificable<Seguridad>> fachos = new();

        public VendedorPauperrimo(string? n, int? d, double? s) : base(n, d, s)
        {
        }
        public void robar()
        {
            Console.WriteLine("Robado: ${0}", GenAleatorioDeDatos.NumeroAleatorio(5000, 100));
            HacerlaMal(fachos);
        }
        public void molestar()
        {
            Console.WriteLine("Compañeros distraidos: {0}", GenAleatorioDeDatos.NumeroAleatorio(5, 1));
            HacerlaMal(negreros);
        }
        public void descansar()
        {
            Console.WriteLine("Descanso: ${0} minutos", GenAleatorioDeDatos.NumeroAleatorio(59, 10));
            HacerlaMal(histericos);
        }
        public override void Venta(int monto)
        {
            base.Venta(monto);
            if (monto < 500)
                robar();
            else if (monto < 4000)
                molestar();
            else
                descansar();
        }

        public void Suscribir(Notificable<Cliente> s)
        {
            histericos.Add(s);
        }
        public void Suscribir(Notificable<Seguridad> s)
        {
            fachos.Add(s);
        }
        public void Suscribir(Notificable<Gerente> s)
        {
            negreros.Add(s);
        }
        public void Publicar()
        {
            Console.WriteLine("¿Que te pensas?, ¿que voy a andar contando todo lo que hago? , Melon!!,  jajajajja");
        }
        private void HacerlaMal<T>(List<Notificable<T>> entrometidos)
        {
            foreach (Notificable<T> ortiba in entrometidos)
                ortiba.RecibirNotificacion();
        }
    }
}
