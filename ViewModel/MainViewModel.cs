using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Logika;
using Model;
namespace ViewModel
{
    public class MainViewModel
    {

        private MainModel model;

        public ObservableCollection<LogikaKuli> Kule { get { return model.Kule; } }
        public int Szerokosc { get { return model.X; } }
        public int Wysokosc { get { return model.Y; } }
        public string IloscKulek { get { return model.IloscKulek; } set { model.IloscKulek = value; } } 
        public ICommand Start { get; set; }

        public MainViewModel()
        {
            this.model = new MainModel();
            Start = new RelayCommand(model.Start);
            
        }
    }

}