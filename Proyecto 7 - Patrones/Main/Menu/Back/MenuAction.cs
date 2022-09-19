using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Front.Interfaces;
using TP.Main.NSMenu.Back;

namespace TP.Main.Menu.Back
{
    public class MenuAction : Menu<int, Action>
    {
        public override IList<Action> F { get; set; }

        public MenuAction(IList<Action> F, IMenuFront mf) : base(mf)
        {
            this.F = F;
        }
        public override int Ejecutar()
        {
            int opt = mf.GetOpcionValida(F.Count);
            F![opt]();
            return opt;
        }
    }
}
