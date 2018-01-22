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
    /// Interaction logic for NarzedzieWindow.xaml
    /// </summary>
    public partial class NarzedzieWindow : Window
    {
        MainWindow mw;

        public NarzedzieWindow(MainWindow mw)
        {
            InitializeComponent();

            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int NrSeryjny;
            bool parse1 = int.TryParse(Nr_Seryjny.Text, out NrSeryjny);

            string nazwa = Nazwa.Text;
            decimal cena;
            bool parse2 = decimal.TryParse(Cena.Text, out cena);
            string opis = Opis.Text;


            if (parse1 && !string.IsNullOrEmpty(nazwa) && parse2 && !string.IsNullOrEmpty(opis))
            {
                Narzedzie n = new Narzedzie(NrSeryjny, nazwa, cena, opis);

                mw.m.ListaNarzedzi.Add(n);
                mw.InitBinding();

                mw.m.Zapisz();
                this.Close();
            }
            else
            {
                MessageBox.Show("Złe dane!");
            }
        }
    }
}
