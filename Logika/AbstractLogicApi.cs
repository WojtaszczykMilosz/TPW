using System.Collections.Generic;
using Dane;

namespace Logika
{
    public abstract class AbstractLogicApi
    {

        public abstract List<Kula> Kule { get; }
        public abstract void TworzKule(int ile);
        public abstract void PrzemieszczajKule();
        public abstract void Cancel();
        public abstract void RozpocznijInformatora();
        public abstract int Szerokosc { get; }
        public abstract int Wysokosc { get; }

    }
}
