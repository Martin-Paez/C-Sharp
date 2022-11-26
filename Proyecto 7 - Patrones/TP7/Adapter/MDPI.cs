/*
 * Created by Metodologías de Programación I
 * Activity 4. 
 * Adpater and Decorator patterns 
 *
 * IMPORTANTE *  
 * El código que está en este archivo NO debe modificarse en lo absluto para resolver la actividad solicitada
 * 
 */

using System;
using System.Collections.Generic;
using TP.TP1.Interfaces;
using TP.TP7.Interfaces.Iterador;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Interfaces;

namespace TP.TP7.Adapter
{
    public interface Student
    {
        string getName();
        int yourAnswerIs(int question);
        void setScore(int score);
        string showResult();
        bool equals(Student student);
        bool lessThan(Student student);
        bool greaterThan(Student student);
    }

    public interface Collection
    {
        IteratorOfStudent getIterator();
        void addStudent(Student student);
        void sort();
    }

    public interface IteratorOfStudent
    {
        void beginning();
        Student current();
        bool next();
    }

    internal class ListOfStudent : Collection
    {
        private List<Student> list = new List<Student>();

        public IteratorOfStudent getIterator()
        {
            return new ListOfStudentIterator(list);
        }

        public void addStudent(Student student)
        {
            list.Add(student);
        }

        public void sort()
        {
            list.Sort(new StudentComparer());
        }
    }

    internal class AdapterIterator : IteratorOfStudent
    {
        private Iterador<AdapterAlumno> itr;
        public AdapterIterator(Iterador<AdapterAlumno> itr)
        {
            this.itr = itr;
        }
        public void beginning()
        {
            itr.Primero();
        }

        public Student current()
        {
            return itr.Elem();
        }

        public bool next()
        {
            return itr.Sig();
        }
    }

    internal class ListOfStudentIterator : IteratorOfStudent
    {
        private List<Student> list;
        private int index=-1;

        public ListOfStudentIterator(List<Student> _list)
        {
            list = _list;
        }

        public void beginning()
        {
            index = -1;
        }

        public Student current()
        {
            return list[index];
        }

        public bool next()
        {
            bool ok = index != list.Count - 1;
            // si sumo de mas, cuando agreguen un elemento a la lista me lo pierdo
            if (ok)
                index++;
            return ok;
        }
    }

    internal class StudentComparer : IComparer<Student>
    {
        public int Compare(Student? s1, Student? s2)
        {
            if (s1 == null || s2 == null)
                return -1;
            if (s1.equals(s2))
                return 0;
            else
            if (s1.lessThan(s2))
                return 1;
            else
                return -1;
        }
    }

    public class Teacher
    {
        private Collection students;

        public Teacher()
        {
            students = new ListOfStudent();
        }

        public void setStudents(Collection _students)
        {
            students = _students;
        }

        public void goToClass(Student student)
        {
            students.addStudent(student);
        }

        public void teachingAClass()
        {
            Student student;
            IteratorOfStudent iterator = students.getIterator();

            // Pasar lista
            Console.WriteLine("Good morning\n\n");
            Console.WriteLine("I'm going to take attendance");
            iterator.beginning();
            while (iterator.next())
            {
                student = iterator.current();
                Console.WriteLine("\t" + student.getName() + " is present");
            }
            Console.WriteLine("\n\n");

            // tomar examen
            Console.WriteLine("I'm going to take an exam");
            iterator.beginning();
            while (iterator.next())
            {
                student = iterator.current();
                takeAnExam(student);
            }
            Console.WriteLine("\n\n");

            // mostrar resultado
            Console.WriteLine("Exam results");
            students.sort();
            iterator.beginning();
            while (iterator.next())
            {
                student = iterator.current();
                Console.WriteLine(student.showResult() + "\n");
            }
        }

        private void takeAnExam(Student student)
        {
            int hit = 0;
            for (int i = 0; i < 10; i++)
            {
                int answer = student.yourAnswerIs(i);
                if (answer == i % 3)
                    hit++;
            }
            student.setScore((hit==0)?1:hit);

            Console.WriteLine("\t" + student.getName() + "'s score is " + hit.ToString());
        }
    }
}
