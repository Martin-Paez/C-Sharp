/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP
{
	/// <summary>
	/// Description of Manejador.
	/// </summary>
	public class Manejador
	{
		public Manejador()
		{
		}
		
		public static void resolver(string codigo){
			switch(codigo) {
				case "E1":
					msg = "El dni ya esta registrado";
					break;
				default:
					msg = "Surgio un error inesperado";
					break;
			}
			Console.WriteLine("\n"+msg);
		}
	}
}
