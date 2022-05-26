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
	public class Persona:Identificable
	{
		private string nombre;
		private string apellido;
		
		public Persona(string nombre, string apellido, string dni)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.id = dni;
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
			set{this.id=value;}
			get{return this.id;}
		}

		public override string ToString() {
			return "Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.id;
		}
	}
}
