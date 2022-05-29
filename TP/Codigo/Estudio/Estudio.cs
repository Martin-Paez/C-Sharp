using System;
using System.Collections;
using IdentificableNS;

namespace EstudioNS
{
	public class Estudio {
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

		// Excepcion NumExpedienteRepetido()
        // Excepcion DemasiadosExpedientes()
        // No puedo reutilizar el del padre, por el orden de chequeos
        public void Agregar(Expediente e) {
        	if ( base.existe(e.Numero) )
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se permite asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++;  // Excepcion DemasiadosExpedientes()
			this.lista.Add(e);
		}

        //Excepcion "FaltanExpedientes"
        //Excepcion "DatoInvalido"
        public override Identificable Eliminar(string numero) {
        	int i = base.posicion(numero); //Excepcion "DatoInvalido"
        	Expediente e = (Expediente) this.lista[i];
        	if (e.Abogado != null)
        		e.Abogado.CantExps--; //Excepcion "FaltanExpedientes"
			this.lista.RemoveAt(i); 
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
        
        // Excepcion IdInvalido()
		// InconsistenciaExpedientesSinAsignar
		public override Identificable Eliminar(string dni) {
			Abogado a = (Abogado) base.Eliminar(dni); //Excepcion IdInvalido()
            int j = -1;
            bool warning = false;
			ListaExpedientes exps = this.estudio.Expedientes;
            while ( a.CantExps > 0 && ++j<exps.Count() ) {
				Expediente e = (Expediente)exps.Get(j);
				if ( e != null && e.Abogado.Dni == a.Dni ) {
					e.Abogado = null;
					try{
						a.CantExps--;
					} catch (FaltanExpedientes){						
						warning = true;
					};
				}
			}
			if (warning)
				throw new InconsistenciaExpedientesSinAsignar(a);
            return a;
        }
        
    }
	
	public class DniRepetido:DatoInvalido{
		public DniRepetido(){
			this.msg = "\nYa existe un abogado con el mismo DNI";
		}
	}

	public class NumExpedienteRepetido:DatoInvalido{
		public NumExpedienteRepetido(){
			this.msg = "\nHay un expediente registrado con el mismo numero";
		}
	}

	
	public class InconsistenciaExpedientesSinAsignar:DatoInvalido{
		public InconsistenciaExpedientesSinAsignar(Abogado a) {
			this.msg = "\nWARNING: Se detecto que el abogado tenia un conteo erroneo en la cantidad de expedientes asignados";
		}
	}
}