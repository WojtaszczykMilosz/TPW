
using System;
using System.Collections.ObjectModel;
using Dane;
using Logika;


namespace Model
{
    public class MainModel
    {
        private AbstractLogicApi logicApi;

        private ObservableCollection<LogikaKuli> kule = new ObservableCollection<LogikaKuli>();
        public ObservableCollection<LogikaKuli> Kule { get { return kule; } }
        public string IloscKulek { get { return logicApi.IloscKulek; } set { logicApi.IloscKulek = value; } }

        public int Szerokosc { get { return logicApi.Szerokosc; } }
        public int Wysokosc { get { return logicApi.Wysokosc; } }


        public MainModel() { 
            logicApi = LogicApiFactory.CreateLogicApi();
            
        }
        
        
        public void WczytajKule()
        {
            foreach (var logika in logicApi.LogikaKul) { 
                kule.Add(logika);
            }
        }

        public void Start()
        {
            kule.Clear();
            logicApi.ZacznijTworzycKule();
            WczytajKule();
            logicApi.PrzemieszczajKule();
        }
    }
}
