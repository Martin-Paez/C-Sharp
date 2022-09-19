using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back;
using TP.Main.Menu.Back.Decoradores;
using TP.Main.Menu.Front;
using TP.Main.Menu.Front.Decoradores;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Decoradores;
using TP.Main.NSMenu.Front;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Fabrica
{
    public class FabMenu
    {
        public static Menu<int, Action> Crear(IList<Action> F
               , string opciones, bool limpiarConsola = true, bool opcionSalir = true
               , bool leerTeclaPosEjecutar = true, bool bucle = true, bool pedirTeclaPosBucle = false)
        {
            IMenuFront mf = ConsolaUI(opciones, limpiarConsola, opcionSalir);
            Menu<int,Action> m = new MenuAction(F,mf);
            Decorar(ref m, leerTeclaPosEjecutar, bucle, F.Count, () => { }, pedirTeclaPosBucle);
            return m;
        }
        public static Menu<T, Func<T?>> Crear<T>(IList<Func<T?>> F
               , string opciones, bool limpiarConsola=false, bool opcionSalir = false
               , bool leerTeclaPosEjecutar = false, bool bucle = false, T? fin = default, bool pedirTeclaPosBucle = false)
        {
            IMenuFront mf = ConsolaUI(opciones, limpiarConsola, opcionSalir);
            Menu<T,Func<T?>> m = new MenuFunc<T>(F,mf);
            Decorar(ref m, leerTeclaPosEjecutar, bucle, fin, () => { return fin; }, pedirTeclaPosBucle);
            return m;
        }
        private static IMenuFront ConsolaUI(string opciones,  bool limpiarConsola, bool opcionSalir=true)
        {
            MenuFront mf = new MenuConsola(opciones);
            if (opcionSalir)
                mf = new OpcionSalir(mf);
            if (limpiarConsola)
                mf = new ConsolaLimpia(mf);
            return mf;
        }
        private static void Decorar<T, M>(ref Menu<T, M> m, bool leerTeclaPosEjecutar = true, bool bucle = true
                , T? fin = default, M? finDelBucle = default , bool pedirTeclaPosBucle = false) where M : Delegate
        {
            if (leerTeclaPosEjecutar)
                m = new LeerTeclaAlFinal<T, M>(m);
            if (bucle && fin != null && finDelBucle != null)
                m = new Bucle<T, M>(m, fin, finDelBucle);
            if (pedirTeclaPosBucle)
                m = new LeerTeclaAlFinal<T, M>(m);
        }
    }
}
