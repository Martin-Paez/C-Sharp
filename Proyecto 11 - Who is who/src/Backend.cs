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
        public Action gameOverListener { get;  set; }

        public Backend() 
        {
            Data = new RawData();
            Node = Root = new(SFactory.New(Data));
        }
        public List<Query> startGame()
        {
            Node = Root;
            RawData d = Data;
            Replys = new();
            int sel = new Random().Next(0, d.Ylen);
            character = d.Name(sel);
            HashSet<Query> hs = new();
            for (int j = 0; j < d.Xlen - 1; j++)
                for (int i = 0; i < d.Ylen; i++)
                    if (hs.Add(new Query(d.Val(i, j), d.Query![j])))
                        Replys.Add(d.Val(i, j) == d.Val(sel, j) ? "si" : "no");
            return hs.ToList();
        }
        public bool Ends()
        {
            return Node.ChildLess();
        }
        public string Query()
        {
            if (Ends())
                throw new Exception("No hay preguntas para hacer");
            return Node.Data.ToString();
		}
		public (string,double) Decide()
		{
            if (!Ends())
                throw new Exception("Todavia no hay informacion suficiente para decidir, el juego no termino");
            return ((Result)Node.Data).Rand();
		}
		public bool Answer(bool valor)
		{
            if (Ends())
                throw new Exception("No se va a preguntar mas nada, ya se ah tomado una decision");
            Node = valor ? Node.Left! : Node.Right!;
            if (Ends())
            {
                gameOverListener.Invoke();
                return false;
            }
            return true;
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
                throw new Exception("El juego no empezo.");
            return Face.Equals(character);
        }
        public string Name()
        {
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