using System.Collections.Generic;
using Dane;

namespace Logika
{
    public abstract class AbstractLogicApi
    {

        public abstract List<Kula> Kule { get; }
        public abstract void TworzKule(int ile);
        public abstract void PrzemieszczajKule();
        public abstract void AnulujToken();
        public abstract void ObslozKolizje(Kula kula);
        public abstract void ObslozKolizjeZeSciania(Kula kula);
        public abstract bool SprawdzCzyWychodziPozaObszarXzPrawej(Kula kula);
        public abstract bool SprawdzCzyWychodziPozaObszarXzLewej(Kula kula);
        public abstract bool SprawdzCzyWychodziPozaObszarYzGory(Kula kula);
        public abstract bool SprawdzCzyWychodziPozaObszarYzDolu(Kula kula);
        public abstract bool JestKulaNaPozycji(double x, double y, int srednica);
        public abstract void RozpocznijInformatora(int czas);
        public abstract int Szerokosc { get; }
        public abstract int Wysokosc { get; }

    }
}
