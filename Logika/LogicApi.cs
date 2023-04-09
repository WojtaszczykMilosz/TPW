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

        private List<LogikaKuli> logikaKul = new List<LogikaKuli>();
        public override List<LogikaKuli> LogikaKul { get { return logikaKul; }}


        public override string IloscKulek { get { return dataApi.IloscKulek; } set { dataApi.IloscKulek = value; } }

        public override int GranicaX { get { return dataApi.GranicaX; } }

        public override int GranicaY { get { return dataApi.GranicaY; } }
        private readonly object zamek = new object();

        public LogicApi()
        {
            dataApi = DataApiFactory.CreateDataApi();
        }

        
        
        public override void TworzLogikeKul()
        {
            logikaKul.Clear();
            List<Kula> kule = dataApi.Kule;
            foreach (var kula in kule)
            {
                logikaKul.Add(new LogikaKuli(kula));
            }
        }

        public override void PrzemieszczajKule()
        {

            foreach (var logikaKuli in logikaKul)
            {
                Thread t = new Thread(() => {
                    while (true)
                    {
                        lock (zamek)
                        {
                            logikaKuli.przemieszczaj();
                            Kolizje(logikaKuli);
                        }
                        Thread.Sleep(5);
                    }
                });
                t.Start();
            }
        }

        public void Kolizje(LogikaKuli logika)
        {
            if(KulaWychodziPozaObszarX(logika))
            {
                logika.PredkoscX = -logika.PredkoscX;
            } 
          
            if (KulaWychodziPozaObszarY(logika))
            {
                logika.PredkoscY = -logika.PredkoscY;
            }
           
        }

        private bool KulaWychodziPozaObszarX(LogikaKuli kula)
        {
            return kula.X + kula.PredkoscX + kula.Srednica >= GranicaX || kula.X + kula.PredkoscX <= 0;
        }

        private bool KulaWychodziPozaObszarY(LogikaKuli kula)
        {
            return kula.Y + kula.PredkoscY + kula.Srednica >= GranicaY || kula.Y + kula.PredkoscY <= 0;
        }

        public override void ZacznijTworzycKule()
        {
            dataApi.ZacznijTworzycKule();
            TworzLogikeKul();
           
        }

        




    }
}

