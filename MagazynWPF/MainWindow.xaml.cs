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

namespace MagazynWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Magazyn m;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPokaz_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = txtNazwa.Text;
            m = Magazyn.Odczytaj(nazwa);

            if (m == null)
            {
                lblMagazyn.Content = "Brak takiego magazynu";
                lblMagazyn.Foreground = Brushes.Red;
                lblMagazyn1.Content = "Nazwa:   Liczba:    ";
            }
            else
            {
                lblMagazyn1.Content = String.Format("Nazwa: {0} Liczba: {1}", m.Nazwa, m.LiczbaNarzedzi);
                lblMagazyn.Content = String.Empty;
            }
        }
    }
}
