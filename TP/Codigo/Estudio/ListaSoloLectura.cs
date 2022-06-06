using System;
using System.Collections;
using EstudioNS;

namespace ListaIdNS
{
	
    public abstract class ListaSoloLectura 
    {
        protected ArrayList lista = new ArrayList();

    	protected DatoInvalido idErr = new IdInvalido();

        // Excepcion "IdInvalido()"
        public abstract bool coincide(int i, Object id);

        // Excepcion "this.idErr()"
        public int posicion(Object id){
            int i = -1;
            while ( (++i<this.lista.Count) && ! this.coincide(i,id) ); 
            if ( i >= this.lista.Count)
                 throw this.idErr; 
            return i;
        }

        public bool existe(Object id){
            try{
                this.posicion(id);
            } catch {
                return false;
            }
            return  true;
        }

        // Excepcion "this.idErr()"
        public Object Get(Object id) {
            int i = this.posicion(id);  // Excepcion "this.idErr()"
            return (Object) this.lista[i];
        }

        // Excepcion IndexOutOfRangeException
        public Object Get(int i) {
        	return (Object) this.lista[i];
        }

        public int Count(){
        	return this.lista.Count;
        }

        public override string ToString(){
            string str= "\n-----------------------------------------------\n";
            foreach(Object elem in this.lista) {
            	str += "\n" + elem.ToString();
                str += "\n-----------------------------------------------\n";
            }
            return str;
        }

    }
    
    public class DatoInvalido:Exception {
		protected string msg = "No se puede completar la operacion con el dato recibido.";

		public string MSG {
			get{return msg;}
		}
	}

	public class IdInvalido:DatoInvalido{
        public IdInvalido() {
    		this.msg = "Se intenta realizar la comparacion de un elemento de la lista contra un objeto de tipo invalido";
		}
	}

}

/* Sobreescribiendo el metodo Equal en Identificable se podria implementar de este modo
    Sin embargo no conviene, con la otra implementacion el ingreso de datos es mas seguro.


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