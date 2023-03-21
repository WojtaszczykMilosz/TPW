

namespace ViewModel
{
    public class Pudelko
    {

        private int wysokosc;
        private int szerokosc;

        public int Wysokosc { get { return wysokosc; } }
        public int Szereokosc { get { return szerokosc; } }

        public Pudelko(int height, int width)
        {
            this.wysokosc = height;
            this.szerokosc = width;
        }
        
    }
}