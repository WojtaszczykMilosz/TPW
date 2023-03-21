using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModel
{
    public class Pudelko
    {


        private int height;
        private int width;

        public Pudelko(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int Height { get { return height; } }
        public int Width { get { return width; } }

        
    }
}