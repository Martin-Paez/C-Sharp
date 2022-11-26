using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Command
{
    public interface Comando
    {
        void Ejecutar();
    }
    public interface Comando<T>
    {
        void Ejecutar(T e);
    }
}