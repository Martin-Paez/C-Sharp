using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Front.Interfaces
{
    public interface IMenuConsola : IMenuFront
    {
        string Opciones { get; set; }
        char ElegirOpcion();
        int Interpretar(char opt, int max);
    }
}
