namespace karta
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
            btnPlaySound = new Button();
            btnActiveX = new Button();
            btnWaveOut = new Button();
            btnDirectSound = new Button();
            label1 = new Label();
            btnReadWavHeader = new Button();
            label2 = new Label();
            label3 = new Label();
            btnStartRecording = new Button();
            btnStopRecording = new Button();
            btnChooseFile = new Button();
            txtWavHeader = new TextBox();
            cmbInputDevices = new ComboBox();
            btnStop = new Button();
            btnReadMp3Header = new Button();
            SuspendLayout();
            // 
            // btnPlaySound
            // 
            btnPlaySound.Location = new Point(18, 65);
            btnPlaySound.Margin = new Padding(3, 4, 3, 4);
            btnPlaySound.Name = "btnPlaySound";
            btnPlaySound.Size = new Size(113, 33);
            btnPlaySound.TabIndex = 0;
            btnPlaySound.Text = "PlaySound";
            btnPlaySound.UseVisualStyleBackColor = true;
            btnPlaySound.Click += btnPlaySound_Click;
            // 
            // btnActiveX
            // 
            btnActiveX.Location = new Point(137, 65);
            btnActiveX.Margin = new Padding(3, 4, 3, 4);
            btnActiveX.Name = "btnActiveX";
            btnActiveX.Size = new Size(113, 33);
            btnActiveX.TabIndex = 1;
            btnActiveX.Text = "ActiveX";
            btnActiveX.UseVisualStyleBackColor = true;
            btnActiveX.Click += btnActiveX_Click;
            // 
            // btnWaveOut
            // 
            btnWaveOut.Location = new Point(256, 65);
            btnWaveOut.Margin = new Padding(3, 4, 3, 4);
            btnWaveOut.Name = "btnWaveOut";
            btnWaveOut.Size = new Size(113, 33);
            btnWaveOut.TabIndex = 2;
            btnWaveOut.Text = "WaveOut";
            btnWaveOut.UseVisualStyleBackColor = true;
            btnWaveOut.Click += btnWaveOut_Click;
            // 
            // btnDirectSound
            // 
            btnDirectSound.Location = new Point(375, 65);
            btnDirectSound.Margin = new Padding(3, 4, 3, 4);
            btnDirectSound.Name = "btnDirectSound";
            btnDirectSound.Size = new Size(113, 33);
            btnDirectSound.TabIndex = 3;
            btnDirectSound.Text = "DirectSound";
            btnDirectSound.UseVisualStyleBackColor = true;
            btnDirectSound.Click += btnDirectSound_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 29);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 4;
            label1.Text = "Odtwarzanie";
            label1.Click += label1_Click;
            // 
            // btnReadWavHeader
            // 
            btnReadWavHeader.Location = new Point(18, 262);
            btnReadWavHeader.Margin = new Padding(3, 4, 3, 4);
            btnReadWavHeader.Name = "btnReadWavHeader";
            btnReadWavHeader.RightToLeft = RightToLeft.No;
            btnReadWavHeader.Size = new Size(204, 33);
            btnReadWavHeader.TabIndex = 5;
            btnReadWavHeader.Text = "Nagłówek Wav";
            btnReadWavHeader.UseVisualStyleBackColor = true;
            btnReadWavHeader.Click += btnReadWavHeader_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 238);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 6;
            label2.Text = "Wyświetlanie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 127);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 7;
            label3.Text = "Nagrywanie";
            // 
            // btnStartRecording
            // 
            btnStartRecording.Location = new Point(168, 151);
            btnStartRecording.Margin = new Padding(3, 4, 3, 4);
            btnStartRecording.Name = "btnStartRecording";
            btnStartRecording.RightToLeft = RightToLeft.No;
            btnStartRecording.Size = new Size(113, 33);
            btnStartRecording.TabIndex = 8;
            btnStartRecording.Text = "Start";
            btnStartRecording.UseVisualStyleBackColor = true;
            btnStartRecording.Click += btnStartRecording_Click;
            // 
            // btnStopRecording
            // 
            btnStopRecording.Location = new Point(168, 192);
            btnStopRecording.Margin = new Padding(3, 4, 3, 4);
            btnStopRecording.Name = "btnStopRecording";
            btnStopRecording.RightToLeft = RightToLeft.No;
            btnStopRecording.Size = new Size(113, 33);
            btnStopRecording.TabIndex = 9;
            btnStopRecording.Text = "Stop";
            btnStopRecording.UseVisualStyleBackColor = true;
            btnStopRecording.Click += btnStopRecording_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(137, 20);
            btnChooseFile.Margin = new Padding(3, 4, 3, 4);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(144, 37);
            btnChooseFile.TabIndex = 10;
            btnChooseFile.Text = "Wybierz plik audio";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // txtWavHeader
            // 
            txtWavHeader.Location = new Point(18, 316);
            txtWavHeader.Margin = new Padding(3, 4, 3, 4);
            txtWavHeader.Multiline = true;
            txtWavHeader.Name = "txtWavHeader";
            txtWavHeader.ReadOnly = true;
            txtWavHeader.ScrollBars = ScrollBars.Vertical;
            txtWavHeader.Size = new Size(414, 251);
            txtWavHeader.TabIndex = 10;
            // 
            // cmbInputDevices
            // 
            cmbInputDevices.FormattingEnabled = true;
            cmbInputDevices.Location = new Point(19, 172);
            cmbInputDevices.Margin = new Padding(3, 4, 3, 4);
            cmbInputDevices.Name = "cmbInputDevices";
            cmbInputDevices.Size = new Size(138, 28);
            cmbInputDevices.TabIndex = 13;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(494, 65);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(113, 33);
            btnStop.TabIndex = 14;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnReadMp3Header
            // 
            btnReadMp3Header.Location = new Point(228, 262);
            btnReadMp3Header.Margin = new Padding(3, 4, 3, 4);
            btnReadMp3Header.Name = "btnReadMp3Header";
            btnReadMp3Header.RightToLeft = RightToLeft.No;
            btnReadMp3Header.Size = new Size(204, 33);
            btnReadMp3Header.TabIndex = 15;
            btnReadMp3Header.Text = "Nagłówek Mp3";
            btnReadMp3Header.UseVisualStyleBackColor = true;
            btnReadMp3Header.Click += btnReadMp3Header_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnReadMp3Header);
            Controls.Add(btnStop);
            Controls.Add(cmbInputDevices);
            Controls.Add(txtWavHeader);
            Controls.Add(btnChooseFile);
            Controls.Add(btnStopRecording);
            Controls.Add(btnStartRecording);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnReadWavHeader);
            Controls.Add(label1);
            Controls.Add(btnDirectSound);
            Controls.Add(btnWaveOut);
            Controls.Add(btnActiveX);
            Controls.Add(btnPlaySound);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlaySound;
        private Button btnActiveX;
        private Button btnWaveOut;
        private Button btnDirectSound;
        private Label label1;
        private Button btnReadWavHeader;
        private Label label2;
        private Label label3;
        private Button btnStartRecording;
        private Button btnStopRecording;
        private Button btnChooseFile;
        private TextBox txtWavHeader;
        private ComboBox cmbInputDevices;
        private Button btnStop;
        private Button btnReadMp3Header;
    }
}
