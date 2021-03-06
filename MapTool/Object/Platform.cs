﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MapTool
{
    class Platform :
        TiledObject
    {
        public Platform()
        {
            ObjectName = "platform";
            m_CenterImage = new Image(ObjectName);
            m_CenterImage.Size = new Vector2(100, m_CenterImage.Size.y / m_CenterImage.Size.x * 100);
            Size = m_CenterImage.Size;
            AddChild(m_CenterImage);

            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);

            Judge = new ObjectJudge(this, "jump", -Program.MainMap.LineInterval.x);
        }

        public Platform(NormalObjectlData data)
        {
            ObjectName = "platform";
            m_CenterImage = new Image(ObjectName);
            m_CenterImage.Size = new Vector2(100, m_CenterImage.Size.y / m_CenterImage.Size.x * 100);
            Size = m_CenterImage.Size;
            AddChild(m_CenterImage);

            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);

            Position = new Vector2(data.PositionX, data.PositionY);
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

        public override void Save(ref MapData mapdata)
        {
            NormalObjectlData data = new NormalObjectlData();

            data.ObjectType = ObjectName;

            data.PositionX = (int)Position.x;
            data.PositionY = (int)Position.y;
            data.Width = (int)Size.x;
            data.Height = (int)Size.y;

            mapdata.NormalObjectList.Add(data);
        }
    }
}
