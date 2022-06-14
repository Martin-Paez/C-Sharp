using System;
using ListaIdNS;

namespace EstudioNS
{
	public class Persona
	{
		private string nombre;
		private string apellido;
		private string dni;
		
		public Persona(){}

		// FormatoDni
		public Persona(string nombre, string apellido, string dni)
		{
			this.Dni = dni; // FormatoDni
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

		// FormatoDni
		public virtual string Dni {
			set{
				try {
					ulong.Parse(value);
				} catch {
					throw new FormatoDni();
				}
				this.dni= value;}
			get{return this.dni;}
		}

		public override string ToString() {
			return "Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.dni.ToString();
		}
	}

}

public class FormatoDni:DatoInvalido {
	public FormatoDni() {
		this.msg = "El DNI debe ser un numero entero (sin puntos)";
	}
}
