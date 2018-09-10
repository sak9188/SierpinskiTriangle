using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SierpinskiTriangle
{
    public class Triangle
    {
        
        public Point[] Points { get; set; }

        public double Length { get; set; } = 1;

        public double RealLength { get { return Length * Size; } }

        public double midLength { get; set; }
        public double shortLength { get; set; }
        public double longLength { get; set; }

        public int Size { get; set; } = 400;

        public Point MidPoint { get; set; }

        public Triangle(Point[] points)
        {
            if (points.Length > 3)
            {
                throw new SystemException("你传的数组太长了");
            }
            Points = points;          
        }

        public Triangle(List<Point> points)
        {
            if (points.Count > 3)
            {
                throw new SystemException("你传的数组太长了");
            }
            Points = points.ToArray();        
        }

        public Triangle(Point midPoint)
        {
            MidPoint = midPoint;
            init();
        }

        public Triangle(Point midPoint, int size)
        {
            MidPoint = midPoint;
            Size = size;
            init();
        }

        private void init()
        {
            //初始化点数组
            this.Points = new Point[3];
            
            //初始化点
            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();

            double radians = (Math.PI / 180);

            //算出三边
            //longLength = this.Length;
            midLength = Length * Size / 2;
            shortLength = midLength * Math.Sin(30 * radians) / Math.Cos(30 * radians);
            longLength = shortLength * 2;

            //算出三点的具体位置
            p1.X = Convert.ToInt32(MidPoint.X - midLength);
            p1.Y = MidPoint.Y + Convert.ToInt32(shortLength);

            p2.X = MidPoint.X;
            p2.Y = MidPoint.Y - Convert.ToInt32(longLength);

            p3.X = Convert.ToInt32(MidPoint.X + midLength);
            p3.Y = MidPoint.Y + Convert.ToInt32(shortLength);
            
            //加入到Points中
            Points[0] = p1;
            Points[1] = p2;
            Points[2] = p3;

        }


    }
}
