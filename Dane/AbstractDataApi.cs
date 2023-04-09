using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        
        public abstract void TworzKule();
        public void ZacznijTworzycKule() { TworzKule(); }
        public abstract List<Kula> Kule {  get; }
        public abstract string IloscKulek { get; set; }
        public abstract int GranicaX { get;}
        public abstract int GranicaY { get;}
    }
}
