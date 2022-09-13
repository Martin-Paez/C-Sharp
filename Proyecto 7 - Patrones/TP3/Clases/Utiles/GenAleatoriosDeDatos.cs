using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Clases.Utiles
{
    public class GenAleatoriosDeDatos
    {
        public Numero NumeroAleatorio(int max)
        {
            return new Numero(new Random((int)DateTime.Now.Ticks).Next()%max);
        }
        public string StringAleatorio(int cant)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            string s = "";
            for(int i=0; i<cant; i++)
                s += (char)r.Next();
            return s;
        }
    }
}
