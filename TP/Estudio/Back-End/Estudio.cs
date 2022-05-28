using System;
using System.Collections;
using ListaIdNS;

namespace EstudioNS
{
	public class Estudio
	{
		private ListaExpedientes exps;
		private ListaAbogados abogados;
		
		public Estudio() {
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
	
	public class ListaExpedientes:ListaId{

        // Excepcion "DemasiadosExpedientes"
        // No puedo reutilizar el del padre, por el orden de chequeos
        public void Agregar(Expediente e) {
        	if ( base.existe(e.Numero) )
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se permite asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; 
			this.lista.Add(e);
		}

        //Excepcion "FaltanExpedientes"
        //Excepcion "DatoInvalido"
        public override Identificable Eliminar(string numero) {
			Expediente e = (Expediente) base.Eliminar(numero); //Excepcion "DatoInvalido"
            e.Abogado.CantExps--; // Excepcion "FaltanExpedientes" 
            return e;
		}

	}
	
	public class ListaAbogados:ListaId {

        private Estudio estudio;

        public ListaAbogados(Estudio e) {
            this.estudio = e;
        }

        public void Agregar(Abogado a){
			if ( existe(a.Id) )
				throw new DniRepetido();
			this.lista.Add(a);
		}
        
        // Excepcion DatoInvalido()
		public override Identificable Eliminar(string dni) {
			Abogado a = (Abogado) base.Eliminar(dni); //Excepcion DatoInvalido()
            int j = -1;
            ListaExpedientes exps = this.estudio.Expedientes;
            while ( a.CantExps > 0 && ++j<=exps.Count()-1 ) {
				if ( ((Expediente)exps.Get(j)).Abogado.Dni == a.Dni ) {
					((Expediente)exps.Get(j)).Abogado = null;
					a.CantExps--;
				}
			}
            return a;
        }
        
    }

}