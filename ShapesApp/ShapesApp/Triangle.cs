using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class Triangle :Shape
    {
        private double _height;
        private double _base;

        public Triangle(double h, double b)
        {
            Height = h;
            Base = b;
        }

        public double Base
        {
            get { return _base; }
            set
            {
                if (value > 0)
                _base = value;
                else
                    throw new Exception("The base you gave is not valid");
            }
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

        public override double CalcArea()
        {
            return (Height*Base)/2;
        }
        public override string ToString()
        {
            return String.Format(" with height of:{0} and base of:{1}", _height, _base);
        }
    }
}
