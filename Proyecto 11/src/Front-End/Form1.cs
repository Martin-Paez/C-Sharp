using System.Runtime.InteropServices;
using tpf;
using WiW.src.Clasificador;
using WiW.src.IDato;

namespace WiW
{
    public partial class Form1 : Form
    {
        public Backend Game;
        public Form1(Backend game)
        {
            Game = game;
            InitializeComponent();
            LocalInit(Game.startGame());
		}

        private void LocalInit(List<Query> userQuerys)
        {
            this.txtPregunta.Text = Game.Query();

            System.Windows.Forms.PictureBox ptboxcara;
            string direccion;
            string nombre;


            int x = 0;
            int y = 0;
            int i = 0;
            RawData data = Game.Data;
            for( int j=0; j<data.Ylen; j++)
            {
                nombre = data.Name(j);
               // nombre = nombre.Equals(Backend.Nombre_seleccionado) ? "Sel_" + nombre : nombre; 
                ptboxcara = new System.Windows.Forms.PictureBox();
                direccion = FilePath.get_path_img(nombre);

                Image file = Image.FromFile(@direccion);
                if (null != file)
                {
                    ptboxcara.Cursor = System.Windows.Forms.Cursors.Hand;
                    ptboxcara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
                    ptboxcara.Image = file;
                    ptboxcara.Location = this.pictureBox2.Location = new System.Drawing.Point(x * FilePath.w + 100, y * FilePath.h + 200);
                    ptboxcara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                    ptboxcara.Name = nombre;
                    ptboxcara.Click += new EventHandler(picOneFaceUpA_Click);
                    caras.Controls.Add(ptboxcara);
                }
                i++;
                y = i / 6;
                x = i % 6;

            }
            
            foreach (var item in userQuerys)
            {
                this.comboBox1.Items.Add(item.ToString());
            }
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.Enabled = false;
            this.button7.Enabled = false;
            this.button8.Enabled = false;


        }
        void picOneFaceUpA_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pictureBox = (System.Windows.Forms.PictureBox) sender;

            if (pictureBox.Name.StartsWith("No_"))
            {
                pictureBox.Name = pictureBox.Name.Substring(3);
            }
            else
            {
                pictureBox.Name = "No_" + pictureBox.Name;
            }

            pictureBox.Image = Image.FromFile(FilePath.get_path_img(pictureBox.Name));

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checks(bool valor)
        {
            Game.Next(valor);
            
           if (Game.Ends())
            {
                (string,double) p = Game.Decide();
                string s = "Definitivamente elijiste a ";
                if (p.Item2 != 100)
                    s = "Me arriesgo a decir que eligiste a ";
                string path = FilePath.get_path_img(p.Item1);
                Form2 resultado = new Form2(this, path, s + p.Item1, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200))))));
                resultado.Show();
                this.Hide();
            }
            else
            {
                this.txtPregunta.Text = Game.Query();
                this.comboBox1.Enabled = true;
                this.button7.Enabled = true;
                this.button8.Enabled = true;
                this.pictureBox2.Visible = true;
                this.pictureBoxSi.Visible = false;
                this.pictureBoxNo.Visible = false;
                this.btnNo.Enabled = false;
                this.button1.Enabled = false; 
                this.txtPregunta.Enabled = false;
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.checks(true);

        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.checks(false);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void barra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            string resultado = Game.OddsRequest();
            this.mostrarConsulta(resultado);

        }

        private void btn_consulta2_Click(object sender, EventArgs e)
        {
            string resultado = Game.PathsRequest();
            this.mostrarConsulta(resultado);
        }

        private void btn_consulta3_Click(object sender, EventArgs e)
        {
            string resultado = Game.LevelsRequest();
            this.mostrarConsulta(resultado);
        }

        private void mostrarConsulta(string resultado)
        {
            Consultas consulta = new Consultas(this, resultado);
            consulta.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = false;
            this.button7.Enabled = false;
            this.button8.Enabled = false;
            this.btnNo.Enabled = true;
            this.button1.Enabled = true;
            this.txtPregunta.Enabled = true;

            string reply = Game.Ask(this.comboBox1.SelectedIndex);
            this.pictureBoxSi.Visible = false;
            this.pictureBoxNo.Visible = false;
            this.pictureBox2.Visible = false;
            if (reply.Equals("si"))
            {
                this.pictureBoxSi.Visible = true;
            }
            else
            {
                this.pictureBoxNo.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormUser fmrusr = new FormUser(this, false);
            fmrusr.Show();
            this.Hide();
        }

        private void txtPregunta_TextChanged(object sender, EventArgs e)
        {

        }

        private void caras_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}