using System;

namespace Dane
{
    public class Kula : NotifiedObject
    {
        public Kula() {
            Random rand = new Random();
            masa = rand.Next(40)+1;

        }

        private double x;

        public double X 
        {
            get { return x; } 
            set 
            {
                x = value; 
                OnPropertyChanged(nameof(X));
            } 
        }

        private double y;

        public double Y 
        { 
            get { return y; }
            set 
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            } 
        }

        private int srednica;

        public int Srednica 
        {
            get { return srednica; }
            set { srednica = value; } 
        }

        private double predkoscX;
        public double PredkoscX
        { 
            get { return predkoscX; } 
            set { predkoscX = value; }
        }

        private double predkoscY;
        public double PredkoscY 
        {
            get { return predkoscY; }
            set { predkoscY = value; }
        }

        private int masa;
        public int Masa
        {
            get { return masa; }
            set { masa = value; }
        }

       

        public void Przemieszczaj()
        {
            X += PredkoscX;
            Y += PredkoscY; 
        }
        public Kula Kopiuj()
        {
            Kula kopia = new Kula();
            kopia.X = X;
            kopia.Y = Y;
            kopia.PredkoscX = PredkoscX;
            kopia.PredkoscY = PredkoscY;
            return kopia;
        }

        public void ZmienWlasciwosci(Kula k)
        {
            this.X = k.X;
            this.Y = k.Y;
            this.predkoscX = k.PredkoscX;
            this.predkoscY = k.PredkoscY;
        }

    }
}

