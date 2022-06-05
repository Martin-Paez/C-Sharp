using System;
using System.Collections;
using EstudioNS;

namespace ListaIdNS
{
	
    public abstract class ListaSoloLectura 
    {
        protected ArrayList lista = new ArrayList();

    	protected DatoInvalido idErr = new IdInvalido();

        // Excepcion "FormatoIDInvalido()"
        public abstract bool coincide(int i, Object id);
	        /*{
            throw new FormatoIDInvalido(id);
        }*/

        // Excepcion "this.idErr()"
        public int posicion(Object id){
            int i = -1;
            while ( (++i<this.lista.Count) && ! coincide(i,id) ); 
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
    
	public abstract class ListaId:ListaSoloLectura {

        // Excepcion "DatoInvalido()"
        public virtual void Agregar(Object o) {
            throw new DatoInvalido();
        }

        // Excepcion "this.idErr()"
        public virtual Object Quitar(Object id) {
            int i = posicion(id); //Excepcion this.idErr()
        	Object e = (Object) this.lista[i];
			this.lista.RemoveAt(i);
            return e;
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
			this.msg = "No hay ningun registro asociado";
		}
	}
    
	public class FormatoIDInvalido:DatoInvalido{
        public FormatoIDInvalido(Object o) {
			this.msg = "No esta permitido buscar un elemento utilizando como referencia : " + o.ToString();
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