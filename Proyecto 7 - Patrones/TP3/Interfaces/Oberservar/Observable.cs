﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Interfaces.Oberservar
{
    public interface Suscribible<Suscriptor, Informacion>
    {
        void Publicar(Informacion info);
        void Suscribir(Suscriptor s);
        //void Desuscribir(Suscriptor s);

    }
    public interface Suscribible<Suscriptor>
    {
        void Publicar();
        void Suscribir(Suscriptor s);
        //void Desuscribir(Suscriptor s);
    }
}
