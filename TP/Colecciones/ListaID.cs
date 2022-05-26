using System;
using System.Collections;
using EstudioNS;

namespace ListaIdNS
{
    public abstract class ListaId {
        private ArrayList lista = new ArrayList();

        public int posicion(string id){
            int i = -1;
            while ( (++i<this.lista.Count) && ((Identificable)this.lista[i]).Id != id );
            if ( i >= this.lista.Count)
                i = -1;
            return i;
        }

        public bool existe(string id){
            return posicion(id) > -1;
        }

        public Identificable Get(string id) {
            int i = posicion(id);
            if ( i == -1 )
                throw new DatoInvalido();
            return (Identificable) this.lista[i];
        }
        
        // IndexOutOfRangeException
        protected Identificable Get(int i){
        	return (Identificable) this.lista[i];
        }

        protected void Agregar(Identificable e){
			if ( this.existe(e.Id) )
				throw new Repetido();
			this.lista.Add(e);
		}

        // Excepcion DatoInvalido()
        public Identificable Eliminar(string numero) {
			Identificable e = this.Get(numero); // Excepcion DatoInvalido()
			this.lista.Remove(e);
            return e;
		}

        public override string ToString(){
        	string str = "";
        	foreach(Identificable e in this.lista) {
            	str += "\n"+e+"\n";
            }
        	return str;
        }
        
        public int Count{
        	get {return this.lista.Count;}
        }
    }
}