using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Clases;
using TP.TP7.ChainOR;

namespace TP.TP7.Clases.Utiles
{
    public class GenAleatorioDeDatos : GenDatos
    {
        private static GenAleatorioDeDatos? Gen = null;
        private GenAleatorioDeDatos(GenDatos? sig) : base(sig)
        {
        }
        public static GenAleatorioDeDatos GetInstance(GenDatos? sig = null)
        {
            if (Gen == null)
                Gen = new GenAleatorioDeDatos(sig);
            else if (sig != null && Gen.Sig != null
                && !Gen.Sig.Equals(sig))
                throw new Exception("Ya existe una instancia con otro GenDatos");
            return Gen;
        }
        static public int NumeroAleatorio(int max, int min=1)
        {
            return new Random((int)DateTime.Now.Ticks).Next(min,max);
        }
        static public string StringAleatorio(int cant)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            string s = "";
            for(int i=0; i<cant; i++)
                s += (char)r.Next();
            return s;
        }
        static public int DniAleatorio()
        {
            int d = 0;
            // un numero razonable para un DNI actual
            while (d < 1000000 || d > 200000000)
                d = new Random().Next();
            return d;
        }
        static public string NombreAleatorio()
        {
            string[] noms = new string[] { "Carlos", "Esteban", "Ana",
            "Maria", "Juan", "Pablo", "Lucia", "Nicolas", "Diego"};
            return noms[new Random().Next() % 8];
        }
        public static DateTime FechaAleatoria()
        {
            int dia, mes, anio;
            dia = GenAleatorioDeDatos.NumeroAleatorio(31);
            mes = GenAleatorioDeDatos.NumeroAleatorio(12);
            anio = GenAleatorioDeDatos.NumeroAleatorio(DateTime.Now.Year, 1900);
            string fecha = anio.ToString();
            fecha += (mes < 10) ? "0" : "";
            fecha += mes.ToString();
            fecha += (dia < 10) ? "0" : "";
            fecha += dia.ToString();
            DateTime d;
            DateTime.TryParseExact(fecha, "yyyyMMdd"
            , CultureInfo.InvariantCulture
                         , DateTimeStyles.None, out d);
            return d;
        }

        public override int GetNum(int min, int max, string tag)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.GetNum(max, min, tag);
        }

        public override string GetS(int len, string tag)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.GetS(len, tag);
        }

        public override int RandNum(int min, int max)
        {
            return NumeroAleatorio(max,min); 
        }

        public override string RandS(int len)
        {
            return StringAleatorio(len);
        }
    }
}
