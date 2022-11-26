using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Adapter;
using TP.TP6.Clases.Comparables.AlumnoNS;

namespace TP.TP6.Command.ComandosAula
{
    public class AgregarAlumno : ComandoAula, Comando<AdapterAlumno>
    {
        public AgregarAlumno(Aula Au) : base(Au)
        {
        }
        public void Ejecutar(AdapterAlumno a)
        {
            Au.NuevoAlumno(a);
        }
    }
}
