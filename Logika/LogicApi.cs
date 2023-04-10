using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Dane;

namespace Logika
{
    public class LogicApi : AbstractLogicApi
    {

        

        private AbstractDataApi dataApi;

        private List<Kula> kule= new List<Kula>();
        public override List<Kula> Kule { get { return kule; } }

        public override int Szerokosc { get { return dataApi.Szerokosc; } }

        public override int Wysokosc { get { return dataApi.Wysokosc; } }

        private readonly object zamek = new object();

        public LogicApi(AbstractDataApi dataApi = null)
        {
            if (dataApi == null)
                this.dataApi = DataApiFactory.CreateDataApi();
            else
                this.dataApi = dataApi;

        }

        


        public override void TworzKule(int ileKul)
        {
            kule.Clear();
            for (int i = 0; i < ileKul; i++)
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
                x = random.Next(Szerokosc - kula.Srednica);
                y = random.Next(Wysokosc - kula.Srednica);
            } while (JestKulaNaPozycji(x, y, kula.Srednica));
            kula.X = x;
            kula.Y = y;
        }

        public bool JestKulaNaPozycji(int x, int y, int srednica)
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




        

        public override void PrzemieszczajKule()
        {

            foreach (var kula in kule)
            {
                Thread t = new Thread(() => {
                    while (true)
                    {
                        lock (zamek)
                        {
                            kula.Przemieszczaj();
                            ObslozKolizje(kula);
                        }
                        Thread.Sleep(5);
                    }
                });
                t.IsBackground = true;
                t.Start();
            }
        }

        public void ObslozKolizje(Kula kula)
        {
            if(SprawdzCzyWychodziPozaObszarX(kula))
            {
                kula.PredkoscX = -kula.PredkoscX;
            } 
          
            if (SprawdzCzyWychodziPozaObszarY(kula))
            {
                kula.PredkoscY = -kula.PredkoscY;
            }
           
        }

        public bool SprawdzCzyWychodziPozaObszarX(Kula kula)
        {
            return kula.X + kula.PredkoscX + kula.Srednica > Szerokosc || kula.X + kula.PredkoscX < 0;
        }

        public bool SprawdzCzyWychodziPozaObszarY(Kula kula)
        {
            return kula.Y + kula.PredkoscY + kula.Srednica > Wysokosc || kula.Y + kula.PredkoscY < 0;
        }

        

        




    }
}

