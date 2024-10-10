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
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX.DirectSound;
using SlimDX;

namespace widowappIG
{
    public partial class Form1 : Form
    {
        private delegate void WaveInProc(IntPtr WaveIn, int uMsg, IntPtr Instance, IntPtr Param1, IntPtr Param2);

        private static IntPtr waveInHandle;
        private IntPtr WaveOut; // uchwyt  waveout
        private WaveHeader waveHeader; // naglowek audio .wav
        private byte[] audioData; // bufor odtwarzanego dzwieku
        private static byte[] buffer; // bufor nagrywanego dzwieku
        private static GCHandle bufferHandle;
        private DirectSound directSound;
        private SecondarySoundBuffer secondaryBuffer;

        string file_path;
        SoundPlayer sound = null;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string Cmd, StringBuilder StrReturn, int ReturnLength, IntPtr HwndCallback);
        bool mci = false;
        bool wiw = false;

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
        public static extern int waveOutUnprepareHeader(IntPtr WaveOut, ref WaveHeader WaveOutHdr, int uSize);




        [DllImport("winmm.dll")]
        private static extern int waveInOpen(out IntPtr WaveIn, int DeviceID, WaveFormat Format, WaveInProc Callback, IntPtr Instance, int Flags);

        [DllImport("winmm.dll")]
        private static extern int waveInPrepareHeader(IntPtr hWaveIn, ref WaveHeader lpWaveInHdr, int uSize);

        [DllImport("winmm.dll")]
        private static extern int waveInAddBuffer(IntPtr WaveIn, ref WaveHeader lpWaveInHdr, int uSize);

        [DllImport("winmm.dll")]
        private static extern int waveInStart(IntPtr WaveIn);

        [DllImport("winmm.dll")]
        private static extern int waveInStop(IntPtr hWaveIn);

        [DllImport("winmm.dll")]
        private static extern int waveInClose(IntPtr hWaveIn);

        [StructLayout(LayoutKind.Sequential)]
        public class WaveFormat
        {
            public short FormatTag = 1;
            public short Channels = 2;
            public int SamplesPerSec = 44100;
            public int AvgBytesPerSec = 44100 * 4;
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

        private void WMPplay(object sender, EventArgs e)
        {
            if(file_path != "")
            {
                axWindowsMediaPlayer1.URL = @file_path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void WOWplay(object sender, EventArgs e)
        {
            if(file_path != "")
            {
                audioData = File.ReadAllBytes(file_path);
                GCHandle handle = GCHandle.Alloc(audioData, GCHandleType.Pinned);

                waveHeader = new WaveHeader();
                waveHeader.Data = handle.AddrOfPinnedObject();
                waveHeader.BufferLength = audioData.Length;

                WaveFormat format = new WaveFormat();

                waveOutOpen(out WaveOut, -1, format, IntPtr.Zero, IntPtr.Zero, 0);
                waveOutPrepareHeader(WaveOut, ref waveHeader, Marshal.SizeOf(waveHeader));

                if (audioData != null && WaveOut != IntPtr.Zero)
                {
                    waveOutWrite(WaveOut, ref waveHeader, Marshal.SizeOf(waveHeader));
                }
            }
        }

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

        private void DSplay(object sender, EventArgs e)
        {
            if (file_path != "")
            {
                
            }
        }

        private void PSstop(object sender, EventArgs e)
        {
            if(sound != null)
            {
                sound.Stop();
                sound.Dispose();
            }
        }

        private void WMPstop(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        private void WOWstop(object sender, EventArgs e)
        {
            if (WaveOut != IntPtr.Zero)
            {
                waveOutClose(WaveOut);
                WaveOut = IntPtr.Zero;
            }
        }

        private void MCIstop(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "close audio";
                mciSendString(command, null, 0, IntPtr.Zero);
                mci = false;
            }
        }

        private void DSstop(object sender, EventArgs e)
        {

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
            if (WaveOut != IntPtr.Zero)
            {
                waveOutPause(WaveOut);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (mci)
            {
                string command = "pause audio";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void button16_Click(object sender, EventArgs e) // pause DS
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

        private void button20_Click(object sender, EventArgs e) // WOW resume
        {
            if (WaveOut != IntPtr.Zero)
            {
                waveOutRestart(WaveOut);
            }
        }

        private void button18_Click(object sender, EventArgs e) // WIW record sound
        {
            WaveFormat waveFormat = new WaveFormat();
            if (waveInOpen(out waveInHandle, 0, waveFormat, null, IntPtr.Zero, 0x00030000) != 0)
            {
                infolabel.Text = "Nie znaleziono urzadzenia nagrywajacego.";
                return;
            }

            buffer = new byte[waveFormat.AvgBytesPerSec*10];
            bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            waveHeader = new WaveHeader
            {
                Data = bufferHandle.AddrOfPinnedObject(),
                BufferLength = buffer.Length,
                BytesRecorded = 0,
                User = IntPtr.Zero,
                Flags = 0,
                Loops = 1,
                Next = IntPtr.Zero,
                reserved = IntPtr.Zero
            };

            waveInPrepareHeader(waveInHandle, ref waveHeader, Marshal.SizeOf(waveHeader));
            waveInAddBuffer(waveInHandle, ref waveHeader, Marshal.SizeOf(waveHeader));

            waveInStart(waveInHandle);
            wiw = true;
        }

        private void button21_Click(object sender, EventArgs e) // WIW stop record
        {
            if (wiw)
            {
                waveInStop(waveInHandle);
                waveInClose(waveInHandle);
                try
                {
                    using (var fileStream = new FileStream("recording.wav", FileMode.Create))
                    {
                        // pola waveformat do utworzenia naglowka pliku wyjsciowego
                        WaveFormat outputFormat = new WaveFormat();

                        int formatSize = 16;
                        int dataSize = buffer.Length;
                        int fileSize = 4 + (8 + formatSize) + (8 + dataSize);

                        using (var writer = new BinaryWriter(fileStream))
                        {
                            // naglowek riff
                            writer.Write("RIFF".ToCharArray());
                            writer.Write(fileSize);
                            writer.Write("WAVE".ToCharArray());

                            // fmt i pola obiektu waveformat
                            writer.Write("fmt ".ToCharArray());
                            writer.Write(formatSize);
                            writer.Write(outputFormat.FormatTag);
                            writer.Write(outputFormat.Channels);
                            writer.Write(outputFormat.SamplesPerSec);
                            writer.Write(outputFormat.AvgBytesPerSec);
                            writer.Write(outputFormat.BlockAlign);
                            writer.Write(outputFormat.BitsPerSample);

                            // czesc na dane
                            writer.Write("data".ToCharArray());
                            writer.Write(dataSize);
                            writer.Write(buffer);
                        }
                    }
                }
                catch(Exception ex) { infolabel.Text = ex.Message; }
                
                bufferHandle.Free();
                wiw = false;
            }
        }

        private void button17_Click(object sender, EventArgs e) //sound effects for Direct Sound
        {

        }
    }
}
