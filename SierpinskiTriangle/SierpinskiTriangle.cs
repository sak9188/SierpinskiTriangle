using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SierpinskiTriangle
{
    public class SierpinskiTriangle
    {
        private readonly int lev = 8;

        public Point GeneratePoint { get; set; }

        public Graphics Graphics { get; set; }
        
        public SierpinskiTriangle(Graphics graphics, Point generatePoint)
        {
            this.Graphics = graphics;
            this.GeneratePoint = generatePoint;

        }

        public void Paint()
        {
            if (Graphics == null)
                throw new SystemException("没有画板怎么画");
            Pen p = new Pen(Brushes.Red);
            p.Width = 1;
            Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //一个很简单的迭代算法
            //递归应该比我的要简单
            List<Triangle> lists = new List<Triangle>();            
            lists.Add(new Triangle(GeneratePoint));
            for (int i = 0; i < lev; i++)
            {
                foreach (var item in lists)
                {
                    Graphics.DrawPolygon(p, item.Points);
                    //Graphics.DrawEllipse(p, item.MidPoint.X, item.MidPoint.Y, 2, 2);
                }
                
                List<Triangle> lists2 = new List<Triangle>();
                foreach (var item in lists)
                {
                    lists2.AddRange(GenerateSierTriangle(item));
                    lists = lists2;
                }
            }            

        }

        //计算出谢尔宾斯基三角形的三个方向的三角形
        public List<Triangle> GenerateSierTriangle(Triangle tra)
        {
            //初始化数组
            List<Triangle> triangles = new List<Triangle>();

            //初始化变量
            Point p1 = new Point();
            Point p2 = new Point();
            Point p3 = new Point();

            //计算初具体的点
            //！！！！一定要和你自己在类中设的点顺序一样，否则会有问题
            p1.X = Convert.ToInt32(tra.MidPoint.X - tra.RealLength / 4);
            p1.Y = Convert.ToInt32(tra.MidPoint.Y + tra.shortLength / 2);
                  
            p2.X = Convert.ToInt32(tra.MidPoint.X);
            p2.Y = Convert.ToInt32(tra.MidPoint.Y - tra.shortLength);
            
            p3.X = Convert.ToInt32(tra.MidPoint.X + tra.RealLength / 4);
            p3.Y = Convert.ToInt32(tra.MidPoint.Y + tra.shortLength / 2);
            
            triangles.Add(new Triangle(p1, tra.Size / 2));
            triangles.Add(new Triangle(p2, tra.Size / 2));
            triangles.Add(new Triangle(p3, tra.Size / 2));

            return triangles;

        }

    }
}
