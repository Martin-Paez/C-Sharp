namespace WiW
{
    partial class GameOver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOver));
            this.barra = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.PictureBox();
            this.caras = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inicio = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.salir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            this.caras.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.barra.Controls.Add(this.btnclose);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Margin = new System.Windows.Forms.Padding(5);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(472, 59);
            this.barra.TabIndex = 0;
            this.barra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag);
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(417, 10);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(39, 41);
            this.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnclose.TabIndex = 0;
            this.btnclose.TabStop = false;
            this.btnclose.Click += new System.EventHandler(this.BtnClose);
            // 
            // caras
            // 
            this.caras.AutoScroll = true;
            this.caras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.caras.Controls.Add(this.panel3);
            this.caras.Controls.Add(this.panel2);
            this.caras.Controls.Add(this.pictureBox1);
            this.caras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caras.Location = new System.Drawing.Point(0, 0);
            this.caras.Margin = new System.Windows.Forms.Padding(5);
            this.caras.Name = "caras";
            this.caras.Size = new System.Drawing.Size(472, 800);
            this.caras.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 145);
            this.panel3.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Eligio a ...";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.inicio);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.salir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 590);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 210);
            this.panel2.TabIndex = 14;
            // 
            // inicio
            // 
            this.inicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.inicio.FlatAppearance.BorderSize = 0;
            this.inicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.inicio.ForeColor = System.Drawing.Color.White;
            this.inicio.Image = ((System.Drawing.Image)(resources.GetObject("inicio.Image")));
            this.inicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inicio.Location = new System.Drawing.Point(161, 37);
            this.inicio.Margin = new System.Windows.Forms.Padding(5);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(309, 50);
            this.inicio.TabIndex = 11;
            this.inicio.Text = "Inicio";
            this.inicio.UseVisualStyleBackColor = false;
            this.inicio.Click += new System.EventHandler(this.NewGame);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel12.Location = new System.Drawing.Point(147, 37);
            this.panel12.Margin = new System.Windows.Forms.Padding(5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(16, 50);
            this.panel12.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(143, 128);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 50);
            this.panel1.TabIndex = 12;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.salir.FlatAppearance.BorderSize = 0;
            this.salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.salir.ForeColor = System.Drawing.Color.White;
            this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
            this.salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salir.Location = new System.Drawing.Point(159, 128);
            this.salir.Margin = new System.Windows.Forms.Padding(5);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(309, 50);
            this.salir.TabIndex = 13;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.BtnClose);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(100, 184);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 340);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 800);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.caras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "GameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado";
            this.barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            this.caras.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Panel barra;
        private Panel caras;
        private PictureBox btnclose;
        private PictureBox pictureBox1;
        private Board Parent;
        private Panel panel12;
        private Button inicio;
        private Panel panel1;
        private Button salir;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
    }
}