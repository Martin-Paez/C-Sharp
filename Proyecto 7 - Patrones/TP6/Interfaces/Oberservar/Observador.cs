using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Interfaces.Oberservar
{
    public interface Observador<Topico>
    {
        void RecibirNotificacion();
    }
    public interface Observador<Editor, Informacion>
    {
        void RecibirNotificacion(Editor editor, Informacion info);
    }
}
