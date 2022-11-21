using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using tpf;
using System.IO;

namespace WiW
{
    public partial class GameOver : Dragable
    {
        private Backend Game;

        public GameOver(Image predictedFace, string titulo, Color backColor)
        {
            InitializeComponent();
            Image file = predictedFace;
            pictureBox1.Image = file;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            label1.Text = titulo;
            label1.ForeColor = backColor;
            caras.BackColor= backColor;    
            barra.BackColor= backColor;
        }

        private void BtnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewGame(object sender, EventArgs e)
        {
            Close();
            Program.NewGame();
        }

    }
}
