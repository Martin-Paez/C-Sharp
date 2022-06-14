using System;
using System.Collections;
using EstudioNS;

namespace ListaIdNS
{
	
    // Lista abstracta sin metodos que permitan modificar su contenido
    public abstract class ListaSoloLectura 
    {
        protected ArrayList lista = new ArrayList();

    	protected DatoInvalido idErr = new IdInvalido();

        /* Chequea si en una posicion se encuentra un elemento
         * 
         * Recibe:
         *   i       posicion del elemento a chequear
         *   id      valor del atributo que identifica al elemento
         *
         *  Retorna:
         *   True    El elemento es el buscado
         *   False   El elemento no coincide
         *
         * Excepciones que puede lanzar
         *    "IdInvalido()"    el parametro id tiene un valor invalido
         */
        public abstract bool coincide(int i, string id);

        /* Busca un elemento
         * 
         * Recibe:
         *   id      valor del atributo que identifica al elemento a buscar
         *
         *  Retorna:
         *   int     posicion del elemento en la lista
         *
         * Excepciones que puede lanzar
         *    this.idErr    el elemento no se encuentra en la lista
         */
        public int posicion(string id){
            int i = -1;
            while ( (++i<this.lista.Count) && ! this.coincide(i,id) ); 
            if ( i >= this.lista.Count)
                 throw this.idErr; 
            return i;
        }

         /* Busca un elemento
         * 
         * Recibe:
         *   id      valor del atributo que identifica al elemento a buscar
         *
         *  Retorna:
         *   True    el elemento se encuentra en la lista
         *   False   el elemento no fue encontrado
         */
        public bool Existe(string id){
            try{
                this.Posicion(id);
            } catch {
                return false;
            }
            return  true;
        }

        /* Busca un elemento
         * 
         * Recibe:
         *   id       valor del atributo que identifica al elemento a buscar
         *
         *  Retorna:
         *   Object   El elemento buscado
         *
         * Excepciones que puede lanzar
         *    this.idErr    el elemento no se encuentra en la lista
         */
        public Object Get(string id) {
            int i = this.Posicion(id);  // Excepcion "this.idErr()"
            return this.lista[i];
        }

        /* Busca un elemento
         * 
         * Recibe:
         *   i       posicin del elemento buscado
         *
         *  Retorna:
         *   Object   El elemento buscado
         *
         * Excepciones que puede lanzar
         *    IndexOutOfRangeException     posicion invalida, negativa o mayor a la cantidad de elementos
         */
        public Object Get(int i) {
        	return this.lista[i];
        }

        /* Retorna la cantidad de elementos de la lista.
         */
        public int Count(){
        	return this.lista.Count;
        }

        /* Imprime los elementos de la lista
         */
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
