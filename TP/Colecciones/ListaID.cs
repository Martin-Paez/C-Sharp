using System;
using System.Collections;
using ListaIdNS;
using EstudioNS;

namespace ListaIdNS
{
    public abstract class ListaId {
        protected ArrayList lista = new ArrayList();

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

        // Excepcion IndexOutOfRangeException
        public Identificable Get(int i) {
        	return (Identificable) this.lista[i];
        }

        // Excepcion DatoInvalido()
        public virtual Identificable Eliminar(string numero) {
			Identificable e = this.Get(numero); // Excepcion DatoInvalido()
			this.lista.Remove(e);
            return e;
		}

        public int Count(){
        	return this.lista.Count;
        }

        public override string ToString(){
            string str = "\n";
            foreach(Identificable elem in this.lista)
            	str += elem.ToString() + "\n";
            return str;
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