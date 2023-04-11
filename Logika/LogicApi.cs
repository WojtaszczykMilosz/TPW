using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dane;

namespace Logika
{
    public class LogicApi : AbstractLogicApi
    {

        private CancellationTokenSource TworcaTokenow = null;
        private bool ruchKul = false;

        private readonly AbstractDataApi dataApi;

        private List<Kula> kule= new List<Kula>();
        public override List<Kula> Kule 
        { 
            get { return kule; }
        }

        public override int Szerokosc
        { 
            get { return dataApi.Szerokosc; } 
        }

        public override int Wysokosc 
        { 
            get { return dataApi.Wysokosc; }
        }

        private readonly object zamek = new object();

        public LogicApi()
        {
            dataApi = DataApiFactory.CreateDataApi();
        }

        


        public override void TworzKule(int ileKul)
        {
            Cancel();
            kule.Clear();
            for (int i = 0; i < ileKul; i++)
            {
                Kula kula = new Kula();
                kula.Srednica = 20;
                GenerujPolozenieKuli(kula);
                GenerujPredkoscKuli(kula);
                kule.Add(kula);
            }
            dataApi.PrzepiszKule(kule);

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

        private void GenerujPredkoscKuli(Kula kula)
        {
            Random random = new Random();
            int r;
            do
            {
                r = random.Next(9) - 2;

            } while (r == 0);
            
            kula.PredkoscY = r;

            do
            {
                r = random.Next(9) - 2;

            } while (r == 0);

            kula.PredkoscX = r;

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

        private void CiaglyRuchKuli(Kula kula, CancellationToken token)
        {
            while (true)
            {
                Debug.WriteLine(Thread.CurrentThread.Name + " czeka na zamek");
                lock (zamek)
                {
                    Debug.WriteLine(Thread.CurrentThread.Name + " jest w posiadaniu zamka");
                    if (token.IsCancellationRequested)
                    {
                        Debug.WriteLine(Thread.CurrentThread.Name + " zakończyła ruch.");
                        return;
                    }
                    kula.Przemieszczaj();
                    ObslozKolizje(kula);
                }
                Thread.Sleep(10);
            }
        }

        public override void PrzemieszczajKule()
        {
            if (!ruchKul && kule.Count != 0) 
            {
                ruchKul = true;
                TworcaTokenow = new CancellationTokenSource();
                var token = TworcaTokenow.Token;
                int i = 1;
                foreach (var kula in kule)
                {
                    Thread thread = new Thread(() => CiaglyRuchKuli(kula, token));
                    thread.Name = "Kula numer: " + i;
                    thread.IsBackground = true;
                    thread.Start();
                    i++;
                }
            }
           
        }
        private void Informator(CancellationToken token)
        {
            while (true)
            {
                Debug.WriteLine(Thread.CurrentThread.Name + " czeka na zamek");
                lock (zamek)
                {
                    Debug.WriteLine(Thread.CurrentThread.Name + " jest w posiadaniu zamka");
                    if (token.IsCancellationRequested)
                    {
                        Debug.WriteLine(Thread.CurrentThread.Name + " zakończył pracę.");
                        return;
                    }
                    dataApi.ZaktualizujKule(kule);
                }
                dataApi.WypiszKule();
                Thread.Sleep(2000);
            }
        }
        public override void RozpocznijInformatora()
        {
            if (ruchKul && kule.Count != 0)
            {
                var token = TworcaTokenow.Token;
                Thread thread = new Thread(() => Informator(token));
                thread.Name = "INFORMATOR";
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public override void Cancel()
        {
            TworcaTokenow?.Cancel();
            ruchKul = false;
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

