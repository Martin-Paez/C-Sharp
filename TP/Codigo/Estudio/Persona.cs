using System;

namespace EstudioNS
{
	public class Persona
	{
		private string nombre;
		private string apellido;
		private ulong dni;
		
		public Persona(string nombre, string apellido, ulong dni)
		{
			this.dni = dni;
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

		public ulong Dni {
			set{this.dni=value;}
			get{return this.dni;}
		}

		public override string ToString() {
			return "Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.dni.ToString();
		}
	}

}
