using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back.Decoradores;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Decoradores
{
    public class LeerTeclaAlFinal<T,M> : DMenu<T,M> where M : Delegate
    {
        public LeerTeclaAlFinal(Menu<T,M> m) : base(m) { }
       
        public override T? Ejecutar()
        {
            T? o = m.Ejecutar();
            Console.WriteLine("\nPresione cualquier tecla para continuar.");
            Console.ReadKey();
            return o;
        }
    }
}
