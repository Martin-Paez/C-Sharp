using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Interfaces.Oberservar
{
    public interface Notificable<Topico>
    {
        void RecibirNotificacion();
    }
    public interface Notificable<Editor, Informacion>
    {
        void RecibirNotificacion(Editor editor, Informacion info);
    }
}
