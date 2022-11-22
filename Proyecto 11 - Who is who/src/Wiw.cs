using tpf;
using WiW.src.IViews;
using WiW.src.Views;

namespace WiW.src
{
    public class WiW
    {
        public Machine Pc;
        private FileMgr fileMgr;
        private BoardView VBoard;
        private FacesView VFaces;
        private OutputView output;
        private GameOverView VGameOver;
        
        public WiW()
        {
            CreateObjects();
            InitEvents();
            RunApp();
        }
        
        // Turno de la PC

        private void BtnYes(object? sender, EventArgs e)
        {
            UserReply(true);
        }

        private void BtnNo(object? sender, EventArgs e)
        {
            UserReply(false);
        }

        private void UserReply(bool reply)
        {
            (string, double)? rta = Pc.Answer(reply);
            if (rta == null)
                VBoard.UserTurn(Pc.Query());
            else
            {
                Image face = fileMgr.Img(rta?.Item1!);
                VBoard.Close();
                VGameOver.PcGuess(face, (double)rta?.Item2!);
            }
        }

        // Consultas

        private void BtnLeafs(object? sender, EventArgs e)
        {
            PrintRequest(Pc.Leafs());
        }

        private void BtnPaths(object? sender, EventArgs e)
        {
            PrintRequest(Pc.Paths());
        }

        private void BtnLevels(object? sender, EventArgs e)
        {
            PrintRequest(Pc.Levels());
        }

        private void PrintRequest(string resultado)
        {
            output.Print = resultado;
            VBoard.Hide();
            output.Show();
        }

        // Turno del usuario

        private void BtnAsk(object? sender, EventArgs e)
        {
            VBoard.PcTurn();
            VBoard.PcReply(Pc.Ask(VBoard.SelectedQuery));            
        }

        private void BtnGuess(object? sender, EventArgs e)
        {
            VFaces.Show();
            VBoard.Hide();
        }

        private void Guess(object? sender, NameArg e)
        {
            if (VFaces.AreYouShure("¿ Seguro queres elegir a " + e.Name + "?"))
            {
                VBoard.Close();
                Image img = fileMgr.Img(Pc.Name());
                if (Pc.Guess(e.Name))
                    VGameOver.PlayerHit(img);
                else
                    VGameOver.PlayerMiss(img);
            }
        }

        // Objetos participantes

        private void CreateObjects()
        {
            fileMgr = FileMgr.Instance();
            Pc = new Machine();
            VFaces = new FacesForm(Pc.Data);
            VGameOver = new GameOver();
            output = new Output();
        }

        // Secuencia de eventos

        private void InitEvents()
        {
            VFaces.ImgSelected += InitBoardView;
            VFaces.BtnClose += delegate { Application.Exit(); };
            VGameOver.BtnNewGame += BtnNewGame;
            VGameOver.BtnClose += delegate { Application.Exit(); };
            output.BtnClose += delegate { output.Hide(); };
        }

        private void InitBoardView(object? sender, ImgArg e)
        {
            Board board = new Board(Pc.startGame(), Pc.Query(), VFaces.Imgs);
            board.userFace.Image = e.Face;
            VFaces.Hide();
            VFaces.ImgSelected -= InitBoardView;
            VFaces.NameSelected += Guess;
            VBoard.Yes += BtnYes;
            VBoard.No += BtnNo;
            VBoard.Paths += BtnPaths;
            VBoard.Levels += BtnLevels;
            VBoard.Leafs += BtnLeafs;
            VBoard.Guess += BtnGuess;
            VBoard.Ask += BtnAsk;
            board.Show();
        }

        private void BtnNewGame(object? sender, EventArgs e)
        {
            VGameOver.Hide();
            VFaces.ImgSelected += InitBoardView;
            VFaces.NameSelected -= Guess;
            VFaces.Show();
        }

        // Iniciar Aplicacion

        private void RunApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(VFaces!.GetForm());
        }

    }
}
