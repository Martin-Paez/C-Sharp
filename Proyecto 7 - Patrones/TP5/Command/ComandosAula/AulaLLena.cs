using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP5.Adapter;
using TP.TP5.Interfaces;

namespace TP.TP5.Command.ComandosAula
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
