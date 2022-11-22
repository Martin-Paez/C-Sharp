using System.Runtime.InteropServices;
using tpf;
using WiW.src.Clasificador;
using WiW.src.IDato;
using WiW.src.Views;

namespace WiW
{
    public partial class Board : Dragable, BoardView
    {
        public int SelectedQuery { get { return userQuerys.SelectedIndex; } }

        public event EventHandler Yes;
        public event EventHandler No;
        public event EventHandler Paths;
        public event EventHandler Levels;
        public event EventHandler Leafs;
        public event EventHandler Guess;
        public event EventHandler Ask;

        public Board(List<Query> querys, string pcQuery, List<PictureBox> faces) : base()
        {
            InitializeComponent();
            InitEvents();
            LocalInit(querys, faces, pcQuery);
		}

        private void InitEvents()
        {
            btnYes.Click += delegate { Yes?.Invoke(this, EventArgs.Empty); };
            btnNo.Click += delegate { No?.Invoke(this, EventArgs.Empty); };
            btnPaths.Click += delegate { Paths?.Invoke(this, EventArgs.Empty); };
            btnLevels.Click += delegate { Levels?.Invoke(this, EventArgs.Empty); };
            btnLeafs.Click += delegate { Leafs?.Invoke(this, EventArgs.Empty); };
            btnGuess.Click += delegate { Guess?.Invoke(this, EventArgs.Empty); };
            btnAsk.Click += delegate { Ask?.Invoke(this, EventArgs.Empty); };
        }

        private void LocalInit(List<Query> querys, List<PictureBox> faces, string pcQuery)
        {
            userQuerys.DataSource = userQuerys;
            txtPregunta.Text = pcQuery;
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
            userQuerys.SelectedIndex = 0;
            btnGuess.Enabled = true;
            PcTurn();
        }

        public void UserTurn(string pcQuery)
        {
            txtPregunta.Text = pcQuery;
            userQuerys.Enabled = true;
            btnAsk.Enabled = true;
            pictureBox2.Visible = true;
            pictureBoxSi.Visible = false;
            pictureBoxNo.Visible = false;
            btnNo.Enabled = false;
            btnYes.Enabled = false;
            txtPregunta.Enabled = false;
        }

        public void PcTurn()
        {
            userQuerys.Enabled = false;
            btnAsk.Enabled = false;
            btnNo.Enabled = true;
            btnYes.Enabled = true;
            txtPregunta.Enabled = true;
        }

        public void PcReply(bool reply)
        {
            pictureBoxSi.Visible = reply;
            pictureBoxNo.Visible = !pictureBoxSi.Visible;
            pictureBox2.Visible = false;
        }

        public Form GetForm()
        {
            return this;
        }
        void MarkFace(object? sender, EventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException();
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox.Name.StartsWith("No_"))
                pictureBox.Name = pictureBox.Name.Substring(3);
            else
                pictureBox.Name = "No_" + pictureBox.Name;
            pictureBox.Image = fileMgr.Img(pictureBox.Name);
        }
    }
}