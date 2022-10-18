using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.AlumnoNS;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores;
using TP.TP4.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumnoAbst;
using TP.TP4.Interfaces.Comparar;

namespace TP.TP4.Adapter
{
    public class AdapterAlumno : Student, Comparable<AdapterAlumno>
    {
        public Alumno Alu { get; }

        public AdapterAlumno(Alumno a)
        {
            this.Alu = a;
        }

        public bool equals(Student student)
        {
            if(student is AdapterAlumno)
                return Alu.SosIgual(((AdapterAlumno)student).Alu);
            return student.equals(this);
        }

        public string getName()
        {
            return (Alu.Nombre==null)?"null" : Alu.Nombre;
        }

        public bool greaterThan(Student student)
        {
            if (student is AdapterAlumno)
                return Alu.SosMayor(((AdapterAlumno)student).Alu);
            return ! student.greaterThan(this);
        }

        public bool lessThan(Student student)
        {
            if (student is AdapterAlumno)
                return Alu.SosMenor(((AdapterAlumno)student).Alu);
            return ! student.lessThan(this);
        }

        public void setScore(int score)
        {
            Alu.Calif = score;
        }

        public string showResult()
        {
            return Alu.MostrarCalif();
        }

        public int yourAnswerIs(int question)
        {
            return Alu.Responder(question);
        }

        public bool SosIgual(Student c)
        {
            throw new NotImplementedException();
        }

        public bool SosMayor(Student c)
        {
            throw new NotImplementedException();
        }

        public bool SosMenor(Student c)
        {
            throw new NotImplementedException();
        }

        public bool SosIgual(AdapterAlumno c)
        {
            throw new NotImplementedException();
        }

        public bool SosMayor(AdapterAlumno c)
        {
            throw new NotImplementedException();
        }

        public bool SosMenor(AdapterAlumno c)
        {
            throw new NotImplementedException();
        }
    }
}
