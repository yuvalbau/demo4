using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class Circle : Shape
    {
        public Circle(double r)
        {
            Radius = r;
        }

        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value > 0)
                    _radius = value;
                else
                    throw new Exception("The radius you gave is not valid");
            }
        }
        public override double CalcArea()
        {
          return (_radius*_radius*Math.PI);
        }

        public override string ToString()
        {
            return String.Format(" with Radius of:{0}", _radius);
        }
    }
}
