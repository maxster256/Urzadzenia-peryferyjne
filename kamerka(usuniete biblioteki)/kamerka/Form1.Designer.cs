namespace kamerka
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.contrastBar = new System.Windows.Forms.TrackBar();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.saturationBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "uruchom wskazana kamere";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.turnOnCamera);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "uchwyc zdjecie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.takePhoto);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 363);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "rozpocznij nagrywanie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.startRecording);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(186, 363);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 49);
            this.button4.TabIndex = 3;
            this.button4.Text = "zakoncz nagrywanie";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.stopRecording);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(356, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1080, 608);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(64, 133);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 82);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wybierz jedna z dostepnych kamer";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(186, 231);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "wylacz kamere";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.turnOffCamera);
            // 
            // contrastBar
            // 
            this.contrastBar.Location = new System.Drawing.Point(16, 442);
            this.contrastBar.Maximum = 100;
            this.contrastBar.Name = "contrastBar";
            this.contrastBar.Size = new System.Drawing.Size(320, 45);
            this.contrastBar.TabIndex = 8;
            this.contrastBar.Value = 50;
            this.contrastBar.Scroll += new System.EventHandler(this.contrastScrollBar);
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(16, 522);
            this.brightnessBar.Maximum = 100;
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(320, 45);
            this.brightnessBar.TabIndex = 9;
            this.brightnessBar.Value = 50;
            this.brightnessBar.Scroll += new System.EventHandler(this.brightnessScrollBar);
            // 
            // saturationBar
            // 
            this.saturationBar.Location = new System.Drawing.Point(16, 606);
            this.saturationBar.Maximum = 100;
            this.saturationBar.Name = "saturationBar";
            this.saturationBar.Size = new System.Drawing.Size(320, 45);
            this.saturationBar.TabIndex = 10;
            this.saturationBar.Value = 50;
            this.saturationBar.Scroll += new System.EventHandler(this.saturationScrollBar);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "nasycenie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "jasność";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "kontrast";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 719);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saturationBar);
            this.Controls.Add(this.brightnessBar);
            this.Controls.Add(this.contrastBar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar contrastBar;
        private System.Windows.Forms.TrackBar brightnessBar;
        private System.Windows.Forms.TrackBar saturationBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

