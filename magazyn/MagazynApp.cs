
static void Main(string[] args)
{
        
}

namespace Magazyn

{ 

    public class Produkt 

    { 

        public string Nazwa { get; set; } 

        public int Ilosc { get; set; } 

 

        public Produkt(string nazwa, int ilosc) 

        { 

            Nazwa = nazwa; 

            Ilosc = ilosc; 

        } 

    } 

 

    public class Magazyn 

    { 

        private List<Produkt> produkty; 

 

        public Magazyn() 

        { 

            produkty = new List<Produkt>(); 

        } 

 

        public bool dodajProdukt(string nazwa, int ilosc) 

        { 

            if (string.IsNullOrWhiteSpace(nazwa) || ilosc <= 0) 

                return false; 

 

            var istniejący = produkty.FirstOrDefault(p => p.Nazwa == nazwa); 

            if (istniejący != null) 

            { 

                istniejący.Ilosc += ilosc; 

            } 

            else 

            { 

                produkty.Add(new Produkt(nazwa, ilosc)); 

            } 

            return true; 

        } 

 

        public bool zdejmijProdukt(string nazwa, int ilosc) 

        { 

            var produkt = produkty.FirstOrDefault(p => p.Nazwa == nazwa); 

            if (produkt == null || ilosc <= 0 || produkt.Ilosc < ilosc) 

                return false; 

 

            produkt.Ilosc -= ilosc; 

 

            if (produkt.Ilosc == 0) 

                produkty.Remove(produkt); 

 

            return true; 

        } 

 

        public int sprawdzStan(string nazwa) 

        { 

            var produkt = produkty.FirstOrDefault(p => p.Nazwa == nazwa); 

            return produkt?.Ilosc ?? 0; 

        } 

    } 

}