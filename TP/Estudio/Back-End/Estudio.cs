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
			this.abogados = new ArrayList(this);
			this.exps = new ArrayList();
		}

		public ArrayList Abogados {
			
			get{return this.abogados;}
		}
		
		public ArrayList Expedientes{
			
			get{return this.exps;}
		}

	}
}