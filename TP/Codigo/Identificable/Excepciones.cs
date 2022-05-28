using System;

namespace IdentificableNS {
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

}