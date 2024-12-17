using System.Runtime.InteropServices;
using System;
using AxWMPLib;
using WMPLib;
using NAudio.Wave;

namespace karta
{
    public partial class Form1 : Form
    {
        // Import PlaySound z winmm.dll
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_FILENAME = 0x00020000; // Flaga: odtwarzanie z pliku
        private const uint SND_ASYNC = 0x0001;
        private string selectedFilePath = string.Empty;

        private WaveInEvent waveIn;          // Nagrywanie za pomoc¹ mikrofonu
        private WaveFileWriter waveWriter;   // Zapisywanie pliku WAV
        private string outputFilePath;       // Œcie¿ka zapisu pliku WAV

        private WaveOutEvent waveOut; // Globalna zmienna dla WaveOut
        private AudioFileReader audioFile;

        private DirectSoundOut directSound; // Globalna zmienna dla DirectSound
        private WindowsMediaPlayer activeXPlayer; // WindowsMediaPlayer dla ActiveX


        public Form1()
        {
            InitializeComponent();
            InitializeInputDevicesComboBox();
        }

        private void InitializeInputDevicesComboBox()
        {

            // Wczytanie dostêpnych urz¹dzeñ wejœciowych
            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                var deviceInfo = WaveInEvent.GetCapabilities(i);
                cmbInputDevices.Items.Add($"{i}: {deviceInfo.ProductName}");
            }

            // Domyœlny wybór pierwszego urz¹dzenia
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
                openFileDialog.Filter = "Pliki audio (*.wav)|*.wav|Wszystkie pliki (*.*)|*.*"; // Filtr dla plików WAV
                openFileDialog.Title = "Wybierz plik audio";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName; // Zapis wybranej œcie¿ki
                    MessageBox.Show($"Wybrano plik: {selectedFilePath}", "Plik wybrany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Obs³uga przycisku "PlaySound"
        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
            {
                bool result = PlaySound(selectedFilePath, IntPtr.Zero, SND_FILENAME | SND_ASYNC);
                if (!result)
                {
                    MessageBox.Show("Nie uda³o siê odtworzyæ pliku!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku lub plik nie istnieje!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obs³uga przycisku "ActiveX"
        private void btnActiveX_Click(object sender, EventArgs e)
        {
            try
            {
                // Zatrzymanie poprzedniego odtwarzania ActiveX
                if (activeXPlayer != null)
                {
                    activeXPlayer.controls.stop();
                    activeXPlayer.close();
                    activeXPlayer = null;
                }

                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    activeXPlayer = new WindowsMediaPlayer(); // Tworzenie nowej instancji ActiveX
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
                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    // Zatrzymanie poprzedniego odtwarzania, jeœli istnieje
                    if (waveOut != null)
                    {
                        waveOut.Stop();
                        waveOut.Dispose();
                        audioFile.Dispose();
                    }

                    // Inicjalizacja WaveOut i odczytu pliku WAV
                    audioFile = new AudioFileReader(selectedFilePath);
                    waveOut = new WaveOutEvent();
                    waveOut.Init(audioFile);

                    // Rozpoczêcie odtwarzania
                    waveOut.Play();
                    MessageBox.Show("Odtwarzanie za pomoc¹ WaveOut rozpoczête!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    // Zatrzymanie poprzedniego odtwarzania, jeœli istnieje
                    if (directSound != null)
                    {
                        directSound.Stop();
                        directSound.Dispose();
                        audioFile.Dispose();
                    }

                    // Inicjalizacja DirectSound i odczytu pliku WAV
                    audioFile = new AudioFileReader(selectedFilePath);
                    directSound = new DirectSoundOut();
                    directSound.Init(audioFile);

                    // Rozpoczêcie odtwarzania
                    directSound.Play();
                    MessageBox.Show("Odtwarzanie za pomoc¹ DirectSound rozpoczête!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Zatrzymanie PlaySound
                PlaySound(null, IntPtr.Zero, SND_ASYNC);

                // Zatrzymanie ActiveX Player
                if (activeXPlayer != null)
                {
                    activeXPlayer.controls.stop();
                    activeXPlayer.close();
                    activeXPlayer = null;
                }

                // Zatrzymanie WaveOut
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }

                // Zatrzymanie DirectSoundOut
                if (directSound != null)
                {
                    directSound.Stop();
                    directSound.Dispose();
                    directSound = null;
                }

                // Zwolnienie pliku audio
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

                        // Wyœwietlenie wyników w TextBox
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

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                // Sprawdzenie czy wybrano urz¹dzenie
                if (cmbInputDevices.SelectedIndex < 0)
                {
                    MessageBox.Show("Wybierz urz¹dzenie wejœciowe!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Œcie¿ka do zapisu pliku WAV
                outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "recorded.wav");

                // Konfiguracja nagrywania
                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = cmbInputDevices.SelectedIndex; // Wybór urz¹dzenia z ComboBox
                waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1 kHz, mono

                waveWriter = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);

                // Zdarzenia nagrywania
                waveIn.DataAvailable += (s, a) =>
                {
                    waveWriter.Write(a.Buffer, 0, a.BytesRecorded);
                };

                waveIn.RecordingStopped += (s, a) =>
                {
                    waveWriter?.Dispose();
                    waveIn.Dispose();
                    MessageBox.Show($"Nagrywanie zakoñczone. Plik zapisano w: {outputFilePath}", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                // Rozpoczêcie nagrywania
                waveIn.StartRecording();
                MessageBox.Show("Rozpoczêto nagrywanie...", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B³¹d: {ex.Message}", "B³¹d nagrywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
            }
            else
            {
                MessageBox.Show("Nagrywanie nie zosta³o rozpoczête!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
