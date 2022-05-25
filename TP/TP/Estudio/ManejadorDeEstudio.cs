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
	public class ManejadorDeEstudio
	{
		public ManejadorDeEstudio()
		{
		}
		
		public static void resolver(string err, Estudio e){
			switch(err) {
				case "E1":
					dniAbogado(e,"Hay un abogado registrado con el mismo DNI");
					break;
				case "E2":
					numeroExpediente(e,"Hay un expediente registrado con el mismo numero");
					break;
				case "A1":
					expedientesAsignados(e,"El abogado ya tiene demasiados expedientes asignados");
					break;
				default:
					errInesperado("Surgio un error inesperado");
					break;
			}
			
		}
		
		protected static int dniAbogado(Estudio e, string err){
			Console.WriteLine(err);
		}
		
		protected static int numeroExpediente(Estudio e, string err){
			Console.WriteLine(err);
		}
			
		protected static int expedientesAsignados(Estudio e, string err){
			Console.WriteLine(err);
		}
		
		protected static void errInesperado(string err){
			Console.WriteLine(err);
		}
					
	}
}
