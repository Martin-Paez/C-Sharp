using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces;

namespace TP.TP7.Adapter
{
    public class AdapterColeccionable : Collection
    {
        private Coleccionable<AdapterAlumno> c;

        public AdapterColeccionable(Coleccionable<AdapterAlumno> c)
        {
            this.c = c;
        }

        public void addStudent(Student student)
        {
            c.Agregar((AdapterAlumno)student);
        }

        public IteratorOfStudent getIterator()
        {
            return new AdapterIterator(c.crearItr());
        }

        public void sort()
        {
            c.Ordenar(new StudentComparer());
        }
    }

}
