using System;
using System.Collections.Generic;
using System.Globalization;
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
using WineryByTheLake.Models;

namespace WineryByTheLake.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wineColor.ItemsSource = Enum.GetValues(typeof(ColorE));

        }

        private void TextBox_NumberOnly(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var fullText = "";

            if(textBox != null)
            {
                fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            }

            double val;

            e.Handled = !double.TryParse(fullText, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out val);
        }
    }
}
