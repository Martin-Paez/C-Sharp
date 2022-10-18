using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP.TP4.Clases.Utiles
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
            while (!Regex.IsMatch(o = Leer(etiqueta), @"^[a-zA-Z]+$"))
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
                    string s = Leer(etiqueta);
                    o = int.Parse(QuitarPuntos(s));
                    if (o < min || o > 200000000)
                        throw new Exception();
                    return o;
                }
                catch (Exception)
                {
                    Console.WriteLine("{0} debe ser un numero >= a {1} y <= a {2}", etiqueta, min, max);
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
        public static DateTime LeerFecha(DateTime min, DateTime max, string etiqueta)
        {
            DateTime date = DateTime.Now;
            do
            {
                Console.WriteLine("Se espera que ingrese una fecha >= a {0} y <= a {1}", min, max);
                string d = Leer(etiqueta);
                try
                {
                    date = DateTime.Parse(d);
                }
                catch (Exception)
                {
                    Console.WriteLine("Formato invalido. Intente con mm/dd/aaaa");
                }
            }
            while (date.CompareTo(min) < 0 || date.CompareTo(max) > 0);
            return date;
        }
    }
}
