using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    abstract class NormalObject :
        BaseObject
    {
        protected bool m_IsClicked = false;
        protected bool m_IsObjectLeftClicked = false;
        protected bool m_IsObjectRightClicked = false;
        protected Image m_Image;

        public NormalObject(string objectType)
        {
            m_Image = new Image(objectType);
            m_Image.Size = new Vector2(100, 100);
            AddChild(m_Image);
            Size = new Vector2(100, 100);
        }

        public NormalObject(NormalObjectlData data)
        {
            m_Image = new Image(data.ObjectType);
            m_Image.Size = new Vector2(data.Width, 100);
            AddChild(m_Image);
            ObjectName = data.ObjectType;
            Position = new Vector2(data.PositionX, data.PositionY);
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (LeftBorder.Contains((Point)p))
                m_IsObjectLeftClicked = true;

            else if (RightBorder.Contains((Point)p))
                m_IsObjectRightClicked = true;

            else if (m_Image.ContainsPoint(p))
                m_IsClicked = true;
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsClicked)
                AutoSnap(e);

            /*if (m_IsObjectLeftClicked)
                LeftSizeMoveEvent(e);

            if (m_IsObjectRightClicked)
                RightSizeMoveEvent(e);*/
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

        protected virtual void LeftSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = e.Location - Program.MainMap.Position;
            Vector2 left = new Vector2(Position.x + Size.x, Position.y);

            Position.x = p.x;
            Size.x = left.x - p.x;
        }

        protected virtual void RightSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = e.Location - Program.MainMap.Position;

            Size.x = p.x - Position.x;
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

        private Rectangle LeftBorder
        {
            get
            {
                Rectangle r = new Rectangle();
                Vector2 WorldPos = WorldLeftTop;

                r.X = (int)WorldPos.x;
                r.Y = (int)WorldPos.y;
                r.Width = Border;
                r.Height = (int)m_Image.Size.y;

                return r;
            }
        }

        private Rectangle RightBorder
        {
            get
            {
                Rectangle r = new Rectangle();
                Vector2 WorldPos = WorldRightTop;

                r.X = (int)(WorldPos.x - Border);
                r.Y = (int)(WorldPos.y);
                r.Width = Border;
                r.Height = (int)m_Image.Size.y;

                return r;
            }
        }

        public override void Draw(Graphics g)
        {
            m_Image.Draw(g);
            g.DrawRectangle(new Pen(Color.Black), LeftBorder);
            g.DrawRectangle(new Pen(Color.Black), RightBorder);
        }

        public override Vector2 Size
        {
            get
            {
                if (m_Image == null)
                    return new Vector2();

                return m_Image.Size;
            }

            set
            {
                if (m_Image == null)
                    return;

                m_Image.Size = value;
            }
        }

        public override void ChangeImage(Bitmap bit)
        {
            //m_Image.image = bit;
        }
    }
}
