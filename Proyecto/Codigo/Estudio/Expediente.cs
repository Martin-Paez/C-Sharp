/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 19:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ListaIdNS;

namespace EstudioNS
{
	/// <summary>
	/// Description of Expediente.
	/// </summary>
	public class Expediente
	{
		private Persona titular;
		private string tipo;
		private string estado;
		protected Abogado abogado = null;
		private DateTime fechaCreacion;
		private string numero;
		

		public Expediente(string numero, Persona titular, string tipo, string estado, DateTime fechaCreacion)
		{
			this.numero = numero;
			this.titular = titular;
			this.tipo = tipo;
			this.estado = estado;
			this.fechaCreacion = fechaCreacion;
		}
		
		public Abogado GetAbogado() {
			return this.abogado;
		}

		public virtual string Numero {
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
		
		public DateTime FechaCreacion{
			set{this.fechaCreacion=value;}
			get{return this.fechaCreacion;}
		}

		public override string ToString() {
			string str = "EXPEDIENTE " + this.numero +"\n";
			str += "\nEstado: " + this.estado;
			str += "\nTipo: " + this.tipo;
			str += "\nFecha de creacion: " + this.fechaCreacion.ToString("d");
			str += "\n\nDATOS DEL TITULAR: ";
			str += "\n"+this.titular.ToString();
			str += "\n\nDATOS DEL ABOGADO: ";
			if (this.abogado != null) 
				str += "\n" + this.GetAbogado().ToString() + "\n";
			else 
				str += "\n\nNo tiene un abogado asignado \n";
			return str;
		}

	}

}
