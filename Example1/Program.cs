using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example1
{

    public class Rectangle
    {
        public Point LeftUpperCorner { get; set; }
        public double Heigth { get; set; }
        public double Width { get; set; }
        public Rectangle()
        {
            LeftUpperCorner = new Point();
            Heigth = 100;
            Width = 100;
        }
    }

    public class Point : IComparable
    {
        public int x;
        public int y;
        public Point()
        {
            x = 10;
            y = 10;
        }

        public int CompareTo(object obj)
        {
            Point p = obj as Point;
            if (this.x > p.x)
            {
                return 1;
            }
            if (this.y > p.y)
            {
                return 1;
            }

            if (this.x == p.x && this.y == p.y)
            {
                return 0;
            }

            return -1;
        }

        public override string ToString()
        {
            return string.Format("x: {0}, y: {1}", x, y);
        }
    }

    public class MyPoint : Point
    {

    }

    class Program
    {
        static void Main(string[] args)
        {

            F3();
        }

        private static void F3()
        {
            SortedSet<MyPoint> set = new SortedSet<MyPoint>();
            set.Add(new MyPoint { x = 20, y = 20 });
            set.Add(new MyPoint { x = 11, y = 20 });
            set.Add(new MyPoint { x = 22, y = 20 });
            set.Add(new MyPoint { x = 20, y = 20 });
            set.Add(new MyPoint { x = 20, y = 21 });

            foreach (MyPoint p in set)
            {
                Console.WriteLine(p.ToString());
            }
        }

        private static void F2()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Rectangle));
            FileStream fs = new FileStream("rec.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Rectangle r1 = new Rectangle();
            xs.Serialize(fs, r1);

            fs.Close();

            FileStream fs2 = new FileStream("rec.txt", FileMode.Open, FileAccess.Read);
            Rectangle r2 = xs.Deserialize(fs2) as Rectangle;
            fs.Close();
        }

        private static void F1()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Point));
            FileStream ms = new FileStream("point.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Point p1 = new Point();
            p1.x = 200;
            xs.Serialize(ms, p1);
            ms.Close();

            FileStream fs = new FileStream("point.txt", FileMode.Open, FileAccess.Read);
            Point p2 = xs.Deserialize(fs) as Point;
            fs.Close();
        }
    }
}
