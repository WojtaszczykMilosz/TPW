using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel
    {

        private ObservableCollection<Kula> kule = new ObservableCollection<Kula>();
        public ObservableCollection<Kula> Kule { get { return kule; } set { kule = value; } }


        private int iloscKulek;
        public string IloscKulek { get { return Convert.ToString(iloscKulek); } set { iloscKulek = Convert.ToInt32(value); } }

        private Pudelko pudlo;
        public int Wysokosc { get { return pudlo.Wysokosc; } }

        public int Szerokosc { get { return pudlo.Szereokosc; } }

        public MainViewModel()
        {
            Start = new RelayCommand(TworzKule);
            pudlo = new Pudelko(400,400);

        }

        public ICommand Start { get; set; }     

        public void TworzKule()
        {
            Random random = new Random();
            kule.Clear();
            for (int i = 0; i < iloscKulek; i++) {
                Kula kula = new Kula();
                kula.Srednica = 20;
                int x = random.Next(pudlo.Szereokosc - kula.Srednica);
                int y = random.Next(pudlo.Wysokosc - kula.Srednica);
                while (!SprawdzKoordynaty(x, y, kula.Srednica))
                {
                     x = random.Next(pudlo.Szereokosc - kula.Srednica);
                     y = random.Next(pudlo.Wysokosc - kula.Srednica);
                }
                kula.X = x;
                kula.Y = y;
                kule.Add(kula);
            }
            
        }

        public bool SprawdzKoordynaty(int x, int y, int srednica)
        {
            foreach(var kula in kule)
            {
                /*if (((x >= kula.X) && (x <= kula.X + kula.Srednica)) || ((x + promien >= kula.X) && (x + promien <= kula.X + kula.Srednica)))
                {
                    if (((y >= kula.Y) && (y <= kula.Y + kula.Srednica)) || ((y + promien >= kula.Y) && (y + promien <= kula.Y + kula.Srednica)))
                    {
                        return false;
                    }
                }*/

                if (x + srednica >= kula.X && x <= kula.X + kula.Srednica)
                {
                    if (y + srednica >= kula.Y && y <= kula.Y + kula.Srednica)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
