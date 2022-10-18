using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Arboles.Arbol_Binario.AVL
{
    public class ArbolAVLDeMuestras : AVL<float>
    {
        public ArbolAVLDeMuestras(float dato) : base(dato)
        {
        }
        public float minimoDeltaHistorico(float v)
        {/*
            IteradorNodoAVL<float> i = new(this);
            ArbolAVLDeMuestras m;
            while ((m=(ArbolAVLDeMuestras)i.Next()) != null) {
                if (m.getDatoRaiz() == v)
                    return calcDelta(m);
            }*/
            return 0;

        }
    }
}
