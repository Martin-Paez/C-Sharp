using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Colecciones;
using TP.TP2.Interfaces;
using TP.TP2.Clases;
using System.Diagnostics;
using TP.Main;

namespace TP.TP2
{
    public class TpDos
    {
        public static bool TpMenu()
        {
            Func<bool>[] f = { EjDos};
            Menu.run(ref f,
                  "Ejercicios:              \n"
                + "-----------              \n"
                + " 1)Ejercicio 2 (tp.ej7)  \n"
                + " s)Salir                 \n");
            return false;
        }

        public static bool EjDos()
        {
            exEjDiecisiete();
            Console.WriteLine(" El enunciado pedia modificar LlenarAlumnos(), sin embargo\n"
                            + " se deberia haber modificado Informar() , para que solo se\n"
                            + " asigne la estrategia al Alumno creado para buscar, y no\n"
                            + " a cada uno de los alumnos en la lista (que tiene la opcion\n"
                            + " por defecto del constructor) . Por ese motivo se decidio que\n"
                            + " el metodo Contiene() (perteneciente a la coleccion) invoque la\n"
                            + " estrategia sobre el parametro recibido. Cabe aclarar que esta \n"
                            + " decision respeta el enunciado, o sea, solo se modifico \n"
                            + " LlenarAlumnos(), sin tocar la funcion Informar(). Si bien no\n"
                            + " soluciona el problema, la clase Coleccion() queda preparada para\n"
                            + " para trabajar del modo eficiente. "
                            + " Por otro lado, para cumplir con lo antes mencionado, se modifico \n"
                            + " LeerComparableDelTipo() para que setee el comparador del objeto \n"
                            + " creado para buscar, de modo que tenga el mismo tipo de comparador\n"
                            + " que el parametro recibido.\n");
            return true;
        }

        public static bool exEjDiecisiete()
        {
            Console.WriteLine("Ejercicio 17:\n-------------\n");
            Pila<Alumno> p = new Pila<Alumno>();
            Cola<Alumno> c = new Cola<Alumno>();
            ColeccionMultiple<Alumno> m = new ColeccionMultiple<Alumno>(p, c);
            Console.WriteLine("Alumnos\n");
            LlenarAlumnos(p);
            LlenarAlumnos(c);
            Console.WriteLine("Pila + Cola\n");
            Informar(m);
            return true;
        }

        // Para simplificar agrega numeros del 0 al 100
        public static void Llenar(Coleccionable<Numero> c)
        {
            for (int i = 0; i < 20; i++)
            {
                c.Agregar(new Numero(new Random().Next() % 100));
            }
        }

        public static int RandomDni()
        {
            int d = 0;
            // un numero razonable para un DNI actual
            while (d < 1000000 || d > 200000000)
                d = new Random().Next();
            return d;
        }

        public static string RandomNombre()
        {
            string[] noms = new string[] { "Carlos", "Esteban", "Ana",
            "Maria", "Juan", "Pablo", "Lucia", "Nicolas", "Diego"};
            return noms[new Random().Next() % 8];
        }

        public static void LlenarPersonas(Coleccionable<Persona> c)
        {
            for (int i = 0; i < 20; i++)
                c.Agregar(new Persona(RandomNombre(), RandomDni()));
        }

        public static void LlenarAlumnos(Coleccionable<Alumno> c)
        {
            for (int i = 0; i < 20; i++)
            {
                int leg = 0;
                // un numero razonable para un legajo
                while (leg < 1000 || leg > 100000)
                    leg = new Random().Next();
                int p = new Random().Next() % 10;
                Alumno a = new Alumno(RandomNombre(), RandomDni(), leg, p);
                a.CmpA = new PorNom();
                c.Agregar(a);
            }
        }

        public static void Informar<T>(Coleccionable<T> c) where T : Comparable<T>
        {
            int size = c.Cuantos();
            if (size == 0)
            {
                Console.WriteLine("No Hay elementos\n");
                return;
            }
            Console.WriteLine("Hay {0} elementos\n", size);
            T? e = c.Minimo();
            Console.WriteLine("El más chico es {0}\n", e);
            Console.WriteLine("El más grande es {0}\n", c.Maximo());
            T? f = default;
            while (f == null && e != null)
                f = (T?) LeerComparableDelTipo(e);
            if ( f != null )
                if (c.Contiene(f))
                    Console.WriteLine("\n{0}, está en la colección\n", f);
                else
                    Console.WriteLine("\n{0}, no está en la colección\n", f);
            Console.WriteLine("");
        }

        private static object? LeerComparableDelTipo(object? o)
        {
            try
            {
                string? s;
                switch (o!.GetType().Name)
                {
                    case "Alumno":
                        switch (((Alumno)o).CmpA.GetType().Name)
                        {
                            case "PorDni":
                                Console.Write("\n\nDNI : ");
                                s = Console.ReadLine();
                                o = (object)new Alumno("", int.Parse(s!), null, 0);
                                ((Alumno)o).CmpA = new PorDni();
                                break;
                            case "PorLeg":
                                Console.Write("\n\nLegajo : ");
                                s = Console.ReadLine();
                                o = (object)new Alumno("", null, int.Parse(s!), 0);
                                ((Alumno)o).CmpA = new PorLeg();
                                break;
                            case "PorNom":
                                Console.Write("\n\nNombre : ");
                                s = Console.ReadLine();
                                o = (object)new Alumno(s!, null, null, 0);
                                ((Alumno)o).CmpA = new PorNom();
                                break;
                            default:
                                Console.WriteLine("{0} no implementada", ((Alumno)o).CmpA.GetType().Name);
                                o = null;
                                break;
                        }
                        break;
                    case "Persona":
                        Console.Write("DNI : ");
                        s = Console.ReadLine();
                        o = (object)new Persona("", int.Parse(s!));
                        break;
                    case "Numero":
                        Console.Write("Numero : ");
                        s = Console.ReadLine();
                        o = (object)new Numero(int.Parse(s!));
                        break;
                    default:
                        Console.WriteLine("Solo se permite buscar por Personas, Alumnos y Numeros");
                        o = null;   
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("    Valor invalido\n");
                o = null;
            }

            return o;
        }
        
    }

}
