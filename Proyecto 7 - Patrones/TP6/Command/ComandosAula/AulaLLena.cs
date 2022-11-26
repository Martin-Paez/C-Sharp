using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP6.Adapter;
using TP.TP6.Interfaces;

namespace TP.TP6.Command.ComandosAula
{
    public class AulaLLena : ComandoAula, Comando<Coleccionable<AdapterAlumno>>
    {
        public AulaLLena(Aula Au) : base(Au)
        {
        }
        public void Ejecutar(Coleccionable<AdapterAlumno> c)
        {
            Au.ClaseLista(c);
        }
    }
}
