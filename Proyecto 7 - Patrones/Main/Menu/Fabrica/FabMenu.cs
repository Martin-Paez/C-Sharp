using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back;
using TP.Main.Menu.Back.Decoradores;
using TP.Main.Menu.Back.NSMenuBool;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Decoradores;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Fabrica
{
    public class FabMenu
    {
        public static Menu<bool> Crear(Action[] F, string opciones, bool limpiarConsola = true
                                                 , bool pedirTeclaFinal = true, bool bucle = true)
        {
            MenuBool m = new MenuAction(F, UI(opciones, limpiarConsola));
            if (pedirTeclaFinal)
                m = new LeerTeclaAlFinal(m);
            if (bucle)
                m = new Bucle(m);
            return m;
        }
        public static Menu<T> Crear<T>(Func<T>[] F, string opciones, bool limpiarConsola=true)
        {
           return new MenuFunc<T>(F, UI(opciones, limpiarConsola));
        }
        private static IMenuFront UI(string opciones,  bool limpiarConsola)
        {
            if (limpiarConsola)
                return new MenuCmdLimpia(opciones);
            else
                return new MenuConsola(opciones);
        }
    }
}
