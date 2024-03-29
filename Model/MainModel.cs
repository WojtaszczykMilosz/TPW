﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Dane;
using Logika;


namespace Model
{
    public class MainModel
    {
        private readonly AbstractLogicApi logicApi;

        private ObservableCollection<Kula> kule = new ObservableCollection<Kula>();
        public ObservableCollection<Kula> Kule 
        { 
            get { return kule; } 
        }
        

        private int iloscKulek;
        public string IloscKulek
        {
            get { return Convert.ToString(iloscKulek); }
            set { iloscKulek = Convert.ToInt32(value); }
        }
        public int Szerokosc 
        {
            get { return logicApi.Szerokosc; } 
        }
        public int Wysokosc 
        {
            get { return logicApi.Wysokosc; } 
        }


        public MainModel() 
        { 
            logicApi = LogicApiFactory.CreateLogicApi();
        }
        
        
        public void WczytajKule()
        {
            foreach (var logika in logicApi.Kule) 
            { 
                kule.Add(logika);
            }
        }

        public void Start()
        {
            logicApi.PrzemieszczajKule();
            logicApi.RozpocznijInformatora(3000);
            //logicApi.ZapiszDoXML();
        }
        public void StworzKule()
        {
            kule.Clear();
            logicApi.TworzKule(iloscKulek);
            WczytajKule();
            Logger.NewSession();

        }
        public void Stop()
        {
            Debug.WriteLine(DateTime.Now.Millisecond);
            logicApi.AnulujToken();
            //logicApi.ZapiszDoXML();
        }
    }
}
