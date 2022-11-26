using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Interfaces.Oberservar
{
    public interface Observable<Suscriptor, Informacion>
    {
        void Publicar(Informacion info);
        void Suscribir(Suscriptor s);
        //void Desuscribir(Suscriptor s);
    }
    public interface Observable<Suscriptor>
    {
        void Publicar();
        void Suscribir(Suscriptor s);
        //void Desuscribir(Suscriptor s);
    }
}
