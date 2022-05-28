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
				if ( value>maxExp ) 
					throw new DemasiadosExpedientes();
				else if ( value<0 )
					throw new FaltanExpedientes();
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
	
	public class DemasiadosExpedientes:DatoInvalido{
		public DemasiadosExpedientes(){
			this.msg = "\nEl abogado ya tiene demasiados expedientes asignados";
		}
	}

	public class FaltanExpedientes:DatoInvalido{
		public FaltanExpedientes() {
			this.msg = "\nEl abogado ya no tiene mas expedientes asignados";
		}
	}
}
