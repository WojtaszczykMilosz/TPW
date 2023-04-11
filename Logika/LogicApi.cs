using System;
using System.Collections.Generic;
using System.Threading;
using Dane;

namespace Logika
{
    public class LogicApi : AbstractLogicApi
    {

        private CancellationTokenSource tworcaTokenow = null;
        private bool ruchKul = false;
        public bool RuchKul
        {
            get { return ruchKul; } 
        }

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

        private List<Thread> watkiKul = new List<Thread>();

        public List<Thread> WatkiKul
        {
            get { return watkiKul; }
        }

        private Thread informator = null;
        public Thread Informator
        {
            get { return informator; }
        }


        public override void TworzKule(int ileKul)
        {
            AnulujToken();
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

        public override void AnulujToken()
        {
            tworcaTokenow?.Cancel();

            ruchKul = false;
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

        private void GenerujPredkoscKuli(Kula kula)
        {
            

            kula.PredkoscY = LosujPredkosc();
            kula.PredkoscX = LosujPredkosc();

        }

        private int LosujPredkosc() {
            Random random = new Random();
            int r;
            do
            {
                r = random.Next(9) - 4;

            } while (r == 0);
            return r;
        }

        public override void PrzemieszczajKule()
        {
            if (!ruchKul && kule.Count != 0)
            {
                ruchKul = true;
                tworcaTokenow = new CancellationTokenSource();
                var token = tworcaTokenow.Token;
                int i = 1;
                foreach (var kula in kule)
                {
                    Thread thread = new Thread(() => CiaglyRuchKuli(kula, token));
                    thread.Name = "Kula numer: " + i;
                    thread.IsBackground = true;
                    thread.Start();
                    i++;
                    watkiKul.Add(thread);
                }
            }

        }

        private void CiaglyRuchKuli(Kula kula, CancellationToken token)
        {
            while (true)
            {
                 //Debug.WriteLine(Thread.CurrentThread.Name + " czeka na zamek");
                lock (zamek)
                {
                   // Debug.WriteLine(Thread.CurrentThread.Name + " jest w posiadaniu zamka");
                    if (token.IsCancellationRequested)
                    {
                        // Debug.WriteLine(Thread.CurrentThread.Name + " zakończyła ruch.");
                        return;
                    }
                    kula.Przemieszczaj();
                    ObslozKolizje(kula);
                }
                Thread.Sleep(10);
            }
        }

        public void ObslozKolizje(Kula kula)
        {
            if (SprawdzCzyWychodziPozaObszarX(kula))
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

        public override void RozpocznijInformatora(int czas)
        {
            if (ruchKul && kule.Count != 0 && tworcaTokenow != null)
            {
                var token = tworcaTokenow.Token;
                Thread thread = new Thread(() => InformatorStart(czas, token));
                thread.Name = "INFORMATOR";
                thread.IsBackground = true;
                thread.Start();
                informator = thread;
            }
        }

        private void InformatorStart(int czas,CancellationToken token)
        {
            while (true)
            {
                //Debug.WriteLine(Thread.CurrentThread.Name + " czeka na zamek");
                lock (zamek)
                {
                    //Debug.WriteLine(Thread.CurrentThread.Name + " jest w posiadaniu zamka");
                    if (token.IsCancellationRequested)
                    {
                        //Debug.WriteLine(Thread.CurrentThread.Name + " zakończył pracę.");
                        return;
                    }
                    dataApi.ZaktualizujKule(kule);
                }
                //dataApi.WypiszKule();
                Thread.Sleep(czas);
            }
        }
       

       

       

    }
}

