using System;
using System.Collections;

namespace ListaIdNS
{
    public abstract class ListaId {
        private ArrayList lista = new ArrayList();

        protected int posicion(string id){
            int i = -1;
            while ( (++i<this.lista.Count) && ((Identificable)this.lista[i]).Id != id );
            if ( i >= this.lista.Count)
                i = -1;
            return i;
        }

        protected bool existe(string id){
            return posicion(id) > -1;
        }

        public Identificable Get(string id) {
            int i = posicion(id);
            if ( i == -1 )
                return null;
            return (Identificable) this.lista[i];
        }

        public abstract void Agregar(Identificable e);

        public abstract bool Eliminar(string numero);
    
    }
}