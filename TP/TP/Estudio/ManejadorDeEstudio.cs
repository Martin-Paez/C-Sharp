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
		
		public void resolver(string err, Estudio e){
			switch(err) {
				case "E0":
					dniAbogado(e,"No hay ningun abogado registrado con ese DNI");
					break;
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
		
		public virtual Abogado dniAbogado(Estudio e, string err){
			Console.WriteLine(err);
			return null;
		}
		
		protected Expediente numeroExpediente(Estudio e, string err){
			Console.WriteLine(err);
			return null;
		}
			
		protected Abogado expedientesAsignados(Estudio e, string err){
			Console.WriteLine(err);
			return null;
		}
		
		protected static void errInesperado(string err){
			Console.WriteLine(err);
		}
					
	}
}
