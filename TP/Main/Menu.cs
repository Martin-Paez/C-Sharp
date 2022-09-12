using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Main
{
    public class Menu
    {
        public static void run(ref Func<bool> [] f, string menu)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(menu);
                char? opt = Console.ReadKey().KeyChar;
                Console.Clear();
                if (opt == 's' || opt == 'S')
                    return;
                if ((opt = (char?)(opt - '0' - 1)) >= 0 && opt < f.Length)
                    if (f[(int)opt]())
                    {
                        Console.WriteLine("\nPresione cualquier tecla para voler al menu");
                        Console.ReadKey();
                    }
                else
                    Console.WriteLine("\nOpcion invalida\n");
            }
        }
    }
}
