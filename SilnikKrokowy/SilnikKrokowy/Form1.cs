using System.Collections.Specialized;
using System.Text;
using FTD2XX_NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SilnikKrokowy
{
    public partial class Form1 : Form
    {
        private FTDI ftdiDevice = new FTDI();
        FTDI.FT_DEVICE_INFO_NODE[] deviceList;
        private int motorDirection = -1;    // -1 - lewo, 1 - prawo
        private int index = 0;
        byte[] motorSequence = { 0x08, 0x02, 0x04, 0x01 };
        byte[] waveSequence = { 0x08, 0x02, 0x04, 0x01 };           // sterowanie falowe
        byte[] fullstepSequence = { 0x06, 0x0A, 0x09, 0x05 };       // sterowanie krokowe
        byte[] halfstepSequence = { 0x08, 0x0A, 0x02, 0x06, 0x04, 0x05, 0x01, 0x09 };       // sterowanie pó³krokowe

        public Form1()
        {
            InitializeComponent();
            ftdiDevice = new FTDI();
            PrepareDevices();
        }

        private void PrepareDevices()
        {
            uint deviceCount = 0;

            // pobranie liczby urz¹dzeñ
            FTDI.FT_STATUS status = ftdiDevice.GetNumberOfDevices(ref deviceCount);
            if (status != FTDI.FT_STATUS.FT_OK || deviceCount == 0)
            {
                MessageBox.Show("Nie znaleziono urz¹dzeñ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // pobranie listy urz¹dzeñ
            deviceList = new FTDI.FT_DEVICE_INFO_NODE[deviceCount];
            status = ftdiDevice.GetDeviceList(deviceList);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("Nie uda³o siê pobraæ listy urz¹dzeñ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Wype³nienie ComboBox informacjami o urz¹dzeniach
            comboBoxDevices.Items.Clear();
            for (uint i = 0; i < deviceCount; i++)
            {
                comboBoxDevices.Items.Add($"{i}: {deviceList[i].Description}");
                Console.WriteLine("Element: " + deviceList[i].ToString());
            }
            comboBoxDevices.SelectedIndex = 0; // domyœlnie wybrane pierwsze urz¹dzenie

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ftdiDevice != null)
            {
                ftdiDevice.Close();
            }
            base.OnFormClosing(e);
        }

        private void driveWave_Click(object sender, EventArgs e)
        {
            motorSequence = waveSequence;
            labelModeText.Text = "Sterowanie Falowe";
        }

        private void driveFullstep_Click(object sender, EventArgs e)
        {
            motorSequence = fullstepSequence;
            labelModeText.Text = "Sterowanie Krokowe";
        }

        private void driveHalfstep_Click(object sender, EventArgs e)
        {
            motorSequence = halfstepSequence;
            labelModeText.Text = "Sterowanie Pó³krokowe";
        }

        private void rotateLeft_Click(object sender, EventArgs e)
        {
            motorDirection = -1;
            PerformSteps(motorSequence, motorDirection);
        }

        private void rotateRight_Click(object sender, EventArgs e)
        {
            motorDirection = 1;
            PerformSteps(motorSequence, motorDirection);
        }

        private void PerformSteps(byte[] sequence, int direction)
        {
            int sequenceLength = sequence.Length;
            int number_of_steps = Convert.ToInt32(numberSteps.Text);
            int stepDelay = Convert.ToInt32(timeSteps.Text);
            
            for (int i = 0, j = index; i < number_of_steps; i++)
            {
                // Obliczanie indeksu w sekwencji
                int stepIndex;
                if (direction == 1)
                {
                    stepIndex = ++j % sequenceLength; // W prawo
                }
                else
                {
                    stepIndex = (sequenceLength - (++j % sequenceLength) - 1); // W lewo
                }
                index = stepIndex;

                // Dane do wys³ania
                byte[] data = { sequence[stepIndex] };

                // Wysy³anie danych do urz¹dzenia
                uint bytesWritten = 0;
                FTDI.FT_STATUS status = ftdiDevice.Write(data, data.Length, ref bytesWritten);
                if (status != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("B³¹d wysy³ania danych!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // opoŸnienie miêdzy krokami
                System.Threading.Thread.Sleep(stepDelay);
            }
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDevices.SelectedIndex < 0)
                return;

            // zakonczenie istniejacego po³¹czenia
            if (ftdiDevice.IsOpen)
            {
                ftdiDevice.Close();
            }

            // otwarcie wybranego urz¹dzenia
            int selectedIndex = (int)comboBoxDevices.SelectedIndex;
            FTDI.FT_STATUS status = ftdiDevice.OpenBySerialNumber(deviceList[selectedIndex].SerialNumber);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("Nie uda³o siê otworzyæ wybranego urz¹dzenia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ftdiDevice.SetBitMode(0xFF, 1);
                MessageBox.Show($"Urz¹dzenie \"{comboBoxDevices.SelectedItem}\" otwarte pomyœlnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EPROM_Click(object sender, EventArgs e)
        {
            FTDI.FT232B_EEPROM_STRUCTURE structure = new FTDI.FT232B_EEPROM_STRUCTURE();
            FTDI.FT_STATUS status = ftdiDevice.ReadFT232BEEPROM(structure);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("B³¹d odczytu pamiêci EPROM!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                textEPROM.AppendText("VID: " + structure.VendorID.ToString("X"));
                textEPROM.AppendText(Environment.NewLine);
                textEPROM.AppendText("PID: " + structure.ProductID.ToString("X"));
                textEPROM.AppendText(Environment.NewLine);
                textEPROM.AppendText("Description: " + Convert.ToString(structure.Description));
                textEPROM.AppendText(Environment.NewLine);
            }
        }
        // modyfikacja pamieci EEPROM
        private void buttonName_Click(object sender, EventArgs e)
        {
            // Odczyt aktualnej struktury EEPROM
            FTDI.FT232B_EEPROM_STRUCTURE structure = new FTDI.FT232B_EEPROM_STRUCTURE();
            FTDI.FT_STATUS status = ftdiDevice.ReadFT232BEEPROM(structure);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("B³¹d odczytu pamiêci EPROM!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ustawienie nowej nazwy
            structure.Description = textBoxName.Text;

            // Zapis nowej struktury do EEPROM
            status = ftdiDevice.WriteFT232BEEPROM(structure);
            if (status != FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show("B³¹d zapisu do pamiêci EPROM!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Nazwa urz¹dzenia zosta³a zmieniona na \"{structure.Description}\".", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
