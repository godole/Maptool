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
        BaseObject
    {
        List<Image> m_Images;
        Image m_CenterImage;
        public bool IsFlip { get; set; }

        bool m_IsClicked = false;
        bool m_IsObjectLeftClicked = false;
        bool m_IsObjectRightClicked = false;

        public Niddle()
        {
            ObjectName = "niddle";
            m_CenterImage = new Image("niddle");
            m_CenterImage.Size = new Vector2(100, 100);
            Size = m_CenterImage.Size;
            AddChild(m_CenterImage);

            m_Images = new List<Image>();
            m_Images.Add(m_CenterImage);

            Judge = new ObjectJudge(this, ObjectName, -Program.MainMap.LineInterval.x + Size.x / 2);
            
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

            Judge = new ObjectJudge(this, ObjectName, -Program.MainMap.LineInterval.x + Size.x / 2);
        }

        public override void AutoSnap(MouseEventArgs e)
        {
            double minDistance = double.MaxValue;
            Node selectedobj = null;

            for (int i = 0; i < ObjectContainer.PlatformList.Count; i++)
            {
                BaseObject obj = ObjectContainer.PlatformList[i];
                Vector2 objScrPos = obj.WorldPosition;

                if (0 <= objScrPos.x || objScrPos.x <= 1240)
                {
                    double distance = Vector2.Distance(objScrPos, new Vector2(e.Location));
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
                    double distance = Vector2.Distance(objScrPos, new Vector2(e.Location));
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

                if (e.Y < selectedobj.WorldPosition.y)
                {
                    IsFlip = false;
                    y = -Size.y * Anchor.y - selectedobj.Size.y * selectedobj.Anchor.y;
                }
                else
                {
                    IsFlip = true;
                    y = Size.y * (1 - Anchor.y) + selectedobj.Size.y * (1 - selectedobj.Anchor.y);
                }

                WorldPosition = selectedobj.WorldPosition + new Vector2(selectedobj.Size.x * (0.5 - selectedobj.Anchor.x), y);
            }
        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < m_Images.Count; i++)
                m_Images[i].Draw(g);

            g.DrawRectangle(new Pen(Color.Black), LeftBorder);
            g.DrawRectangle(new Pen(Color.Black), RightBorder);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle((int)m_CenterImage.WorldLeftTop.x, (int)m_CenterImage.WorldLeftTop.y, (int)m_CenterImage.Size.x, (int)m_CenterImage.Size.y));
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (LeftBorder.Contains((Point)p))
                m_IsObjectLeftClicked = true;

            else if (RightBorder.Contains((Point)p))
                m_IsObjectRightClicked = true;

            else if (m_CenterImage.ContainsPoint(p))
                m_IsClicked = true;
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            m_IsClicked = false;
            m_IsObjectLeftClicked = false;
            m_IsObjectRightClicked = false;
        }

        public override bool IsSelected
        {
            get { return m_IsClicked || m_IsObjectLeftClicked || m_IsObjectRightClicked; }
        }

        protected void LeftSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (p.x + m_CenterImage.Size.x < m_Images[0].WorldLeftTop.x)
            {
                Image img = new Image("niddle");
                img.Position = m_Images[0].Position - new Vector2(m_CenterImage.Size.x, 0);
                img.Size = new Vector2(100, 100);
                m_Images.Insert(0, img);
                AddChild(img);
            }

            else if (p.x > m_Images[0].WorldPosition.x &&
                m_Images.Count > 1 &&
                !m_Images[0].Equals(m_CenterImage))
                m_Images.RemoveAt(0);
        }

        protected void RightSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (p.x - m_CenterImage.Size.x > m_Images[m_Images.Count - 1].WorldRightTop.x)
            {
                Image img = new Image("niddle");
                img.Position = m_Images[m_Images.Count - 1].Position + new Vector2(m_CenterImage.Size.x, 0);
                img.Size = new Vector2(100, 100);
                m_Images.Add(img);
                AddChild(img);
            }

            else if (p.x < m_Images[m_Images.Count - 1].WorldPosition.x &&
                m_Images.Count > 1 &&
                !m_Images[m_Images.Count - 1].Equals(m_CenterImage))
                m_Images.RemoveAt(m_Images.Count - 1);
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

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsClicked)
                AutoSnap(e);

            if (m_IsObjectLeftClicked)
                LeftSizeMoveEvent(e);

            if (m_IsObjectRightClicked)
                RightSizeMoveEvent(e);
        }

        public override void ChangeImage(Bitmap bit)
        {
            /*for(int i = 0; i < m_Images.Count; i++)
            {
                m_Images[i].image = bit;
                m_Images[i].Size = new Vector2(100, 100);
            }*/
        }

        Rectangle LeftBorder
        {
            get
            {
                Rectangle r = new Rectangle();
                Vector2 worldPos = m_Images[0].WorldLeftTop;

                r.X = (int)(worldPos.x);
                r.Y = (int)(worldPos.y);
                r.Width = Border;
                r.Height = (int)m_CenterImage.Size.y;

                return r;
            }
        }

        Rectangle RightBorder
        {
            get
            {
                Rectangle r = new Rectangle();
                Vector2 worldPos = m_Images[m_Images.Count - 1].WorldRightTop;

                r.X = (int)(worldPos.x - Border);
                r.Y = (int)(worldPos.y);
                r.Width = Border;
                r.Height = (int)m_CenterImage.Size.y;

                return r;
            }
        }
    }
}
