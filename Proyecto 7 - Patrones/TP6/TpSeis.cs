using TP.TP6.Colecciones;
using TP.TP6.Interfaces;
using TP.TP6.Clases;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Interfaces.Iterador;
using TP.TP6.Clases.Estrategias;
using TP.TP6.Clases.Utiles;
using TP.TP6.Clases.Fabricas;
using TP.Main.NSMenu.Fabrica;
using TP.TP6.Clases.Fabricas.Comparables;
using TP.TP6.Adapter;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Clases.Comparables.VendedorNS;
using TP.TP6.Clases.Comparables.Tipos;
using TP.TP6.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP6.Command;
using TP.TP6.Command.ComandosAula;
using System;
using TP.TP6.Colecciones.ProxyColeccionableNS;
using TP.TP6.Clases.Comparables.AlumnoNS.Composite;
using TP.TP6.Template_Method;
using TP.TP6.Template_Method.JugadorNS;
using TP.TP6.Template_Method.Jugador;

namespace TP.TP6
{
    public class TpSeis
    {
        // TODO, cmp override, Alumno ( saltea el new ? )
        public static void TpMenu()
        {
            Action[] f = { Ej2Tp6, JugarCSucio, JugarCasitaRobada };
            FabMenu.Crear(f,
                  "Ejercicios (con opcionales):\n"
                + "----------------------------\n"
                + "  1) Ej 2 TP 6              \n"
                + "  2) Jugar CSucio           \n"
                + "  3) Jugar Casita Robada    \n"
                + "  s) Salir                  \n"
                ).Ejecutar();
        }
        public static void JugarCSucio()
        {
            CSucio c = new();
            List<JugadorCSucio> j = new();
            j.Add(new("Martin"));
            j.Add(new("Andrea"));
            j.Add(new("Pablo"));
            Console.WriteLine("\nGano " + c.Jugar(j)![0].Nombre + " !!");
        }
        public static void JugarCasitaRobada()
        {
            List<JugadorCRobada> j = new();
            j.Add(new("Martin"));
            j.Add(new("Andrea"));
            j.Add(new("Claudia"));
            CasitaRobada c = new(j);
            List<JugadorCRobada> g = c.Jugar(j)!;
            if (g.Count > 1)
            {
                string s = "Es un empate entre : ";
                foreach (JugadorCRobada jug in g)
                    s += jug.ToString() + " - ";
                Console.WriteLine(s);
            } else
                Console.WriteLine("\nGano " + g[0].Nombre.ToString() + " !!");
        }
        public static void Ej2Tp6()
        {
            Teacher t = new();
            Pila<AdapterAlumno> p = new();
            Comparador<Alumno> cmp = new PorCalif();
            for (int i = 0; i < 20; i++)
            {
                Alumno a = FabricaDeComparables<DecoAlumno>.Rand(cmp);
                if (i < 10)
                    a = new AlumnoEstudioso(a);
                p.Agregar(new AdapterAlumno(a));
            }
            p.Agregar(new AdapterAlumno(FabricaDeComparables<CompositeAlumno<DecoAlumno>>.Rand(cmp)));
            AdapterColeccionable c = new(p);
            t.setStudents(c);
            t.teachingAClass();
        }
        public static void Ej6_7y9()
        {
            Action[] f = { () => { mixTp1Ejs9y17<Numero>(); }
                         , () => { mixTp1Ejs9y17(FabricaDeComparables<Persona>.CrearCriterio()); }
                         , () => { mixTp1Ejs9y17(FabricaDeComparables<Alumno>.CrearCriterio()); }
                         , () => { mixTp1Ejs9y17(FabricaDeComparables<Egresado>.CrearCriterio()); }
                         , () => { mixTp1Ejs9y17(FabricaDeComparables<Vendedor>.CrearCriterio()); } };
            FabMenu.Crear(f,
                          "Informar:        \n"
                        + "---------        \n"
                        + " 1) Numeros     \n"
                        + " 2) Personas    \n"
                        + " 3) Alumnos     \n"
                        + " 4) Egresados   \n"
                        + " 5) Vendedores  \n"
                        , limpiarConsola: false
                        , leerTeclaPosEjecutar: false
                        , bucle: false
                        ).Ejecutar();
        }
        public static void mixTp1Ejs9y17<T>(Comparador<T>? cmp = null) where T : Comparable<T>
        {
            Console.WriteLine("Coleccion multiple. Elija el primer tipo :  \n");
            Coleccionable<T> a = FabColeccionables<T>.PorTeclado();
            Console.WriteLine("Ahora elija el segundo tipo: \n");
            Coleccionable<T> b = FabColeccionables<T>.PorTeclado();
            ColeccionMultiple<T> m = new(b, a);
            Llenar(b);
            Llenar(a);
            Console.WriteLine("\n{0}\n", Helper.GetTypeName(a));
            Informar(b, cmp);
            Console.WriteLine(Helper.GetTypeName(b) + "\n");
            Informar(a, cmp);
            Console.WriteLine("Coleccion Multiple\n");
            Informar(m, cmp);
        }
        
