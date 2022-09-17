using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Colecciones;
using TP.TP1.Interfaces;
using TP.TP1.Clases;
using TP.Main.NSMenu.Fabrica;

namespace TP.TP1
{
    public class TpUno
    {

        public static void TpMenu()
        {
            Action[] f = { EjSiete, EjNueve, EjTrece, UltimosTresEj };
            FabMenu.Crear(f,
                  "Ejercicios:              \n"
                + "-----------              \n"
                + " 1)Ejercicio 7           \n"
                + " 2)Ejercicio 9           \n"
                + " 3)Ejercicio 13          \n"
                + " 4)Ejercicio 17-18-19    \n"
                + " s)Salir                 \n"
                ).Ejecutar();
        }

        public static void EjSiete()
        {
            Console.WriteLine("Ejercicio 7:\n-------------\n");
            Pila p = new Pila();
            Cola c = new Cola();
            Llenar(p);
            Llenar(c);
            Console.WriteLine("Pila\n");
            Informar(p);
            Console.WriteLine("Cola\n");
            Informar(c);
        }

        public static void EjNueve()
        {
            Console.WriteLine("Ejercicio 9:\n-------------\n");
            Pila p = new Pila();
            Cola c = new Cola();
            ColeccionMultiple m = new ColeccionMultiple(p, c);
            Llenar(p);
            Llenar(c);
            Console.WriteLine("Pila\n");
            Informar(p);
            Console.WriteLine("Cola\n");
            Informar(c);
            Console.WriteLine("Pila + Cola\n");
            Informar(m);
            Console.WriteLine("Ejercicio 10:\n-------------");
            Console.WriteLine("   No fue necesario modificar nada de lo anterior");
        }

        public static void EjTrece()
        {
            Console.WriteLine("Ejercicio 13:\n-------------\n");
            Pila p = new Pila();
            Cola c = new Cola();
            ColeccionMultiple m = new ColeccionMultiple(p, c);
            Console.WriteLine("Personas\n");
            LlenarPersonas(p);
            LlenarPersonas(c);
            Console.WriteLine("Pila + Cola\n");
            Informar(m);
            Console.WriteLine("Ejercicio 14:\n-------------");
            Console.WriteLine("   Se modifico un metodo empleado por Informar(), porque al buscar un");
            Console.WriteLine("   elemento fue necesario instaciar Persona.");
        }

