using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP5.Clases.Utiles
{
    public class LectorDeDatos
    {
        static public int NumeroPorTeclado(string etiqueta)
        {
            while (true)
            {
                Console.WriteLine(etiqueta);
                try
                {
                    return int.Parse(Console.ReadLine()!);
                }
                catch(Exception)
                {
                    Console.WriteLine("Dato invalido");
                }
            }
        }
        static public string StringPorTeclado(string etiqueta)
        {
            Console.WriteLine(etiqueta);
            return Console.ReadLine()!;
        }
    }
}
