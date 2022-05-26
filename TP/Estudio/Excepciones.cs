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
	/// <summary>
	/// Description of Manejador.
	/// </summary>
	
	public class ExcepcionEstudio:Exception {
		private const string MSG="";
		
		public void Msg() {
			Console.WriteLine(MSG);
		}
	}

	public class DatoInvalido:Excepcion {
		private const string MSG = "\nNo hay datos registrados para esa entrada";
		private const string ENTRADA = "Ingrese otro: "
		public string resolver(){
			Console.Write(MSG +"\n  "+ENTRADA+": ");
			return Console.ReadLine();
		}
	}

	public class NumExpedienteRepetido:DatoInvalido{
		private const string MSG = "\nHay un expediente registrado con el mismo numero";
	}

	public class DemasiadosExpedientes:ExcepcionEstudio{
		private const string MSG = "\nEl abogado ya tiene demasiados expedientes asignados";
	}

	public class FaltanExpedientes:ExcepcionEstudio{
		private const string MSG = "\nEl abogado ya no tiene mas expedientes asignados";
	}

}