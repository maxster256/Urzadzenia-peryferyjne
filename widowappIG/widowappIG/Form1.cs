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
using static widowappIG.Form1;
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

        private static IntPtr waveInHandle;
        private IntPtr WaveOut; // uchwyt  waveout
        private WaveHeader waveHeader; // naglowek audio .wav
        private byte[] audioData; // bufor odtwarzanego dzwieku

        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(uint mcierr, StringBuilder pszText, int cchText);


        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr WaveOut, int uDeviceID, WaveFormat lpFormat, IntPtr Callback, IntPtr Instance, int dwFlags);

        [DllImport("winmm.dll")]
        public static extern int waveOutPrepareHeader(IntPtr WaveOut, ref WaveHeader lpWaveOutHdr, int uSize);

        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr WaveOut, ref WaveHeader lpWaveOutHdr, int uSize);

        [DllImport("winmm.dll")]
        public static extern int waveOutPause(IntPtr WaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutRestart(IntPtr WaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutClose(IntPtr WaveOut);
        [DllImport("winmm.dll")]
        public static extern int waveOutReset(IntPtr WaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutUnprepareHeader(IntPtr WaveOut, ref WaveHeader WaveOutHdr, int uSize);

        [StructLayout(LayoutKind.Sequential)]
        public class WaveFormat
        {
            public short FormatTag = 1;
            public short Channels = 2;
            public int SamplesPerSec = 44100;
            public int AverageBytesPerSecond = 44100 * 4;
            public short BlockAlign = 4;
            public short BitsPerSample = 16;
            public short cbSize = 0;
        }

        // Nagłówek danych audio
        [StructLayout(LayoutKind.Sequential)]
        public struct WaveHeader
        {
            public IntPtr Data;
            public int BufferLength;
            public int BytesRecorded;
            public IntPtr User;
            public int Flags;
            public int Loops;
            public IntPtr Next;
            public IntPtr reserved;
        }

        public Form1()
        {
            InitializeComponent();

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
            if (file_path != null)
            {
                audioData = File.ReadAllBytes(file_path);
                GCHandle handle = GCHandle.Alloc(audioData, GCHandleType.Pinned);

                waveHeader = new WaveHeader()
                {
                    Data = handle.AddrOfPinnedObject(),
                    BufferLength = audioData.Length
                };

                WaveFormat format = new WaveFormat()
                {
                    Channels = 2, // Stereo
                    SamplesPerSec = 44100, // 44.1 kHz
                    BitsPerSample = 16, // 16-bit
                    BlockAlign = 4, // 2 (Stereo) * 2 (16-bit)
                    AverageBytesPerSecond = 44100 * 4 // 44100 * 2 * 16/8
                };

                waveOutOpen(out WaveOut, -1, format, IntPtr.Zero, IntPtr.Zero, 0);
                waveOutPrepareHeader(WaveOut, ref waveHeader, Marshal.SizeOf(waveHeader));

                if (audioData != null && WaveOut != IntPtr.Zero)
                {
                    waveOutWrite(WaveOut, ref waveHeader, Marshal.SizeOf(waveHeader));
                }
            }
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
        private void DSplay(object sender, EventArgs e)
        {
            if (file_path != null)
            {
                var soundStream = new SoundStream(File.OpenRead(file_path));
                directSound = new DirectSound();
                directSound.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);
                SharpDX.Multimedia.WaveFormat waveFormat = soundStream.Format;
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
            if (WaveOut != IntPtr.Zero)
            {
                waveOutReset(WaveOut);
                waveOutClose(WaveOut);
                WaveOut = IntPtr.Zero;
            }
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

        //WindowsMediaPlayer
        private void WMPpause(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private void WoWpause(object sender, EventArgs e) // wow pause
        {
            if (WaveOut != IntPtr.Zero)
            {
                waveOutPause(WaveOut);
            }
        }

        private void mcipause(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "pause audio";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void WoWresume(object sender, EventArgs e) // wow resume
        {
            if (WaveOut != IntPtr.Zero)
            {
                waveOutRestart(WaveOut);
            }
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

        private void record(object sender, EventArgs e)
        {
            string command = "open new type waveaudio alias recording";
            long result = mciSendString(command, null, 0, IntPtr.Zero);
            if (result != 0)
            {
                StringBuilder errorText = new StringBuilder(256);
                mciGetErrorString((uint)result, errorText, errorText.Capacity);
                MessageBox.Show("MCI Error: " + errorText.ToString());
            }
            infolabel.Text = result.ToString();
            command = "record recording";
            result = mciSendString(command, null, 0, IntPtr.Zero);
            if (result != 0)
            {
                StringBuilder errorText = new StringBuilder(256);
                mciGetErrorString((uint)result, errorText, errorText.Capacity);
                MessageBox.Show("MCI Error: " + errorText.ToString());
            }
            infolabel.Text = result.ToString();
        }

        private void stopRecord(object sender, EventArgs e)
        {
            {
                long result = mciSendString("stop recording", null, 0, IntPtr.Zero);
                infolabel.Text = result.ToString();
                if (result != 0)
                {
                    StringBuilder errorText = new StringBuilder(256);
                    mciGetErrorString((uint)result, errorText, errorText.Capacity);
                    MessageBox.Show("MCI Error: " + errorText.ToString());
                }
                result = mciSendString("save recording C:\\Users\\julia\\OneDrive\\Pulpit\\result.wav", null, 0, IntPtr.Zero);
                if (result != 0)
                {
                    StringBuilder errorText = new StringBuilder(256);
                    mciGetErrorString((uint)result, errorText, errorText.Capacity);
                    MessageBox.Show("MCI Error: " + errorText.ToString());
                }
                infolabel.Text = result.ToString();
                result = mciSendString("close recording", null, 0, IntPtr.Zero);
                if (result != 0)
                {
                    StringBuilder errorText = new StringBuilder(256);
                    mciGetErrorString((uint)result, errorText, errorText.Capacity);
                    MessageBox.Show("MCI Error: " + errorText.ToString());
                }
                infolabel.Text = result.ToString();
            }
        }
    }
}