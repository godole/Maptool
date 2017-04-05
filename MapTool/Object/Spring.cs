using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Spring : 
        BaseObject
    {
        bool m_IsClicked = false;
        bool m_IsObjectLeftClicked = false;
        bool m_IsObjectRightClicked = false;

        List<Image> m_Images;
        Image m_CenterImage;

        bool m_IsUpStart = false;

        bool m_IsSizeClicked = false;
        int m_SizeCount = 1;

        int m_CurPrevIndex = 0;

        public Spring()
        {
            ObjectName = "spring"; 
            m_CenterImage = new Image("spring");
            m_CenterImage.Size = new Vector2(100, 100);
            Judge = new ObjectJudge(this, ObjectName, 100 / 2);
            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);
            AddChild(m_CenterImage);
        }

        public Spring(SpringObjectData data)
        {
            ObjectName = "spring";
            m_CenterImage = new Image("spring");
            m_CenterImage.Size = new Vector2(100, 100);
            Judge = new ObjectJudge(this, ObjectName, 100 / 2);
            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);
            AddChild(m_CenterImage);
            m_SizeCount = data.SizeCount;
            m_IsUpStart = data.IsUpStart;

            for(int i = 1; i < data.Count; i++)
            {
                CreateNextSpring();
            }

            Position = new Vector2(data.PositionX, data.PositionY);
        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < m_Images.Count; i++)
                m_Images[i].Draw(g);

            if (m_Images.Count > 1)
                g.DrawRectangle(new Pen(Color.Black), SizeBorder);

            g.DrawRectangle(new Pen(Color.Black), RightBorder);
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (RightBorder.Contains((Point)p))
            {
                m_IsObjectRightClicked = true;
            }

            else if (m_CenterImage.ContainsPoint(p))
            {
                m_IsClicked = true;
            }

            else if(m_Images.Count > 1)
            {
                if (SizeBorder.Contains((Point)p))
                    m_IsSizeClicked = true;
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsClicked)
                AutoSnap(e);

            if (m_IsObjectLeftClicked)
                LeftSizeMoveEvent(e);

            if (m_IsObjectRightClicked)
                RightSizeMoveEvent(e);

            if (m_IsSizeClicked)
                SizeMoveEvent(e);
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            m_IsClicked = false;
            m_IsObjectLeftClicked = false;
            m_IsObjectRightClicked = false;
            m_IsSizeClicked = false;
        }

        public override bool IsSelected
        {
            get { return m_IsClicked || m_IsObjectLeftClicked || m_IsObjectRightClicked || m_IsSizeClicked; }
        }

        private void LeftSizeMoveEvent(MouseEventArgs e)
        {
        }

        private void RightSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);
            var lastImage = m_Images[m_Images.Count - 1];

            if (p.x > lastImage.WorldPosition.x + m_CenterImage.Size.x + ((int)Program.MainMap.LineInterval.x * m_SizeCount))
            {
                if(m_Images.Count == 1)
                {
                    if (e.Y < m_CenterImage.WorldPosition.y)
                        m_IsUpStart = true;
                    else
                        m_IsUpStart = false;
                }

                CreateNextSpring();
            }

            else if (p.x < lastImage.WorldPosition.x + m_Images[0].Size.x / 2 &&
                m_Images.Count > 1)
                m_Images.RemoveAt(m_Images.Count - 1);
        }

        private void SizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);
            if(m_IsUpStart)
            {
                if (e.Y < m_Images[1].WorldPosition.y - (int)Program.MainMap.LineInterval.y)
                    m_SizeCount++;
                else if (e.Y > m_Images[1].WorldPosition.y && m_SizeCount > 1)
                    m_SizeCount--;
            }

            else
            {
                if (e.Y > m_Images[1].WorldPosition.y + (int)Program.MainMap.LineInterval.y)
                    m_SizeCount++;
                else if (e.Y < m_Images[1].WorldPosition.y && m_SizeCount > 1)
                    m_SizeCount--;
            }
            for(int i = 0; i < m_Images.Count; i++)
            {
                m_Images[i].Position.x = m_CenterImage.Position.x + (i * (int)Program.MainMap.LineInterval.x * m_SizeCount);

                if (i % 2 == 0)
                    continue;

                m_Images[i].Position.y = m_CenterImage.Position.y + ((int)Program.MainMap.LineInterval.y * (m_IsUpStart ? -1 : 1)) * m_SizeCount;
            }
        }

        public override void PlaySound(long curtime)
        {
            double pos = Program.MainMap.PlayerMoveSpeed * curtime / 1000;
            Vector2 deltaPos = m_Images[m_CurPrevIndex].Position + Position;

            if (pos > deltaPos.x + m_Images[m_CurPrevIndex].Size.x / 2)
            {
                m_CurPrevIndex++;
                SoundManager.Play(ObjectName);

                if(m_CurPrevIndex == m_Images.Count)
                {
                    m_CurPrevIndex = 0;
                    IsPlayed = true;
                }
            }
        }

        public override void Save(ref MapData mapdata)
        {
            SpringObjectData data = new SpringObjectData();
            
            data.PositionX = (int)Position.x;
            data.PositionY = (int)Position.y;
            data.IsUpStart = m_IsUpStart;
            data.Count = m_Images.Count;
            data.SizeCount = m_SizeCount;

            mapdata.SpringObjectList.Add(data);
        }

        public override void ChangeImage(Bitmap bit)
        {
            /*for (int i = 0; i < m_Images.Count; i++)
            {
                m_Images[i].image = bit;
                m_Images[i].Size = new Vector2(100, 100);
            }*/
        }

        void CreateNextSpring()
        {
            var lastImage = m_Images[m_Images.Count - 1];
            Image img = new Image("spring");
            img.Position.x = lastImage.Position.x + ((int)Program.MainMap.LineInterval.x * m_SizeCount);
            int ydelta = (m_Images.Count % 2 == (m_IsUpStart ? 1 : 0) ? (int)Program.MainMap.LineInterval.y : -(int)Program.MainMap.LineInterval.y) * m_SizeCount;
            img.Position.y = lastImage.Position.y - ydelta;
            img.Size = new Vector2(100, 100);
            m_Images.Add(img);
            AddChild(img);
        }

        Rectangle RightBorder
        {
            get
            {
                Rectangle r = new Rectangle();
                Vector2 rt = m_Images[m_Images.Count - 1].WorldRightTop;

                r.X = (int)(rt.x - Border);
                r.Y = (int)rt.y;
                r.Width = Border;
                r.Height = (int)m_CenterImage.Size.y;

                return r;
            }
        }

        Rectangle SizeBorder
        {
            get
            {
                Rectangle r = new Rectangle();

                r.X = (int)m_Images[0].WorldPosition.x;
                if (m_IsUpStart)
                    r.Y = (int)(m_Images[1].WorldPosition.y - m_Images[0].Size.y);
                else
                    r.Y = (int)(m_Images[0].WorldPosition.y + m_Images[0].Size.y);
                r.Width = (int)(m_Images[0].Size.x + (m_Images.Count - 1) * Program.MainMap.LineInterval.x);
                r.Height = (int)m_CenterImage.Size.y;

                return r;
            }
        }
    }
}
