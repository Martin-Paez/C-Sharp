// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TP.Main.NSMenu.Fabrica;
using TP.TP1;
using TP.TP2;
using TP.TP3;

namespace TP.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action[] f = { TpUno.TpMenu, TpDos.TpMenu, TpTres.TpMenu };
            FabMenu.Crear(f, 
                  "TPs:         \n"
                + "----         \n"
                + " 1) TP 1     \n"
                + " 2) TP 2     \n"
                + " 3) TP 3     \n"
                , leerTeclaPosEjecutar : false ).Ejecutar();
        }

    }
}