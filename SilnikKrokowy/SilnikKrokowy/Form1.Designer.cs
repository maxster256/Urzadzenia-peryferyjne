namespace SilnikKrokowy
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
            driveWave = new Button();
            driveHalfstep = new Button();
            driveFullstep = new Button();
            rotateLeft = new Button();
            rotateRight = new Button();
            numberSteps = new TextBox();
            timeSteps = new TextBox();
            labelTime = new Label();
            labelSteps = new Label();
            lebelMode = new Label();
            labelModeText = new Label();
            comboBoxDevices = new ComboBox();
            EPROM = new Button();
            textEPROM = new TextBox();
            buttonName = new Button();
            textBoxName = new TextBox();
            SuspendLayout();
            // 
            // driveWave
            // 
            driveWave.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            driveWave.Location = new Point(53, 89);
            driveWave.Name = "driveWave";
            driveWave.Size = new Size(265, 29);
            driveWave.TabIndex = 0;
            driveWave.Text = "Sterowanie Falowe";
            driveWave.UseVisualStyleBackColor = true;
            driveWave.Click += driveWave_Click;
            // 
            // driveHalfstep
            // 
            driveHalfstep.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            driveHalfstep.Location = new Point(53, 141);
            driveHalfstep.Name = "driveHalfstep";
            driveHalfstep.Size = new Size(265, 29);
            driveHalfstep.TabIndex = 1;
            driveHalfstep.Text = "Sterowanie Półkrokowe";
            driveHalfstep.UseVisualStyleBackColor = true;
            driveHalfstep.Click += driveHalfstep_Click;
            // 
            // driveFullstep
            // 
            driveFullstep.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            driveFullstep.Location = new Point(53, 194);
            driveFullstep.Name = "driveFullstep";
            driveFullstep.Size = new Size(265, 29);
            driveFullstep.TabIndex = 2;
            driveFullstep.Text = "Sterowanie Krokowe";
            driveFullstep.UseVisualStyleBackColor = true;
            driveFullstep.Click += driveFullstep_Click;
            // 
            // rotateLeft
            // 
            rotateLeft.Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            rotateLeft.Location = new Point(423, 89);
            rotateLeft.Name = "rotateLeft";
            rotateLeft.Size = new Size(137, 134);
            rotateLeft.TabIndex = 5;
            rotateLeft.Text = "Lewo";
            rotateLeft.Click += rotateLeft_Click;
            // 
            // rotateRight
            // 
            rotateRight.Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            rotateRight.Location = new Point(588, 89);
            rotateRight.Name = "rotateRight";
            rotateRight.Size = new Size(139, 134);
            rotateRight.TabIndex = 4;
            rotateRight.Text = "Prawo";
            rotateRight.UseVisualStyleBackColor = true;
            rotateRight.Click += rotateRight_Click;
            // 
            // numberSteps
            // 
            numberSteps.Location = new Point(524, 246);
            numberSteps.Name = "numberSteps";
            numberSteps.Size = new Size(36, 27);
            numberSteps.TabIndex = 0;
            numberSteps.Text = "5";
            numberSteps.TextAlign = HorizontalAlignment.Center;
            // 
            // timeSteps
            // 
            timeSteps.Location = new Point(693, 246);
            timeSteps.Name = "timeSteps";
            timeSteps.Size = new Size(34, 27);
            timeSteps.TabIndex = 6;
            timeSteps.Text = "400";
            timeSteps.TextAlign = HorizontalAlignment.Center;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelTime.Location = new Point(562, 253);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(125, 20);
            labelTime.TabIndex = 7;
            labelTime.Text = "Czas kroku [ms]:";
            // 
            // labelSteps
            // 
            labelSteps.AutoSize = true;
            labelSteps.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelSteps.Location = new Point(407, 253);
            labelSteps.Name = "labelSteps";
            labelSteps.Size = new Size(111, 20);
            labelSteps.TabIndex = 8;
            labelSteps.Text = "Liczba kroków:";
            // 
            // lebelMode
            // 
            lebelMode.AutoSize = true;
            lebelMode.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lebelMode.Location = new Point(62, 37);
            lebelMode.Name = "lebelMode";
            lebelMode.Size = new Size(41, 20);
            lebelMode.TabIndex = 9;
            lebelMode.Text = "Tryb:";
            // 
            // labelModeText
            // 
            labelModeText.AutoSize = true;
            labelModeText.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelModeText.Location = new Point(109, 37);
            labelModeText.Name = "labelModeText";
            labelModeText.Size = new Size(137, 20);
            labelModeText.TabIndex = 10;
            labelModeText.Text = "Sterowanie Falowe";
            // 
            // comboBoxDevices
            // 
            comboBoxDevices.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBoxDevices.FormattingEnabled = true;
            comboBoxDevices.Location = new Point(423, 34);
            comboBoxDevices.Name = "comboBoxDevices";
            comboBoxDevices.Size = new Size(304, 28);
            comboBoxDevices.TabIndex = 11;
            comboBoxDevices.SelectedIndexChanged += comboBoxDevices_SelectedIndexChanged;
            // 
            // EPROM
            // 
            EPROM.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            EPROM.Location = new Point(53, 249);
            EPROM.Name = "EPROM";
            EPROM.Size = new Size(265, 29);
            EPROM.TabIndex = 12;
            EPROM.Text = "Pamięć EPROM";
            EPROM.UseVisualStyleBackColor = true;
            EPROM.Click += EPROM_Click;
            // 
            // textEPROM
            // 
            textEPROM.Location = new Point(53, 317);
            textEPROM.Multiline = true;
            textEPROM.Name = "textEPROM";
            textEPROM.Size = new Size(342, 150);
            textEPROM.TabIndex = 13;
            // 
            // buttonName
            // 
            buttonName.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonName.Location = new Point(442, 317);
            buttonName.Name = "buttonName";
            buttonName.Size = new Size(265, 29);
            buttonName.TabIndex = 14;
            buttonName.Text = "Zmień nazwę";
            buttonName.UseVisualStyleBackColor = true;
            buttonName.Click += buttonName_Click;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxName.Location = new Point(442, 373);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(263, 32);
            textBoxName.TabIndex = 15;
            textBoxName.Text = "usb step motor";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 504);
            Controls.Add(textBoxName);
            Controls.Add(buttonName);
            Controls.Add(textEPROM);
            Controls.Add(EPROM);
            Controls.Add(comboBoxDevices);
            Controls.Add(labelModeText);
            Controls.Add(lebelMode);
            Controls.Add(labelSteps);
            Controls.Add(labelTime);
            Controls.Add(timeSteps);
            Controls.Add(numberSteps);
            Controls.Add(rotateRight);
            Controls.Add(rotateLeft);
            Controls.Add(driveFullstep);
            Controls.Add(driveHalfstep);
            Controls.Add(driveWave);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button driveWave;
        private Button driveHalfstep;
        private Button driveFullstep;
        private Button rotateLeft;
        private Button rotateRight;
        private TextBox numberSteps;
        private TextBox timeSteps;
        private Label labelTime;
        private Label labelSteps;
        private Label lebelMode;
        private Label labelModeText;
        private ComboBox comboBoxDevices;
        private Button EPROM;
        private TextBox textEPROM;
        private Button buttonName;
        private TextBox textBoxName;
    }
}
