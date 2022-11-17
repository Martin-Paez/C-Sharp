using WiW;
using WiW.src.Clasificador;
using WiW.src.IDato;

namespace tpf
{
    public class Backend
	{
        private DTree Node { get; set; }
        private DTree Root { get; set; }
        public RawData Data { get; set; }
        private List<string>? Replys { get; set; }
        private string? character;

        public Backend()
        {
            Data = new RawData(FilePath.Path());
			Root = new (SFactory.New(Data));
			Node = Root;
        }
        public List<Query> startGame()
        {
            Node = Root;
            Replys = new();
            int sel = new Random().Next(1, Data.Ylen);
            character = Data.Name(sel);
            HashSet<Query> hs = new();
            for (int j = 0; j < Data.Xlen - 1; j++)
                for (int i = 0; i < Data.Ylen; i++)
                    if (hs.Add(new Query(Data.Elem(i, j), RawData.Header![j])))
                        if (Data.Elem(i, j).Equals(Data.Elem(sel, j)))
                            Replys.Add("si");
                        else
                            Replys.Add("no");
            return hs.ToList();
        }
        public bool Ends()
        {
            return Node.ChildLess();
        }
        public string Query()
        {
            if (Ends())
                throw new Exception("Ya se ah tomado una decision");
            return Node.Data.ToString();
		}
		public (string,double) Decide()
		{
            if (!Ends())
                throw new Exception("Todavia no hay informacion suficiente");
            return ((Result)Node.Data).Rand();
		}
		public void Next(bool valor)
		{
            if (Ends())
                throw new Exception("Ya se ah tomado una decision");
            Node = valor ? Node.Left! : Node.Right!;
		}
        public string Ask(int queryNum)
        {
            if (Replys == null)
                throw new Exception("El juego todavia no empezo.");
            return Replys[queryNum];
        }
        public bool Guess(string Face)
        {
            if (Face == null)
                throw new Exception("El juego todavia no empezo.");
            return Face.Equals(character);
        }
        public string Character()
        {
            if (character == null)
                throw new Exception("Todavia no termino el juego");
            return character;
        }
        public string OddsRequest()
        {
            return Node.Leafs();
        }
        public string PathsRequest()
        {
            return Node.Paths();
        }
        public string LevelsRequest()
        {
			return Node.Levels();
        }
    }
}