using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP7.Adapter;
using TP.TP7.Interfaces;

namespace TP.TP7.Command.ComandosAula
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
