using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Colecciones
{
    public class ClaveValor<K, T> : Comparable<ClaveValor<K, T>> where K : Comparable<K> 
                                                                 where T : Comparable<T>
    {
        public K Key { get; }
        public T Elem { get; set; }

        public ClaveValor(K k, T e)
        {
            this.Key = k;
            this.Elem = e;
        }

        public bool SosIgual(ClaveValor<K, T> c)
        {
            return this.Elem.SosIgual(c.Elem);
        }

        public bool SosMayor(ClaveValor<K, T> c)
        {
            return this.Elem.SosMayor(c.Elem);
        }

        public bool SosMenor(ClaveValor<K, T> c)
        {
            return this.Elem.SosMenor(c.Elem);
        }
    }

    public interface IGeneradorDeClaves<K>
    {
        K Crear(int semilla);
    }

    public class GeneradorN : IGeneradorDeClaves<double>
    {
        public double Crear(int semilla)
        {
            return semilla*123;
        }
    }

    // No hereda de coleccion porque no tiene sentido Min, Max, 
    public class Diccionario<K,T> : Coleccion<ClaveValor<K, T>> where T : Comparable<T> 
                                                                where K : Comparable<K>
    {
        public IGeneradorDeClaves<K>? genClave { get; set; } = null;
        private int semilla = 0;

        public override void Agregar(ClaveValor<K, T> c)
        {
            this.Agregar(c.Key, c.Elem);
        }

        public void Agregar(T e)
        {
            if (genClave == null)
                throw new Exception("No hay un generador de claves asignado");

            // Me cubro por si el generador envia claves repetidas
            Agregar(genClave.Crear(semilla++), e);
        }

        public void Agregar(K k, T e)
        {
            // Preferible no usar ValorDe() , por si default(T) != null
            foreach (ClaveValor<K, T> c in this.elementos)
                if (c.Key.SosIgual(k))
                {
                    c.Elem = e;
                    return;
                }
            base.Agregar(new ClaveValor<K, T>(k, e));
        }

        public T? ValorDe(K k)
        {
            foreach (ClaveValor<K, T> c in this.elementos)
                if (c.Key.SosIgual(k))
                    return c;
            return default;
        }
    }
}
