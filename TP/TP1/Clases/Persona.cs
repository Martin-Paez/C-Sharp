using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;

namespace TP.TP1.Clases
{
    public class Persona : Comparable
    {
        private string nombre;
        private int? dni;

        public Persona(string n, int? d)
        {
            nombre = n;
            dni = d;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int? GetDni()
        {
            return dni;
        }

        public virtual bool SosIgual(Comparable p)
        {
            return dni == ((Persona)p).GetDni();
        }

        public virtual bool SosMayor(Comparable p)
        {
            return dni > ((Persona)p).GetDni();
        }

        public virtual bool SosMenor(Comparable p)
        {
            return dni < ((Persona)p).GetDni();
        }

        public override string ToString()
        {
            string s = GetNombre();
            if (dni != null)
                s += " DNI: " + GetDni().ToString();
            return s;
        }

    }

}
