
using System;
using System.IO;
using System.Collections.Generic;
using WiW;
using WiW.src.IDato;
using WiW.src.Parse;

namespace WiW.src.Clasificador
{
    public class RawData
    {
        public static IList<string>? Header { get; set; }
        private List<IList<string>> Rows { get; set; }
        public int Ylen { get { return Rows.Count; } }
        public int Xlen { get { return Rows[0].Count; } }
        private Spliter strategy = new Spliter();

        public RawData(List<IList<string>>? rows = null)
        {
            Rows = rows != null ? rows : new List<IList<string>>();
        }
        public RawData(string path)
        {
            Rows = new List<IList<string>>();
            using (var stream = File.OpenRead(path))
            using (var reader = new StreamReader(stream))
            {
                var data = Parser.ParseHeadAndTail(reader, ',', '"');
                Header = data.Item1;
                foreach (var line in data.Item2)
                    Rows.Add(line);
            }
        }
        public string Name(int Fila)
        {
            return Rows[Fila][Rows[Fila].Count - 1];
        }
        public string Elem(int i, int j)
        {
            return Rows[i][j];
        }
        public IList<string> Row(int i)
        {
            return Rows[i];
        }
        public void Add(IList<string> row)
        {
            Rows.Add(row);
        }
        public (Query, RawData[]) BestQuery()
        {
            return strategy.BestSplit(this);
        }
        public HashSet<string> ToHashSet()
        {
            HashSet<string> h = new();
            for (int i = 0; i<Ylen; i++)
                h.Add(Name(i));
            return h;
        }
        public Dictionary<string, int> Names()
        {   //Counts the number of each type of example in a dataset."""
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < Ylen; i++)
            {
                string name = Name(i);
                if (!dic.ContainsKey(name))
                    dic.Add(name, 0);
                dic[name] = dic[name] + 1;
            }
            return dic;
        }


    }
}
