using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Logika
{
    public class LogikaKuli : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Kula kula;

        public int X { get {  return kula.X; } }    
        public int Y { get { return kula.Y; } }

        public int Srednica { get { return kula.Srednica; } }

        private int predkoscX;
        public int PredkoscX { get { return predkoscX; } set { predkoscX = value; } }
        
        private int predkoscY;
        public int PredkoscY { get { return predkoscY; } set { predkoscY = value; } }

        

        private int predkosc = 2;
        public int Predkosc { get { return predkosc; } }

        public LogikaKuli(Kula kula) {
            this.kula = kula;
            predkoscX = predkosc;
            predkoscY = predkosc;
        }


        public void Przemieszczaj() {
            kula.X += predkoscX;
            kula.Y += predkoscY;
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
