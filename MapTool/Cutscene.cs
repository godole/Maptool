using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class Cutscene
    {
        int m_Border;
        bool m_IsClicked = false;
        bool m_IsObjectLeftClicked = false;
        bool m_IsObjectRightClicked = false;
        bool m_PrevCollision = false;

        Rectangle m_BoundingBox;

        public Cutscene(Rectangle r)
        {
            BoundingBox = r;
            m_Border = 10;
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Aqua);
            g.FillRectangle(new SolidBrush(Color.Black), m_BoundingBox);
            g.DrawRectangle(p, m_BoundingBox);
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            if (LeftBorder.Contains(e.Location))
                m_IsObjectLeftClicked = true;

            else if (RightBorder.Contains(e.Location))
                m_IsObjectRightClicked = true;

            else if (BoundingBox.Contains(e.Location))
                m_IsClicked = true;
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (LeftBorder.Contains(e.Location) || RightBorder.Contains(e.Location) ||
                m_IsObjectLeftClicked || m_IsObjectRightClicked)
            {
                if (!m_PrevCollision)
                {
                    m_PrevCollision = true;
                    Main.ActiveForm.Cursor = Cursors.SizeWE;
                }
            }
            else
            {
                if(m_PrevCollision)
                    Main.ActiveForm.Cursor = Cursors.Arrow;
                m_PrevCollision = false;
            }

            if (m_IsObjectLeftClicked)
            {
                Point left = new Point(BoundingBox.X + BoundingBox.Width, BoundingBox.Y);

                m_BoundingBox.Location = new Point(e.X, BoundingBox.Y);
                m_BoundingBox.Width = left.X - e.X;
            }

            if(m_IsObjectRightClicked)
            {
                m_BoundingBox.Width = e.X - BoundingBox.X;
            }

            if (m_IsClicked)
                m_BoundingBox.X = e.X - BoundingBox.Width / 2;
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            m_IsClicked = false;
            m_IsObjectLeftClicked = false;
            m_IsObjectRightClicked = false;
        }

        private Rectangle LeftBorder
        {
            get
            {
                Rectangle r = new Rectangle();

                r.X = BoundingBox.X;
                r.Y = BoundingBox.Y;
                r.Width = m_Border;
                r.Height = BoundingBox.Height;

                return r;
            }
        }

        private Rectangle RightBorder
        {
            get
            {
                Rectangle r = new Rectangle();

                r.X = BoundingBox.X + BoundingBox.Width - m_Border;
                r.Y = BoundingBox.Y;
                r.Width = m_Border;
                r.Height = BoundingBox.Height;

                return r;
            }
        }

        public Rectangle BoundingBox { get { return m_BoundingBox; } set { m_BoundingBox = value; } }

        public Point Position
        {
            get { return m_BoundingBox.Location; }
            set { m_BoundingBox.Location = value; }
        }

        public int PositionX
        {
            get { return m_BoundingBox.Location.X; }
            set { m_BoundingBox.Location = new Point(value, m_BoundingBox.Location.Y); }
        }
    }
}
