using System;
using System.Collections;
using IdentificableNS;

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
        	int i = base.posicion(numero); //Excepcion "DatoInvalido"
        	Expediente e = (Expediente) this.lista[i];
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
        
        // Excepcion DatoInvalido()
		// InconsistenciaExpedientesSinAsignar
		public override Identificable Eliminar(string dni) {
			Abogado a = (Abogado) base.Eliminar(dni); //Excepcion DatoInvalido()
            int j = -1;
            bool warning = false;
			ListaExpedientes exps = this.estudio.Expedientes;
            while ( a.CantExps > 0 && ++j<=exps.Count()-1 ) {
				if ( ((Expediente)exps.Get(j)).Abogado.Dni == a.Dni ) {
					((Expediente)exps.Get(j)).Abogado = null;
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
		private Abogado a;
		public InconsistenciaExpedientesSinAsignar(Abogado a) {
			this.msg = "\nWARNING: Se detecto que el abogado tenia un conteo erroneo en la cantidad de expedientes asignados";
			this.a = a;
		}

		public Abogado abogado{
			get{return a;}
		}
	}
}