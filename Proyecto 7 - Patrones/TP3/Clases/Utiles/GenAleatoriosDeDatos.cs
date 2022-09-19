using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Clases.Utiles
{
    public class GenAleatoriosDeDatos
    {
        static public int NumeroAleatorio(int max, int min=1)
        {
            return new Random((int)DateTime.Now.Ticks).Next(min,max);
        }
        static public string StringAleatorio(int cant)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            string s = "";
            for(int i=0; i<cant; i++)
                s += (char)r.Next();
            return s;
        }
        static public int DniAleatorio()
        {
            int d = 0;
            // un numero razonable para un DNI actual
            while (d < 1000000 || d > 200000000)
                d = new Random().Next();
            return d;
        }
        static public string NombreAleatorio()
        {
            string[] noms = new string[] { "Carlos", "Esteban", "Ana",
            "Maria", "Juan", "Pablo", "Lucia", "Nicolas", "Diego"};
            return noms[new Random().Next() % 8];
        }

    }
}
