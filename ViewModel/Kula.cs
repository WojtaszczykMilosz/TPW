using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Kula:INotifyPropertyChanged
    {
        public Kula() { }

        
        
        private int promien;
        private float x;
        private float y;
        private float vx;
        private float vy;

        public float Vx { get { return vx; } set { vx = value; } }
        public float Vy { get { return vy; } set { vy = value; } }

        public int Promien
        {
            get { return promien; }
            set
            {
                promien = value;

            }
        }


        public float X {
            get { return x; } 
            set { x = value;
               
            } }
        public float Y { 
            get { return y; }
            set
            {
                y = value;
            
            } }

        public void przemieszczaj(Pudelko pudlo)
        {
            if (pudlo == null) return;
            
            if (X + Vx > pudlo.Width - Promien || X + Vx < 0)
            {
                Vx = -Vx;
            }
            if (Y + Vy > pudlo.Height - Promien || Y + Vy < 0)
            {
                Vy = -Vy;
            }
            X += vx;
            Y += vy; 
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
