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
using TP.TP2.Interfaces.Comparar;
using TP.TP2.Interfaces.Iterador;
using TP.TP2.Clases.Estrategias;
using TP.TP2.Colecciones.Diccionario;
using System.Net;
using TP.TP1.Colecciones;
using TP.TP2.Clases.Utiles;

namespace TP.TP2
{
    public class TpDos
    {
        public static bool TpMenu()
        {
            Func<bool>[] f = { EjDos, EjOcho, EjDiez, EjOnce, EjPropioUno };
            Menu.run(ref f,
                  "Ejercicios:              \n"
                + "-----------              \n"
                + " 1)Ejercicio 2 (tp.ej7)  \n"
                + " 2)Ejercicio 8           \n"
                + " 3)Ejercicio 10          \n\n"
                + "Optativos:               \n"
                + "----------               \n"
                + " 4)Ejercicio 11          \n\n"
                + "Propios:                 \n"
                + "----------               \n"
                + " 5)CompMulti con ColecMulti\n"
                + " s)Salir                 \n");
            return false;
        }
        public static bool EjDos()
        {
            Console.WriteLine("Ejercicio 17:\n-------------\n...invocando al ejercicio 17...\n");
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
            Pila<Alumno> p = new();
            Cola<Alumno> c = new();
            ColeccionMultiple<Alumno> m = new(p, c);
            Console.WriteLine("Alumnos\n");
            LlenarAlumnos(p);
            LlenarAlumnos(c);
            Console.WriteLine("Pila + Cola\n");
            Informar(m);
            return true;
        }
        public static bool EjOcho()
        {
            Console.WriteLine("Ejercicio 8:\n-------------\n");
            Pila<Alumno> pila = new();
            Cola<Alumno> cola = new();
            Conjunto<Alumno> conj = new();
            Diccionario<Numero, Alumno> dic = new(new SimpleKeyGen());
            LlenarAlumnos(pila);
            LlenarAlumnos(cola);
            LlenarAlumnos(conj);
            LlenarAlumnos(dic);
            Console.WriteLine("\nAlumnos");
            Console.WriteLine("\nPila\n");
            ImprimirElementos(pila);
            Console.WriteLine("\nCola\n");
            ImprimirElementos(cola);
            Console.WriteLine("\nConjunto\n");
            ImprimirElementos(conj);
            Console.WriteLine("\nDiccionario por Alumno\n");
            ImprimirElementos<Alumno>(dic);
            Console.WriteLine("\nDiccionario por Tuplas\n");
            ImprimirElementos<ClaveValor<Numero, Alumno>>(dic);
            Console.WriteLine();
            Console.WriteLine("\n"
                + "Conclusion:\n"
                + "-----------\n\n"
                + " Era condicion para el diccionario:\n"
                + "     Buscar por clave.\n"
                + " \n"
                + " Por consiguiente K : Comparable<K>.\n"
                + " \n\n"
                + " Tambien era condicion:\n"
                + "     Guardar Tuplas ClaveValor.\n"
                + " \n"
                + " Como se buscaba reutilizar el codigo de Coleccion<U> : Coleccionable<U>, era necesario\n"
                + " que ClaveValor<K,T> implementara Comparable<K,T>.\n"
                + " \n\n"
                + " La tercer condicion era:\n"
                + "     Implementar Coleccionable<T>.\n"
                + " \n"
                + " Como debia realizar operaciones en funcion de T, entonces, T : Comparable<T>.\n"
                + " \n\n"
                + " C# no permite herencia multiple, por lo tanto no se puede heredar de Coleccion<T> y\n"
                + " Coleccion<ClaveValor<K,T>> en simultaneo, ni tampoco tendria sentido tener dos listas.\n"
                + " Se opto por heredar de Coleccion<ClaveValor<K,T>> eh implementar Coleccionable<T>, de\n"
                + " ese modo se guardan tambien las K. Las implementaciones de los metodos de Coleccionable<T>\n"
                + " llaman al padre, filtran la tupla recibida y retornan T.\n"
                + " Otra vez, vemos como, Coleccion<T>.Contiene(T e) en vez de Coleccion<T>.Contiene<K>(K e) es\n"
                + " es un problema. En este caso, no se puede crear ClaveValor sin un elemento K, ni\n"
                + " tampoco instaciar un K desde la coleccion, porque se desconocen la cantidad y tipo de\n"
                + " parametros que valla a recibir el constructor. Por lo tanto fue necesario reimplementar\n"
                + " el metodo, el codigo resultante es practicamente el mismo.\n"
                + " \n"
                + " Como resultado final, al Diccionario se le puede pedir que retorne tanto tuplas como elementos T.\n"
                + " \n"
                + " Console.WriteLine(dic.Minimo()) = {0}\n\n"
                + " Console.WriteLine(dic.Coleccionable<Alumno>.Minimo()) = Error , la sintaxis es solo para definir\n\n"
                + " Console.WriteLine(((Coleccionable<Alumno>)dic).Minimo()) = {1}\n\n"
                + " Console.WriteLine(((Coleccionable<ClaveValor<Numero,Alumno>>)dic).Minimo()) = {2}\n\n"
                + " Console.WriteLine(((Coleccion<ClaveValor<Numero,Alumno>>)dic).Minimo()) = {3}\n"
                + " \n"
                + " Lo realmente interesanto fue al aplicar este concepto en un funcion generica, la sintaxis\n"
                + " resulta muy intuitiva y el compilador pide que se especifique si deseamos trabajar con\n"
                + " Coleccionable<ClaveValor<K,T>> o Coleccionable<T>.\n"
                + " \n"
                + " ImprimirElementos<Alumno>(dic);\n"
                + " ImprimirElementos<ClaveValor<Numero, Alumno>>(dic);\n"
                + " \n"
                + " Otro buen ejemplo se da al usar la funcion Informar(), si bien, para probar mejor el funcionamiento\n"
                + " de Diccionario, deberiamos permimir que Informar trabaje con ClaveValor (ademas de Numero, Persona\n"
                + " Alumno, etc), sin cambiar nada de codigo, podemos tratar al diccionario como una Coleccion de alumnos.\n"
                + " \n"
                + " Informar<Alumno>(dic) \n"
                + " \n"
                + " Tambien, hay que aclarar que Diccionario no puede hacer un override de los metodos cuando retorna\n"
                + " un elemento diferente. Por lo tanto, si bien en este caso resulta conveniente, habria que estudiar\n"
                + " una solucion, si, en determinada circunstancia, este comportamiento fuera indeseable.\n"
                + " \n"
                + " Por ultimo, se sugeria reutilizar Conjunto, lo cual no cobro ningun sentido, ya que el unico metodo\n"
                + " que tiene se debe reimplementar, o sea, el metodo agregar en el caso del diccionario debe actualizar\n"
                + " el valor asociado a la clave, en vez de descartar el repetido.\n"
            , dic.Minimo(), ((Coleccionable<Alumno>)dic).Minimo()
            , ((Coleccionable<ClaveValor<Numero, Alumno>>)dic).Minimo()
            , ((Coleccion<ClaveValor<Numero, Alumno>>)dic).Minimo()
            );
            return true;
        }
        public static bool EjDiez()
        {
            Console.WriteLine("Ejercicio 10:\n-------------\n");
            Pila<Alumno> pila = new();
            LlenarAlumnos(pila);
            ComparacionMultiCriterio(pila, CriteriosDeCompAlumnos<Alumno>());
            return true;
        }
        public static bool EjOnce()
        {
            Console.WriteLine("Ejercicio 11:\n-------------\n");
            Pila <Egresado> pila = new();
            LlenarEgresados(pila);
            ComparacionMultiCriterio(pila, CriteriosDeCompEgresados());
            Console.WriteLine("\n"
                + "Conclusion:\n"
                + "-----------\n"
                + " Era muy similar al codigo empleado para Alumno, por ello se uso la clase Tupla\n"
                + " para guardar los pares (EstretegiaDeComparacion, StringParaMostrarAlUsuario).\n"
                + " En alumno se uso un Array, porque se inicializan de un modo practico. Luego, al\n"
                + " incorporar Egresado fue necesario agregar elementos. Por ello se investigo y \n"
                + " descubrio que los arrays, asi como las Listas, implementan IList, ademas del hecho\n"
                + " de que una lista puede recibir un array en el constructor. De este modo, se \n"
                + " reutilizo el codigo que genera las tuplas de Comparador<Alumno> para agregarle\n"
                + " el comparador propio de Egresado. Si bien seria mas eficiente usar directamente\n"
                + " List en Alumno, resulto interesante poner en practica lo aprendido en la materia,\n"
                + " para investigar y usar lo que proveen las librerias de C#. Resulto intuitivo \n"
                + " encontrar lo que se buscaba, basandose en lo aprendido al crear nuevas interfacez\n"
                + " \nPor otro lado, debido al uso de Generics surgio el inconveniente de que no era\n" 
                + " posible reutilizar el atributo Cmp de Alumno, el cual guarda la estrategia de\n"
                + " comparacion. Esto se debe a que es del tipo Comparador<Alumno>, el cual no puede\n"
                + " almecenar un Comparador<Egresado>, debido a las restricciones de C#. Este fue,\n" 
                + " probablemente, el desafio mas grande hasta el momento. Se intentaron varias soluciones,\n"
                + " pero al final se pudo solucionar el problema empleando la interfaz StrategyComparable.\n"
                + " La interfaz establece que debe haber un Comparador<T>, de este modo el metodo\n"
                + " CambiarEstrategia paso a ser generico donde T : StrategyComparable. De otro modo,\n"
                + " lo que sucedia era que se agregaba el nuevo comparador en la variable de Alumno y\n"
                + " no en la de Egresado, la cual habia sido declarada con el mismo nombre usando new\n"
                + " y no override, ya que no permite usarlo si el tipo del generico no es exactamente\n"
                + " el mismo.Cabe aclarar que, en C# si se recibe un elemento del tipo Egresado, pero\n"
                + " dentro de un parametro del tipo Alumno, el comportamiento resulta ser identico al que\n"
                + " hubiese tenido si fuera Alumno, no se resulve en Runtime a menos que pueda emplearse\n"
                + " override.\n"
                + " \nPor ultimo, se espera encontrar otro patro a la hora de instaciar el Egresado\n"
                + " necesario para realizar la busqueda. Ya se hizo evidente que el switch y los if\n"
                + " no son para nada una opcion escalable. Cabe aclara ademas, que cuando se usa switch\n"
                + " en vez de if, no se puede aprobechar herencia, porque la comparacion se realiza por\n"
                + " GetType().Name, lo cual es un string. Por ejemplo 'Egresado'!='Alumno', sin embargo\n"
                + " con un if : Egresado is Alumno == true.\n"
                + " "
            );

            return true;
        }
        public static bool EjPropioUno()
        {
            Console.WriteLine("Ejercicio Propio 1:\n-------------\n");
            Pila<Egresado> p = new();
            Cola<Egresado> c = new();
            LlenarEgresados(p);
            LlenarEgresados(c);
            ColeccionMultiple<Egresado> m = new(p, c);
            ComparacionMultiCriterio(m, CriteriosDeCompEgresados());
            Console.WriteLine("\n"
                + "Conclusion:\n"
                + "-----------\n"
                + " Se agrego un iterador para ColeccionMultiple. En el main no fue necesario modificar\n"
                + " nada. Como se uso la clase Egresado, estaba todo implementado. \n"
                + " En el ejercicio 11, al agregar Egresado, fue necesario modificar el main, y eso hizo,\n"
                + " debido a la dificultad descripta en EjOnce(), que sea dificil apreciar las ventajas de\n"
                + " los iteradores. En este caso, se necesito crear la clase ItrColMulti y hacer que \n"
                + " ColeccionMultiple implemente Iterable.\n"
                + " Se evaluo que ItrColMulti heredase de ListItr y agregar un atributo ListaB, en el hijo,\n"
                + " para que almacene la segunda lista. De este modo, al no quedar mas elementos en la primera,\n"
                + " se intercambiaria ListItr.Lista por ListaB. El resultado seria que los metodos de ListItr\n"
                + " pasarian a trabajar con la segunda coleccion sin que el usuario se enterase. El problema\n"
                + " es que la Lista no deberia ser publica, o sea, alguien que tiene la coleccion no deberia\n"
                + " ni siquiera saber que internamente esta implementada con List. Como ColeccionMultiple recibe,\n"
                + " en le constructor, dos Coleccionables que desconoce, no deberia acceder a sus listas a la\n"
                + " hora de crear el ItrColMulti. Por este motivo, ItrColMulti almacena Itadores<T> eh implementa\n"
                + " Iterador<T> desde cero. Se opto, ademas, por convertirlo en un iterador para mas de 2 posibles\n"
                + " coleccines, cuya implementacion requirio muy pocas lineas de codigo."
                );
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
        {
            Iterador<T> i = c.crearItr();
            while (i.Sig())
                i.Elem().Cmp = cmp;
        }
        public static void ImprimirElementos<T>(Coleccionable<T> c) where T : Comparable<T>
        {
            Iterador<T> itr = c.crearItr();
            while (itr.Sig())
                Console.WriteLine(itr.Elem());
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

        /* 
         * Intuyo que mas adelante , con otro patron, podre mejorar estas implementaciones.
         *
         */

        public static void Llenar(Coleccionable<Numero> c)
        {   // Para simplificar agrega numeros del 0 al 100
            for (int i = 0; i < 20; i++)
            {
                c.Agregar(new Numero(new Random().Next() % 100));
            }
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
                int p;
                while ((p = new Random().Next() % 11) == 0) ;
                Alumno a = new Alumno(RandomNombre(), RandomDni(), leg, p);
                a.Cmp = new PorLeg();
                c.Agregar(a);
            }
        }
        //TODO - Esta igual que el de LlenarAlumnos()
        public static void LlenarEgresados(Coleccionable<Egresado> c)
        {
            for (int i = 0; i < 20; i++)
            {
                int leg = 0;
                // un numero razonable para un legajo
                while (leg < 1000 || leg > 100000)
                    leg = new Random().Next();
                int p;
                while ((p = new Random().Next() % 11) == 0) ;
                Egresado a = new Egresado(RandomNombre(), RandomDni(), leg, p, DateTime.Today);
                a.Cmp = new PorEgreso();
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
                    Console.WriteLine("\nLa colección contiene al menos un elemento con el valor ingresado.\n");
                else
                    Console.WriteLine("\nNo se encontro ningun elemento para el valor ingresado.\n");
            Console.WriteLine("");
        }
        //TODO - Horrible switch para Egresado
        private static object? LeerComparableDelTipo(object? o)
        {
            try
            {
                string? s;
                // No hace switch GetType porque no se aprobecha la herencia
                if (o is Egresado) {
                    switch (((Egresado)o).Cmp.GetType().Name)
                    {
                        case "PorEgreso":
                            Console.Write("\nFecha de Egreso : ");
                            s = Console.ReadLine();
                            o = (object)new Egresado("", null, null, 0, Convert.ToDateTime(s));
                            ((Egresado)o).Cmp = new PorEgreso();
                            break;
                        case "PorDni":
                            Console.Write("\nDNI : ");
                            s = Console.ReadLine();
                            o = (object)new Egresado("", int.Parse(s!), null, 0, DateTime.Today);
                            ((Egresado)o).Cmp = new PorDni();
                            break;
                        case "PorLeg":
                            Console.Write("\nLegajo : ");
                            s = Console.ReadLine();
                            o = (object)new Egresado("", null, int.Parse(s!), 0, DateTime.Today);
                            ((Egresado)o).Cmp = new PorLeg();
                            break;
                        case "PorNom":
                            Console.Write("\nNombre : ");
                            s = Console.ReadLine();
                            o = (object)new Egresado(s!, null, null, 0, DateTime.Today);
                            ((Egresado)o).Cmp = new PorNom();
                            break;
                        case "PorProm":
                            Console.Write("\nPromedio : ");
                            s = Console.ReadLine();
                            o = (object)new Egresado("", null, null, float.Parse(s!), DateTime.Today);
                            ((Egresado)o).Cmp = new PorProm();
                            break;
                        default:
                            Console.WriteLine("{0} no implementada", ((Egresado)o).Cmp.GetType().Name);
                            o = null;
                            break;
                    }
                }
                else if (o is Alumno) {
                    switch (((Alumno)o).Cmp.GetType().Name)
                    {
                        case "PorDni":
                            Console.Write("\nDNI : ");
                            s = Console.ReadLine();
                            o = (object)new Alumno("", int.Parse(s!), null, 0);
                            ((Alumno)o).Cmp = new PorDni();
                            break;
                        case "PorLeg":
                            Console.Write("\nLegajo : ");
                            s = Console.ReadLine();
                            o = (object)new Alumno("", null, int.Parse(s!), 0);
                            ((Alumno)o).Cmp = new PorLeg();
                            break;
                        case "PorNom":
                            Console.Write("\nNombre : ");
                            s = Console.ReadLine();
                            o = (object)new Alumno(s!, null, null, 0);
                            ((Alumno)o).Cmp = new PorNom();
                            break;
                        case "PorProm":
                            Console.Write("\nPromedio : ");
                            s = Console.ReadLine();
                            o = (object)new Alumno("", null, null, float.Parse(s!));
                            ((Alumno)o).Cmp = new PorProm();
                            break;
                        default:
                            Console.WriteLine("{0} no implementada", ((Alumno)o).Cmp.GetType().Name);
                            o = null;
                            break;
                    }
                }
                else if (o is Persona) {
                    Console.Write("DNI : ");
                    s = Console.ReadLine();
                    o = (object)new Persona("", int.Parse(s!));
                }
                else if (o is Numero)
                {
                    Console.Write("Numero : ");
                    s = Console.ReadLine();
                    o = (object)new Numero(int.Parse(s!));
                }
                else
                {
                    Console.WriteLine("Solo se permite buscar por Personas, Alumnos y Numeros");
                    o = null;
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
