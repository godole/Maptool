using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    public class Vector2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Point p)
        {
            x = p.X;
            y = p.Y;
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public static explicit operator Point(Vector2 vec)
        {
            return new Point((int)vec.x, (int)vec.y);
        }

        public static explicit operator PointF(Vector2 vec)
        {
            return new PointF((float)vec.x, (float)vec.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator -(Point v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.x, v1.Y - v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Point v2)
        {
            return new Vector2(v1.x - v2.X, v1.y - v2.Y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator +(Vector2 p1, Point p2)
        {
            return new Vector2(p1.x + p2.X, p1.y + p2.Y);
        }

        public static Vector2 operator +(Point p1, Vector2 p2)
        {
            return new Vector2(p1.X + p2.x, p1.Y + p2.y);
        }

        public static double Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
            
        public double Dot(Vector2 v)
        {
            return x * v.x + y * v.y;
        }

        public static Vector2 operator * (Vector2 v, double o)
        {
            return new Vector2(v.x * o, v.y * 0);
        }

        public static Vector2 operator * (double o, Vector2 v)
        {
            return new Vector2(v.x * o, v.y * 0);
        }

        public static Vector2 operator /(Vector2 v, double o)
        {
            return new Vector2(v.x / o, v.y / 0);
        }

        public static Vector2 operator /(double o, Vector2 v)
        {
            return new Vector2(v.x / o, v.y / 0);
        }

        public static double Distance(Vector2 v1, Vector2 v2)
        {
            return Math.Sqrt(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2));
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public static Vector2 RotateFrom(Vector2 v, Vector2 center, float angle)
        {
            Vector2 retval = new Vector2();

            double nAngle = angle / 180.0f * Math.PI;
            retval.x = Math.Cos(nAngle) * (v.x - center.x) - Math.Sin(nAngle) * (v.y - center.y) + center.x;
            retval.y = Math.Sin(nAngle) * (v.x - center.x) + Math.Cos(nAngle) * (v.y - center.y) + center.y;

            return retval;
        }
    }
}
