using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA1
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int n { get; set; } //номер
        public Point(int X, int Y, int n)
        {
            this.X = X;
            this.Y = Y;
            this.n = n;
        }

        public object Clone()
        {
            return new Point(this.X, this.Y, this.n);
        }
    }
}
