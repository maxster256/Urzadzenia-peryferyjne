namespace skanerAplikacja
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.polacz = new System.Windows.Forms.Button();
            this.skanuj = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.right90 = new System.Windows.Forms.Button();
            this.left90 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelx = new System.Windows.Forms.Label();
            this.labely = new System.Windows.Forms.Label();
            this.labelwidth = new System.Windows.Forms.Label();
            this.labelheight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // polacz
            // 
            this.polacz.Location = new System.Drawing.Point(25, 36);
            this.polacz.Name = "polacz";
            this.polacz.Size = new System.Drawing.Size(125, 40);
            this.polacz.TabIndex = 0;
            this.polacz.Text = "Polacz";
            this.polacz.UseVisualStyleBackColor = true;
            this.polacz.Click += new System.EventHandler(this.polacz_Click);
            // 
            // skanuj
            // 
            this.skanuj.Location = new System.Drawing.Point(25, 88);
            this.skanuj.Name = "skanuj";
            this.skanuj.Size = new System.Drawing.Size(125, 37);
            this.skanuj.TabIndex = 1;
            this.skanuj.Text = "Skan";
            this.skanuj.UseVisualStyleBackColor = true;
            this.skanuj.Click += new System.EventHandler(this.skanuj_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 446);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "JPEG";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // right90
            // 
            this.right90.Location = new System.Drawing.Point(25, 446);
            this.right90.Name = "right90";
            this.right90.Size = new System.Drawing.Size(125, 48);
            this.right90.TabIndex = 3;
            this.right90.Text = "Obrot o 90 w prawo";
            this.right90.UseVisualStyleBackColor = true;
            this.right90.Click += new System.EventHandler(this.right90_Click);
            // 
            // left90
            // 
            this.left90.Location = new System.Drawing.Point(25, 517);
            this.left90.Name = "left90";
            this.left90.Size = new System.Drawing.Size(125, 46);
            this.left90.TabIndex = 4;
            this.left90.Text = "Obrot o 90 w lewo";
            this.left90.UseVisualStyleBackColor = true;
            this.left90.Click += new System.EventHandler(this.left90_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tryb skanowania:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(322, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 545);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(172, 328);
            this.trackBar1.Maximum = 12;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(121, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "DPI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 12;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 287);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Kolorowy";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 315);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Skala Szarosci";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(25, 342);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(76, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Czern i biel";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(172, 60);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(123, 20);
            this.textBoxX.TabIndex = 16;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(172, 116);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(121, 20);
            this.textBoxY.TabIndex = 17;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(172, 166);
            this.textBoxWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(121, 20);
            this.textBoxWidth.TabIndex = 18;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(172, 210);
            this.textBoxHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(121, 20);
            this.textBoxHeight.TabIndex = 19;
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(179, 38);
            this.labelx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(12, 13);
            this.labelx.TabIndex = 20;
            this.labelx.Text = "x";
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(177, 99);
            this.labely.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(12, 13);
            this.labely.TabIndex = 21;
            this.labely.Text = "y";
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(177, 151);
            this.labelwidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(104, 13);
            this.labelwidth.TabIndex = 22;
            this.labelwidth.Text = "szerokosc (max 396)";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(177, 193);
            this.labelheight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(103, 13);
            this.labelheight.TabIndex = 23;
            this.labelheight.Text = "wysokosc (max 546)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 627);
            this.Controls.Add(this.labelheight);
            this.Controls.Add(this.labelwidth);
            this.Controls.Add(this.labely);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.left90);
            this.Controls.Add(this.right90);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.skanuj);
            this.Controls.Add(this.polacz);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button polacz;
        private System.Windows.Forms.Button skanuj;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button right90;
        private System.Windows.Forms.Button left90;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.Label labely;
        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Label labelheight;
    }
}

