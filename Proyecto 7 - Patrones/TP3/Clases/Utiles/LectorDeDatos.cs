using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Clases.Utiles
{
    public class LectorDeDatos
    {
        public Numero numeroPorTeclado()
        {
            while (true)
            {
                Console.WriteLine("Numero: ");
                try
                {
                    return new Numero(int.Parse(Console.ReadLine()!));
                }
                catch(Exception)
                {
                    Console.WriteLine("Dato invalido");
                }
            }
        }
        public string stringPorTeclado()
        {
            Console.WriteLine("Texto: ");
            return Console.ReadLine()!;
        }
    }
}
