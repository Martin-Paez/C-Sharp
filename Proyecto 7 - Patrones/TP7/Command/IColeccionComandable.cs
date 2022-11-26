using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Command
{
    public interface IColeccionComandable<T> where T:Comparable<T>
    {
        Comando? CmdInicio { get; set; }
        Comando<T>? CmdAgregar { get; set; }
        Comando<Coleccionable<T>>? CmdLlena { get; set; }
        int? Cupo { get; set; }
    }
}
