using System;
using System.Collections;
using ListaIdNS;

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
			if (e.Abogado != null) // Se permite asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; // Excepcion por cant>6
			exps.Add(e);
		}

		public bool EliminarExpediente(string numero) {
			int i = posicion(numero, exps);
			if ( i==-1 )
				return false;
			((Expediente)exps[i]).Abogado.CantExps--;
			exps.RemoveAt(i);
			return true;
		}

		public bool EliminarAbogado(string dni) {
			int i = posicion(dni, abogados);
			if ( i==-1 )
				return false;
			Abogado a = ((Abogado)abogados[i]);
			int j = -1;
			while ( a.CantExps > 0 && ++j<=exps.Count-1 ) {
				if ( ((Expediente)exps[j]).Abogado.Dni == a.Dni ) {
					((Expediente)exps[j]).Abogado = null;
					a.CantExps--;
				}
			}
			abogados.Remove(a);
			return true;
		}
		
		public ArrayList Abogados {
			
			get{return this.abogados;}
		}
		
		public ArrayList Expedientes{
			
			get{return this.exps;}
		}

	}
}