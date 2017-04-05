using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class Util
    {
        public static int Round(int num, int round)
        {
            int retvalue = num;

            retvalue /= round;
            retvalue *= round;

            return retvalue;
        }

        public static double DgreeToRadian(double dgree)
        {
            return dgree / 180 * Math.PI;
        }

        public static double RadianToDgree(double radian)
        {
            return radian / Math.PI * 180;
        }

        public static double GetDegree(Vector2 from, Vector2 to)
        {
            return Math.Atan2(to.y - from.y, to.x - from.x) * 180 / 3.1415926535;
        }

        public static double Distance(Point p1, Point p2)
        {
            double x = p1.X - p2.X;
            double y = p1.Y - p2.Y;

            return Math.Sqrt(x * x + y * y);
        }

        public static Point ChangeToInGamePoint(Point p)
        {
            Point retp = new Point();

            retp.X = p.X;
            float dy = (720 - p.Y) - 360;
            retp.Y = (int)dy;

            return retp;
        }

        public static Point ChangeToMapTollPoint(Point ingameP)
        {
            Point retp = new Point();

            retp.X = ingameP.X;
            float dy = (360 - ingameP.Y);
            retp.Y = (int)dy;

            return retp;
        }
    }
}
