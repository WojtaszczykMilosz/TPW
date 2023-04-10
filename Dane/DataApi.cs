using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class DataApi:AbstractDataApi
    {
        
        //private List<Kula> kule = new List<Kula>();

        //public override List<Kula> Kule { get { return kule; } } 
        private Pudelko pudlo;

        public override int Szerokosc { get { return pudlo.Szerokosc; } }

        public override int Wysokosc { get { return pudlo.Wysokosc; } }

        public DataApi(){
            pudlo = new Pudelko(400, 400);
            
            //kule = new List<Kula>();    
        }

        

        

       

    }
}
