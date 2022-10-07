using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario
{
    public class ProfundidadDeArbolBinario
    {
        private ArbolBinario<int>? tree;
        
        public ProfundidadDeArbolBinario(ArbolBinario<int>? tree)
        {
            this.tree = tree;
        }

        public int sumaElementosProfundidad(int p)
        {
            if (tree == null)
                return 0;
            int acum = 0;
            tree.entreNiveles(p, p, (x) => { acum += x.getDatoRaiz(); });
            return acum;
        }
    }
}   
