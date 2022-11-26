// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TP.Main.NSMenu.Fabrica;
using TP.TP1;
using TP.TP2;
using TP.TP3;
using TP.TP4;
using TP.TP5;
using TP.TP6;
using TP.TP7;

namespace TP.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action[] f = { TpUno.TpMenu, TpDos.TpMenu, TpTres.TpMenu, TpCuatro.TpMenu
                         , TpCinco.TpMenu, TpSeis.TpMenu, TpSiete.TpMenu};
            FabMenu.Crear(f, 
                  "TPs:         \n"
                + "----         \n"
                + " 1) TP 1     \n"
                + " 2) TP 2     \n"
                + " 3) TP 3     \n"
                + " 4) TP 4     \n"
                + " 5) TP 5     \n"
                + " 6) TP 6     \n"
                + " 7) TP 7     \n"
                , leerTeclaPosEjecutar : false ).Ejecutar();
        }

    }
}