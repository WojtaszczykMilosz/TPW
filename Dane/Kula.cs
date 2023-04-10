
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Kula : INotifyPropertyChanged
    {
        public Kula() {
            predkoscX = predkosc;
            predkoscY = predkosc;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private int x;

        public int X {
            get { return x; } 
            set {
                x = value; 
                OnPropertyChanged();
            } 
        }

        private int y;

        public int Y { 
            get { return y; }
            set {
                y = value;
                OnPropertyChanged();
            } 
        }

        private int srednica;

        public int Srednica { get { return srednica; } set { srednica = value; } }

        private int predkoscX;
        public int PredkoscX { get { return predkoscX; } set { predkoscX = value; } }

        private int predkoscY;
        public int PredkoscY { get { return predkoscY; } set { predkoscY = value; } }

        private int predkosc = 2;
        public int Predkosc { get { return predkosc; } }

        public void Przemieszczaj()
        {
            X += PredkoscX;
            Y += PredkoscY; 
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

