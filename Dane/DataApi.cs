using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class DataApi:AbstractDataApi
    {
        private List<Kula> kule = new List<Kula>();

        public override List<Kula> Kule { get { return kule; } } 
        private Pudelko pudlo;

        

        private int iloscKulek;
        public override string IloscKulek { get { return Convert.ToString(iloscKulek); } set { iloscKulek = Convert.ToInt32(value); } }

        public override int Szerokosc { get { return pudlo.Szerokosc; } }

        public override int Wysokosc { get { return pudlo.Wysokosc; } }

        public DataApi(){
            pudlo = new Pudelko(400, 400);

        }

        

        public override void TworzKule()
        {
            kule.Clear();
            for (int i = 0; i < iloscKulek; i++)
            {
                Kula kula = new Kula();
                kula.Srednica = 20;
                GenerujPolozenieKuli(kula);
                kule.Add(kula);
            }
        }

        private void GenerujPolozenieKuli(Kula kula)
        {
            Random random = new Random();
            int x;
            int y;
            do
            {
                x = random.Next(pudlo.Szerokosc - kula.Srednica);
                y = random.Next(pudlo.Wysokosc - kula.Srednica);
            } while (JestKulaNaPozycji(x, y, kula.Srednica));
            kula.X = x;
            kula.Y = y;
        }

        private bool JestKulaNaPozycji(int x, int y, int srednica)
        {
           
            foreach (var kula in kule)
            {
                if (x + srednica >= kula.X && x <= kula.X + kula.Srednica)
                {
                    if (y + srednica >= kula.Y && y <= kula.Y + kula.Srednica)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

       

    }
}
