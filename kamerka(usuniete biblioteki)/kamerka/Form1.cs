using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Accord.Video.DirectShow; Aforge zawiera w sobie wszystkie funkcjonalnosci Accord.Video.DirectShow i sie gryzą XDDD
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics.Tracing;
using Accord.Imaging.Filters; // do efektow jasnosci, kontrastu i nasycenia

namespace kamerka
{
    public partial class Form1 : Form
    {
        FilterInfoCollection cameraDevices;
        VideoCaptureDevice camera;
        private int contrast, brightness, saturation;
        private bool frameToCapture = false;
        public Form1()
        {
            InitializeComponent();

            // domyslne wartosci suwakow ustawione na srodek
            contrast = 50;
            brightness = 50;
            saturation = 50;

            pictureBox1.BackColor = Color.Black;
            cameraDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (cameraDevices.Count > 0)
            {
                for(int i=0; i<cameraDevices.Count; i++)
                {
                    listBox1.Items.Add(cameraDevices[i].Name);
                }
            }
            else
            {
                label1.Text = "Nie wykryto zadnej kamery.";
                this.Close();
            }
        }

        private void turnOnCamera(object sender, EventArgs e)
        {
            if (cameraDevices.Count == 0) return;
            camera = new VideoCaptureDevice(cameraDevices[0].MonikerString);
            camera.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            camera.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if(frameToCapture)
            {
                try
                {
                    Bitmap capturedFrame = (Bitmap)eventArgs.Frame.Clone();
                    
                    //Konwersja zakresu suwaka [0 do 100] na bliski zakresowi BrightnessCorrection [-255 do 255]
                    BrightnessCorrection bc = new BrightnessCorrection((brightness - 50)*5);
                    capturedFrame = bc.Apply((Bitmap)capturedFrame.Clone());
                    //Konwersja zakresu suwaka [0 do 100] na bliski zakresowi ContrastCorrection [-127 do 127]
                    ContrastCorrection cc = new ContrastCorrection((int)((contrast - 50)*2.5));
                    capturedFrame = cc.Apply((Bitmap)capturedFrame.Clone());
                    //Konwersja zakresu suwaka [0 do 100] na bliski zakresowi SaturationCorrection [-1 do 1]
                    SaturationCorrection sc = new SaturationCorrection((int)((saturation - 50.0)/50.0));
                    capturedFrame = sc.Apply((Bitmap)capturedFrame.Clone());
                    
                    // zapisanie pliku .jpg o oryginalnej rozdzielczosci z kamery
                    string filePath = "capturedFrame.jpg";
                    capturedFrame.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    label1.Text = "Klatka została zapisana jako " + filePath;
                    frameToCapture = false;

                    // narysowanie w aplikacji zapisanej klatki w nowym rozmiarze dostosowanym do rozmiaru pictureBox
                    Bitmap resizedFrame = new Bitmap(1080, 608);
                    using (Graphics g = Graphics.FromImage(resizedFrame))
                    {
                        g.DrawImage(capturedFrame, 0, 0, 1080, 608);
                    }
                    pictureBox1.BackgroundImage = resizedFrame;
                }
                catch(Exception ex)
                {
                    label1.Text = ex.Message;
                }
            }
        }

        private void takePhoto(object sender, EventArgs e)
        {
            // przypisanie wartosci true pozwala na wykonanie zawartosci funkcji Video_NewFrame()
            frameToCapture = true;
        }

        private void startRecording(object sender, EventArgs e)
        {

        }

        private void stopRecording(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void turnOffCamera(object sender, EventArgs e)
        {
            if (camera.IsRunning)
            {
                camera.Stop();
                camera = null;
                label1.Text = "Zamknieto kamere.";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void contrastScrollBar(object sender, EventArgs e)
        {
            contrast = contrastBar.Value;
        }

        private void brightnessScrollBar(object sender, EventArgs e)
        {
            brightness = brightnessBar.Value;
        }

        private void saturationScrollBar(object sender, EventArgs e)
        {
            saturation = saturationBar.Value;
        }
    }
}