        public static void UltimosTresEj()
        {
            Console.WriteLine("Ejercicio 17:\n-------------\n");
            Pila p = new Pila();
            Cola c = new Cola();
            ColeccionMultiple m = new ColeccionMultiple(p, c);
            Console.WriteLine("Alumnos\n");
            LlenarAlumnos(p);
            LlenarAlumnos(c);
            Console.WriteLine("Pila + Cola\n");
            Informar(m);
            Console.WriteLine(
                  "Conclusiones:\n"
                + "------------\n"
                + "   Funciono, solo se crearon RandomDni() y RandomNombre() para no \n"
                + "   repetir codigo entre LlenarPersonas() y LlenarAlumnos().\n"
                + "   No fue necesario que Alumno implemente Comparable explisitamente.\n"
                + "   El criterio de comparacion entre alumnos fue el mismo que Persona,\n"
                + "   para reutilizar el codigo.\n");
            Console.WriteLine(
                  "Ejercicio 18:\n"
                + "-------------\n"
                + "   Para evitar que Alumno interactuara con el usuario, quedando el frontend\n"
                + "   unicamente en el Main, se opto por brindar un metodo SetCmpPorLegajo(bool),\n"
                + "   mediante el cual se selecciona entre la comparacion por dni (por defecto)\n"
                + "   o por legajo. \n"
                + "   Por otro lado, fue necesario modificar el metodo llamado desde Informar(),\n"
                + "   para poder instanciar un Alumno a la hora de buscar un elemento. \n"
                + "   Ademas, se dio la posibilidad de que una persona pueda no tener asignado\n"
                + "   un dni y ni un alumno un legajo (ambos puede ser null). Esto  se debe al \n"
                + "   hecho de que para buscar un elemento, por enunciado, se  esta recibiendo \n"
                + "   un Comparable, en lugar de un atributo identificatorio, que podria haberse \n"
                + "   definido con genericos. En consecuencia si se busca,por ejemplo por dni, \n"
                + "   solo se pide dicho dato para crear un Alumno de legajo nulo, empleado en la\n"
                + "   busqueda, y viceversa si se lo hace por legajo.\n");
            Console.WriteLine(
                  "Ejercicio 19 ( no forma parte de la entrega ) :\n"
                + "-----------------------------------------------\n"
                + "   Se emplearon dos interfaces: Coleccionable y Comparable.\n"
                + "\n"
                + "   Coleccionable se uso en Informar() y las funciones LlenarX(): podria haberse\n"
                + "   considerado como una clase abstracta, con la limitacion de que sus hijos ya no\n"
                + "   podrian tener otro padre. Lo mismo se da al usar Comparable en Informar().\n"
                + "   Siguiendo este razonamiento, no pareceria estar bien modelado el problema si un\n"
                + "   Numero tuviera el mismo padre que una Persona.\n"
                + "\n"
                + "   Comparable se empleo en LeerComparableDelTipo(): alli se podria haber recibido\n"
                + "   un 'Object' debido a que fue una implementacion limitada. La funcion busca resolver\n"
                + "   el inconveniente originado por el hecho de que se requiere solicitar al usuario\n"
                + "   distintos datos para instanciar diferenteas clases que implementan la misma interfaz. \n"
                + "   Si el ejercicio fuese mas complejo y se optase, por ejemplo, por crear clases de\n"
                + "   frontend para Persona, Alumno y Numero, que serian luego instanciadas desde el Main\n"
                + "   , seria provechoso el uso de interfaces y limitada la opcion de usar 'Object', ya que \n"
                + "   se podrian aprobechar los metodos (que no estan descriptos en 'Objetc').\n"
                + "   NOTA: analizando el ejemplo de las clases de frontend, pareceria ser mejor emplear\n"
                + "   composicion, y no herencia, para relacionar dichas clases con su correspondiente de\n"
                + "   backend. Por ejemplo:\n"
                + "      PersonaFront contiene Persona. (this.PersonaBack = persona) \n"
                + "      Luego AlumnoFront hereda de PersonaFront (this.AlumnoBack = base.PersonaBack)\n"
                + "   Si PersonaFront fuese hijo de Persona, luego AlumnoFront seria hijo de Alumno y no\n"
                + "   podria heredar los metodos de PersonaFront.\n"
                + "\n"
                + "   Ademas, Comparable se utilizo en Coleccinable y las clases que lo implementaron : En \n"
                + "   estos casos se podria haber empleado 'Object' para recibir por parametro o crear \n"
                + "   variables, sin embargo a la hora de invocar un metodo hubiese sido necesario castear.\n"
                + "   Al ser colecciones seria muy engorroso y no recomendable. Para sosIgual() se podria\n"
                + "   haber empleado el metodo 'Equals()' de 'Object' en vez de los implementados, \n"
                + "   sobreescribiendo en cada caso dicho metodo para describir el criterio de comparacion\n"
                + "   correspondiente. Esto estaría limitando el posible comportamiento a los metodos de Object.\n"
                + "\n"
                + "   En conclusion: si se reemplazan las interfaces por clases abstractas se elimina la\n"
                + "   posibilidad de heredar de otro padre, por ello deberia optarse por herencia solo\n"
                + "   donde realmente el modelo la describa.\n"
                + "   Por otro lado, sirven para modelar comportamiento en comun entre diferentes clases.\n"
                + "   Este concepto es distinto al de herencia, no se trata de que tengan que 'ampliar un origen\n"
                + "   que los define', si no para 'resaltar cosas en comun que ya tienen', 'amigos'. \n"
                + "   Tambien, se pueden interpretar bajo el punto de vista de la versatilidad que brinda la\n"
                + "   herencia de poder guardar obj de diferentes clases en una variable en comun, tal es el caso\n"
                + "   mas generico de parametros 'Object', pero ampliando el comportamiento descripto en dicha\n"
                + "   clase. \n"
                + "   Por ultimo, en los casos en que sea estricatamente necesario , y habria que buscar un\n"
                + "   ejemplo, se puede simular herencia multiple, con todas las limitaciones que eso conlleva,\n"
                + "   tal es el caso de la implementacion de metodos o los atributos. \n");
        }

