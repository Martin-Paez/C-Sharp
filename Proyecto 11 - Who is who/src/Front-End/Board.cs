using System.Runtime.InteropServices;
using tpf;
using WiW.src.Clasificador;
using WiW.src.IDato;

namespace WiW
{
    public partial class Board : Dragable
    {
        public Backend Game;
        public Board(Backend game, List<PictureBox> faces) : base()
        {
            InitializeComponent();
            Game = game;
            LocalInit(Game.startGame(), faces);
		}

        private void LocalInit(List<Query> userQuerys, List<PictureBox> faces)
        {
            this.txtPregunta.Text = Game.Query();
            Game.gameOverListener = GameOver;
            int x = 0, y = 0, i = 0, w = 125, h = 192;
            foreach (PictureBox f in faces)
            {
                PictureBox face = new PictureBox();
                face.Cursor = f.Cursor;
                face.BackColor = f.BackColor;
                face.Image = f.Image;
                face.SizeMode = f.SizeMode;
                face.Name = f.Name;
                face.Size = new Size(w, h);
                face.Location = this.pictureBox2.Location = new System.Drawing.Point(x * w + 5, y * h + 5);
                face.Click += new EventHandler(MarkFace);
                y = ++i / 6;
                x = i % 6;
                caras.Controls.Add(face);
            }
            foreach (var item in userQuerys)
            {
                this.userQuery.Items.Add(item.ToString());
            }
            this.userQuery.SelectedIndex = 0;
            this.userQuery.Enabled = false;
            this.btnAsk.Enabled = false;
            this.btnGuess.Enabled = true;
        }
        void MarkFace(object? sender, EventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException();
            PictureBox pictureBox = (PictureBox) sender;
            if (pictureBox.Name.StartsWith("No_"))
                pictureBox.Name = pictureBox.Name.Substring(3);
            else
                pictureBox.Name = "No_" + pictureBox.Name;
            pictureBox.Image = fileMgr.Img(pictureBox.Name);
        }

        private void BtnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void GameOver()
        {
            (string, double) p = Game.Decide();
            string s = "Definitivamente elijiste a ";
            if (p.Item2 != 100)
                s = "Me arriesgo a decir que eligiste a ";
            GameOver resultado = new GameOver(fileMgr.Img(p.Item1), s + p.Item1, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200))))));
            resultado.Show();
            this.Hide();
        }

        private void checks(bool valor)
        {
            if (Game.Answer(valor))
            {
                txtPregunta.Text = Game.Query();
                userQuery.Enabled = true;
                btnAsk.Enabled = true;
                pictureBox2.Visible = true;
                pictureBoxSi.Visible = false;
                pictureBoxNo.Visible = false;
                btnNo.Enabled = false;
                btnsi.Enabled = false;
                txtPregunta.Enabled = false;
            }
        }

        private void BtnSi(object sender, EventArgs e)
        {
            this.checks(true);

        }
        private void BtnNo(object sender, EventArgs e)
        {
            this.checks(false);
        }

        // Consultas

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            this.mostrarConsulta(Game.OddsRequest());
        }

        private void btn_consulta2_Click(object sender, EventArgs e)
        {
            this.mostrarConsulta(Game.PathsRequest());
        }

        private void btn_consulta3_Click(object sender, EventArgs e)
        {
            this.mostrarConsulta(Game.LevelsRequest());
        }

        private void mostrarConsulta(string resultado)
        {
            Output consulta = new Output(this, resultado);
            consulta.Show();
            this.Hide();
        }

        private void BtnAsk(object sender, EventArgs e)
        {
            userQuery.Enabled = false;
            btnAsk.Enabled = false;
            btnNo.Enabled = true;
            btnsi.Enabled = true;
            txtPregunta.Enabled = true;

            string reply = Game.Ask(userQuery.SelectedIndex);
            pictureBoxSi.Visible = reply.Equals("si");
            pictureBoxNo.Visible = !pictureBoxSi.Visible;
            pictureBox2.Visible = false;
        }

        private void BtnGuess(object sender, EventArgs e)
        {
            FacesForm.Call().Guess();
            Hide();
        }
    }
}