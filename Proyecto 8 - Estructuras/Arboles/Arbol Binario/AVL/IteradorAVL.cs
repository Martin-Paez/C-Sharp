using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Arboles.Arbol_Binario.AVL
{
    public class IteradorNodosAVL<T> where T : IComparable<T>
    {
        private AVL<T> tree { get; set; }
        private Stack<AVL<T>?> s = new Stack<AVL<T>?>();
        private AVL<T>? last = null;
        private bool first = true;
        public IteradorNodosAVL(AVL<T> t)
        {
            this.tree = t;
            s.Push(tree);
        }
        public bool HasNext()
        {
            return s.Count > 1 || (s.Count == 1 && s.Peek() != null);
        }
        public void Reset()
        {
            s = new Stack<AVL<T>?>();
            s.Push(tree);
        }
        public AVL<T>? Next()
        {
            AVL<T>? t = s.Peek()!;
            if (t == null)
            {
                s.Pop();
                t = s.Pop();
                if (t!.getHijoDerecho() != null)
                    s.Push((AVL<T>)t!.getHijoDerecho()!);
                return t;
            }
            if (t.getHijoIzquierdo() != null)
            {
                s.Push((AVL<T>)t.getHijoIzquierdo()!);
                return Next();
            }
            s.Pop();
            s.Push(null);
            return t;
        }
        public void ResetFlexible()
        {
            last = null;
            first = true;
        }
        public virtual AVL<T>? NextFlexible ()
        {
            AVL<T> t = tree;
            AVL<T>? p = null;
            if (first)
            {
                first = false;
                last = t.min();
                return last;
            }
            while (true)
            {
                if (last!.getDatoRaiz().CompareTo(t.getDatoRaiz()) >= 0)
                    if (t.getHijoDerecho() == null)
                    {
                        last = p;
                        return p;
                    }
                    else
                        t = (AVL<T>)t.getHijoDerecho()!;
                else if (t.getHijoIzquierdo() == null)
                {
                    last = t;
                    return t;
                }
                else
                {
                    p = t;
                    t = (AVL<T>)t.getHijoIzquierdo()!;
                }
            }
        }
    }

    public class IteradorAVL<T> : IteradorNodosAVL<T> where T : IComparable<T>
    {
        public IteradorAVL(AVL<T> t) : base(t)
        {
        }
        public new T? Next()
        {
            AVL<T>? t = base.Next();
            return (t==null)?default:t.getDatoRaiz();
        }
    }
}