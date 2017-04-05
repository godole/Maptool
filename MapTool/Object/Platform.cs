using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MapTool
{
    class Platform :
        NormalObject
    {
        public Platform() :
            base("platform")
        {
            Judge = new ObjectJudge(this, "platform", -Program.MainMap.LineInterval.x + Size.x / 2);
        }

        public Platform(NormalObjectlData data) :
            base(data)
        {
            ObjectName = "platform";
        }

        public override void Release()
        {
            base.Release();
            ObjectContainer.PlatformList.Remove(this);
        }

        public override void AutoSnap(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);
            Vector2 pos = CalculateNormalSnap(new Vector2(e.Location));

            if(p.y < 0)
            {
                WorldPosition = new Vector2(pos.x, Size.y * Anchor.y);
                return;
            }

            else if (Map.GroundPositionY < p.y)
            {
                WorldPosition = new Vector2(pos.x, Map.GroundPositionY - Size.y * (1 - Anchor.y));
                return;
            }

            for(int i = 1; i <= 4; i++)
            {
                if(Program.MainMap.LineInterval.y * (i - 1) < p.y && p.y < Program.MainMap.LineInterval.y * i)
                {
                    if (p.y < Program.MainMap.LineInterval.y * (i - 0.5))
                        p.y = (int)(Program.MainMap.LineInterval.y * (i - 1) + Size.y * Anchor.y);
                    else
                        p.y = (int)(Program.MainMap.LineInterval.y * i - Size.y * (1 - Anchor.y));

                    break;
                }
            }

            pos.y = p.y;

            WorldPosition = pos;
        }
    }
}
