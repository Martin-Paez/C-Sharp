using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Back;
using TP.Main.NSMenu.Front.Interfaces;

namespace TP.Main.Menu.Back.NSMenuBool
{
    public abstract class MenuBool : Menu<bool>
    {
        public MenuBool(IMenuFront mf) : base(mf) { }
    }
}
