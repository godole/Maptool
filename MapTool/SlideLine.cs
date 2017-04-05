using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class SlideLine : Node, 
        IPreview
    {
        public SlideLine()
        {
            Size = new Vector2(30, 0);
            Anchor = new Vector2(0.5, 0.0);
        }

        public bool IsPlayed { get; set; }

        public bool IsOnScreen()
        {
            double deltax = WorldPosition.x;

            if (deltax > 0 && deltax < 1280)
                return true;

            else
                return false;
        }

        public void PlaySound(long curtime)
        {
            throw new NotImplementedException();
        }

        public Vector2 EndPosition
        {
            set
            {
                Vector2 worldPos = WorldPosition;
                Angle = (float)Util.GetDegree(worldPos, value) - 90.0f;
                Size.y = Vector2.Distance(worldPos, value);
            }
        }

        public void Draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.Transform = WorldMatrix;

            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle((int)(-Anchor.x * Size.x), (int)(-Anchor.y * Size.y), (int)Size.x, (int)Size.y));

            g.Transform = new Matrix();
        }
    }
}
