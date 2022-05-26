using System;
using ListaIdNS;

namespace EstudioNS {

    public class ListaExpedientes:ListId{

        // Excepcion "DemasiadosExpedientes"
        // No puedo reutilizar el del padre, por el orden de chequeos
        public override void Agregar(Expediente e)
		{
			if ( base.existe(e.Numero) )
				throw new NumExpedienteRepetido();
			if (e.Abogado != null) // Se permite asignar despues. Idem al despedir un abogado.
				e.Abogado.CantExps++; 
			this.lista.Add(e);
		}

        //Excepcion "FaltanExpedientes"
        //Excepcion "DatoInvalido"
        public override void Eliminar(string numero) {
			Expediente e = (Expediente) base.Eliminar(numero); //Excepcion "DatoInvalido"
            e.Abogado.CantExps--; // Excepcion "FaltanExpedientes" 
		}

    }

}