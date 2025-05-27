using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;

namespace skanerAplikacja
{
    public partial class Form1 : Form
    {
        DeviceManager deviceManager = new DeviceManager();
        Device device;
        string extension, format;
        int trybSkanowania = 1, dpi = 300;
        const double millimetersToInches = 25.4, inchesToMillimeters = 1/25.4; // zmieniona nazwa tych zmiennych :]
        bool connected = false;
        static double a4_height = (297 / millimetersToInches);
        static double a4_width = (210 / millimetersToInches);
        // usuniete scale_x, scale_y
        double x_start = 0, x_end, y_start = 0, y_end; // pozamieniane na double zeby nie bylo problemow z rzutowaniem
        double width = 396.0; // podstawienie maksymalnych rozmiarow z myszy zamiast rozmiarow A4
        double height = 546.0; //

        public Form1()
        {
            InitializeComponent();
            // uzupelnienie comboBoxa o rozne rozszerzenia pliku
            init_comboBox();
            // ustawienie domyslnego rozszerzenia .jpg wraz z odpowiednim trybem
            setFormat(".jpg", "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            textBoxX.Text = x_start.ToString(); //
            textBoxY.Text = y_start.ToString(); // inicjalizacja pol tekstowych
            textBoxWidth.Text = width.ToString(); //
            textBoxHeight.Text = height.ToString(); //

            pictureBox1.BackColor = Color.Black;
            // zdarzenia obsługi myszy na pictureBox
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void init_comboBox()
        {
            comboBox1.Items.Add("JPEG");
            comboBox1.Items.Add("PNG");
            comboBox1.Items.Add("GIF");
            comboBox1.Items.Add("BMP");
            comboBox1.Items.Add("TIFF");
        }

        private void polacz_Click(object sender, EventArgs e)
        {
            // if są jakiekolwiek podlaczone urzadzenia
            if(deviceManager.DeviceInfos.Count > 0)
            {
                device = deviceManager.DeviceInfos[1].Connect();
                connected = true;
                label3.Text = "";
                MessageBox.Show("Polaczono ze skanerem!", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Nie wykryto zadnych podlaczonych urzadzen!", "", MessageBoxButtons.OK);
            }
        }

        private void skanuj_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                Item item = device.Items[1];

                // ustawienie parametrów skanowania
                item.Properties.get_Item("6146").set_Value(trybSkanowania); // tryb skanera
                item.Properties.get_Item("6147").set_Value(dpi); // dpi poziome
                item.Properties.get_Item("6148").set_Value(dpi); // dpi pionowe
                item.Properties.get_Item("6149").set_Value(Double.Parse(textBoxX.Text) * dpi / 46.75); // x_poczatek - te 46.75 to dobrane ekspeymentalnie XDDD (+ tutaj tez trzeba bylo dodać DPI)
                item.Properties.get_Item("6150").set_Value(Double.Parse(textBoxY.Text) * dpi / 46.75); // y_poczatek - pobierane z pola tekstowego
                item.Properties.get_Item("6151").set_Value(dpi * a4_width * (Double.Parse(textBoxWidth.Text) / 396.0)); // szerokosc skanowania - pobierana z pola tekstowego
                item.Properties.get_Item("6152").set_Value(dpi * a4_height * (Double.Parse(textBoxHeight.Text) / 546.0)); // wysokosc(dlugosc) skanowania

                pictureBox1.Paint += PictureBox_Paint; // dodanie zdarzenia polegającego na narysowaniu prostokata
                pictureBox1.Invalidate(); // odswiezenie picturebox

                // przekazanie wyniku skanowania do pliku
                ImageFile imageFile = (ImageFile)item.Transfer(format);

                pictureBox1.Paint -= PictureBox_Paint; // usuniecie zdarzenia (wiec rowniez prostokata)
                pictureBox1.Invalidate(); // odswiezenie picturebox

                string path = "PlikSkan" + extension;

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                imageFile.SaveFile(path);
                
                // wyswietlenie w pictureBox1 zapisanego pliku
                pictureBox1.ImageLocation = path;
            }
            else
            {
                MessageBox.Show("Brak podlaczonego urzadzenia!", "", MessageBoxButtons.OK);
            }
        }
        // funkcja do rysowania prostokąta
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectToDraw = new Rectangle(Int32.Parse(textBoxX.Text), Int32.Parse(textBoxY.Text), Int32.Parse(textBoxWidth.Text), Int32.Parse(textBoxHeight.Text));
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, rectToDraw);
            }
        }

        private void setFormat(string extension, string format)
        {
            this.extension = extension;
            this.format = format;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1: setFormat(".png", "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"); break;
                case 2: setFormat(".gif", "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}"); break;
                case 3: setFormat(".bmp", "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}"); break;
                case 4: setFormat(".tiff", "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}"); break;
                default: setFormat(".jpg", "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"); break;
            }
        }

        private void obrocObraz(RotateFlipType rotation)
        {
            Image image = pictureBox1.Image;
            image.RotateFlip(rotation);
            // zamiana wartosci atrybutow pictureBox przy uzyciu krotki
            (pictureBox1.Width, pictureBox1.Height) = (pictureBox1.Height, pictureBox1.Width);
        }

        private void right90_Click(object sender, EventArgs e)
        {
            // obrot o 90 w prawo
            obrocObraz(RotateFlipType.Rotate90FlipNone);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            trybSkanowania = 1;
            label1.Text = "Tryb skanowania:\nKolorowy";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            trybSkanowania = 2;
            label1.Text = "Tryb skanowania:\nSkala Szarosci";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            trybSkanowania = 4;
            label1.Text = "Tryb skanowania:\nCzern i biel";
        }

        private void left90_Click(object sender, EventArgs e)
        {
            // obrot o 90 w lewo (270 w prawo)
            obrocObraz(RotateFlipType.Rotate270FlipNone);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dpi = trackBar1.Value * 50;
            label2.Text = "DPI: " + dpi;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            x_end = e.X;
            y_end = e.Y;

            width = x_end - x_start;
            height = y_end - y_start;

            textBoxWidth.Text = width.ToString();
            textBoxHeight.Text = height.ToString();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x_start = e.X;
            y_start = e.Y;
            textBoxX.Text = x_start.ToString();
            textBoxY.Text = y_start.ToString();
        }
    }
}
