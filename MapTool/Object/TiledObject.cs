using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    abstract class TiledObject :
        BaseObject
    {
        protected List<Image> m_Images;
        protected Image m_CenterImage;

        protected bool m_IsClicked = false;
        protected bool m_IsObjectLeftClicked = false;
        protected bool m_IsObjectRightClicked = false;

        public override bool IsSelected
        {
            get { return m_IsClicked || m_IsObjectLeftClicked || m_IsObjectRightClicked; }
        }

        public override void ChangeImage(Bitmap bit)
        {
            
        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < m_Images.Count; i++)
                m_Images[i].Draw(g);
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

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsClicked)
                AutoSnap(e);

            if (m_IsObjectLeftClicked)
                LeftSizeMoveEvent(e);

            if (m_IsObjectRightClicked)
                RightSizeMoveEvent(e);
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            m_IsClicked = false;
            m_IsObjectLeftClicked = false;
            m_IsObjectRightClicked = false;
        }

        protected void LeftSizeMoveEvent(MouseEventArgs e)
        {
            Vector2 p = new Vector2(e.Location);

            if (p.x + m_CenterImage.Size.x < m_Images[0].WorldLeftTop.x)
            {
                Image img = new Image(ObjectName);
                img.Position = m_Images[0].Position - new Vector2(m_CenterImage.Size.x, 0);
                img.Size = m_CenterImage.Size;
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
                Image img = new Image(ObjectName);
                img.Position = m_Images[m_Images.Count - 1].Position + new Vector2(m_CenterImage.Size.x, 0);
                img.Size = m_CenterImage.Size;
                m_Images.Add(img);
                AddChild(img);
            }

            else if (p.x < m_Images[m_Images.Count - 1].WorldPosition.x &&
                m_Images.Count > 1 &&
                !m_Images[m_Images.Count - 1].Equals(m_CenterImage))
                m_Images.RemoveAt(m_Images.Count - 1);
        }

        protected Rectangle LeftBorder
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

        protected Rectangle RightBorder
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
