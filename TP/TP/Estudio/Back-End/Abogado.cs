/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EstudioNS
{
	/// <summary>
	/// Description of Abogado.
	/// </summary>
	public class Abogado : Persona
	{
		private string espec;
		private int cantExpedientes = 0;
		private const int MAX_EXPEDIENTES = 6;
		
		public Abogado(string nombre, string apellido, string dni, string espec):base(nombre, apellido, dni)
		{
			this.espec = espec;
		}
		
		public string Espec {
			set{this.espec=value;}
			get{return this.espec;}
		}
		
		public int CantExpedientes{
			set{
				if ( this.CantExpedientes + value > MAX_EXPEDIENTES ) 
					throw new Exception("A1");
				this.cantExpedientes=value;
			}
			get{return this.cantExpedientes;}
		}
		
	}
}
