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
        public abstract bool Coincide(int i, string id);

        // Excepcion "this.idErr()"
        public int Posicion(string id){
            int i = -1;
            while ( (++i<this.lista.Count) && ! this.coincide(i,id) ); 
            if ( i >= this.lista.Count)
                 throw this.idErr; 
            return i;
        }

        public bool Existe(string id){
            try{
                this.Posicion(id);
            } catch {
                return false;
            }
            return  true;
        }

        // Excepcion "this.idErr()"
        public Object Get(string id) {
            int i = this.Posicion(id);  // Excepcion "this.idErr()"
            return this.lista[i];
        }

        // Excepcion IndexOutOfRangeException
        public Object Get(int i) {
        	return this.lista[i];
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
