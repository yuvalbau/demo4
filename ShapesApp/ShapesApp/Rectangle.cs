using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class Rectangle : Shape
    {
        private double _height;
        private double _width;

        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value > 0) 
                _height = value;
                else
                    throw new Exception("The height you gave is not valid");
            }
        }

        public double Width
        {
            get { return _width; }
            
            set {
                if (value > 0)
                _width = value;
                else
                    throw new Exception("The width you gave is not valid");
                }
        
        }

        public override double CalcArea()
        {
            return _height*_width ;
        }
        public override string ToString()
        {
            return String.Format(" with height of:{0} and width of:{1}", _height,_width);
        }
    }
}
