using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDLIlib1
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return "(X=" + this.X + "," + this.Y + ")";

        }
    }
}
