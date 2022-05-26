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
			int i = posicion(a.Dni, abogados);
			if ( i == -1 )
				return null;
			return (Abogado) abogados[i];
		}
		
		public void AgregarAbogado(Abogado a)
		{
			if ( existe(a.Dni, abogados) )
				throw new DniRepetido();
			abogados.Add(a);
		}
		
		public void AgregarExpediente(Expediente e)
		{
			if ( existe(e.Numero,exps) )
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se puede asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; // cant>6 => throw
			exps.Add(e);
		}

		private int posicion(string id, ArrayList list){
			int i = -1;
			while ( (++i<list.Count) && ((Identificable)list[i]).Id != id );
			if ( i >= list.Count)
				i = -1;
			return i;
		}

		private bool existe(string id, ArrayList list){
			return posicion(id, list) > -1;
		}
		
		public bool EliminarAbogado(string dni) {
			int i = existe(a.Dni, abogados);
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