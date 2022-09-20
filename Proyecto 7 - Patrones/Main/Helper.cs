using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP.Main
{
    public class Helper
    {
        public static string GetTypeName<T>(T e)
        {
            string nombre = e!.GetType().Name;
            return nombre.Substring(0, nombre.Length - 2);
        }
        public static string Leer(string etiqueta)
        {
            Console.Write(etiqueta);
            string? o;
            while ((o = Console.ReadLine()) == null) ;
            return o!;
        }
        public static string LeerLetras(string etiqueta)
        {
            string o;
            while(! Regex.IsMatch(o = Helper.Leer(etiqueta), @"^[a-zA-Z]+$"))
                Console.WriteLine("Solo se admiten letras");
            return o;
        }
        public static int LeerNumero(int min, int max, string etiqueta)
        {
            int o;
            do
            {
                try
                {
                    string s = Helper.Leer(etiqueta);
                    o = int.Parse(QuitarPuntos(s));
                    if (o < min || o > 200000000)
                        throw new Exception();
                    return o;
                }
                catch (Exception)
                {
                    Console.WriteLine("{0}debe ser un numero mayor a 1000000 y menor a 200000000", etiqueta);
                }
            } while (true);
        }
        public static string QuitarPuntos(string num)
        {
            int p = 0, c = num.Length;
            for (int i = 3; i < c - p; i += 4)
                num.Replace('.', '\0');
            return num;
        }
    }
}
