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
		private ListaExpedientes exps;
		private ListaAbogados abogados;
		
		public Estudio()
		{
			this.abogados = new ListaAbogados(this);
			this.exps = new ListaExpedientes();
		}

		public ListaAbogados Abogados {
			
			get{return this.abogados;}
		}
		
		public ListaExpedientes Expedientes{
			
			get{return this.exps;}
		}

	}
}