using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;
using TP.Main.NSMenu.Back;

namespace TP.Main.Menu.Back.NSMenuBool
{
    public class MenuAction : MenuBool
    {
        protected IList<Action> F { get; set; }

        public MenuAction(IList<Action> F, IMenuFront mf) : base(mf)
        {
            this.F = F;
        }
        public override bool Ejecutar()
        {
            int i = m.Run(F.Count);
            if (i < 0)
                return false;
            F![i]();
            return true;
        }
    }
}
