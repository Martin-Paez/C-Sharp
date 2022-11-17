using System.Xml.Linq;
using WiW.src.IDato;

namespace tpf
{
	public class Result : IData
	{
		private HashSet<string> Faces { get; }
		public double Potluck { get; }
		public Result(HashSet<string> results)
		{
			Faces = results;
			Potluck = 100 / Faces.Count;
        }
        public (string, double) Rand()
		{
            int i = new Random().Next(Faces.Count);
            return (Faces.ElementAt(i), Potluck);
        }
        private string? Face(string name)
		{
			if (!Faces.Contains(name))
				return null;
			return name + " : " + Potluck.ToString() + "%";
		}
		public override string ToString()
		{
			string s = "";
			foreach (string name in Faces)
				s += " " + Face(name) + " , ";
			s = s.Substring(0, s.Length - 2);
            if (Faces.Count > 1)
                s = "(" + s + ")";
			return s;
		}

	}
}
