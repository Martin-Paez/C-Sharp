using tpf;
using WiW.src.Clasificador;

namespace WiW
{
    public partial class FacesForm : Dragable
    {
        private Backend Game { get; set; }

        private List<PictureBox> faces;
        private Action<string> BtnStrategy;
        private static FacesForm? singleton;
        
        private FacesForm(Backend game)
        {
            InitializeComponent();
            Game = game;
            faces = drawFaces();
        }

        public static FacesForm NewGame(Backend game)
        {
            if (singleton != null)
                singleton.Game = game;
            else
                singleton = new FacesForm(game);
            singleton.Restart();
            return singleton;
        }

        public static FacesForm Call()
        {
            if (singleton == null)
                throw new Exception("No fue instanciado.");
            return singleton;
        }

        public void Restart()
        {
            BtnStrategy = NewBoard;
            ShowForm();
        }

        public void Guess()
        {
            BtnStrategy = BtnGuess;
            ShowForm();
        }

        private void ShowForm()
        {
            Show();
            Activate(); // Lo trae al frente 
        }

        private List<PictureBox> drawFaces()
        {
            RawData data = Game.Data;
            List<PictureBox> faces = new();
            for (int j = 0, x = 0, y = 0; j < data.Ylen;)
            {
                faces.Add(CreateFace(data.Name(j), x, y));
                y = ++j / 6;
                x = j % 6;
            }
            return faces;
        }

        private PictureBox CreateFace(string name, int x, int y)
        {
            int w = 70, h = 105;
            PictureBox face = new();
            face.Size = new System.Drawing.Size(w, h);
            Image file = fileMgr.Img(name);
            if (null != file)
            {
                face.Cursor = System.Windows.Forms.Cursors.Hand;
                face.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
                face.Image = file;
                face.Location = new System.Drawing.Point(x * w + 3, y * h + 3);
                face.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                face.Name = name;
                face.Click += new System.EventHandler(this.BtnFace);
                answerPanel.Controls.Add(face);
            }
            return face;
        }

        private void BtnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnFace(object sender, EventArgs e)
        {
            BtnStrategy.Invoke(((PictureBox)sender).Name);
        }

        private void NewBoard(string face)
        {
            Board board = new Board(Game, faces);
            board.userFace.Image = fileMgr.Img("Sel_" + face);
            Hide();
            board.Show();
        }

        private void BtnGuess(string face)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de arriesgar con " + face + "?",
                          "Pregunta", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Image img = fileMgr.Img(Game.Name());
                    GameOver resultado;
                    if (Game.Guess(face))
                        resultado = new GameOver(img, "Correcto!!", Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(80))))));
                    else
                        resultado = new GameOver(img, "Incorrecto!!", Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(10)))), ((int)(((byte)(0))))));
                    resultado.Show();
                    resultado.Activate();
                    break;
                case DialogResult.No:
                    this.Parent.Show();
                    break;
            }
        }
    }
}
