/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EstudioNS
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Persona
	{
		private string nombre;
		private string apellido;
		private string dni;
		
		public Persona(string nombre, string apellido, string dni)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
		}
		
		public string Nombre {
			set{this.nombre=value;}
			get{return this.nombre;}
		}
		
		public string Apellido {
			set{this.apellido=value;}
			get{return this.apellido;}
		}
		
		public string Dni {
			set{this.dni=value;}
			get{return this.dni;}
		}
	}
}
