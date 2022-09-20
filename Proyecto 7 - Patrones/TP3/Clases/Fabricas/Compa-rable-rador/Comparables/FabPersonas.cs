using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Main.NSMenu.Fabrica;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Utiles;
using TP.TP3.Interfaces.Comparar;

namespace TP.TP3.Clases.Fabricas.Comparables
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
        public override T Rand()
        {
            SetRand();
            return CrearPersona();
        }
        public void DniTeclado()
        {
            Dni = Helper.LeerNumero(1000000, 200000000, "DNI: ");
        }
        public void NombreTeclado()
        {
            Nombre = Helper.LeerLetras("Nombre: ");
        }
        public virtual void SetTeclado()
        {
            DniTeclado();
            NombreTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearPersona();
        }
        public T CrearPersona()
        {
            Persona p = new(Nombre, Dni);
            if (Criterio != null)
                p.Cmp = (Comparador<Persona?>)Criterio;
            return (T)(object)p;
        }
        protected override Comparador<T>? CrearCriterio()
        {
            return FabMenu.Crear(Comparadores(), CriterioMenu(), limpiarConsola: false).Ejecutar();
        }
        protected virtual IList<Func<Comparador<T>?>> Comparadores()
        {
            List<Func<Comparador<T>?>> list = new()
            {
                () => { return new PorDni(); },
                () => { return new PorNom(); }
            };
            return list;
        }
        protected virtual string CriterioMenu()
        {
            return "Criterio:    \n"
                 + "---------    \n"
                 + "  1) DNI     \n"
                 + "  2) Nombre  \n";
        }
    }
}
