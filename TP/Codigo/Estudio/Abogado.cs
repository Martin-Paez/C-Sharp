using System;
using ListaIdNS;

namespace EstudioNS{
	public class Abogado : Persona
	{
		private string espec;
		protected uint cantExps = 0;
		protected uint maxExp = 6;
		
		public Abogado(string nombre, string apellido, ulong dni, string espec):base(nombre, apellido, dni)
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
			return base.ToString() + "\nEspecializacion: " + this.espec + "\n";
		}
	}
	
	public class DemasiadosExpedientes:DatoInvalido {
		public DemasiadosExpedientes(){
			this.msg = "\nEl abogado ya tiene demasiados expedientes asignados";
		}
	}

	public class ExpedienteInvalido:DatoInvalido {
		public ExpedienteInvalido() {
			this.msg = "\nSe intenta quitar un expediente a un abogado que no lo posee.";
		}
	}

	public class WarningConteoErroneo:DatoInvalido {
		public WarningConteoErroneo() {
			this.msg = "\nWARNING: Se detecto que el abogado tenia un conteo erroneo en la cantidad de expedientes asignados";
		}
	}

}
