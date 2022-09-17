using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.Menu.Back.NSMenuBool;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.NSMenu.Decoradores
{
    public class LeerTeclaAlFinal : MenuBool
    {
        public MenuBool mm { get; set; }
        
        public LeerTeclaAlFinal(MenuBool m) : base(m.m) 
        {
            this.mm = m;
        }
       
        public override bool Ejecutar()
        {
            if (!mm.Ejecutar())
                return false;
            Console.WriteLine("\nPresione cualquier tecla para voler al menu");
            Console.ReadKey();
            return true;
        }
    }
}
