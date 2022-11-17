using System;
using WiW.src.Clasificador;
using WiW.src.IDato;

namespace tpf
{
	public class DTree
	{
		public IData Data { get; set; }
		public DTree? Left { get; }
		public DTree? Right { get; }

        private DTree(IData dato) {
			this.Data = dato;
		}

        public DTree(ISorter s)
        {
            Data = s.Data();
            if (s.isParent())
            {
                Right = new (s.Right()!);
                Left = new(s.Left()!);
            }
        }

        public bool ChildLess() {
			return Left==null;
		}
        public string Leafs()
        {
            return _Leafs(this);
        }
        public string Paths()
        {
            return _Paths(this, "");
        }
        public string Levels()
        {
            Queue<DTree> a = new();
            a.Enqueue(this);
            return _Levels(a, 0);
        }

        /* ------------------ ALGORITMOS --------------------- */

        private string _Leafs(DTree a)
        {
            if (a.ChildLess())
                return a.Data.ToString()!;
            return _Leafs(a.Left!) + "\n" + _Leafs(a.Right!);
        }

        private string _Paths(DTree a, string paths)
        {
            string s = paths + a.Data;
            if (a.ChildLess())
                return s + "\n";
            return _Paths(a.Left!, s + " | ") + _Paths(a.Right!, s + " | ");
        }

        private string _Levels(Queue<DTree> q, int n)
        {
            Queue<DTree> c = new();
            string s = "Nivel: " + n + "\n  | ";
            while (q.Count > 0)
                s += Next(q, c) + (q.Count % 2 == 1 ? " , " : " | ");
            return s + "\n" + (c.Count > 0 ? _Levels(c, n + 1) : "");
        }

        private IData Next(Queue<DTree> a, Queue<DTree> b)
        {
            DTree t = a.Dequeue();
            if (!t.ChildLess())
            {
                b.Enqueue(t.Left!);
                b.Enqueue(t.Right!);
            }
            return t.Data;
        }

    }
}
