using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Clases;
using TP.TP1.Colecciones;

namespace TP.TP1.Extra
{

    public class Meets
    {

        public static void ClaseUno()
        {
            /*Numero num1 = new Numero(2);
            Numero num2 = new Numero(5);
            //Console.WriteLine(num1.Equals(num2));

            Coleccion pila = new Coleccion();
            pila.Agregar(num1);
            pila.Agregar(num2);
            //Console.WriteLine(((Numero)pila.Maximo()).GetValor());

            Stack<Numero> stack = new Stack<Numero>();
            stack.Push(num1);
            stack.Push(num2);
            foreach (Numero num in stack)
                Console.WriteLine(num.GetValor());

            Queue<Numero> cola = new Queue<Numero>();
            cola.Enqueue(num1);
            cola.Enqueue(num2);
            foreach (Numero num in cola)
                Console.WriteLine(num.GetValor());

            List<Numero> list = new List<Numero>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new Numero(new Random().Next()));
            }

            //version lambda
            var listaOrdenada = list.OrderBy(x => x.GetValor()).ToList();
            foreach (Numero num in listaOrdenada)
                Console.WriteLine(num.GetValor());

            //version linq
            var listaOrdenada2 = from elemento in list
                                 orderby elemento.GetValor()
                                 select elemento.GetValor();
           /* foreach (int num in listaOrdenada2)
                Console.WriteLine(num);*/
        }

    }

}
