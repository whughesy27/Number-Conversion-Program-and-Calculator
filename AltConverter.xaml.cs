using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Converter
{
    /// <summary>
    /// Interaction logic for AltConverter.xaml
    /// </summary>
    public partial class AltConverter : Window
    {
        public AltConverter()
        {
            InitializeComponent();
        }

        private string[] decToBin(int decValue, ref string[] binValues)
        {
            int n = 7;
            for (int i = 0; i < 8; i++)
            {
                if (decValue >= Math.Pow(2, n))
                {
                    decValue -= (int)Math.Pow(2, n);
                    binValues[i] = "1";
                }
                n--;
            }

            return binValues;
        }

        private void binLF(object sender, RoutedEventArgs e)
        {
            decTxtBox.Text = "";
            hexTxtBox.Text = "";
            errorMessage.Content = "";

            bool charCheck = true;

            if (binTxtBox.Text == "")
            {
                errorMessage.Content = "Enter a Value First";
            }
            else if (binTxtBox.Text.Length != 8)
            {
                errorMessage.Content = "Invalid Entry";
            }

            foreach (char i in binTxtBox.Text)
            {
                if (i != '0' && i != '1')
                {
                    errorMessage.Content = "Invalid Entry";
                    charCheck = false;
                }
            }

            if (charCheck == true && binTxtBox.Text.Length == 8)
            {
                int n = 0;
                char[] denValues = binTxtBox.Text.ToCharArray();
                Array.Reverse(denValues);

                for (int i = 0; i < denValues.Length; i++)
                {
                    if (denValues[i] == '1')
                    {
                        n += (int)Math.Pow(2, i);
                    }
                }

                decTxtBox.Text = n.ToString();

                string[] hexValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
                hexTxtBox.Text = hexValues[n / 16] + hexValues[n % 16];
            }

        }

        private void decLF(object sender, RoutedEventArgs e)
        {
            binTxtBox.Text = "";
            hexTxtBox.Text = "";
            errorMessage.Content = "";

            int denInput = 0;

            if (decTxtBox.Text == "")
            {
                errorMessage.Content = "Enter a Value First";
            }
            else
            {
                try
                {
                    denInput = int.Parse(decTxtBox.Text);
                }
                catch (FormatException)
                {
                    errorMessage.Content = "Invalid Entry";
                    return;
                }
                if (denInput > 255 || denInput < 0)
                {
                    errorMessage.Content = "Invalid Entry";
                    return;
                }

                string[] hexValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
                hexTxtBox.Text = hexValues[denInput / 16] + hexValues[denInput % 16];

                string[] binValues = { "0", "0", "0", "0", "0", "0", "0", "0" };
                decToBin(denInput, ref binValues);
                binTxtBox.Text = String.Join("", binValues);
            }

        }

        private void hexLF(object sender, RoutedEventArgs e)
        {
            decTxtBox.Text = "";
            binTxtBox.Text = "";
            errorMessage.Content = "";

            int denValue = 0;
            char[] hexValues = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int[] nibbles = { 0, 0 };
            bool[] charFound = { false, false };

            if (hexTxtBox.Text == "")
            {
                errorMessage.Content = "Enter a Value First";
            }
            else if (hexTxtBox.Text.Length != 2)
            {
                errorMessage.Content = "Invalid Entry";
            }
            else
            {
                for (int x = 0; x < 2; x++)
                {
                    for (int i = 0; i < hexValues.Length; i++)
                    {
                        if (hexTxtBox.Text.ToUpper()[x] == hexValues[i])
                        {
                            nibbles[x] = i;
                            charFound[x] = true;
                        }
                    }
                }

                if (charFound[0] == true && charFound[1] == true)
                {
                    denValue = (nibbles[0] * 16) + nibbles[1];
                    decTxtBox.Text = denValue.ToString();
                }
                else
                {
                    errorMessage.Content = "Invalid Entry";
                    return;
                }

                string[] binValues = { "0", "0", "0", "0", "0", "0", "0", "0" };
                decToBin(denValue, ref binValues);
                binTxtBox.Text = String.Join("", binValues);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (binTxtBox.Text == "" && hexTxtBox.Text == "" && decTxtBox.Text == "")
            {
                errorMessage.Content = "Enter a Value First";
            }
            else
            {
                conButton.Focus();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

    }
}
