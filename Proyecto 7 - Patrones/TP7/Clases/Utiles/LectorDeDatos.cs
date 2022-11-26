using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.ChainOR;

namespace TP.TP7.Clases.Utiles
{
    public class LectorDeDatos : GenDatos
    {
        private static LectorDeDatos? Gen = null;
        private LectorDeDatos(GenDatos? sig) : base(sig)
        {
        }
        public static LectorDeDatos GetInstance(GenDatos? sig = null)
        {
            if (Gen == null)
                Gen = new LectorDeDatos(sig);
            else if (sig != null && Gen.Sig != null 
                && ! Gen.Sig.Equals(sig))
                throw new Exception("Ya existe una instancia con otro GenDatos");
            return Gen;
        }

        public static int LeerNumero(int min, int max, string etiqueta)
        {
            int o;
            do
            {
                try
                {
                    string s = Helper.Leer(etiqueta);
                    o = int.Parse(Helper.QuitarPuntos(s));
                    if (o < min || o > 200000000)
                        throw new Exception();
                    return o;
                }
                catch (Exception)
                {
                    Console.WriteLine("{0} debe ser un numero >= a {1} y <= a {2}", etiqueta, min, max);
                }
            } while (true);
        }

        static public string StringPorTeclado(string etiqueta)
        {
            Console.WriteLine(etiqueta);
            return Console.ReadLine()!;
        }

        public override int GetNum(int min, int max, string tag)
        {
            return LeerNumero(min, max, tag);
        }

        public override string GetS(int len, string tag)
        {
            string s = "";
            while ((s = StringPorTeclado(tag)).Length < len) ;
            return s;
        }

        public override int RandNum(int min, int max)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.RandNum(min, max);
        }

        public override string RandS(int len)
        {
            if (Sig == null)
                throw new Exception("Nadie pudo responder la solicitud");
            return Sig.RandS(len);
        }
    }
}
