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

namespace WiW
{
    public partial class Output : Dragable
    {
        public Output(Board form1, string datos)
        {
            InitializeComponent();
            this.Parent = form1;
            this.txt.Text = datos;
        }

        private void BtnClose(object sender, EventArgs e)
        {
            Close();
            Parent.Show();
        }
    }
}

