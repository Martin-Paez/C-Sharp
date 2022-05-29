/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using IdentificableNS;

namespace EstudioNS
{
	public class Persona:Identificable
	{
		private string nombre;
		private string apellido;
		
		public Persona(string nombre, string apellido, int dni)
		{
			this.Dni = dni;
			this.Nombre = nombre;
			this.Apellido = apellido;
		}
		
		public string Nombre {
			set{this.nombre=value;}
			get{return this.nombre;}
		}
		
		public string Apellido {
			set{this.apellido=value;}
			get{return this.apellido;}
		}
		
		// Excepcion DniFormatoIvalido()
		// Se implementa aca para evitar estar validando los datos ingresados como string en cada lugar 
		// donde es construido o modificado el objeto Persona. A demas, este modo permite brindar un mensaje 
		// por defecto en la clase DniFormatoInvalido.
		public int Dni {
			set{this.id=value.ToString();}
			get{return int.Parse(this.id);}
		}

		public override string ToString() {
			return "Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.id;
		}
	}

}
