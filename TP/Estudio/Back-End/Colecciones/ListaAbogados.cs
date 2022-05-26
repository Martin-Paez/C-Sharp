using System;
using ListaIdNS;

namespace EstudioNS {

    public class ListaAbogados:ListaId {

        private Estudio estudio;

        public ListaAbogados(Estudio e) {
            this.estudio = e;
        }

        // Excepcion DatoInvalido()
		public override void Eliminar(string dni) {
			Abogado a = (Abogado) base.Eliminar(dni); //Excepcion DatoInvalido()
            int j = -1;
            ListaExpedientes exps = this.estudio.Expedientes;
			while ( a.CantExps > 0 && ++j<=exps.Count-1 ) {
				if ( ((Expediente)exps.Get(j)).Abogado.Dni == a.Dni ) {
					((Expediente)exps.Get(j)).Abogado = null;
					a.CantExps--;
				}
			}
        }
        
    }  

}