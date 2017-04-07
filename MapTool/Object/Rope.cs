using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Rope :
        BaseObject
    {
        Image m_RopeImage;
        Image m_LineHitImage;
        Image m_LineImage;

        bool m_IsClick = false;
        bool m_IsHitboxClick = false;
        bool m_IsMoved = false;

        double m_LineAngle;

        public Rope()
        {
            ObjectName = "rope";
            m_RopeImage = new Image("rope");
            m_RopeImage.Size = new Vector2(100, 100);
            Size = m_RopeImage.Size;
            AddChild(m_RopeImage);

            m_LineImage = new Image("ropeline");
            m_LineImage.Anchor = new Vector2(0.5f, 0.0f);
            m_RopeImage.AddChild(m_LineImage);

            m_LineHitImage = new Image("ropehitbox");
            m_LineHitImage.Position = new Vector2(0, 50);
            AddChild(m_LineHitImage);

            m_LineAngle = 0;

            Judge = new ObjectJudge(this, ObjectName, m_LineHitImage.Position.x);
        }

        public Rope(RopeObjectData data)
        {
            ObjectName = "rope";
            m_RopeImage = new Image("rope");
            m_RopeImage.Size = new Vector2(100, 100);
            Size = m_RopeImage.Size;
            AddChild(m_RopeImage);

            m_LineImage = new Image("ropeline");
            m_LineImage.Anchor = new Vector2(0.5f, 0.0f);
            m_LineImage.Size.y = data.Length;
            m_LineImage.Angle = (float)data.Angle + 90;
            m_RopeImage.AddChild(m_LineImage);

            m_LineHitImage = new Image("ropehitbox");
            m_LineHitImage.Position.x = data.HitPosX;
            m_LineHitImage.Position.y = data.HitPosY;
            AddChild(m_LineHitImage);

            Judge = new ObjectJudge(this, ObjectName, m_LineHitImage.Position.x);

            Position = new Vector2(data.PositionX, data.PositionY);
        }

        public override void Draw(Graphics g)
        {
            m_LineHitImage.Draw(g);
            m_LineImage.Draw(g);
            m_RopeImage.Draw(g);
        }

        public override bool IsSelected
        {
            get
            {
                return m_IsClick || m_IsHitboxClick;
            }
        }

        public override void AutoSnap(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (m_RopeImage.ContainsPoint(p))
            {
                m_IsClick = true;
                return;
            }

            if (m_LineHitImage.ContainsPoint(p))
                m_IsHitboxClick = true;
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (m_IsClick)
            {
                Position = new Vector2(Util.Round((int)(p.x - Program.MainMap.Position.x), (int)Program.MainMap.LineInterval.x) + (int)(Program.MainMap.LineInterval.x / 2), 0);

                m_IsMoved = true;
            }

            if (m_IsHitboxClick)
            {
                m_LineHitImage.WorldPosition = CalculateNormalSnap(p);
                m_LineImage.Angle = (float)Util.GetDegree(WorldPosition, p) - 90.0f;
                m_LineImage.Size.y = (int)m_LineHitImage.Position.Length;

                Judge.m_DeltaPosX = m_LineHitImage.Position.x;
            }
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            m_IsClick = m_IsHitboxClick = false;
        }

        public override void Save(ref MapData mapdata)
        {
            RopeObjectData data = new RopeObjectData();

            data.PositionX = (int)Position.x;
            data.PositionY = (int)Position.y;
            data.HitPosX = (int)m_LineHitImage.Position.x;
            data.HitPosY = (int)m_LineHitImage.Position.y;

            data.Angle = 90 - (m_LineAngle - 180);
            data.Length = (int)(Vector2.Distance(WorldPosition, m_LineHitImage.WorldPosition));

            mapdata.RopeObjectList.Add(data);
        }

        public override void Release()
        {
            base.Release();
        }

        public override void ChangeImage(Bitmap bit)
        {
            //m_RopeImage.image = bit;
        }
    }
}
