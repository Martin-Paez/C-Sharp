using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Clases.Fabricas
{
    public class CmpPersonas : _CmpPersonas<Persona> { }

    public class _CmpPersonas<T> : _FabPersonas<T> where T : Persona
    {
        public override void SetRand()
        {
            DniRand();
        }
    }
}
