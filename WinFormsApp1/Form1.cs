using System.ComponentModel;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Lat_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Try to parse the input as a decimal number
            if (decimal.TryParse(textBox.Text, out decimal value))
            {
                // Truncate the number to a maximum of 4 decimal places, then limmit uper and lower bounds
                decimal truncatedValue = Math.Truncate(value * 10000m) / 10000m;
                truncatedValue = (truncatedValue > 90) ? 90 : (truncatedValue < -90 ? -90 : truncatedValue);
                // Update the TextBox text with the truncated value
                textBox.Text = truncatedValue.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
            }
        }

        private void Lon_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Try to parse the input as a decimal number
            if (decimal.TryParse(textBox.Text, out decimal value))
            {
                // Truncate the number to a maximum of 4 decimal places, then limmit uper and lower bounds
                decimal truncatedValue = Math.Truncate(value * 10000m) / 10000m;
                truncatedValue = (truncatedValue > 180) ? 180 : (truncatedValue < -180 ? -180 : truncatedValue);
                // Update the TextBox text with the truncated value
                textBox.Text = truncatedValue.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
            }
        }

        private async void BtnGetTemp_Click(object sender, EventArgs e)
        {
            try
            {
                double latitude = Convert.ToDouble(TxtLat.Text);
                double longitude = Convert.ToDouble(TxtLon.Text);

                WeatherService weatherService = new WeatherService();
                double temperature = (double)await weatherService.GetTemperatureAsync(latitude, longitude);

                LblTemp.Text = $"Temperature: {temperature}°F";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtLat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}