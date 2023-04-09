

namespace Dane
{
    public class Pudelko
    {

        private int wysokosc;
        private int szerokosc;

        public int Wysokosc { get { return wysokosc; } }
        public int Szerokosc { get { return szerokosc; } }

        public Pudelko(int height, int width)
        {
            this.wysokosc = height;
            this.szerokosc = width;
        }
        
    }
}