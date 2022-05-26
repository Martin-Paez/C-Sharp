using System;
using System.Collections;

namespace EstudioNS
{
	/// <summary>
	/// Estudio de abogados.
	/// </summary>
	public class Estudio
	{
		private ArrayList exps;
		private ArrayList abogados;
		
		public Estudio()
		{
			this.abogados = new ArrayList();
			this.exps = new ArrayList();
		}
		
		public ArrayList Abogados {
			
			get{return this.abogados;}
		}
		
		public ArrayList Expedientes{
			
			get{return this.exps;}
		}

		public Abogado GetAbogado(string dni) {
			int i = this.existeAbogado(dni);
			if ( i == -1 )
				return null;
			return (Abogado) abogados[i];
		}
		
		public void AgregarAbogado(Abogado a)
		{
			if (this.existeAbogado(a.Dni) > -1)
				throw new DniRepetido();
			abogados.Add(a);
		}
		
		public void AgregarExpediente(Expediente e)
		{
			if (this.existeExpediente(e.Numero))
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se puede asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; // cant>6 => throw
			exps.Add(e);
		}
		
		private bool existeExpediente(string numero){
			int i = -1;
			while ( (++i<=exps.Count-1) && ((Expediente)exps[i]).Numero != numero);
			return i<=abogados.Count-1;
		}
		
		private int existeAbogado(string dni){
			int i = -1;
			while ( (++i<abogados.Count) && ((Abogado)abogados[i]).Dni != dni );
			if ( i >= abogados.Count)
				i = -1;
			return i;
		}
		
		public bool EliminarAbogado(string dni) {
			int i = this.existeAbogado(dni);
			int j = -1;
			bool existe= i > -1;
			if (existe) {
				Abogado a = ((Abogado)abogados[i]);
				while ( a.CantExps > 0 && ++j<=exps.Count-1 ) {
					if ( ((Expediente)exps[j]).Abogado.Dni == a.Dni ) {
						((Expediente)exps[j]).Abogado = null;
						a.CantExps--;
					}
				}
				abogados.Remove(a);
			}
			return existe;
		}

	}
}