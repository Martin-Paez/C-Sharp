using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Main
{
    public class Menu
    {
        public static T? run<T>(ref Func<T> [] f, string menu, bool mostrarFin = true, bool soloUnaVez = false
                                , bool borrarPantalla = true)
        {
            while (true)
            {
                if (borrarPantalla)
                    Console.Clear();
                Console.Write(menu + "\nOpcion: ");
                char? opt = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (borrarPantalla) 
                    Console.Clear();
                if (opt == 's' || opt == 'S')
                    return default;
                if ((opt = (char?)(opt - '0' - 1)) >= 0 && opt < f.Length)
                {
                    T o = f[(int)opt]();
                    if (mostrarFin)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para voler al menu");
                        Console.ReadKey();
                    }
                    if (soloUnaVez)
                        return o;
                }
                else
                    Console.WriteLine("\nOpcion invalida\n");
            }
        }
    }
}
