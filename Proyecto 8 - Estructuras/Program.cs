using System.Diagnostics;
using System.Linq.Expressions;
using TP1_Arbol_Binario.Arboles;
using TP1_Arbol_Binario.Arboles.Arbol_Binario;
using TP1_Arbol_Binario.Arboles.Arbol_Binario.AVL;
using TP1_Arbol_Binario.Hash;
using TP1_Arbol_Binario.Heap;
using TP1_Arbol_Binario.Utiles;

namespace TP1_Arbol_Binario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArbolGeneral<int> a = Crear(4, 1, 2, -1, (x,y) => { return new Random().Next(); }, false);
            Console.WriteLine(a);
            a.printPre();
            a.printIn();
            a.printPos();
        }

        public static void testIteradorAVL()
        {
            AVL<int> t = new(1);
            foreach (int j in new int[] { 2, 3, 4, 5, 60, 70, 80, 90 })
                t = t.Agregar(j);
            IteradorAVL<int> i = new(t);
            while (i.HasNext())
                Console.WriteLine(i.Next());
        }

        public static void agregarAVL()
        {
            AVL<int> t = new(1);
            foreach (int i in new int[] { 11, 9, 7, 5, 4, 1 })
                t = t.Agregar(i);
            Console.WriteLine(t);
            t = new(40);
            foreach (int i in new int[] { 20, 30, 38, 33, 36, 34, 37 })
                t = t.Agregar(i);
            Console.WriteLine(t);
        }

            public static void agregarABB()
        {
            ABB<int> t = new(15);
            foreach (int i in new int[] { 11, 9, 7, 5, 4, 1 })
                t.Agregar(i);
            Console.WriteLine(t);
            t = new(3);
            foreach (int i in new int[] { 1, 4, 6, 8, 2, 5, 7 })
                t.Agregar(i);
            Console.WriteLine("-----------------------");
            Console.WriteLine(t);
            Console.WriteLine("Inorden");
            t.inorden();
            Console.WriteLine("\nPreorden");
            t.preorden();
            Console.WriteLine("\nPostorden");
            t.postorden();
            Console.WriteLine("\nIncluye el 4: {0}",t.incluye(4));
            Console.WriteLine("Incluye el 0: {0}", t.incluye(0));
        }
        public static void Hash()
        { 
            Console.WriteLine("Con override de GetHashCode: \n");
            ConGetHashCode();
            Console.WriteLine("El empleado NO se encuentra. Fin de programa");
            Console.WriteLine("\nCon Diccionario Hash: \n");
            ConDiccionario();
            Console.WriteLine("El empleado NO se encuentra. Fin de programa");
            Console.ReadKey();
        }

        /*----------------------------------------------------------------------*/
        /*------------------------------ HASHING -------------------------------*/
        /*----------------------------------------------------------------------*/
        public static void ConGetHashCode()
        {
            HashTable<Empleado> hashT = new(11);
            Empleado e;
            for (int i = 0; i < 20; i++)
            {
                e = new Empleado(Helper.GenNombre(), Helper.GenDni(), i);
                hashT.Add(e);
            }
            Console.WriteLine(hashT);
            while (hashT.Contains(new Empleado("", Helper.LeerNum("Ingrese un Numero: "), 0)))
                 Console.WriteLine("El empleado se encuentra en la coleccion.");
        }

        public static void ConDiccionario() 
        {
            Diccionario<int, Empleado> dic = new(11, (x) => { return x; });
            for (int i = 0; i < 20; i++)
            {
                Empleado e = new Empleado(Helper.GenNombre(), Helper.GenDni(), i);
                dic.Add(e, e.Dni);
            }
            Console.WriteLine(dic);
            while (dic.Contains(Helper.LeerNum("Ingrese un Numero: ")))
                Console.WriteLine("El empleado se encuentra en la coleccion.");
        }
        /*--------------------- ARBOL GENERAL (AUXILIARES) ---------------------*/
        public static ArbolGeneral<T> Crear<T>(int n, T r, int nodosPorNivel, T stop
                                            , Func<int, int,T> genDatos
                                            , bool agregarStop = true) where T : IComparable<T>
        {
            ArbolGeneral<T> raiz = new(r);
            LlenarArbolG(n-1, raiz, nodosPorNivel, stop, genDatos, agregarStop);
            return raiz;
        }
        public static void LlenarArbolG<T>(int altura, ArbolGeneral<T> raiz, int nodosPorNivel
                                       , T stop, Func<int,int,T> genDatos
                                       , bool agregarStop = true) where T : IComparable<T>
        {
            if (altura > 0)
                for (int i = 0; i < nodosPorNivel; i++)
                {
                    T dato = genDatos(i, altura);
                    ArbolGeneral<T> hijo = new(dato);
                    if (dato.CompareTo(stop) != 0)
                    {
                        LlenarArbolG(altura - 1, hijo, nodosPorNivel, stop, genDatos, agregarStop);
                        raiz.AgregarHijo(hijo);
                    }
                    else if (agregarStop)
                        raiz.AgregarHijo(hijo);
                }
            return;
        }

        /*----------------------------------------------------------------------*/
        /*-------------------------- ARBOL GENERAL -----------------------------*/
        /*----------------------------------------------------------------------*/
        public static void CaudalMinimo()
        {
            ArbolGeneral<int> t = Crear<int>(5, 0, 3, 1, (x,y) => { return new Random().Next(0,10); }, false);
            Console.WriteLine("Caudal inicial = 1000.\nCaudal minimo entregado: {0}\n{1}", t.MinHerenciaEquitativa(1000),t);
        }
        public static void Artista()
        {
            int niveles = 3;
            ArbolGeneral<char> tree = Crear<char>(niveles, 'G', 4, 'N'
                , (x, y) =>
                {
                    char[] colores = new char[] { 'G', 'B', 'N' };
                    int min = (y == 1) ? 1 : 0;
                    int c = new Random().Next(min, niveles);
                    return colores[c];
                });
            Console.WriteLine(tree);
            Console.WriteLine(tree.SumHojas(1024, 'N'));
        }
        public static void Niveles(int stop)
        {
            ArbolGeneral<int> raiz = Crear(3, 1, 2, stop, (x, y) => { return y * 10 + x; });
            raiz.Hijos[0].EliminarHijo(raiz.Hijos[0].Hijos[0]);
            Console.WriteLine(raiz.Ancho(3));
        }
        public static void Altura(int nodosPorNivel)
        {
            Func<int, int, int> genDatos = (x, y) => { return y * 10 + x; };
            ArbolGeneral<int> raiz = Crear(3, 110, nodosPorNivel, -1, genDatos);
            ArbolGeneral<int> nodo = raiz;
            /*TODO, ver si es necesario*/
            LlenarArbolG(3, nodo, nodosPorNivel, -1, genDatos);
            List<ArbolGeneral<int>> kk = nodo.Hijos;
            Console.WriteLine(nodo.GetDatoRaiz() + " " + raiz.Nivel(nodo.GetDatoRaiz()));
            Console.WriteLine(kk[0].GetDatoRaiz() + " " + raiz.Nivel(kk[0].GetDatoRaiz()));
            nodo = kk[0];
            kk = nodo.Hijos;
            Console.WriteLine(kk[0].GetDatoRaiz() + " " + raiz.Nivel(kk[0].GetDatoRaiz()));
            nodo = kk[0];
            kk = nodo.Hijos;
            Console.WriteLine(kk[2].GetDatoRaiz() + " " + raiz.Nivel(kk[2].GetDatoRaiz()));
            Console.ReadKey();
        }

        /*----------------------------------------------------------------------*/
        /*-------------------------------- HEAP --------------------------------*/
        /*----------------------------------------------------------------------*/
        public static void Heap()
        {
            int[] datos = { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 5; i++)
                Console.Write(datos[i] + ", ");
            Console.WriteLine();
            Heap<int> heap = new Heap<int>(datos, 5, true);
            Console.WriteLine(heap);
            heap.Eliminar();
            Console.WriteLine(heap);
            heap.Agregar(5);
            Console.WriteLine(heap);
        }
        public static void TpDosEjDos()
        {
            Impresora imp = new();
            imp.NuevoDoc("Doc III");
            imp.NuevoDoc("Doc I");
            imp.NuevoDoc("Doc II");
            for (int i = 0; i < 3; i++)
                imp.Imprimir(); 
        }

        /*----------------------------------------------------------------------*/
        /*--------------------------  ARBOL BINARIO ----------------------------*/
        /*----------------------------------------------------------------------*/
        public static void EjCincoEntreNiveles(ArbolBinario<int> tree)
        {
            try
            {
                tree.recorridoEntreNiveles(1, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nTenga en cuenta que {0}", e.Message);
            }
        }
        public static void Profundidad() {
            ArbolBinario<int> tree = CrearArbolB();
            ProfundidadDeArbolBinario prof = new ProfundidadDeArbolBinario(tree);
            for (int i = 0; i <= tree.altura(); i++)
                Console.WriteLine("nivel {0}: {1}\n", i, prof.sumaElementosProfundidad(i));
        }
        public static void RetardoRedB()
        {
            Console.WriteLine(CrearRedB().RetardoReenvio());
        }
        public static ArbolBinario<int> CrearArbolB()
        {
            List<int> datos = new();
            for (int i = 0; i < 25; i++)
                datos.Add(i);
            ArbolBinario<int> tree = ArbolBinario<int>.Crear(datos);
            /*
            RedBinariaLlena<int>? tree = new RedBinariaLlena<int>(1);
            RedBinariaLlena<int>? hijo = new RedBinariaLlena<int>(2);
            RedBinariaLlena<int>? nieto = new RedBinariaLlena<int>(4);
            nieto.agregarHijoIzquierdo(new RedBinariaLlena<int>(8));
            nieto.agregarHijoDerecho(new RedBinariaLlena<int>(9));
            hijo.agregarHijoIzquierdo(nieto);
            /*branchita = new RedBinariaLlena<int>(5);
            branchita.agregarHijoIzquierdo(new RedBinariaLlena<int>(10));
            branchita.agregarHijoDerecho(new RedBinariaLlena<int>(11));
            branch.agregarHijoDerecho(branchita);*/
           /* tree.agregarHijoIzquierdo(hijo);
            hijo = new RedBinariaLlena<int>(3);
            nieto = new RedBinariaLlena<int>(6);
            //branchita.agregarHijoIzquierdo(new RedBinariaLlena<int>(12));
           /* nieto.agregarHijoDerecho(new RedBinariaLlena<int>(13));
            hijo.agregarHijoIzquierdo(nieto);
            nieto = new RedBinariaLlena<int>(7);
            nieto.agregarHijoIzquierdo(new RedBinariaLlena<int>(14));
            nieto.agregarHijoDerecho(new RedBinariaLlena<int>(15));
            hijo.agregarHijoDerecho(nieto);
            tree.agregarHijoDerecho(hijo);*/
            return tree;
        }
        public static RedBinariaLlena<int> CrearRedB()
        {
            RedBinariaLlena<int>? tree = new RedBinariaLlena<int>(1);
            RedBinariaLlena<int>? hijo = new RedBinariaLlena<int>(2);
            RedBinariaLlena<int>? nieto = new RedBinariaLlena<int>(4);
            nieto.agregarHijoIzquierdo(new RedBinariaLlena<int>(8));
            nieto.agregarHijoDerecho(new RedBinariaLlena<int>(9));
            hijo.agregarHijoIzquierdo(nieto);
            /*branchita = new RedBinariaLlena<int>(5);
            branchita.agregarHijoIzquierdo(new RedBinariaLlena<int>(10));
            branchita.agregarHijoDerecho(new RedBinariaLlena<int>(11));
            branch.agregarHijoDerecho(branchita);*/
            tree.agregarHijoIzquierdo(hijo);
            hijo = new RedBinariaLlena<int>(3);
            nieto = new RedBinariaLlena<int>(6);
            //branchita.agregarHijoIzquierdo(new RedBinariaLlena<int>(12));
            nieto.agregarHijoDerecho(new RedBinariaLlena<int>(13));
            hijo.agregarHijoIzquierdo(nieto);
            nieto = new RedBinariaLlena<int>(7);
            nieto.agregarHijoIzquierdo(new RedBinariaLlena<int>(14));
            nieto.agregarHijoDerecho(new RedBinariaLlena<int>(15));
            hijo.agregarHijoDerecho(nieto);
            tree.agregarHijoDerecho(hijo);
            return tree;
        }
    }
}