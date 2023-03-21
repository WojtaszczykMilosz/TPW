using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Kula> kule = new ObservableCollection<Kula>();

        private int iloscKulek;

        private Pudelko pudlo;
        

        public MainViewModel()
        {
            Start = new RelayCommand(TworzKule, null);
            pudlo = new Pudelko(400,400);
        }

        public ICommand Start {
            get;
            set; 
        }     



        public int Height { get {  return pudlo.Height; } }

        public int Width { get { return pudlo.Width; } }    

        public string IloscKulek
        { 
            get { return Convert.ToString(iloscKulek); } 
            set {
                iloscKulek = Convert.ToInt32(value);
                OnPropertyChanged("OrbQuantity");
            } 
        }


        public void TworzKule(object obj)
        {
            Random r = new Random();
            kule.Clear();
            for (int i = 0; i < iloscKulek; i++) {
                Kula kula = new Kula();
                kula.Promien = 20;
                kula.X = r.Next(pudlo.Width - kula.Promien);
                kula.Y = r.Next(pudlo.Height - kula.Promien);
                kula.Vx = 1;
                kula.Vy = 1;
                kule.Add(kula);
            }
            
        }

        private readonly object ZamekKulka = new object();

        private void Ruch()
        {
            
            foreach(Kula kulka in Kule)
                {
                Thread t = new Thread(() => {
                    while (true)
                    {
                        lock (ZamekKulka)
                        {
                            kulka.przemieszczaj(pudlo);
                        }

                        Thread.Sleep(5);
                    }
                });
                t.Start();

            }
        }



        public ObservableCollection<Kula> Kule {
            get { return kule; } 
            set {
                if (value.Equals(kule)) { return; }
                kule = value;
                OnPropertyChanged("Kule");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
