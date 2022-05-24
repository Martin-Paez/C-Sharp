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

		public Abogado GetAbogado(string dni) {
			int i = this.existeAbogado(dni);
			if ( i == -1 )
				return null;
			return (Abogado) abogados[i];
		}
		
		public void AgregarAbogado(Abogado abogado)
		{
			if (this.existeAbogado(abogado.Dni) > -1)
				throw new Exception("El dni ya esta registrado");
			abogados.Add(abogado);
		}
		
		public void AgregarExpediente(Expediente e)
		{
			if (this.existeExpediente(e.Numero))
				throw new Exception("El numero de expediente ya esta registrado");
			expedientes.Add(e);
		}
		
		private bool existeExpediente(string numero){
			int i = -1;
			while ( (++i<=expedientes.Count-1) && ((Expediente)expedientes[i]).Numero != numero);
			return i<=abogados.Count-1;
		}
		
		private int existeAbogado(string dni){
			int i = -1;
			while ( (++i<abogados.Count) && ((Abogado)abogados[i]).Dni != dni );
			if ( i > abogados.Count)
				i = 0;
			return i-1;
		}
		
		public bool EliminarAbogado(string dni) {
			int i = this.existeAbogado(dni);
			int j = -1;
			bool existe= i > -1;
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
