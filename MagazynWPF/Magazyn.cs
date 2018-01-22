using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagazynWPF
{
    [Serializable]
    public class Magazyn
    {
        public Magazyn(string nazwa, string adres) : this()
        {
            Nazwa = nazwa;
            Adres = adres;
        }

        public Magazyn()
        {
            ListaNarzedzi = new List<Narzedzie>();
        }

        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public int LiczbaNarzedzi { get; set; }

        public List<Narzedzie> ListaNarzedzi { get; set; }

        public void Dodaj(Narzedzie n)
        {
            this.ListaNarzedzi.Add(n);
            LiczbaNarzedzi++;
        }

        public void Usun(int NrSeryjny)
        {
            if (this.ListaNarzedzi.Any(x => x.NrSeryjny == NrSeryjny))
            {
                this.ListaNarzedzi.RemoveAll(x => x.NrSeryjny == NrSeryjny);
                LiczbaNarzedzi--;
            }
        }

        public void Zapisz()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Magazyn));
            FileStream plik = File.Create("Magazyny/" + this.Nazwa + ".xml");

            xs.Serialize(plik, this);
            plik.Close();
        }

        public static Magazyn Odczytaj(string nazwa)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Magazyn));
            string NazwaPliku = "Magazyny/" + nazwa + ".xml";
            if (File.Exists(NazwaPliku))
            {
                StreamReader plik = new StreamReader(NazwaPliku);
                Magazyn m = (Magazyn)xs.Deserialize(plik);
                plik.Close();

                return m;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.Nazwa);
            sb.AppendLine(this.Adres);
            sb.AppendLine(String.Format("Narzędzia: {0}", this.LiczbaNarzedzi));
            foreach (Narzedzie n in ListaNarzedzi)
            {
                sb.AppendLine(n.ToString());
            }
            return sb.ToString();
        }
    }
}
