using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public abstract class AbstractDataApi
    {

        public abstract List<Kula> Kule { get; }
        public abstract int Szerokosc { get; }
        public abstract int Wysokosc { get; }
        public abstract void PrzepiszKule(List<Kula> kule);
        public abstract void ZaktualizujKule(List<Kula> kule);
        public abstract void WypiszKule();
    }
}
