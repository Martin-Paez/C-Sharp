using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Utiles
{
    public class Helper
    {
        public static string GenNombre()
        {
            string[] n = new string[12] { "Pablo", "Juan", "Victoria", "Neyen", "Carlos"
                   , "Tomas", "Brian", "Sofia", "Abril", "Gonzalo", "Tomas", "Romina" };
            return n[new Random().Next(0, 11)];
        }
        public static int GenDni()
        {
            return new Random().Next(2000000, 400000000);
        }
        public static string? Leer(string tag)
        {
            Console.Write(tag);
            return Console.ReadLine();
        }
        public static int LeerNum(string tag)
        {
            while (true)
            {
                Console.Write(tag);
                try
                {
                    int n = int.Parse(Console.ReadLine()!);
                    return n;
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor invalido");
                }
            }
        }
    }
}
