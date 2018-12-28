using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA1
{
    class Segment
    {
        public Point A { get; private set; }
        public Point B { get; private set; }
        public Segment(Point A, Point B)
        {
            this.A = A;
            this.B = B;
        }

        private static int Area(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }
        
        /// <summary>
        /// метод проверяет, пересекаются ли отрезки ab и cd
        /// </summary>
        public static bool Intersect(Point a1, Point a2, Point b1, Point b2)
        {

            if (a1.X >= a2.X)
                Utils.Swap(ref a1, ref a2);
            if (b1.X >= b2.X)
                Utils.Swap(ref b1, ref b2);
            int v1 = Math.Sign((long)(b2.X - b1.X) * (a1.Y - b1.Y) -
                     (long)(b2.Y - b1.Y) * (a1.X - b1.X));

            int v2 = Math.Sign((long)(b2.X - b1.X) * (a2.Y - b1.Y) -
                     (long)(b2.Y - b1.Y) * (a2.X - b1.X));

            int v3 = Math.Sign((long)(a2.X - a1.X) * (b1.Y - a1.Y) -
                     (long)(a2.Y - a1.Y) * (b1.X - a1.X));

            int v4 = Math.Sign((long)(a2.X - a1.X) * (b2.Y - a1.Y) -
                     (long)(a2.Y - a1.Y) * (b2.X - a1.X));
            return v1 * v2 < 0 && v3 * v4 < 0;
        }

    }
}
