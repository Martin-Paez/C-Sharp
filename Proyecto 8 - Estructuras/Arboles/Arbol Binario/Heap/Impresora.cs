using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Heap
{
    public class Impresora
    {
        private Heap<string> Buffer = new(new string[10], 0, false);
        public void NuevoDoc(string doc)
        {
            Buffer.Agregar(doc);
        }
        public void Imprimir()
        {
            Console.WriteLine(Buffer.Eliminar());
        }
    }
}
