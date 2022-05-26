/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 19:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EstudioNS
{
	/// <summary>
	/// Description of Expediente.
	/// </summary>
	public class Expediente
	{
		private string numero;
		private Persona titular;
		private string tipo;
		private string estado;
		private Abogado abogado;
		private DateTime fechaCreacion;
		
		public Expediente(string numero, Persona titular, string tipo, string estado, Abogado abogado, DateTime fechaCreacion)
		{
			this.numero = numero;
			this.titular = titular;
			this.tipo = tipo;
			this.estado = estado;
			this.abogado = abogado;
			this.fechaCreacion = fechaCreacion;
		}
		
		public string Numero {
			set{this.numero=value;}
			get{return this.numero;}
		}
		
		public Persona Titular {
			set{this.titular=value;}
			get{return this.titular;}
		}
		
		public string Tipo {
			set{this.tipo=value;}
			get{return this.tipo;}
		}
		
		public string Estado {
			set{this.estado=value;}
			get{return this.estado;}
		}
		
		public Abogado Abogado{
			set{this.abogado=value;}
			get{return this.abogado;}
		}
		
		public DateTime FechaCreacion{
			set{this.fechaCreacion=value;}
			get{return this.fechaCreacion;}
		}

		public override string ToString() {
			Console.WriteLine("Numero de expediente: " + e.Numero);
			Console.WriteLine("Estado: " + e.Estado);
			Console.WriteLine("Tipo: " + e.Tipo);
			Console.WriteLine("Fecha de creacion: " + e.FechaCreacion.ToString("d"));
			Console.WriteLine("\nDatos del titular: ");
			Console.WriteLine(e.Titular);
			if (e.Abogado != null) {
				Console.WriteLine("\nDatos del abogado: ");
				Console.WriteLine(e.Abogado);
				Console.WriteLine("");
			} else 
				Console.WriteLine("\nNo tiene un abogado asignado \n");
		}

	}
}
