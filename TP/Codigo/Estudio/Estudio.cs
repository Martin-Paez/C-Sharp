using System;
using System.Collections;
using ListaIdNS;

namespace EstudioNS
{
	public class Estudio {


/* -----------------------   CLASES PRIVADAS  -------------------------------------------- */

		private class AbogadoM : Abogado {
			public AbogadoM(Abogado a):base(a.Nombre,a.Apellido,a.Dni,a.Espec) {
			}

			public uint CantExps {
				set{ 
					if ( value < 0 )
						throw new AdvertenciaConteoErroneo();
					this.cantExps = value; 
					}
				get{ return this.cantExps; } // Por practicidad, tambien esta el getter publico.
			}

		}


		private class ExpedienteM : Expediente {
			
			public ExpedienteM(Expediente e):base(e.Numero, e.Titular, e.Tipo, e.Estado, e.FechaCreacion) {
			}

			public AbogadoM Abogado {
				set{ this.abogado = value; }
				get{ return (AbogadoM) this.abogado; }
			}

		}


		private abstract class ListaId:ListaSoloLectura {

			// Excepcion "this.idErr()"
			public virtual Object Quitar(Object id) {
				int i = posicion(id); //Excepcion this.idErr()
				Object e = (Object) this.lista[i];
				this.lista.RemoveAt(i);
				return e;
			}
			
		}


		private class Fichero:ListaId {

			public Fichero(){
				this.idErr = new NumExpInvalido();
			}

			public void Agregar(Expediente e){
				this.lista.Add(e);
			}

			// IndexOutOfBounds
			public bool coincide(int i, string n) {
				return ((Expediente)this.lista[i]).Numero == n;
			}

			// Excepcion "InvalidCastException()"
			public override bool coincide(int i, Object o) {
				string s = "";
				if ( o.GetType() == s.GetType() )
				    return coincide(i, (string)o);
				else
					return coincide(i, ((Expediente)o).Numero);
			}
		
		}


		private class Staff:ListaId {

			public Staff(){
				this.idErr = new DniInvalido();
			}

			public void Contratar(Abogado a){
				if ( this.existe(a) )
					throw new DniRepetido();
				this.lista.Add(a);
			}

			// IndexOutOfBounds
			public bool coincide(int i, ulong dni){
				return ((Abogado)this.lista[i]).Dni == dni;
			}

			// Excepcion "FormatException()"
			// Excepcion "InvalidCastException()"
			// IndexOutOfBounds
			public override bool coincide(int i, Object o){
				ulong n = 0;
				string s = "";
				if ( o.GetType() == n.GetType() )
				    return coincide(i, (ulong) o);
				else 
					if ( o.GetType() == s.GetType() ) {
						n = ulong.Parse( (string) o ); // Excepcion "FormatException()"
				    	return coincide(i,n);
					}
				else
					return coincide(i, ((Abogado)o).Dni); // Excepcion "InvalidCastException()"
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

		// Excepcion DniInvalido()
		public void Contratar(Abogado a) {
			abogados.Contratar( new AbogadoM(a) ); //DniInvalido()
		}

		// Excepcion DniInvalido()
		// Excepcion "WarningConteoErroneo()" . Elimina de todos modos
		public void Despedir(ulong dni) {
			AbogadoM a = (AbogadoM) abogados.Quitar(dni); //Excepcion DniInvalido()
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

		// Excepcion NumExpedienteRepetido()
		// Excepcion DemasiadosExpedientes()
		// Excepcion DniInvalido()
		public void Agregar(Expediente exp) {
			ExpedienteM e = new ExpedienteM( exp );
			if ( fichero.existe(e) )
				throw new NumExpedienteRepetido();
			if ( e.Abogado != null )
				if ( fichero.existe(e.Abogado) )
					e.Abogado.CantExps++;  // Excepcion DemasiadosExpedientes()
				else
					throw new DniInvalido();
			fichero.Agregar(e);
		}

		//Excepcion "WarningConteoErroneo" . Elimina de todos modos
        //Excepcion "NumExpInvalido"
        public void Eliminar(string numero) {
			ExpedienteM e = (ExpedienteM) fichero.Quitar(numero); //Excepcion "NumExpInvalido"
			if (e.Abogado != null) {
				if ( e.Abogado.CantExps == 0 )
					throw new AdvertenciaConteoErroneo();
				e.Abogado.CantExps--;
			}
		}

		// Excepcion DniInvalido()
		// Excepcion NumExpInvalido()
		// Excepcion DemasiadosExpedientes()
		//  WarningConteoErroneo() - Se completa la asignacion
		public void Asignar(ulong dni, string numExp) {
			AbogadoM a = (AbogadoM) abogados.Get(dni);  // DniInvalido
			ExpedienteM e = (ExpedienteM) fichero.Get(numExp); // NumExpInvalido
			a.CantExps++; // DemasiadosExpedientes()
			AbogadoM b = e.Abogado; // Me aseguro que no salte el warning antes de asignar el nuevo
			e.Abogado = a; 
			if ( b != null )
				b.CantExps--;  // WarningConteoErroneo() 
		}
			

/* -----------------------------   GETTERS  ----------------------------------------------- */

		public ListaSoloLectura Abogados {
			get{return this.abogados;}
		}

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

	public class DniInvalido:ExcepcionAbogado {
		public DniInvalido(){
			this.msg = "El DNI no corresponde a ningun abogado del estudio";
		}
	}

	public class AdvertenciaConteoErroneo:ExcepcionAbogado {
		public AdvertenciaConteoErroneo() {
			this.msg = "ADVERTENCIA: Se detecto que un abogado tenia un conteo erroneo en la cantidad de expedientes asignados";
		}
	}

	public class NumExpedienteRepetido:DatoInvalido {
		public NumExpedienteRepetido(){
			this.msg = "Ya existe un expediente registrado con el mismo numero";
		}
	}

	public class NumExpInvalido:DatoInvalido {
		public NumExpInvalido(){
			this.msg = "El numero de expediente no esta registrado";
		}
	}

}