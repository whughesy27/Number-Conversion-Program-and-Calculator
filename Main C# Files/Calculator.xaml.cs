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
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private static bool CharChecker (char[] binValues)
        {
            //subroutine checks that the users input only contains 1 or 0
            foreach (char i in binValues)
            {
                if (i != '0' && i != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private static int DenConversion (char[] binValues)
        {
            //subroutine convert the binary values the user has entered to an integer
            int n = 0;
            Array.Reverse(binValues);

            for (int i = 0; i < binValues.Length; i++)
            {
                if (binValues[i] == '1')
                {
                    n += (int)Math.Pow(2, i);
                }
            }
            return n;
        }

        //code is excecuted upon button press
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //use this for overflow message --> ⚠
            //clear outputs
            binOutBox.Text = "";
            denOutBox.Text = "";
            errorMessage.Content = "";

            //declaring variables & arrays
            char[] binValues1 = binEntry1.Text.Replace(" ", "").ToCharArray();
            char[] binValues2 = binEntry2.Text.Replace(" ", "").ToCharArray();
            char[] binResult = { '0', '0', '0', '0', '0', '0', '0', '0' };

            bool charCheck1 = CharChecker(binValues1);
            bool charCheck2 = CharChecker(binValues2);

            if (binEntry1.Text == "" || binEntry2.Text == "")
            {
                errorMessage.Content = "Enter Both Values First";
            }
            else if (charCheck1 == false || charCheck2 == false)
            {
                errorMessage.Content = "One or More Invalid Entries";
            }
            else
            {
                int denValue1 = DenConversion(binValues1);
                int denValue2 = DenConversion(binValues2);

                //adds together the two values to get the result
                int denResult = denValue1 + denValue2;

                //converts the new integer value to binary to output the result
                int n = 7;
                int denValue = denResult;
                for (int i = 0; i < 8; i++)
                {
                    if (denValue >= Math.Pow(2, n))
                    {
                        denValue -= (int)Math.Pow(2, n);
                        binResult[i] = '1';
                    }
                    n--;
                }
                //if the value is larger than 255 (exceeds 8 bits) it produces an overflow error message
                if (denResult > 255)
                {
                    errorMessage.Content = "⚠ Overflow ⚠";
                }
                //otherwise it outputs the decimal and binary results
                else
                {
                    binOutBox.Text = String.Join("", binResult);
                    denOutBox.Text = denResult.ToString();
                }
            }
        }
    }
}
