using System.Runtime.InteropServices;
using System;
using AxWMPLib;
using WMPLib;
using NAudio.Wave;

namespace karta
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_FILENAME = 0x00020000;
        private const uint SND_ASYNC = 0x0001;
        private string selectedFilePath = string.Empty;

        private WaveInEvent waveIn;          
        private WaveFileWriter waveWriterOriginal;   
        private WaveFileWriter waveWriterFiltered;   
        private string outputFilePath;       

        private WaveOutEvent waveOut; 
        private AudioFileReader audioFile;

        private DirectSoundOut directSound; 
        private WindowsMediaPlayer activeXPlayer; 


        public Form1()
        {
            InitializeComponent();
            InitializeInputDevicesComboBox();
        }

        private void InitializeInputDevicesComboBox()
        {

            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                var deviceInfo = WaveInEvent.GetCapabilities(i);
                cmbInputDevices.Items.Add($"{i}: {deviceInfo.ProductName}");
            }

            if (cmbInputDevices.Items.Count > 0)
                cmbInputDevices.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Pliki audio (*.wav;*.mp3)|*.wav;*.mp3|Wszystkie pliki (*.*)|*.*";
        openFileDialog.Title = "Wybierz plik audio";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            selectedFilePath = openFileDialog.FileName;

            MessageBox.Show($"Wybrano plik: {selectedFilePath}", "Plik wybrany", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
            {
                bool result = PlaySound(selectedFilePath, IntPtr.Zero, SND_FILENAME | SND_ASYNC);
                if (!result)
                {
                    MessageBox.Show("Nie uda³o siê odtworzyæ pliku", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku lub plik nie istnieje", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActiveX_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeXPlayer != null)
                {
                    activeXPlayer.controls.stop();
                    activeXPlayer.close();
                    activeXPlayer = null;
                }

                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    activeXPlayer = new WindowsMediaPlayer(); 
                    activeXPlayer.URL = selectedFilePath;
                    activeXPlayer.controls.play();
                    MessageBox.Show("Odtwarzanie za pomoc¹ ActiveX rozpoczête.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie wybrano pliku lub plik nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWaveOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }

                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    IWaveProvider waveProvider;

                    if (Path.GetExtension(selectedFilePath).ToLower() == ".mp3")
                    {
                        waveProvider = new Mp3FileReader(selectedFilePath);
                    }
                    else
                    {
                        waveProvider = new AudioFileReader(selectedFilePath);
                    }

                    waveOut = new WaveOutEvent();
                    waveOut.Init(waveProvider);
                    waveOut.Play();

                    MessageBox.Show("Odtwarzanie za pomoc¹ WaveOut rozpoczête.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie wybrano pliku lub plik nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d odtwarzania: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDirectSound_Click(object sender, EventArgs e)
        {
            try
            {
                if (directSound != null)
                {
                    directSound.Stop();
                    directSound.Dispose();
                    directSound = null;
                }

                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    IWaveProvider waveProvider;

                    if (Path.GetExtension(selectedFilePath).ToLower() == ".mp3")
                    {
                        waveProvider = new Mp3FileReader(selectedFilePath);
                    }
                    else
                    {
                        waveProvider = new AudioFileReader(selectedFilePath); 
                    }

                    directSound = new DirectSoundOut();
                    directSound.Init(waveProvider);
                    directSound.Play();

                    MessageBox.Show("Odtwarzanie za pomoc¹ DirectSound rozpoczête.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie wybrano pliku lub plik nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d odtwarzania: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                PlaySound(null, IntPtr.Zero, SND_ASYNC);

                if (activeXPlayer != null)
                {
                    activeXPlayer.controls.stop();
                    activeXPlayer.close();
                    activeXPlayer = null;
                }

                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }

                if (directSound != null)
                {
                    directSound.Stop();
                    directSound.Dispose();
                    directSound = null;
                }

                if (audioFile != null)
                {
                    audioFile.Dispose();
                    audioFile = null;
                }

                MessageBox.Show("Odtwarzanie zosta³o zatrzymane.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d zatrzymywania dŸwiêku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadWavHeader_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        string chunkID = new string(reader.ReadChars(4));      // RIFF
                        int chunkSize = reader.ReadInt32();                   // Rozmiar pliku
                        string format = new string(reader.ReadChars(4));      // WAVE

                        string subchunk1ID = new string(reader.ReadChars(4)); // fmt
                        int subchunk1Size = reader.ReadInt32();               // Rozmiar sekcji formatu
                        short audioFormat = reader.ReadInt16();               // Format audio
                        short numChannels = reader.ReadInt16();               // Liczba kana³ów
                        int sampleRate = reader.ReadInt32();                  // Próbkowanie
                        int byteRate = reader.ReadInt32();                    // Bajty na sekundê
                        short blockAlign = reader.ReadInt16();                // Rozmiar bloku
                        short bitsPerSample = reader.ReadInt16();             // Bity na próbkê

                        txtWavHeader.Text = $"Chunk ID: {chunkID}\r\n" +
                                            $"Chunk Size: {chunkSize}\r\n" +
                                            $"Format: {format}\r\n" +
                                            $"Subchunk1 ID: {subchunk1ID}\r\n" +
                                            $"Subchunk1 Size: {subchunk1Size}\r\n" +
                                            $"Audio Format: {audioFormat}\r\n" +
                                            $"Channels: {numChannels}\r\n" +
                                            $"Sample Rate: {sampleRate}\r\n" +
                                            $"Byte Rate: {byteRate}\r\n" +
                                            $"Block Align: {blockAlign}\r\n" +
                                            $"Bits per Sample: {bitsPerSample}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B³¹d podczas odczytu nag³ówka WAV: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku lub plik nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadMp3Header_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath) && Path.GetExtension(selectedFilePath).ToLower() == ".mp3")
                {
                    using (var mp3Reader = new Mp3FileReader(selectedFilePath))
                    {
                        var mp3Header = mp3Reader.Mp3WaveFormat;
                        var duration = mp3Reader.TotalTime;

                        txtWavHeader.Text = $"MP3 Header Info:\r\n" +
                                            $"Format: {mp3Header.Encoding}\r\n" +
                                            $"Channels: {mp3Header.Channels}\r\n" +
                                            $"Sample Rate: {mp3Header.SampleRate} Hz\r\n" +
                                            $"Bit Rate: {mp3Header.AverageBytesPerSecond * 8 / 1000} kbps\r\n" +
                                            $"Duration: {duration}";
                    }
                }
                else
                {
                    MessageBox.Show("Plik MP3 nie zosta³ wybrany lub nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d odczytu nag³ówka MP3: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                string originalFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "recorded_original.wav");
                string filteredFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "recorded_with_pitch_filter.wav");

                waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(44100, 1);

                waveIn.DataAvailable += (s, a) =>
                {
                    waveWriterOriginal.Write(a.Buffer, 0, a.BytesRecorded);

                    byte[] processedBuffer = ApplyLowerPitch(a.Buffer, a.BytesRecorded, waveIn.WaveFormat);
                    waveWriterFiltered.Write(processedBuffer, 0, processedBuffer.Length);
                };

                waveIn.RecordingStopped += (s, a) =>
                {
                    waveWriterOriginal?.Dispose();
                    waveWriterFiltered?.Dispose();
                    waveIn.Dispose();
                    MessageBox.Show($"Nagrywanie zakoñczone. Pliki zapisano:\n{originalFilePath}\n{filteredFilePath}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                waveWriterOriginal = new WaveFileWriter(originalFilePath, waveIn.WaveFormat);
                waveWriterFiltered = new WaveFileWriter(filteredFilePath, waveIn.WaveFormat);

                waveIn.StartRecording();
                MessageBox.Show("Rozpoczêto nagrywanie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d: {ex.Message}", "B³¹d nagrywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ApplyLowerPitch(byte[] buffer, int bytesRecorded, WaveFormat format)
        {
            WaveBuffer waveBuffer = new WaveBuffer(buffer);
            int samples = bytesRecorded / 2;
            List<short> filteredSamples = new List<short>();

            for (int i = 0; i < samples; i += 2)
            {
                filteredSamples.Add(waveBuffer.ShortBuffer[i]);
            }

            byte[] processedBuffer = new byte[filteredSamples.Count * 2];
            Buffer.BlockCopy(filteredSamples.ToArray(), 0, processedBuffer, 0, processedBuffer.Length);
            return processedBuffer;
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