        public static Tupla<IList<Comparador<T>>, IList<string>> CriteriosDeCompAlumnos<T>() where T : Alumno
        {
            Comparador<T>[] cmps = { new PorDni(), new PorLeg(), new PorNom(), new PorProm() };
            string[] etiquetas = { "\nPor DNI :\n", "\nPor Legajo :\n", "\nPor Nombre :\n"
                    , "\nPor Promedio :\n" };
            return new Tupla<IList<Comparador<T>>, IList<string>>(cmps, etiquetas);
        }
        public static Tupla<IList<Comparador<Egresado>>, IList<string>> CriteriosDeCompEgresados()
        {
            Tupla<IList<Comparador<Egresado>>, IList<string>> cmpA = CriteriosDeCompAlumnos<Egresado>();
            List<Comparador<Egresado>> cmps = new(cmpA.X);
            List<string> names = new(cmpA.Y);
            cmps.Add(new PorEgreso());
            names.Add("\nPor Fecha de Egreso :\n");
            return new Tupla<IList<Comparador<Egresado>>, IList<string>>(cmps, names);
        }
        public static void ComparacionMultiCriterio<T>(Coleccionable<T> c, Tupla<IList<Comparador<T>>, IList<string>> cmp)
            where T : Comparable<T>, StrategyComparable<T>
        {
            for (int i = 0; i < cmp.X.Count; i++)
            {
                Console.WriteLine(cmp.Y[i]);
                CambiarEstrategia<T>(c, cmp.X[i]);
                Informar(c);
            }
        }
        public static void CambiarEstrategia<T>(Coleccionable<T> c, Comparador<T> cmp)
            where T : Comparable<T>, StrategyComparable<T>
        {   // mala implementacion, informacion repetida
            Iterador<T> i = c.crearItr();
            while (i.Sig())
                i.Elem().SetCmp(cmp);
        }

        public static void Llenar<T>(Coleccionable<T> c, Comparador<T>? cmp = null) where T : Comparable<T>
        {
            for (int i = 0; i < 20; i++)
                c.Agregar(FabricaDeComparables<T>.Rand(cmp));
        }
        public static void ImprimirElementos<T>(Coleccionable<T> c) where T : Comparable<T>
        {
            Iterador<T> itr = c.crearItr();
            while (itr.Sig())
                Console.WriteLine(itr.Elem());
        }
        public static void Informar<T>(Coleccionable<T> c, Comparador<T>? cmp = null) where T : Comparable<T>
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
            StrategyComparable<T>? sc = (e is StrategyComparable<T>) ? (StrategyComparable<T>)e : null;
            e = FabricaDeComparables<T>.Teclado(cmp,sc, soloComparador : true);
           /* Console.Write(e.ToString() + " ");
            if (sc != null && sc.Cmp != null)
                Console.Write(sc.Cmp.ToString());
            if (cmp != null)
                Console.Write("cmp: " + cmp.ToString());*/
            if (e != null)
                if (c.Contiene(e))
                    Console.WriteLine("\nLa colección contiene al menos un elemento con el valor ingresado.\n");
                else
                    Console.WriteLine("\nNo se encontro ningun elemento para el valor ingresado. \n");
            Console.WriteLine("");
        }
    }
}
