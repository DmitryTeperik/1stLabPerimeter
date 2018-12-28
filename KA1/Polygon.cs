using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA1
{
    class Polygon
    {
        public List<Point> points { get; protected set; } //динамический массив точек 
        
        public Polygon()
        {
            points = new List<Point>();
        }
        
        public void AddPoint(int X, int Y)
        {
            points.Add(new Point(X, Y, points.Count));
        }
       
        //алгоритм генерации следующей перестановки
        public void nextPermutation()
        {
            for (int i = points.Count - 2; i > 0; --i)
            {
                if (points[i].n < points[i + 1].n)
                {
                    int min = i + 1;
                    for (int j = i + 1; j < points.Count; ++j)
                    {
                        if ((points[j].n < points[min].n) && (points[j].n > points[i].n))
                        {
                            min = j;
                        }
                    }
                    points.Swap(i, min);
                    points.Reverse(i + 1, points.Count - i - 1);
                    return;
                }
            }
            points = null;
        }

        /// <summary>
        /// метод проверяет, что в многоугольнике нет пересечений
        /// </summary>
        /// <returns>true - если пересечений нет</returns>
        private bool NoIntersections()
        {
            for(int i = 0; i < points.Count; ++i)
            {
                for(int j = i + 1; j < points.Count; ++j)
                {
                    if(Segment.Intersect(points[i], points[(i + 1) % points.Count], points[j], points[(j + 1) % points.Count]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Вычисление периметра (в этом методе самопересекающиеся многоугольники не рассматриваются, проверка 
        /// на самопересечения осуществляется методом NoIntersections)
        /// </summary>
        /// <returns>Периметр</returns>
        private double PerPol()
        {
            double sum = 0;
            double edge = 0;
            int i;
            if (points.Count < 3)
                return -1;

            for (i = 0; i < points.Count - 1; i++)
            {
                edge = Math.Sqrt(Math.Pow(points[i + 1].X - points[i].X, 2) + Math.Pow(points[i + 1].Y - points[i].Y, 2));
                sum += edge;
            }
            edge = Math.Sqrt(Math.Pow(points[0].X - points[points.Count - 1].X, 2) + Math.Pow(points[0].X - points[points.Count - 1].X, 2));
            sum += edge;
            return sum;
        }

        public virtual double CreatePolygon(ref long progress, ref long total)
        {
            total = Utils.FactNaive(points.Count - 1);
            progress = 0;
            double perimeter;
            double MaxPerimeter = 0;
            List<Point> res = new List<Point>();
            while(points != null)
            {
           
                if (NoIntersections())
                {
                    perimeter = PerPol();
                    if (MaxPerimeter < perimeter) {
                        MaxPerimeter = perimeter;
                        res = new List<Point>(points);
                    }  
                }
                nextPermutation();
                ++progress;
            }
            points = res;
            progress = total;
            return MaxPerimeter;
        }
    }
}
