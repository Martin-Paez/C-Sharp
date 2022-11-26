/*
 * Created by Metodologías de Programación I
 * Activity 7. 
 * Chain of responsability and Singleton patterns 
 *
 * Antes de usar este código el alumno deberá agregar a la variable "ruta_archivo" de la clase 
 * "LectorDeArchivos" la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
 * provistos por la cátedra (archivo datos.txt)
 *
 * IMPORTANTE *  
 * El código que está en este archivo SI puede modificarse para resolver la actividad solicitada
 * 
 */

using System;
using System.IO;
using TP.TP7.ChainOR;

namespace TP.TP7.Clases.Utiles
{
    public class LectorDeArchivos : GenDatos, IDisposable
    {

        // El alumno deberá agregar la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
        private const string ruta_archivo = @"C:\Users\54911\Documents\GitHub\Estudio-Abogados\Proyecto 7 - Patrones\TP7\src\datos.txt";
        // --------------------------------------------------------------------------------------------------------

        private StreamReader lector_de_archivos;
        private static LectorDeArchivos? Gen = null;
        public LectorDeArchivos(GenDatos? sig) : base(sig)
        {
            lector_de_archivos = new StreamReader(ruta_archivo);
        }
        public static LectorDeArchivos GetInstance(GenDatos? sig = null)
        {
            if (Gen == null)
                Gen = new LectorDeArchivos(sig);
            else if (sig != null && Gen.Sig != null
                && !Gen.Sig.Equals(sig))
                throw new Exception("Ya existe una instancia con otro GenDatos");
            return Gen;
        }
        public int numeroDesdeArchivo(double max)
        {
            string linea = lector_de_archivos.ReadLine();
            return (int)(double.Parse(linea.Substring(0, linea.IndexOf('\t'))) * max);
        }

        public string stringDesdeArchivo(int cant)
        {
            string linea = lector_de_archivos.ReadLine();
            linea = linea.Substring(linea.IndexOf('\t') + 1);
            cant = Math.Min(cant, linea.Length);
            return linea.Substring(0, cant);
        }

        public void Dispose()
        {
            lector_de_archivos?.Dispose();
        }

        public override int GetNum(int min, int max, string tag)
        {
            int n = 0;
            while ((n = numeroDesdeArchivo(max)) < min);
            return n;
        }

        public override string GetS(int len, string tag)
        {
            return stringDesdeArchivo(len);
        }

        public override int RandNum(int min, int max)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.RandNum(max, min);
        }

        public override string RandS(int len)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.RandS(len);
        }
    }
}