        // Para simplificar agrega numeros del 0 al 100
        public static void Llenar(Coleccionable c)
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

        public static void LlenarPersonas(Coleccionable c)
        {
            for (int i = 0; i < 20; i++)
                c.Agregar(new Persona(RandomNombre(), RandomDni()));
        }

        public static void LlenarAlumnos(Coleccionable c)
        {
            for (int i = 0; i < 20; i++)
            {
                int leg = 0;
                // un numero razonable para un legajo
                while (leg < 1000 || leg > 100000)
                    leg = new Random().Next();
                int p = new Random().Next() % 10;
                c.Agregar(new Alumno(RandomNombre(), RandomDni(), leg, p));
            }
        }

        public static void Informar(Coleccionable c)
        {
            int size = c.Cuantos();
            if (size == 0)
            {
                Console.WriteLine("No Hay elementos\n");
                return;
            }
            Console.WriteLine("Hay {0} elementos\n", size);
            Comparable? e = c.Minimo();
            Console.WriteLine("El más chico es {0}\n", e);
            Console.WriteLine("El más grande es {0}\n", c.Maximo());
            if (e is Alumno)
            {
                char? opt = null;
                while (opt == null)
                {
                    Console.WriteLine("Menu:\n-----\n 1) Comparar por dni\n 2) Comparar por legajo\n");
                    opt = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    if (opt == '2')
                        ((Alumno)e).SetCmpPorLegajo(true);
                    else if (opt == '1')
                        ((Alumno)e).SetCmpPorLegajo(false);
                    else
                        opt = null;
                }
            }
            Comparable? f = null;
            while (f == null)
                f = LeerComparableDelTipo(e!);
            if (c.Contiene(f!))
                Console.WriteLine("\n{0}, está en la colección\n", f);
            else
                Console.WriteLine("\n{0}, no está en la colección\n", f);
            Console.WriteLine("");
        }

        private static Comparable? LeerComparableDelTipo(Comparable tipo)
        {
            Comparable? c = null;
            try
            {
                if (tipo is Numero)
                {
                    Console.Write("Numero : ");
                    string? s = Console.ReadLine();
                    c = new Numero(int.Parse(s!));
                }
                else if (tipo is Alumno)
                {
                    if (((Alumno)tipo).GetCmpPorLegajo())
                    {
                        Console.Write("Legajo : ");
                        string? s = Console.ReadLine();
                        c = new Alumno("", null, int.Parse(s!), 0);
                    }
                    else
                    {
                        Console.Write("DNI : ");
                        string? s = Console.ReadLine();
                        c = new Alumno("", int.Parse(s!), null, 0);
                    }
                }
                else if (tipo is Persona)
                {
                    Console.Write("DNI : ");
                    string? s = Console.ReadLine();
                    c = new Persona("", int.Parse(s!));
                }
                else
                    Console.WriteLine("La funcion 'Buscar' solo soporta Personas, Alumnos y Numeros");
            }
            catch (Exception)
            {
                Console.WriteLine("    Valor invalido\n");
            }

            return c;
        }

    }
}
