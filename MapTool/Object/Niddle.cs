using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Niddle :
        TiledObject
    {
        public bool IsFlip { get; set; }

        public Niddle()
        {
            ObjectName = "niddle";
            m_CenterImage = new Image("niddle");
            m_CenterImage.Size = new Vector2(100, 100);
            Size = m_CenterImage.Size;
            AddChild(m_CenterImage);

            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);

            Judge = new ObjectJudge(this, "jump", -Program.MainMap.LineInterval.x);
            
            IsFlip = false;
        }

        public Niddle(NiddleObjectData data)
        {
            ObjectName = "niddle";
            m_CenterImage = new MapTool.Image("niddle");
            m_CenterImage.Size = new Vector2(100, 100);
            AddChild(m_CenterImage);
            m_Images = new List<Image>();
            for (int i = 0; i < data.Count; i++)
            {
                var img = new Image("niddle");
                img.Position = new Vector2(Position.x + m_CenterImage.Size.x * i, 0);
                img.Size = new Vector2(100, 100);
                m_Images.Add(img);
                AddChild(img);
            }

            IsFlip = data.IsFlip;
            Position = new Vector2(data.PositionX, data.PositionY);

            Judge = new ObjectJudge(this, "jump", -Program.MainMap.LineInterval.x);
        }

        public override void AutoSnap(MouseEventArgs e)
        {
            double minDistance = double.MaxValue;
            Node selectedobj = null;
            Vector2 p = new Vector2(e.Location);

            for (int i = 0; i < ObjectContainer.PlatformList.Count; i++)
            {
                BaseObject obj = ObjectContainer.PlatformList[i];
                Vector2 objScrPos = obj.WorldPosition;

                if (0 <= objScrPos.x || objScrPos.x <= 1240)
                {
                    double distance = Vector2.Distance(objScrPos, p);
                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        selectedobj = obj;
                    }
                }
            }

            var groundImageList = Program.MainMap._Ground.list;

            for (int i = 0; i < groundImageList.Count; i++)
            {
                Image obj = groundImageList[i];

                if (obj == null)
                    continue;

                Vector2 objScrPos = obj.WorldPosition;

                if (0 <= objScrPos.x || objScrPos.x <= 1240)
                {
                    double distance = Vector2.Distance(objScrPos, p);
                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        selectedobj = obj;
                    }
                }
            }

            if (selectedobj != null)
            {
                double y = 0;

                if (p.y < selectedobj.WorldPosition.y)
                {
                    IsFlip = false;
                    y = -Size.y * Anchor.y - selectedobj.Size.y * selectedobj.Anchor.y;
                }
                else
                {
                    IsFlip = true;
                    y = Size.y * (1 - Anchor.y) + selectedobj.Size.y * (1 - selectedobj.Anchor.y);
                }

                WorldPosition = new Vector2(CalculateNormalSnap(p).x, selectedobj.WorldPosition.y+ y);
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            g.DrawRectangle(new Pen(Color.Black), LeftBorder);
            g.DrawRectangle(new Pen(Color.Black), RightBorder);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle((int)m_CenterImage.WorldLeftTop.x, (int)m_CenterImage.WorldLeftTop.y, (int)m_CenterImage.Size.x, (int)m_CenterImage.Size.y));
        }

        public override void Save(ref MapData mapdata)
        {
            NiddleObjectData data = new NiddleObjectData();

            data.PositionX = (int)Position.x;
            data.PositionY = (int)Position.y;
            data.Count = m_Images.Count;
            data.IsFlip = IsFlip;

            mapdata.NiddleObjectList.Add(data);
        }
    }
}
