using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP7.ChainOR
{
    public abstract class GenDatos
    {
        public GenDatos? Sig { get; set; }
        
        public GenDatos(GenDatos? sig)
        {
            Sig = sig;
        }
        public abstract int GetNum(int min, int max, string tag);
        public abstract string GetS(int len, string tag);
        public abstract int RandNum(int min, int max);
        public abstract string RandS(int len);

    }
}
