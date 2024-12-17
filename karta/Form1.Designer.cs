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
            label4 = new Label();
            cmbInputDevices = new ComboBox();
            btnStop = new Button();
            SuspendLayout();
            // 
            // btnPlaySound
            // 
            btnPlaySound.Location = new Point(16, 49);
            btnPlaySound.Name = "btnPlaySound";
            btnPlaySound.Size = new Size(99, 25);
            btnPlaySound.TabIndex = 0;
            btnPlaySound.Text = "PlaySound";
            btnPlaySound.UseVisualStyleBackColor = true;
            btnPlaySound.Click += btnPlaySound_Click;
            // 
            // btnActiveX
            // 
            btnActiveX.Location = new Point(16, 80);
            btnActiveX.Name = "btnActiveX";
            btnActiveX.Size = new Size(99, 25);
            btnActiveX.TabIndex = 1;
            btnActiveX.Text = "ActiveX";
            btnActiveX.UseVisualStyleBackColor = true;
            btnActiveX.Click += btnActiveX_Click;
            // 
            // btnWaveOut
            // 
            btnWaveOut.Location = new Point(16, 111);
            btnWaveOut.Name = "btnWaveOut";
            btnWaveOut.Size = new Size(99, 25);
            btnWaveOut.TabIndex = 2;
            btnWaveOut.Text = "WaveOut";
            btnWaveOut.UseVisualStyleBackColor = true;
            btnWaveOut.Click += btnWaveOut_Click;
            // 
            // btnDirectSound
            // 
            btnDirectSound.Location = new Point(16, 142);
            btnDirectSound.Name = "btnDirectSound";
            btnDirectSound.Size = new Size(99, 25);
            btnDirectSound.TabIndex = 3;
            btnDirectSound.Text = "DirectSound";
            btnDirectSound.UseVisualStyleBackColor = true;
            btnDirectSound.Click += btnDirectSound_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 22);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Odtwarzanie";
            label1.Click += label1_Click;
            // 
            // btnReadWavHeader
            // 
            btnReadWavHeader.Location = new Point(16, 243);
            btnReadWavHeader.Name = "btnReadWavHeader";
            btnReadWavHeader.RightToLeft = RightToLeft.No;
            btnReadWavHeader.Size = new Size(99, 25);
            btnReadWavHeader.TabIndex = 5;
            btnReadWavHeader.Text = "WAV";
            btnReadWavHeader.UseVisualStyleBackColor = true;
            btnReadWavHeader.Click += btnReadWavHeader_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 225);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 6;
            label2.Text = "Wyświetlanie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 290);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 7;
            label3.Text = "Nagrywanie";
            // 
            // btnStartRecording
            // 
            btnStartRecording.Location = new Point(16, 337);
            btnStartRecording.Name = "btnStartRecording";
            btnStartRecording.RightToLeft = RightToLeft.No;
            btnStartRecording.Size = new Size(99, 25);
            btnStartRecording.TabIndex = 8;
            btnStartRecording.Text = "Start";
            btnStartRecording.UseVisualStyleBackColor = true;
            btnStartRecording.Click += btnStartRecording_Click;
            // 
            // btnStopRecording
            // 
            btnStopRecording.Location = new Point(16, 368);
            btnStopRecording.Name = "btnStopRecording";
            btnStopRecording.RightToLeft = RightToLeft.No;
            btnStopRecording.Size = new Size(99, 25);
            btnStopRecording.TabIndex = 9;
            btnStopRecording.Text = "Stop";
            btnStopRecording.UseVisualStyleBackColor = true;
            btnStopRecording.Click += btnStopRecording_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(132, 15);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(126, 28);
            btnChooseFile.TabIndex = 10;
            btnChooseFile.Text = "Wybierz plik audio";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // txtWavHeader
            // 
            txtWavHeader.Location = new Point(157, 147);
            txtWavHeader.Multiline = true;
            txtWavHeader.Name = "txtWavHeader";
            txtWavHeader.ReadOnly = true;
            txtWavHeader.ScrollBars = ScrollBars.Vertical;
            txtWavHeader.Size = new Size(187, 246);
            txtWavHeader.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 127);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 12;
            label4.Text = "Nagłówek WAV";
            // 
            // cmbInputDevices
            // 
            cmbInputDevices.FormattingEnabled = true;
            cmbInputDevices.Location = new Point(16, 308);
            cmbInputDevices.Name = "cmbInputDevices";
            cmbInputDevices.Size = new Size(121, 23);
            cmbInputDevices.TabIndex = 13;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(16, 173);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(99, 25);
            btnStop.TabIndex = 14;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(cmbInputDevices);
            Controls.Add(label4);
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
            Name = "Form1";
            Text = "Form1";
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
        private Label label4;
        private ComboBox cmbInputDevices;
        private Button btnStop;
    }
}
