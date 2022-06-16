using System;
using System.Collections;
using ListaIdNS;

namespace EstudioNS
{
	public class Estudio {


/* -----------------------   CLASES PRIVADAS  -------------------------------------------- */


		// Es un abogado al que solo el estudio puede asignar expedientes
		private class AbogadoM : Abogado {
			public AbogadoM(Abogado a) {
				this.SetDni( a.Dni ); // FormatoDni
				this.Nombre = a.Nombre;
				this.Apellido = a.Apellido;
				this.Espec = a.Espec;
			}

			public uint CantExps {
				set{ 
					if ( value < 0 )
						throw new AdvertenciaConteoErroneo();
					else if ( value > this.MaxExp )
						throw new DemasiadosExpedientes();
					this.cantExps = value; 
					}
				get{ return this.cantExps; } // Por practicidad, tambien esta el getter en la clase publica Abogado.
			}

			// Ya no se permite modificar el dni de un abogado que pertenece al estudio
			public override string Dni {
				set{throw new NotImplementedException();}
				get{return base.Dni;}
			}

			// Solo el estudio es responsable de modificarlo, para evitar que pudan darse dni repetidos
			public void SetDni(string dni) {
				base.Dni = dni;
			}

		}

		// Son expedientes a los que solo el estudio puede asignar abogados
		private class ExpedienteM : Expediente {
			
			public ExpedienteM(Expediente e):base(e.Numero, e.Titular, e.Tipo, e.Estado, e.FechaCreacion) {
			}

			public AbogadoM Abogado {
				set{ this.abogado = value; }
				get{ return (AbogadoM) this.abogado; } // Por practicidad, tambien esta el getter en la clase publica Expediente.
			}

			// ya no se permite modificar el numero de un expediente que pertenezca al estudio
			public override string Numero {
				set{throw new NotImplementedException();}
				get{return base.Numero;}
			}

			// Solo el estudio es responsable de modificarlo, para evitar que pudan darse valores repetidos
			public void SetNumero(string n){
				base.Numero = n;
			}

		}

		// Lista abstracta que brinda la posibilidad de eliminar sus elementos
		private abstract class ListaId:ListaSoloLectura {

			// Excepcion "this.idErr()"
			public virtual Object Quitar(string id) {
				int i = Posicion(id); //Excepcion this.idErr()
				Object e = this.lista[i];
				this.lista.RemoveAt(i);
				return e;
			}
			
		}

		// Lista de expedientes, con posibilidad de agregar elementos 
		private class Fichero:ListaId {

			public Fichero(){
				this.idErr = new ExpNoRegistrado();
			}

			public void Agregar(Expediente e){
				this.lista.Add(e);
			}

			// IndexOutOfBounds
			public override bool Coincide(int i, string n) {
				return ((Expediente)this.lista[i]).Numero == n;
			}

		}

		// Lista de abogados, con posibilidad de agregar elementos
		private class Staff:ListaId {

			public Staff(){
				this.idErr = new AbogadoNoRegistrado();
			}

			// Excepcion "DniRepetido()"
			public void Contratar(Abogado a){
				if ( this.Existe(a.Dni) )
					throw new DniRepetido();
				this.lista.Add(a);
			}

			// IndexOutOfBounds
			public override bool Coincide(int i, string dni){
				return ((Abogado)this.lista[i]).Dni == dni;
			}
			
		}


/* ---------------------------   ATRIBUTOS  ---------------------------------------------- */


		private Fichero fichero;
		private Staff abogados;


/* -----------------------------   METODOS  ----------------------------------------------- */


		public Estudio() {
			this.abogados = new Staff();
			this.fichero = new Fichero();
		}

		/* Contrata un abogado
		 *
		 * Recibe:
		 *   a     Abogado a contratar
		 *
		 * Posibles excepciones :
		 *   DniRepetido()    el estudio tiene un abogado con el mismo dni
		 */
		public void Contratar(Abogado a) {
			abogados.Contratar( new AbogadoM(a) ); //DniRepetido()
		}

		/* Despide un abogado
		 *
		 * Recibe:
		 *   dni     deni del abogado a despedir
		 *
		 * Posibles excepciones :
		 *   AbogadoNoRegistrado()            El abogado no trabaja en el estudio
		 *   AdvertenciaConteoErroneo()       El abogado creia tener mas expedientes de los que realmente tenia asignado
		 *                                    El abogado es despedido de todos modos.
		 */
		public void Despedir(string dni) {
			AbogadoM a = (AbogadoM) abogados.Quitar(dni); //Excepcion AbogadoNoRegistrado()
            int j = -1;
            bool warning = false;
            while ( a.CantExps > 0 && ++j<fichero.Count() ) {
				ExpedienteM e = (ExpedienteM) fichero.Get(j);
				if ( e.Abogado != null && e.Abogado.Dni == a.Dni ) {
					e.Abogado = null;
					if ( a.CantExps == 0 )
						warning = true;
					else
						a.CantExps--;
				}
			}
			if (warning)
				throw new AdvertenciaConteoErroneo();
        }

