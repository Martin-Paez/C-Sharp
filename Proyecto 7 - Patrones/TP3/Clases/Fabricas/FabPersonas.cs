using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;

namespace TP.TP3.Clases.Fabricas
{
    public class FabPersonas : _FabPersonas<Persona> { }
    public class _FabPersonas<T> : FabricaDeComparables<T> where T : Persona
    {
        protected int? Dni = null;
        protected string? Nombre = null;

        public void DniRand()
        {
            Dni = GenAleatoriosDeDatos.DniAleatorio();
        }
        public void NombreRand()
        {
            Nombre = GenAleatoriosDeDatos.NombreAleatorio();
        }
        public virtual void SetRand()
        {
            DniRand();
            NombreRand();
        }
        protected override T Rand()
        {
            SetRand();
            return (T)new Persona(Nombre, Dni);
        }
    }
}
