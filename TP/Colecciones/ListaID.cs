using System;
using System.Collections;

namespace ListaIdNS
{
    public class ListaId {
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
            return (Identificable) lista[i];
        }

        public Identificable Get(int i) {
            return (Identificable) lista[i];
        }

        public void Agregar(Identificable elem) {
            lista.Add(elem);
        }

        public void Eliminar(Identificable elem) {
            lista.Remove(elem);
        }

        public void Eliminar(int i) {
            lista.RemoveAt(i);
        }
    }
}