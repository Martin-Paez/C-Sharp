using System;
using System.Collections;
using ListaIdNS;

namespace EstudioNS
{
	public class Estudio {

		private FicheroExpedientes fichero;
		private DeptoRR_HH deptoRRHH;

		public Estudio() {
			this.deptoRRHH = new DeptoRR_HH();
			this.fichero = new FicheroExpedientes();
		}

		public ListaSoloLectura DeptoRRHH {
			get{return this.deptoRRHH;}
		}

		public ListaSoloLectura Fichero {
			get{return this.fichero;}
		}

		public void Contratar(Abogado a) {
			deptoRRHH.Agregar(a);
		}

		public void Agregar(Expediente e) {
			this.fichero.Agregar(e);
		}

		//Excepcion "SinExpedientes" . Elimina de todos modos
        //Excepcion "IdInvalido"
        public void Eliminar(string numero) {
			ExpedienteM e = (ExpedienteM) fichero.Quitar(numero); //Excepcion "IdInvalido"
			if (e.Abogado != null) {
				if ( e.Abogado.CantExps == 0 )
					throw new WarningConteoErroneo();
				e.Abogado.CantExps--;
			}
		}

		// Excepcion IdInvalido()
		// Excepcion "SinExpedientes()" . Elimina de todos modos
		public void Despedir(string dni) {
			AbogadoM a = (AbogadoM) deptoRRHH.Quitar(dni); //Excepcion IdInvalido()
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
				throw new WarningConteoErroneo();
        }


		private class AbogadoM : Abogado {
			public AbogadoM(Abogado a):base(a.Nombre,a.Apellido,a.Dni,a.Espec) {
			}

			public uint CantExps{
				set{ this.cantExps = value; }
				get{ return this.cantExps; }
			}
		}


		private class ExpedienteM : Expediente {
			private AbogadoM abogado = null;
			public ExpedienteM(Expediente e):base(e.Numero, e.Titular, e.Tipo, e.Estado, e.FechaCreacion) {
			}

			public AbogadoM Abogado {
				set{ this.abogado = value; }
				get{ return this.Abogado; }
			}
		}


		public class FicheroExpedientes:ListaId {
			// Excepcion NumExpedienteRepetido()
			// Excepcion DemasiadosExpedientes()
			// No puedo reutilizar el del padre, por el orden de chequeos
			public void Agregar(Expediente exp) {
				ExpedienteM e = new ExpedienteM( exp );
				if ( this.existe(e) )
					throw new NumExpedienteRepetido();
				if ( e.Abogado != null ) // Al despedir un abogado puede que dar en null, idem al crear.
					e.Abogado.CantExps++;  // Excepcion DemasiadosExpedientes()
				this.lista.Add(e);
			}

			// IndexOutOfBounds
			public bool coincide(int i, string id) {
				return ((Expediente)this.lista[i]).Numero == id;
			}

			// IndexOutOfBounds
			public bool coincide(int i, Expediente e) {
				return coincide(i, e.Numero);
			}

		}


		public class DeptoRR_HH:ListaId {

			public void Agregar(Abogado a){
				if ( this.existe(a) )
					throw new DniRepetido();
				this.lista.Add(a);
			}

			// IndexOutOfBounds
			public bool coincide(int i, ulong id){
				return ((Abogado)this.lista[i]).Dni == id;
			}
			
			// IndexOutOfBounds
			public bool coincide(int i, Abogado a){
				return coincide(i, a.Dni);
			}
			
		}


	}

	public class DniRepetido:DatoInvalido {
		public DniRepetido(){
			this.msg = "\nYa existe un abogado con el mismo DNI";
		}
	}

	public class NumExpedienteRepetido:DatoInvalido {
		public NumExpedienteRepetido(){
			this.msg = "\nHay un expediente registrado con el mismo numero";
		}
	}

}