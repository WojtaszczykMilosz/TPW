using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Logika;
using Model;
using Dane;
using System.Windows.Media;

namespace ViewModel
{
    public class MainViewModel
    {

        private MainModel model;

        public ObservableCollection<Kula> Kule 
        {
            get { return model.Kule; }
        }
        public int Szerokosc
        {
            get { return model.Szerokosc; } 
        }
        public int Wysokosc 
        {
            get { return model.Wysokosc; } 
        }
        public string IloscKulek 
        {
            get { return model.IloscKulek; } 
            set { model.IloscKulek = value; } 
        } 
        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }
        public ICommand StworzKule { get; set; }

        //public object Color(double masa)
        //{
        //    double hue = masa * 240 / 40;
        //    Color color = ;
        //    color = color.FromHsb(hue, 100, 100);
        //    return new SolidColorBrush();
        //}

        public MainViewModel()
        {
            this.model = new MainModel();
            Start = new RelayCommand(model.Start);
            Stop = new RelayCommand(model.Stop);
            StworzKule = new RelayCommand(model.StworzKule);
            
        }
    }

}