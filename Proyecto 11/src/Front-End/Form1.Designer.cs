using tpf;

namespace WiW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.barra = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.PictureBox();
            this.controles = new System.Windows.Forms.Panel();
            this.pictureBoxNo = new System.Windows.Forms.PictureBox();
            this.pictureBoxSi = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_consulta3 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_consulta2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_consulta1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.caras = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox_sel = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            this.controles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.caras.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sel)).BeginInit();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.barra.Controls.Add(this.btnclose);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(1499, 54);
            this.barra.TabIndex = 0;
            this.barra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_MouseDown);
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(1458, 9);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(32, 38);
            this.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnclose.TabIndex = 0;
            this.btnclose.TabStop = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // controles
            // 
            this.controles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.controles.Controls.Add(this.pictureBoxNo);
            this.controles.Controls.Add(this.pictureBoxSi);
            this.controles.Controls.Add(this.panel6);
            this.controles.Controls.Add(this.btn_consulta3);
            this.controles.Controls.Add(this.panel5);
            this.controles.Controls.Add(this.btn_consulta2);
            this.controles.Controls.Add(this.panel3);
            this.controles.Controls.Add(this.btn_consulta1);
            this.controles.Controls.Add(this.panel1);
            this.controles.Controls.Add(this.button2);
            this.controles.Controls.Add(this.pictureBox2);
            this.controles.Controls.Add(this.txtPregunta);
            this.controles.Controls.Add(this.panel4);
            this.controles.Controls.Add(this.btnNo);
            this.controles.Controls.Add(this.panel2);
            this.controles.Controls.Add(this.button1);
            this.controles.Dock = System.Windows.Forms.DockStyle.Left;
            this.controles.Location = new System.Drawing.Point(0, 54);
            this.controles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controles.Name = "controles";
            this.controles.Size = new System.Drawing.Size(355, 946);
            this.controles.TabIndex = 4;
            // 
            // pictureBoxNo
            // 
            this.pictureBoxNo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNo.Image")));
            this.pictureBoxNo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxNo.InitialImage")));
            this.pictureBoxNo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxNo.Name = "pictureBoxNo";
            this.pictureBoxNo.Size = new System.Drawing.Size(355, 212);
            this.pictureBoxNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNo.TabIndex = 21;
            this.pictureBoxNo.TabStop = false;
            this.pictureBoxNo.Visible = false;
            // 
            // pictureBoxSi
            // 
            this.pictureBoxSi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSi.Image")));
            this.pictureBoxSi.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSi.InitialImage")));
            this.pictureBoxSi.Location = new System.Drawing.Point(4, 0);
            this.pictureBoxSi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxSi.Name = "pictureBoxSi";
            this.pictureBoxSi.Size = new System.Drawing.Size(355, 212);
            this.pictureBoxSi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSi.TabIndex = 20;
            this.pictureBoxSi.TabStop = false;
            this.pictureBoxSi.Visible = false;
            this.pictureBoxSi.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel6.Location = new System.Drawing.Point(71, 850);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(13, 46);
            this.panel6.TabIndex = 19;
            // 
            // btn_consulta3
            // 
            this.btn_consulta3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_consulta3.FlatAppearance.BorderSize = 0;
            this.btn_consulta3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_consulta3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consulta3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_consulta3.ForeColor = System.Drawing.Color.White;
            this.btn_consulta3.Image = ((System.Drawing.Image)(resources.GetObject("btn_consulta3.Image")));
            this.btn_consulta3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consulta3.Location = new System.Drawing.Point(76, 850);
            this.btn_consulta3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_consulta3.Name = "btn_consulta3";
            this.btn_consulta3.Size = new System.Drawing.Size(253, 46);
            this.btn_consulta3.TabIndex = 18;
            this.btn_consulta3.Text = "Profundidad";
            this.btn_consulta3.UseVisualStyleBackColor = false;
            this.btn_consulta3.Click += new System.EventHandler(this.btn_consulta3_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel5.Location = new System.Drawing.Point(71, 787);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(13, 46);
            this.panel5.TabIndex = 17;
            // 
            // btn_consulta2
            // 
            this.btn_consulta2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_consulta2.FlatAppearance.BorderSize = 0;
            this.btn_consulta2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_consulta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consulta2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_consulta2.ForeColor = System.Drawing.Color.White;
            this.btn_consulta2.Image = ((System.Drawing.Image)(resources.GetObject("btn_consulta2.Image")));
            this.btn_consulta2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consulta2.Location = new System.Drawing.Point(76, 787);
            this.btn_consulta2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_consulta2.Name = "btn_consulta2";
            this.btn_consulta2.Size = new System.Drawing.Size(253, 46);
            this.btn_consulta2.TabIndex = 16;
            this.btn_consulta2.Text = "Camino";
            this.btn_consulta2.UseVisualStyleBackColor = false;
            this.btn_consulta2.Click += new System.EventHandler(this.btn_consulta2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel3.Location = new System.Drawing.Point(71, 720);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 46);
            this.panel3.TabIndex = 15;
            // 
            // btn_consulta1
            // 
            this.btn_consulta1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btn_consulta1.FlatAppearance.BorderSize = 0;
            this.btn_consulta1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btn_consulta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consulta1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_consulta1.ForeColor = System.Drawing.Color.White;
            this.btn_consulta1.Image = ((System.Drawing.Image)(resources.GetObject("btn_consulta1.Image")));
            this.btn_consulta1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consulta1.Location = new System.Drawing.Point(76, 720);
            this.btn_consulta1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_consulta1.Name = "btn_consulta1";
            this.btn_consulta1.Size = new System.Drawing.Size(253, 46);
            this.btn_consulta1.TabIndex = 14;
            this.btn_consulta1.Text = "Predicciones";
            this.btn_consulta1.UseVisualStyleBackColor = false;
            this.btn_consulta1.Click += new System.EventHandler(this.btn_consulta1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(22, 643);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 46);
            this.panel1.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(28, 643);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 46);
            this.button2.TabIndex = 12;
            this.button2.Text = "Consultas";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(355, 212);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // txtPregunta
            // 
            this.txtPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.txtPregunta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPregunta.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPregunta.ForeColor = System.Drawing.Color.White;
            this.txtPregunta.Location = new System.Drawing.Point(16, 287);
            this.txtPregunta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.ReadOnly = true;
            this.txtPregunta.Size = new System.Drawing.Size(339, 36);
            this.txtPregunta.TabIndex = 10;
            this.txtPregunta.Text = "Pregunta";
            this.txtPregunta.TextChanged += new System.EventHandler(this.txtPregunta_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel4.Location = new System.Drawing.Point(22, 450);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(13, 46);
            this.panel4.TabIndex = 8;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Location = new System.Drawing.Point(28, 450);
            this.btnNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(253, 46);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Location = new System.Drawing.Point(22, 360);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 46);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(28, 360);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Si";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // caras
            // 
            this.caras.AutoScroll = true;
            this.caras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.caras.Controls.Add(this.panel7);
            this.caras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caras.Location = new System.Drawing.Point(355, 54);
            this.caras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.caras.Name = "caras";
            this.caras.Size = new System.Drawing.Size(1144, 946);
            this.caras.TabIndex = 7;
            this.caras.Paint += new System.Windows.Forms.PaintEventHandler(this.caras_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel7.Controls.Add(this.comboBox1);
            this.panel7.Controls.Add(this.pictureBox_sel);
            this.panel7.Controls.Add(this.panel12);
            this.panel7.Controls.Add(this.button7);
            this.panel7.Controls.Add(this.panel13);
            this.panel7.Controls.Add(this.button8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(789, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(355, 946);
            this.panel7.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 278);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(332, 45);
            this.comboBox1.TabIndex = 13;
            // 
            // pictureBox_sel
            // 
            this.pictureBox_sel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_sel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_sel.Image")));
            this.pictureBox_sel.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_sel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_sel.Name = "pictureBox_sel";
            this.pictureBox_sel.Size = new System.Drawing.Size(355, 212);
            this.pictureBox_sel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_sel.TabIndex = 11;
            this.pictureBox_sel.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel12.Location = new System.Drawing.Point(248, 360);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(13, 46);
            this.panel12.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.Location = new System.Drawing.Point(0, 360);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(253, 46);
            this.button7.TabIndex = 9;
            this.button7.Text = "Preguntar";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel13.Location = new System.Drawing.Point(252, 450);
            this.panel13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(13, 46);
            this.panel13.TabIndex = 7;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.Location = new System.Drawing.Point(4, 450);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(253, 46);
            this.button8.TabIndex = 6;
            this.button8.Text = "Arriesgar";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 1000);
            this.Controls.Add(this.caras);
            this.Controls.Add(this.controles);
            this.Controls.Add(this.barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¿Quien es?";
            this.barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            this.controles.ResumeLayout(false);
            this.controles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.caras.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel barra;
        private PictureBox btnclose;
        private Panel controles;
        public PictureBox pictureBox2;
        private TextBox txtPregunta;
        private Panel panel4;
        private Button btnNo;
        private Panel panel2;
        private Button button1;
        private Panel caras;
        private Panel panel1;
        private Button button2;
        private Panel panel3;
        private Button btn_consulta1;
        private Panel panel6;
        private Button btn_consulta3;
        private Panel panel5;
        private Button btn_consulta2;
        public PictureBox pictureBoxSi;
        public PictureBox pictureBoxNo;
        private Panel panel7;
        public PictureBox pictureBox_sel;
        private Panel panel12;
        private Button button7;
        private Panel panel13;
        private Button button8;
        private ComboBox comboBox1;
    }
}