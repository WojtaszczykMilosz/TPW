using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public abstract class AbstractLogicApi
    {

        public abstract List<LogikaKuli> LogikaKul { get; }
        public abstract string IloscKulek { get; set; }
        public abstract void TworzLogikeKul();
        public abstract void PrzemieszczajKule();
        public abstract void ZacznijTworzycKule();
        public abstract int GranicaX { get; }
        public abstract int GranicaY { get; }

    }
}
