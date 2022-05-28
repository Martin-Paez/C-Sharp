/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ListaIdNS;

namespace EstudioNS
{
	public class Persona:Identificable
	{
		private string nombre;
		private string apellido;
		
		public Persona(string nombre, string apellido, string dni)
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
		
		public string Dni {
			set{
				try {int.Parse(value);
				}catch{throw new DniFormatoInvalido();}
				this.id=value;}
			get{return this.id;}
		}

		public override string ToString() {
			return "Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.id;
		}
	}
	
	public class DniFormatoInvalido:DatoInvalido{
		public DniFormatoInvalido(){
			this.msg = "\nEl dni debe ser un numero (sin puntos)";
		}
	}

}
