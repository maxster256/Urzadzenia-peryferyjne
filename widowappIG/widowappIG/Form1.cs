using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System.Security.Cryptography;

namespace widowappIG
{
    public partial class Form1 : Form
    {
        string file_path;
        SoundPlayer sound = null;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string Cmd, StringBuilder StrReturn, int ReturnLength, IntPtr HwndCallback);
        bool mci = false;
        private DirectSound directSound;
        private SecondarySoundBuffer buffer;
        private int effectIndex = 0; //0 - brak, 1 - pogłos, 2 - echo, 3 - chór, 4 - flanger 

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

//puszczenie dźwięku
        
        //PlaySound
        private void PSplay(object sender, EventArgs e)
        {
            if(file_path != "")
            {
                try
                {
                    sound = new SoundPlayer(file_path);
                    sound.Play();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("The following error was detected in PSplay method: " + ex.Message);
                }
                finally
                {
                    sound.Dispose();
                }
            }
        }

        //Windows Media Player
        private void WMPplay(object sender, EventArgs e)
        {
            if(file_path != "")
            {
                axWindowsMediaPlayer1.URL = @file_path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        //WaveOur Write
        private void WOWplay(object sender, EventArgs e)
        {

        }

        //MCI
        private void MCIplay(object sender, EventArgs e)
        {
            if (file_path != "")
            {
                string command = $"open \"{file_path}\" type waveaudio alias audio";
                mciSendString("close audio", null, 0, IntPtr.Zero);
                mciSendString(command, null, 0, IntPtr.Zero);
                command = "play audio";
                mciSendString(command, null, 0, IntPtr.Zero);
                mci = true;
            }
        }

        //DirectSound
        /*private void DSplay(object sender, EventArgs e)
        {
            if (file_path != "")
            {
                var soundStream = new SoundStream(File.OpenRead(file_path));
                directSound = new DirectSound();
                directSound.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);
                WaveFormat waveFormat = new WaveFormat();
                SoundBufferDescription bufferDesc = new SoundBufferDescription
                {
                    Format = waveFormat,
                    BufferBytes = (int)soundStream.Length,
                    Flags = BufferFlags.ControlEffects
                };
                this.buffer = new SecondarySoundBuffer(directSound, bufferDesc);
                var bufferData = new byte[soundStream.Length];
                soundStream.Read(bufferData, 0, bufferData.Length);
                this.buffer.Write(bufferData, 0, LockFlags.None);
                
                this.buffer.Play(0, PlayFlags.None);
            }
        }*/
        private void DSplay(object sender, EventArgs e)
        {
            if (file_path != "")
            {
                var soundStream = new SoundStream(File.OpenRead(file_path));
                directSound = new DirectSound();
                directSound.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);

                WaveFormat waveFormat = soundStream.Format;
                SoundBufferDescription bufferDesc = new SoundBufferDescription
                {
                    Format = waveFormat,
                    BufferBytes = (int)soundStream.Length,
                    Flags = BufferFlags.ControlVolume | BufferFlags.GlobalFocus
                };

                this.buffer = new SecondarySoundBuffer(directSound, bufferDesc);

                // Odczytaj dane dźwiękowe
                var bufferData = new byte[soundStream.Length];
                soundStream.Read(bufferData, 0, bufferData.Length);

                // Zastosowanie efektu echa, jeśli effectIndex == 2 (echo)
                //if (effectIndex == 2)
                {
                    ApplyEchoEffect(ref bufferData, waveFormat, delayMilliseconds: 500, feedback: 0.5f);
                }

                this.buffer.Write(bufferData, 0, LockFlags.None);
                this.buffer.Play(0, PlayFlags.None);
            }
        }

        private void ApplyEchoEffect(ref byte[] audioData, WaveFormat format, int delayMilliseconds, float feedback)
        {
            int bytesPerSample = format.BitsPerSample / 8; // Ilość bajtów na próbkę
            int sampleRate = format.SampleRate;            // Próbki na sekundę
            int channels = format.Channels;                // Liczba kanałów (np. stereo)

            // Oblicz opóźnienie w próbkach
            int delaySamples = (sampleRate * delayMilliseconds * channels) / 1000;
            int delayBytes = delaySamples * bytesPerSample;

            if (format.BitsPerSample == 16)
            {
                // Dla 16-bitowego audio (często stosowanego)
                for (int i = delayBytes; i < audioData.Length - bytesPerSample; i += bytesPerSample)
                {
                    for (int channel = 0; channel < channels; channel++)
                    {
                        int originalSampleIndex = i + channel * 2;

                        // Odczyt oryginalnej próbki 16-bitowej (małe endianie)
                        short originalSample = BitConverter.ToInt16(audioData, originalSampleIndex);

                        // Odczyt próbki z opóźnieniem, uwzględniając kanał
                        int delayedSampleIndex = originalSampleIndex - delayBytes;
                        if (delayedSampleIndex < 0) continue; // Pomijamy operację, jeśli indeks jest poza zakresem

                        short delayedSample = BitConverter.ToInt16(audioData, delayedSampleIndex);

                        // Modyfikacja próbki na podstawie echa
                        int newSample = originalSample + (int)(delayedSample * feedback);

                        // Ogranicz wartość, aby nie przekroczyć zakresu 16-bitowego (od -32768 do 32767)
                        newSample = Math.Min(Math.Max(newSample, short.MinValue), short.MaxValue);

                        // Konwersja z powrotem do bajtów
                        byte[] newSampleBytes = BitConverter.GetBytes((short)newSample);

                        // Aktualizacja danych dźwiękowych
                        audioData[originalSampleIndex] = newSampleBytes[0];
                        audioData[originalSampleIndex + 1] = newSampleBytes[1];
                    }
                }
            }
            else if (format.BitsPerSample == 8)
            {
                // Dla 8-bitowego audio
                for (int i = delayBytes; i < audioData.Length; i += bytesPerSample)
                {
                    for (int channel = 0; channel < channels; channel++)
                    {
                        int originalSampleIndex = i + channel;

                        // Odczyt oryginalnej próbki 8-bitowej (0-255, przeskalowane na -128 do 127)
                        byte originalSample = audioData[originalSampleIndex];
                        byte delayedSample = audioData[originalSampleIndex - delayBytes];

                        // Modyfikacja próbki
                        int newSample = originalSample + (int)((delayedSample - 128) * feedback);

                        // Ograniczanie wartości do zakresu 0-255
                        newSample = Math.Min(Math.Max(newSample + 128, 0), 255);

                        // Aktualizacja danych dźwiękowych
                        audioData[originalSampleIndex] = (byte)newSample;
                    }
                }
            }
        }



            //zatrzymywanie dźwięku

            //PlaySound
            private void PSstop(object sender, EventArgs e)
        {
            if(sound != null)
            {
                sound.Stop();
                sound.Dispose();
            }
        }

        //WindowsMedia Player
        private void WMPstop(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        //WaveOut Write
        private void WOWstop(object sender, EventArgs e)
        {

        }

        //MCI
        private void MCIstop(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "close audio";
                mciSendString(command, null, 0, IntPtr.Zero);
                mci = false;
            }
        }

        //DirectSound
        private void DSstop(object sender, EventArgs e)
        {
            if (buffer != null)
            {
                this.buffer.Stop();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void WMPpause(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "pause audio";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a WAV file",
                Filter = "WAV files (*.wav)|*.wav",
                Title = "Open WAV file"
            };
            
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                infolabel.Text = "An error was found!";
                return;
            }
            file_path = openFileDialog1.FileName;
            infolabel.Text = "The file is accessed: "+file_path;
        }

        private void infolabel_Click(object sender, EventArgs e)
        {

        }

        private void WMPresume(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void MCIresume(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "resume audio";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            effectIndex = comboBox1.SelectedIndex;
            MessageBox.Show("Wybrany indeks: " + effectIndex.ToString());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
        }
    }
}
