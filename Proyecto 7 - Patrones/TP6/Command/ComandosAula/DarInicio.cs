using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Command.ComandosAula
{
    public class DarInicio : ComandoAula, Comando
    {
        public DarInicio(Aula Au) : base(Au)
        {
        }
        public void Ejecutar()
        {
            Au.Comenzar();
        }
    }
}
