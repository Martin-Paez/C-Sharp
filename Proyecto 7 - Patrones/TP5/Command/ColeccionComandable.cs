using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Command
{
    public interface ColeccionComandable<T> where T:Comparable<T>
    {
        Comando? CmdInicio { get; set; }
        Comando<T>? CmdAgregar { get; set; }
        Comando<Coleccionable<T>>? CmdLlena { get; set; }
        int? Cupo { get; set; }
    }
}
