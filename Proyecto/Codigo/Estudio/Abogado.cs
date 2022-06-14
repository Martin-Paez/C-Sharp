using System;
using ListaIdNS;

namespace EstudioNS{
	public class Abogado : Persona
	{
		private string espec;
		protected uint cantExps = 0;
		protected uint maxExp = 6;
		
		// Excepcion "FormatoDni()"
		public Abogado(string nombre, string apellido, string dni, string espec):base(nombre, apellido, dni)
		{
			this.espec = espec;
		}
		
		public string Espec {
			set{this.espec=value;}
			get{return this.espec;}
		}

		public uint GetCantExps() {
			return this.cantExps;
		}

		public uint MaxExp {
			set{
				if ( value < this.cantExps )
					throw new DemasiadosExpedientes();
				this.maxExp = value;
				}
			get{return this.maxExp;}
		}

		public override string ToString() {
			return base.ToString() + "\nEspecializacion: " + this.espec + "\nExpedientes asginados: " + this.GetCantExps() + "\n";
		}
	}
	

	public class ExcepcionAbogado:IdInvalido {
		public ExcepcionAbogado(){
			this.msg = "No se pudo completar la operacion con el abogado.";
		}

	}

	public class DemasiadosExpedientes:ExcepcionAbogado {
		public DemasiadosExpedientes(){
			this.msg = "El abogado ya tiene demasiados expedientes asignados";
		}
	}


}
