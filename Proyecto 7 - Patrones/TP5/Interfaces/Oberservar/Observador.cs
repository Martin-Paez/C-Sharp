using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Interfaces.Oberservar
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
