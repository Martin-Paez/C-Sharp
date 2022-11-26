using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Interfaces.Oberservar
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
