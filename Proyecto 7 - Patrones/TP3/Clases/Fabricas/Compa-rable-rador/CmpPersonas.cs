using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas.Comparables
{
    public class CmpPersonas : _CmpPersonas<Persona> { }

    public class _CmpPersonas<T> : _FabPersonas<T> where T : Persona
    {
        public new void SetRand()
        {
            if (Criterio is PorNom)
                NombreRand();
            else if (Criterio is PorDni)
                DniRand();
        }
    }
}
