/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EstudioNS
{
	
	public class DatoInvalido:Exception {
		private const string MSG = "\nNo hay datos registrados para esa entrada";
		private const string ENTRADA = "Ingrese otro: ";

		public string resolver(){
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.WriteLine("\n¿Desea intentar nuevamente? S/N");
				rta = Console.ReadLine().ToUpper();
			}
			if(rta=="S") {
				Console.Write(MSG +"\n  "+ENTRADA+": ");
				return Console.ReadLine();
			}
			return "";
		}

		public string _MSG {
			get{return MSG;}
		}
	}

	public class Repetido:DatoInvalido{
		private const string MSG = "\nYa hay existe";
	}

	public class NumExpedienteRepetido:DatoInvalido{
		private const string MSG = "\nHay un expediente registrado con el mismo numero";
	}

	public class DemasiadosExpedientes:DatoInvalido{
		private const string MSG = "\nEl abogado ya tiene demasiados expedientes asignados";
	}

	public class FaltanExpedientes:DatoInvalido{
		private const string MSG = "\nEl abogado ya no tiene mas expedientes asignados";
	}

}