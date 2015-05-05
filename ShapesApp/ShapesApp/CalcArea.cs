using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    
    class CalcArea
    {
       private static List<Shape> shapeList = new List<Shape>();
       private static int i;
       private  static bool loadObject=false; 
       private static void Main(string[] args)
       {
                     
           while (i != 111)
           {

               Console.WriteLine("please choose the shape you want to calculate the area:");
               Console.WriteLine("1.Circle\n2.Triangle\n3.Rectangle\n\n4.Print all shapes \n5.Calculate area of all shapes\n\n type '111' to exit");
               try
               {
               i = int.Parse(Console.ReadLine());
               
                   switch (i)
                   {
                       case 1:
                           Console.WriteLine("please choose radius of circle:");
                           double r = double.Parse(Console.ReadLine());
                           Shape s1 = new Circle(r);
                           Console.WriteLine("Area of circle=" + s1.CalcArea() + "\n");
                           shapeList.Add(s1);
                           break;

                       case 2:
                           Console.WriteLine("please choose height of triangle:");
                           double h = double.Parse(Console.ReadLine());
                           Console.WriteLine("please choose base of triangle:");
                           double b = double.Parse(Console.ReadLine());
                           Shape s2 = new Triangle(h, b);
                           Console.WriteLine("Area of triangle=" + s2.CalcArea() + "\n");
                           shapeList.Add(s2);
                           break;

                       case 3:
                           Console.WriteLine("please choose length of Rectangle:");
                           double w = double.Parse(Console.ReadLine());
                           Console.WriteLine("please choose height of Rectangle:");
                           double j = double.Parse(Console.ReadLine());
                           Shape s3 = new Rectangle(w, j);
                           Console.WriteLine("Area of Rectangle=" + s3.CalcArea() + "\n");
                           shapeList.Add(s3);
                           break;

                       case 4:
                          
                           if (!loadObject)
                           {
                           CalcArea.LoadObjects();
                           }
                           loadObject = true;
                           CalcArea.PrintAllObjects();
                           break;

                       case 5:
                           if (!loadObject)
                           {
                               CalcArea.LoadObjects();
                           }
                           loadObject = true;
                           CalcArea.PrintAreaOfAllObjects();
                           break;
                   }
               }


               catch(Exception e)
               {
                   Console.WriteLine("Exception caught -'{0}'", e.Message);

                        }
           }
       }

        public static void LoadObjects()
        {
            Circle ci = new Circle(4);
            Triangle tr = new Triangle(5, 5);
            Rectangle re = new Rectangle(9, 5);
            shapeList.Add(ci);
            shapeList.Add(tr);
            shapeList.Add(re);

 
        }
        public static void PrintAreaOfAllObjects()
        {
             for (int i = 0; i < shapeList.Count; i++)
             {
                double area= shapeList[i].CalcArea();
                Console.WriteLine("Area of {0}{1} is:{2}", shapeList[i].GetType(), shapeList[i].ToString(), area);
             }

        }
        public static void PrintAllObjects()
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                
                Console.WriteLine(" {0}", shapeList[i].GetType());
            }

        }

    }
}
