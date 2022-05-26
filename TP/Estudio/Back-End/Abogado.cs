﻿/*
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
		private int cantExps = 0;
		private int maxExp = 6;
		
		public Abogado(string nombre, string apellido, string dni, string espec):base(nombre, apellido, dni)
		{
			this.espec = espec;
		}
		
		public string Espec {
			set{this.espec=value;}
			get{return this.espec;}
		}
		
		public int CantExps{
			set{
				if ( value>maxExp || value<0 ) 
					throw new DemasiadosExpedientes();
				this.cantExps=value;
			}
			get{return this.cantExps;}
		}

		public int MaxExp{
			get{return this.maxExp;}
		}
		
		public override string ToString() {
			return base.ToString() + "\nEspecializacion: " + this.espec + "\n";
		}
	}
}
