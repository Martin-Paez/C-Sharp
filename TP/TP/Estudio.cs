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
			this.abogados = new ArrayList();
			this.expedientes = new ArrayList();
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
		
		public void AgregarExpediente(Expediente e)
		{
			expedientes.Add(e);
		}
		
		public bool EliminarAbogado(string dni) {
			int i = -1, j = -1;
			bool existe=false;
			while ( (existe = (++i<=abogados.Count-1)) && ((Abogado)abogados[i]).Dni != dni );
			if (existe) {
				Abogado abogado = ((Abogado)abogados[i]);
				while ( abogado.CantExpedientes > 0 && ++j<=expedientes.Count-1 ) {
					if ( ((Expediente)expedientes[j]).Abogado.Dni == abogado.Dni ) {
						((Expediente)expedientes[j]).Abogado = null;
						abogado.CantExpedientes--;
					}
				}
				abogados.Remove(abogado);
			}
			return existe;
		}

	}
}