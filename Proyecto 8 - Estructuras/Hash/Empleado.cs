using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Arbol_Binario.Utiles;

namespace TP1_Arbol_Binario.Hash
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }

        public Empleado(string n, int dni, int id)
        {   
            Id = id;
            Nombre = n;
            Dni = dni;
        }
        public override int GetHashCode()
        {
            return Dni;
        }
        public override string ToString()
        {
            return Nombre.ToString() + " DNI: " + Dni.ToString() + " Id: " + Id; 
        }
    }
}
