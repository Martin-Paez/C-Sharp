/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP
{
	/// <summary>
	/// Description of Abogado.
	/// </summary>
	public class Abogado : Persona
	{
		private string espec;
		private int cantExpedientes = 0;
		
		public Abogado(string nombre, string apellido, string dni, string espec):base(nombre, apellido, dni)
		{
			this.espec = espec;
		}
		
		public string Espec {
			set{this.espec=value;}
			get{return this.espec;}
		}
		
		public int CantExpedientes{
			set{this.cantExpedientes=value;}
			get{return this.cantExpedientes;}
		}
		
	}
}
