/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using EstudioNS;

namespace TP
{
	/// <summary>
	/// Description of Manejador.
	/// </summary>
	public class Manejador:ManejadorDeEstudio
	{
		public override Abogado dniAbogado(Estudio e, string err){
			base.dniAbogado(e, err);
			string rta;
			Abogado a;
			do {
				rta="";
				Console.Write("\nDni del Abogado: ");
				a = e.GetAbogado(Console.ReadLine());
				if ( a == null )
					Console.WriteLine("No se encontro abogado");
				else if(a.CantExpedientes>=6)
					Console.WriteLine("El abogado tiene demasiados expedientes asignados");
				else
					rta="S"; //Cargado con Exito
				while ( rta != "S" & rta != "N" ) {
					Console.WriteLine("¿Desea dejar el expediente sin asignar? S/N");
					rta = Console.ReadLine().ToUpper();
				} 					
			} while ( rta != "N");
			
			return a;
		}
	}
}