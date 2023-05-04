using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dane
{
    public class DataApi : AbstractDataApi
    {
        
        private List<Kula> kule = new List<Kula>();

        public override List<Kula> Kule 
        {
            get { return kule; } 
        } 
        private Pudelko pudlo;

        public override int Szerokosc 
        {
            get { return pudlo.Szerokosc; } 
        }

        public override int Wysokosc
        { 
            get { return pudlo.Wysokosc; } 
        }

        public DataApi(){
            pudlo = new Pudelko(500, 500);  
        }

        public override void PrzepiszKule(List<Kula> kule)
        {
            this.kule = new List<Kula>();
            foreach(var kula in kule) 
            {
                this.kule.Add(kula.Kopiuj());
            }
        }

        public override void ZaktualizujKule(List<Kula> kule)
        {
            if (kule.Count == this.kule.Count) 
            {
                for (int i = 0; i < kule.Count; i++)
                {
                    this.kule[i].ZmienWlasciwosci(kule[i]);
                }
            }
            
        }

        public override void WypiszKule()
        {
            int i = 1;
            foreach(var kula in this.kule)
            {
                Debug.WriteLine("Kula numer: " + i);
                Debug.WriteLine("X = " + kula.X + ", Y = " + kula.Y + ", vX = " + kula.PredkoscX + ", vY = " + kula.PredkoscY);
                Debug.WriteLine("-------------------------");
                i++;
            }
        }





    }
}
