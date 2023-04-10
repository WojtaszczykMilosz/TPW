using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public abstract class AbstractDataApi
    {

        public abstract List<Kula> Kule { get; }
        public abstract string IloscKulek { get; set; }
        public abstract int Szerokosc { get; }
        public abstract int Wysokosc { get; }

        public void ZacznijTworzycKule() { TworzKule(); }

        public abstract void TworzKule();
        
        
    }
}
