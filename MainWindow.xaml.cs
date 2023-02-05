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

namespace WpfApp5
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

        private void sliPiros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            rctColor.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
            labPirosErtek.Content = Convert.ToString(red);
        }

        private void sliZold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            rctColor.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
            labZoldErtek.Content = Convert.ToString(green);
        }

        private void sliKek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            rctColor.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
            labKekErtek.Content = Convert.ToString(blue);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            byte red, green, blue;
            red = Convert.ToByte(sliPiros.Value);
            green = Convert.ToByte(sliZold.Value);
            blue = Convert.ToByte(sliKek.Value);
            string szinAdatok = $"{red};{green};{blue}";

            List<string> lbSzinekItems = new List<string>();

            foreach (var item in lbSzinek.Items)
            {
                lbSzinekItems.Add(item.ToString());
            }

            if (lbSzinekItems.Contains(szinAdatok))
            {
                MessageBox.Show("Már van ilyen színed!");
            }
            else
            {
                lbSzinek.Items.Add(szinAdatok);
            }

        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Jelölj ki egy sort a listában!");
            }
            
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] tagok = lbSzinek.SelectedItem.ToString().Split(';');

            sliPiros.Value = Convert.ToInt32(tagok[0]);
            sliZold.Value = Convert.ToInt32(tagok[1]);
            sliKek.Value = Convert.ToInt32(tagok[2]);
        }

        // Listadoboz elemére kattintva a slider felveszi a megfelelő értékeket

    }
}
