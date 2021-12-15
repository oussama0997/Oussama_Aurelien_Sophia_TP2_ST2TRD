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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP2_Oussama_Aurélien_Sophia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();   
        }      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var encryptionmethod = EncryptionComboBox.SelectedIndex;
            var key = Key.Text;

            try
            {
                OutputTextBox.Text = string.Empty;
                if (encryptionmethod == 0)
                {
                    OutputTextBox.Text = Caesar.Code(inputText, toDecrypt, key);
                }
                else if (encryptionmethod == 1)
                {
                    OutputTextBox.Text = AES.Code(inputText, toDecrypt);
                }
                else if (encryptionmethod == 2)
                {
                    OutputTextBox.Text = Vigenere.Code(inputText, toDecrypt,key);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var encryptionmethod = EncryptionComboBox.SelectedIndex; if (encryptionmethod == 0)
            {
                Key.IsEnabled = true;
                Key.Text = "3";
            }
            if (encryptionmethod == 1)
            {
                Key.IsEnabled = false;
            }
            else if (encryptionmethod == 2)
            {
                Key.IsEnabled = true;
                Key.Text = "key";
            }
        }

        private void Key_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }   
}
