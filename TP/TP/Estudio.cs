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

		public void AgregarAbogado(Abogado abogado)
		{
			abogados.Add(abogado);
		}
		
		public void EliminarAbogado(string dni) {
			int i = -1;
			while ( ++i<=abogados.Count()-1 & abogados[i].Dni != dni );
			if (i<=abogados.Count()-1)
				abogados.Remove(abogados[i]);
		}
	}
}