		/* Agrega un expediente al fichero
		 *
		 * Recibe:
		 *   exp      expediente para agregar
		 *
		 * Posibles excepciones :
		 *   Excepcion NumExpedienteRepetido()    El estudio ya tiene registrado un expediente con ese mismo numero identificatorio
		 *   Excepcion DemasiadosExpedientes()    El expediente pretende tener asignado un abogado que no puede aceptar mas trabajos
		 *   Excepcion AbogadoNoRegistrado()      El expediente pretende tener asignado un abogado que no trabaja en el estudio
		 */
		public void Agregar(Expediente exp) {
			ExpedienteM e = new ExpedienteM( exp );
			if ( fichero.Existe(e.Numero) )
				throw new NumExpedienteRepetido();
			if ( e.Abogado != null )
				if ( abogados.Existe(e.Abogado.Dni) )
					e.Abogado.CantExps++;  // Excepcion DemasiadosExpedientes()
				else
					throw new AbogadoNoRegistrado();
			fichero.Agregar(e);
		}

		/* Elimina un expediente del fichero
		 *
		 * Recibe:
		 *   numero      numero del expediente a eliminar
		 *
		 * Posibles excepciones :
		 *   AdvertenciaConteoErroneo()     Se detecto que el abogado que figuraba en el expediente creia no tener expedientes asignados
		 *                                  El expediente se elimina de todos modos
         *   ExpNoRegistrado()              Se intenta eliminar un expediente que no pertenece al estudio    
		 */
        public void Eliminar(string numero) {
			ExpedienteM e = (ExpedienteM) fichero.Quitar(numero); //Excepcion "ExpNoRegistrado"
			if (e.Abogado != null) {
				if ( e.Abogado.CantExps == 0 )
					throw new AdvertenciaConteoErroneo();
				e.Abogado.CantExps--;
			}
		}

		/* Asigna un abogado a un expediente
		 *
		 * Recibe:
		 *   numero      numero del expediente 
		 *   dni         dni del abogado
		 *
		 * Posibles excepciones :
		 *   AbogadoNoRegistrado()                 El abogado no trabaja en el estudio
		 *   Excepcion ExpNoRegistrado()           El expediente no pertenece al estudio
		 *   Excepcion DemasiadosExpedientes()     El abogado no puede hacerse cargo de mas expedientes
		 *   AdvertenciaConteoErroneo() 	       El abogado que estaba registrado previamente en el expediente creia no tener expedientes asignados
		 *                                         La operacion se concreta de todos modos
		 */
		public void Asignar(string dni, string numExp) {
			AbogadoM a = (AbogadoM) abogados.Get(dni);  // AbogadoNoRegistrado
			ExpedienteM e = (ExpedienteM) fichero.Get(numExp); // ExpNoRegistrado
			a.CantExps++; // DemasiadosExpedientes()
			AbogadoM b = e.Abogado; // Me aseguro que no salte la advertencia antes de asignar el nuevo
			e.Abogado = a;
			if ( b != null )
				b.CantExps--;  // AdvertenciaConteoErroneo() 
		}

		/* Si el abogado trabaja para el estudio y no hay otro abogado registrado con el nuevo dni,
		 * actualiza el valor y retorna true. Caso contrario retorna false.
		 */
		public bool CambiarDni(string nuevo, string viejo) {
			if ( abogados.Existe(viejo) && ! abogados.Existe(nuevo) )
				((AbogadoM)abogados.Get(viejo)).SetDni(nuevo);
			else
				return false;
			return true;
		}

		/* Si el expediente pertenece al estudio y no hay otro expediente registrado con el mismo numero, 
		 * actualiza el valor y retorna true. Caso contrario retorna false.
		 */
		public bool CambiarNumExp(string nuevo, string viejo) {
			if ( fichero.Existe(viejo) && ! fichero.Existe(nuevo) )
				((ExpedienteM)fichero.Get(viejo)).SetNumero(nuevo);
			else
				return false;
			return true;
		}



/* -----------------------------   GETTERS  ----------------------------------------------- */

		/* Retorna una lista con los abogados que trabajan en el estudio
		 * No se pueden agregar o eliminar abogados, pero si trabajar con ellos para reflejar cualquier cambio PERMITIDO
		 * por ejemplo modificar su especialidad.
		 */
		public ListaSoloLectura Abogados {
			get{return this.abogados;}
		}

		
		/* Retorna una lista con los expedientes que tiene el estudio
		 * No se pueden agregar o eliminar expedientes, pero si trabajar con ellos para reflejar cualquier cambio PERMITIDO
		 * por ejemplo modificar el nombre del titular.
		 */
		public ListaSoloLectura Expedientes {
			get{return this.fichero;}
		}

	}


/* ----------------------------   EXCEPCIONES -------------------------------------------- */
	public class DniRepetido:ExcepcionAbogado {
		public DniRepetido(){
			this.msg = "Ya existe un abogado con el mismo DNI";
		}
	}

	public class AbogadoNoRegistrado:ExcepcionAbogado {
		public AbogadoNoRegistrado(){
			this.msg = "El DNI no corresponde a ningun abogado del estudio";
		}
	}

	public class NumExpedienteRepetido:DatoInvalido {
		public NumExpedienteRepetido(){
			this.msg = "Ya existe un expediente registrado con el mismo numero";
		}
	}

	public class ExpNoRegistrado:DatoInvalido {
		public ExpNoRegistrado(){
			this.msg = "El numero de expediente no esta registrado";
		}
	}

	public class AdvertenciaConteoErroneo:DatoInvalido {
		public AdvertenciaConteoErroneo() {
			this.msg = "ADVERTENCIA: Se detecto que un abogado tenia un conteo erroneo en la cantidad de expedientes asignados";
		}
	}

}
