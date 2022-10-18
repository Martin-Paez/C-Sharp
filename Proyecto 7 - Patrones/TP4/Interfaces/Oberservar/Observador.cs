using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Interfaces;
using TP.TP4.Interfaces.Comparar;

namespace TP.TP4.Interfaces.Oberservar
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
