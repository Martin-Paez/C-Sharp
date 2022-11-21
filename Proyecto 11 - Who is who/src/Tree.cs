﻿using System;
using System.Data;
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

        public string Paths()
        {
            return _Paths("");
        }

        public string Levels()
        {
            Queue<DTree> a = new();
            a.Enqueue(this);
            return _Levels(a, 0);
        }

        /* ------------------ ALGORITMOS --------------------- */

        public string Leafs()
        {
            if (ChildLess())
                return Data.ToString()!;
            return Left!.Leafs() + "\n" + Right!.Leafs();
        }

        public string _Paths(string c)
        {
            if (ChildLess())
                return c + Data + "\n";
            string left = c + Data + " | si | ";
            string right = c + Data + " | no | ";
            return  Left!._Paths(left) + "\n" + Right!._Paths(right);
        }

        private string _Levels(Queue<DTree> q, int n)
        {
            Queue<DTree> c = new();
            string s = "Nivel: " + n + "\n  | ";
            while (q.Count > 0)
                s += Next(q, c) + (q.Count % 2 == 1 ? " , " : " | ");
            return s + "\n" + (c.Count > 0 ? _Levels(c, ++n) : "");
        }

        private string Basico()
        {
            Queue<DTree> c = new(), q = new();
            q.Enqueue(this);
            int n = 1;
            string s = "";
            do {
                s = "Nivel: " + n++ + "\n  | ";
                while (q.Count > 0)
                    s += Next(q, c) + (q.Count % 2 == 1 ? " , " : " | ");
                s += "\n";
            } while (c.Count > 0);
            return s;
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
