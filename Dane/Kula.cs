namespace Dane
{
    public class Kula : NotifiedObject
    {
        public Kula() {
            predkoscX = predkosc;
            predkoscY = predkosc;
        }

        private int x;

        public int X 
        {
            get { return x; } 
            set 
            {
                x = value; 
                OnPropertyChanged(nameof(X));
            } 
        }

        private int y;

        public int Y 
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

        private int predkoscX;
        public int PredkoscX
        { 
            get { return predkoscX; } 
            set { predkoscX = value; }
        }

        private int predkoscY;
        public int PredkoscY 
        {
            get { return predkoscY; }
            set { predkoscY = value; }
        }

        private int predkosc = 2;
        public int Predkosc 
        {
            get { return predkosc; }
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

