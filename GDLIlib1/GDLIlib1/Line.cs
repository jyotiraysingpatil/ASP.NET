using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDLIlib1
{
    public sealed class Line:Shape,IPrintable,Istorable
    {
        public Point StartP { get; set; }
        public Point EndP { get; set; }

        public static int count;
        public Line()
        {
            count++;
            this.StartP = new Point();
            this.EndP = new Point();
            
        }

        public Line(Point stpoint, Point endpont , int thicknes)
        {
            count++;
            this.StartP = stpoint;
            this.EndP = endpont;
            this.thickness = thicknes;
        }
        private int thickness;

        public int Thickness
        {
            get { return thickness; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("line not correct");
                }
                this.thickness = value;
            }
        }







        public override void Draw()
        {
            Console.WriteLine("Drawing a line ");
        }
        //interface methods override
        void IPrintable.Print()
        {
            Console.WriteLine("Printing Line.....");
        }

        void Istorable.Store() {
            Console.WriteLine("Storing ....");
        }
        void Istorable.Restore()
        {
            Console.WriteLine("Restoring.....");
        }



    }
}
