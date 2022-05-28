using System;
using System.Collections;
using ListaIdNS;

namespace ListaIdNS
{
    public abstract class ListaId {
        private ArrayList lista = new ArrayList();

        private int posicion(string id){
            int i = -1;
            while ( (++i<this.lista.Count) && ((Identificable)this.lista[i]).Id != id );
            if ( i >= this.lista.Count)
                i = -1;
            return i;
        }

        private bool existe(string id){
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

/* NO conviene, hay que estar sobreescribiendo metodos de ingresos de datos, para evitar que cargen elementos no deseados


using System;
using System.Collections;
using EstudioNS;

namespace ListaIdNS
{
    public abstract class ListaId:ArrayList {

        public int IndexOf(string id){
            return base.IndexOf( new(Identificable(id)) );
        }
        public bool Contains(string id) {
            return base.Contains( new(Identificable(id)) );
        }

        public Identificable Get(string id) {
            int i = IndexOf(id);
            if ( i == -1 )
                throw new DatoInvalido();
            return (Identificable) this[i];
        }

        public void Remove(string id){
            base.Remove( new(Identificable(id)) );
        }

        public override string ToString(){
        	string str = "";
        	foreach(Identificable e in this.lista) {
            	str += "\n"+e+"\n";
            }
        	return str;
        }

        public override int Add(object value)
        {
            throw new Exception("Operacion no permitida");
        }
        

    }
}
*/