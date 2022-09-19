using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back;
using TP.Main.Menu.Back.Decoradores;
using TP.Main.Menu.Back.NSMenuBool;
using TP.Main.Menu.Front.Decoradores;
using TP.Main.Menu.Front.Interfaces;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Decoradores;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Fabrica
{
    public class FabMenu
    {
        //TODO pedirTecla podria pedirse un valor que requiera un proceso extenso de intercambio con el usuario
        //TODO para el bucle con Func<T>, se podrian guardar los valores en una lista y se retorna la lista al salir
        public static Menu<bool> Crear(IList<Action> F, string opciones, bool limpiarConsola = true
                                                 , bool pedirTeclaFinal = true, bool bucle = true
                                                 , bool opcionSalir = true)
        {
            MenuBool m = new MenuAction(F, UI(opciones, limpiarConsola, opcionSalir));
            if (pedirTeclaFinal)
                m = new LeerTeclaAlFinal(m);
            if (bucle)
                m = new Bucle(m);
            return m;
        }
        public static Menu<T> Crear<T>(IList<Func<T>> F, string opciones, bool limpiarConsola=true)
        {
           return new MenuFunc<T>(F, UI(opciones, limpiarConsola));
        }
        private static IMenuFront UI(string opciones,  bool limpiarConsola, bool opcionSalir=true)
        {
            IMenuConsola mf = new MenuConsola(opciones);
            if (limpiarConsola)
                mf = new ConsolaLimpia(mf);
            if (opcionSalir)
                mf = new OpcionSalir(mf);
            return mf;
        }
    }
}
