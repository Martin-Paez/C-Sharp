using TP.TP5.Colecciones;
using TP.TP5.Interfaces;
using TP.TP5.Clases;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Iterador;
using TP.TP5.Clases.Estrategias;
using TP.TP5.Clases.Utiles;
using TP.TP5.Clases.Fabricas;
using TP.Main.NSMenu.Fabrica;
using TP.TP5.Clases.Fabricas.Comparables;
using TP.TP5.Adapter;
using TP.TP5.Clases.Comparables.AlumnoNS;
using TP.TP5.Clases.Comparables.VendedorNS;
using TP.TP5.Clases.Comparables.Tipos;
using TP.TP5.Clases.Comparables.AlumnoNS.Decoradores.HijoAlumno;
using TP.TP5.Command;
using TP.TP5.Command.ComandosAula;
using System;
using TP.TP5.Colecciones.ProxyColeccionableNS;

namespace TP.TP5
{
    public class TpCinco
    {
        // TODO, cmp override, Alumno ( saltea el new ? )
        public static void TpMenu()
        {
            Action[] f = { Ej2Tp5, Ej10Tp5, Ej12_13y14Tp5 };
            FabMenu.Crear(f,
                  "Ejercicios:                \n"
                + "-----------                \n"
                + "  1) Ej 2 TP 5             \n"
                + "  2) Ej 10 TP 5            \n"
                + "  3) Opcionales 11,13 y 15 TP 5\n"
                + "  s) Salir                 \n"
                ).Ejecutar();
        }
        public static void Ej10Tp5()
        {
            Pila<AdapterAlumno> p = new();
            Aula aula = new Aula();
            p.CmdInicio = new DarInicio(aula);
            p.CmdAgregar = new AgregarAlumno(aula);
            p.CmdLlena = new AulaLLena(aula);
            p.Cupo = 40;
            for (int i = 0; i < 20; i++) {
                p.Agregar(new AdapterAlumno(FabricaDeComparables<Alumno>.Rand()));
                Alumno a = FabricaDeComparables<Alumno>.Rand();
                p.Agregar(new AdapterAlumno(new AlumnoEstudioso(a)));
            }
        }
        public static void Ej2Tp5()
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
            AdapterColeccionable c = new(p);
            t.setStudents(c);
            t.teachingAClass();
        }

        public static void Ej12_13y14Tp5()
        {
            Coleccionable<Numero> coleccionable = new ProxyColeccionable<Numero>();
            Console.WriteLine("Imprime cero: " + coleccionable.Cuantos().ToString());
            Console.Write("Imprime null: ");
            Console.WriteLine(coleccionable.Minimo());
            Console.Write("Imprime null: ");
            Console.WriteLine(coleccionable.Maximo());
            Console.WriteLine("Agrego un 5");
            Console.WriteLine("Se crea la pila real");
            coleccionable.Agregar(new Numero(5)); //se crea la Pila real
            Console.WriteLine("Agrego un 3");
            coleccionable.Agregar(new Numero(3));
            Console.WriteLine("Agrego un 8");
            coleccionable.Agregar(new Numero(8));
            Console.WriteLine("Imprime 3: " + coleccionable.Cuantos().ToString());
            Console.WriteLine("Imprime 3. Se le pide el minimo a la Pila.El proxy “cachea” el Numero 3 como mínimo.");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine("Imprime 8.Se le pide el maximo a la Pila.El proxy “cachea” el Numero 8 como máximo.");
            Console.WriteLine(coleccionable.Maximo());
            Console.WriteLine("Imprime 3: " + coleccionable.Cuantos().ToString());
            Console.WriteLine("Imprime 3.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine("Imprime 8.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Maximo());
            Numero num = new Numero(15);
            Console.WriteLine("Agrego un num = 15");
            coleccionable.Agregar(num);
            Console.WriteLine("Imprime 3.Se le pide el minimo a la Pila.El proxy “cachea” el Numero 3 como mínimo.");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine("Imprime 15.Se le pide el maximo a la Pila.El proxy “cachea” el Numero 15 como máximo.");
            Console.WriteLine(coleccionable.Maximo());
            Console.WriteLine("Imprime 3.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine(" Imprime 15.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Maximo());
            Console.WriteLine("Modifico el valor de num a 1");
            Console.WriteLine("Se uso Observer , deberia funcionar todo bien");
            num.Valor = 1;
            Console.WriteLine("Imprime 1.Se le pide el minimo a la Pila.El proxy “cachea” el Numero 1 como mínimo.");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine("Imprime 8.Se le pide el maximo a la Pila.El proxy “cachea” el Numero 15 como máximo.");
            Console.WriteLine(coleccionable.Maximo());
            Console.WriteLine("Imprime 1.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Minimo());
            Console.WriteLine(" Imprime 8.El proxy devolvió el valor “cacheado”");
            Console.WriteLine(coleccionable.Maximo());
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
