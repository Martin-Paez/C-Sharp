using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases.Utiles;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP5.Clases.Estrategias;

namespace TP.TP5.Clases.Fabricas.Comparables
{
    public class CmpAlumnosEstudiosos : _CmpAlumnos<AlumnoEstudioso> { }
    public class _CmpAlumnosEstudiosos<T> : _FabAlumnosEstudiosos<T> where T : AlumnoEstudioso
    {
        protected int? Calif;
        protected void CalifRand()
        {
            Calif = GenAleatorioDeDatos.NumeroAleatorio(1, 10);
        }
        protected new void SetRand()
        {
            if (Criterio is PorCalif)
                CalifRand();
            else
                ((_CmpAlumnos<T>)this).SetRand();
        }
        public override T Rand()
        {
            SetRand();
            return CrearAlumnoEstudioso();
        }
        protected void CalifTeclado()
        {
            Calif = Helper.LeerNumero(1, 10, "Calificacion: ");
        }
        protected new void SetTeclado()
        {
            if (Criterio is PorCalif)
                CalifTeclado();
            else
                ((_CmpPersonas<T>)this).SetTeclado();
        }
        public override T Teclado()
        {
            SetTeclado();
            return CrearAlumnoEstudioso();
        }
    }
}
