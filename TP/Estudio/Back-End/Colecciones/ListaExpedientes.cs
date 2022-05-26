using System;
using ListaIdNS;

namespace EstudioNS {

    public class ListaExpedientes:ListId{

        // Excepcion "DemasiadosExpedientes"
        public override void Agregar(Expediente e)
		{
			if ( base.existe(e.Numero) )
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se permite asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; 
			this.list.Add(e);
		}

        // Excepcion IndexOutOfRangeException
        public Expediente Get(int i) {
            return (Expediente) this.list[i];
        }

        public Expediente Get(string id){
            return (Expediente) base.Get(id)
        }

        //// Excepcion "FaltanExpedientes"
        public override bool Eliminar(string numero) {
			int i = base.posicion(numero);
			if ( i==-1 )
				return false;
			this.Get(i).Abogado.CantExps--; 
			this.list.RemoveAt(i);
			return true;
		}

    }

}