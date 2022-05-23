using System;
using System.Collections;

namespace TP
{
	/// <summary>
	/// Estudio de abogados.
	/// </summary>
	public class Estudio
	{
		private ArrayList expedientes;
		private ArrayList abogados;
		
		public Estudio()
		{
		}
		
		public ArrayList Abogados {
			
			get{return this.abogados;}
		}
		
		public ArrayList Expedientes{
			
			get{return this.expedientes;}
		}

		public public void AgregarAbogado(Abogado abogado)
		{
			abogados.Add(abogado);
		}
	}
}
