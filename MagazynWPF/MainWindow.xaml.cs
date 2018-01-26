using System;
using System.Collections.Generic;
using System.IO;
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
        public Magazyn m;

        public MainWindow()
        {
            InitializeComponent();
            MagazynyBinding();
        }
       public void InitBinding()
        {
            dgNarzedzia.ItemsSource = null;
            dgNarzedzia.ItemsSource = m.ListaNarzedzi;
        }

        public void MagazynyBinding()
        {
            var files = Directory.GetFiles("Magazyny");
            List<string> pliki = new List<string>();

            foreach (var f in files)
            {
                string magazyn = System.IO.Path.GetFileName(f).Replace(".xml", string.Empty);
                pliki.Add(magazyn);
            }

            cmbMagazyny.ItemsSource = null;
            cmbMagazyny.ItemsSource = pliki;

            if (m != null)
            {
                cmbMagazyny.SelectedItem = pliki.FirstOrDefault(x => x == m.Nazwa);
            }

        }

        public void btnPokaz_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = cmbMagazyny.SelectedValue.ToString();
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

                InitBinding();
            }
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (m != null)
            {
                NarzedzieWindow nw = new NarzedzieWindow(this);
                nw.Show();
            }
            else
            {
                MessageBox.Show("Wybierz magazyn, lub stwórz nowy");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Narzedzie> DoUsuniecia = new List<Narzedzie>();

            foreach(var item in dgNarzedzia.SelectedItems)
            {
                int i = dgNarzedzia.Items.IndexOf(item);
                Narzedzie n = m.ListaNarzedzi[i];
                DoUsuniecia.Add(n);
            }

            foreach (Narzedzie n in DoUsuniecia)
            {
                m.ListaNarzedzi.Remove(n);
            }

            InitBinding();
            m.Zapisz();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MagazynWindow mw = new MagazynWindow(this);
            mw.Show();
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
           string nazwa = cmbMagazyny.SelectedValue.ToString();
    
            if (string.IsNullOrEmpty(nazwa))
            {
                
                MessageBox.Show("Nie wybrano magazynu!");
            }

            else
            {

                
                m = Magazyn.Odczytaj(nazwa); 
                
                m.Edytuj(m);

                MagazynWindowEdytuj mwe = new MagazynWindowEdytuj(this);
                mwe.Show();
            }

        }

        private void Skasuj_Click(object sender, RoutedEventArgs e)
        {
            

            string nazwa = cmbMagazyny.SelectedValue.ToString();

            if (string.IsNullOrEmpty(nazwa))
            {

                MessageBox.Show("Nie wybrano magazynu!");
            }

            else
            {

                m = Magazyn.Odczytaj(nazwa);

                m.Edytuj(m);

                MagazynyBinding();

                m.Zapisz();
                
            }
        }
    }
}
