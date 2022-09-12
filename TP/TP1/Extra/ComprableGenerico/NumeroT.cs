using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP1
{
    public class NumeroT : ComparableT<NumeroT>
    {
        int valor;
        public NumeroT(int valor)
        {
            this.valor = valor;
        }

        public int GetValor()
        {
            return valor;
        }

        public bool SosIgual(NumeroT comparable)
        {
            return this.valor == comparable.valor;
        }

        public bool SosMayor(NumeroT comparable)
        {
            throw new NotImplementedException();
        }

        public bool SosMenor(NumeroT comparable)
        {
            throw new NotImplementedException();
        }
    }
}
