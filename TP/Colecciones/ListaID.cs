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

        protected Identificable Get(string id) {
            int i = posicion(id);
            if ( i == -1 )
                throw new DatoInvalido();
            return (Identificable) this.lista[i];
        }


        // Excepcion IndexOutOfRangeException
        public Identificable Get(int i) {
            return this.list[i];
        }

        public void Agregar(Identificable e){
			if ( base.existe(a.Dni) )
				throw new Repetido();
			this.list.Add(a);
		}

        // Excepcion DatoInvalido()
        public Identificable Eliminar(string numero) {
			Identificable e = this.Get(numero); // Excepcion DatoInvalido()
			this.list.Remove(e);
            return e;
		}

    
    }
}