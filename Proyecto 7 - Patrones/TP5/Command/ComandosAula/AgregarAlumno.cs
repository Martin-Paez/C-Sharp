using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Adapter;
using TP.TP5.Clases.Comparables.AlumnoNS;

namespace TP.TP5.Command.ComandosAula
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
