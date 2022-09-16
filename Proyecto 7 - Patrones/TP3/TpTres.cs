using TP.TP3.Colecciones;
using TP.TP3.Interfaces;
using TP.TP3.Clases;
using TP.Main;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces.Iterador;
using TP.TP3.Clases.Estrategias;
using TP.TP3.Clases.Utiles;
using TP.TP3.Clases.Fabricas;

namespace TP.TP3
{
    public class TpTres
    {
        public static bool TpMenu()
        {
            Func<bool>[] f = { EjSeis };
            Menu.run(ref f,
                  "Ejercicios:              \n"
                + "-----------              \n"
                + " 1)Ejercicio 6           \n"
                + " s)Salir                 \n");
            return false;
        }
        public static bool EjSeis()
        {
            Console.WriteLine("Ejercicio 6:\n"
                            + "------------\n\n"
                            + "Con Numeros:\n"
                            + "------------\n");
            mixTp1Ejs9y17<Numero>();
            Console.WriteLine("\nCon Alumnos:\n"
                                + "------------\n");
            mixTp1Ejs9y17(new PorProm());
            return true;
        }
        public static bool mixTp1Ejs9y17<T>(Comparador<T>? cmp = null) where T : Comparable<T>
        {
            Pila<T> p = new();
            Cola<T> c = new();
            ColeccionMultiple<T> m = new(p, c);
            Llenar(p);
            Llenar(c);
            Console.WriteLine("Pila\n");
            Informar(p);
            Console.WriteLine("Cola\n");
            Informar(c);
            Console.WriteLine("Coleccion Multiple\n");
            Informar(m, cmp);
            return true;
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
        {   // muy mala implementacion, informacion repetida, mala implementacion 
            Iterador<T> i = c.crearItr();
            while (i.Sig())
                i.Elem().Cmp = cmp;
        }

        public static void Llenar<T>(Coleccionable<T> c, Comparador<T>? cmp = null) where T : Comparable<T>
        {
            for (int i = 0; i < 20; i++)
                c.Agregar(FabricaDeComparables<T>.CrearAleatorio(cmp:cmp));
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
            e = FabricaDeComparables<T>.CrearAleatorio(cmp,sc);
            if (e != null)
                if (c.Contiene(e))
                    Console.WriteLine("\nLa colección contiene al menos un elemento con el valor ingresado.\n");
                else
                    Console.WriteLine("\nNo se encontro ningun elemento para el valor ingresado.\n");
            Console.WriteLine("");
        }
    }
}
