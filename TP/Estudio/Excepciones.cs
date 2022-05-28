using System;

namespace EstudioNS
{
	
	public class DatoInvalido:Exception {
		protected string msg = "\nNo hay datos registrados para esa entrada";
		private const string ENTRADA = "Ingrese otro: ";

		public string resolver(){
			Console.WriteLine(msg);
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.WriteLine("\n¿Desea intentar nuevamente? S/N");
				rta = Console.ReadLine().ToUpper();
			}
			if(rta=="S") {
				Console.Write("\n  "+ENTRADA+": ");
				return Console.ReadLine();
			}
			return null;
		}

		public string MSG {
			get{return msg;}
		}
	}

	public class DniFormatoInvalido:DatoInvalido{
		public DniFormatoInvalido(){
			this.msg = "\nEl dni debe ser un numero (sin puntos)";
		}
	}
	
	public class DniRepetido:DatoInvalido{
		public DniRepetido(){
			this.msg = "\nYa existe un abogado con el mismo DNI";
		}
	}

	public class NumExpedienteRepetido:DatoInvalido{
		public NumExpedienteRepetido(){
			this.msg = "\nHay un expediente registrado con el mismo numero";
		}
	}

	public class DemasiadosExpedientes:DatoInvalido{
		public DemasiadosExpedientes(){
			this.msg = "\nEl abogado ya tiene demasiados expedientes asignados";
		}
	}

	public class FaltanExpedientes:DatoInvalido{
		public FaltanExpedientes() {
			this.msg = "\nEl abogado ya no tiene mas expedientes asignados";
		}
	}

}