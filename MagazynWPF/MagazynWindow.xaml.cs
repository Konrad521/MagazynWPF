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

namespace MagazynWPF
{
    /// <summary>
    /// Interaction logic for MagazynWindow.xaml
    /// </summary>
    public partial class MagazynWindow : Window
    {
        MainWindow mw;

        public MagazynWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = Nazwa.Text;
            string adres = Adres.Text;

            if (!string.IsNullOrEmpty(nazwa) && !string.IsNullOrEmpty(adres))
            {
                Magazyn m = new Magazyn(nazwa, adres);
                m.Zapisz();

                mw.MagazynyBinding();
                this.Close();
            }
            else
            {
                MessageBox.Show("Złe dane");
            }
        }
    }
}
