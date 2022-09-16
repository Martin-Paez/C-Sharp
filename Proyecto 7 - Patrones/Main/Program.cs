// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TP.TP1;
using TP.TP2;
using TP.TP3;

namespace TP.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<bool>[] f = { TpUno.TpMenu, TpDos.TpMenu, TpTres.TpMenu };
            Menu.run(ref f, 
                  "TPs:         \n"
                + "----         \n"
                + " 1) TP 1     \n"
                + " 2) TP 2     \n"
                + " 3) TP 3     \n"
                + " s) Salir    \n"
                , mostrarFin : false);

        }

    }
}