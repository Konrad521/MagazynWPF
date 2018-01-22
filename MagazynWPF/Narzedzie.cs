using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWPF
{
    [Serializable]
    public class Narzedzie
    {
        public Narzedzie(int nrSeryjny, string nazwa, decimal cena, string opis)
        {
            NrSeryjny = nrSeryjny;
            Nazwa = nazwa;
            Cena = cena;
            Opis = opis;
        }
        

        public Narzedzie()
        {
        }

        public int NrSeryjny { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", this.NrSeryjny, this.Nazwa, this.Cena, this.Opis);
        }
        
    }
}
