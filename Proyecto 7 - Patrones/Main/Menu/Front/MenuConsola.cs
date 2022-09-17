using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Front
{
    public class MenuConsola : IMenuFront
    {
        public string Opciones { get; }

        public MenuConsola(string opciones)
        {
            Opciones = opciones;
        }

        public virtual char Mostrar()
        {
            Console.Write(Opciones + "\nOpcion: ");
            char opt = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return opt;
        }
        public int Seleccionar(int max)
        {
            while (true)
            {
                char opt = Mostrar();
                if (opt == 's' || opt == 'S')
                    return -1;
                int i = opt - '0' - 1;
                if (i >= 0 && i < max)
                    return i;
            }
        }
    }
}
