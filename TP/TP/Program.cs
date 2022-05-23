/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP
{
	class Program
	{
		public static void Main(string[] args)
		{
			string nombre = "maxi";
			string apellido = "lopez";
			string dni = "34.123.123";
			Persona titular = new Persona(nombre,apellido,dni);
			
			string espec = "familiar";
			Abogado abogado = new Abogado(nombre, apellido, dni, espec);
			
			Expediente expediente = new Expediente(1,titular,"audiencia", "activo", abogado, DateTime.Today());
			
			Console.WriteLine("");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void imprimirPersona(Persona p) {
			Console.WriteLine(p.Nombre);
		}
	}
}