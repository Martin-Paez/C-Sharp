using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Adapter;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Interfaces;

namespace TP.TP6.Command
{
    public class Aula
    {
        public Teacher? Prof { get; set; }
        public void Comenzar()
        {
            Prof = new Teacher();
            Console.WriteLine("Comenzando la clase...\n");
        }
        public void NuevoAlumno(AdapterAlumno a)
        {   // Opto por una nueva implementacion 
            //Prof!.goToClass(new AdapterAlumno(a));
            if (Prof == null)
                throw new Exception("No se dio inicio a la clase");
            Console.WriteLine("         {0} inscripto", a.getName());
        }
        public void ClaseLista(Coleccionable<AdapterAlumno> c)
        {
            if (Prof == null)
                throw new Exception("No se dio inicio a la clase");
            Prof.setStudents(new AdapterColeccionable(c));
            Console.WriteLine("\n");
            Prof.teachingAClass();
        }
    }
}
