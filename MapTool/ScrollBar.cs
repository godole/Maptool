using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MapTool
{
    class ScrollBar : 
        Node
    {
        public delegate void MoveCallback(float percent);
        public event MoveCallback ScrollMoveCallback;

        int m_StandardLength;
        int m_MaxLength;
        int m_ButtonSize;

        Rectangle m_DrawRect;
        Rectangle m_SmallDrawRect;
        Rectangle m_LeftButtonRect;
        Rectangle m_RightButtonRect;

        //Cutscene[] m_Cutscene;

        public bool IsClicked { get; set; }
        
        public ScrollBar(int standard, int max, Point pos, Size size, int buttonSize)
        {
            m_StandardLength = standard;
            m_MaxLength = max;
            m_ButtonSize = buttonSize;
            m_DrawRect.X = pos.X + m_ButtonSize;
            m_DrawRect.Y = pos.Y;
            m_DrawRect.Width = size.Width - m_ButtonSize * 2;
            m_DrawRect.Height = size.Height;

            m_SmallDrawRect.X = pos.X + buttonSize;
            m_SmallDrawRect.Y = pos.Y;
            float ratio = (float)m_StandardLength / m_MaxLength * m_DrawRect.Width * 20;
            m_SmallDrawRect.Width = (int)ratio;
            m_SmallDrawRect.Height = size.Height;

            m_LeftButtonRect.X = pos.X;
            m_LeftButtonRect.Y = pos.Y;
            m_LeftButtonRect.Width = m_ButtonSize;
            m_LeftButtonRect.Height = size.Height;

            m_RightButtonRect.X = size.Width - m_ButtonSize;
            m_RightButtonRect.Y = pos.Y;
            m_RightButtonRect.Width = m_ButtonSize;
            m_RightButtonRect.Height = size.Height;

            /*m_Cutscene = new Cutscene[3];
            m_Cutscene[0] = new Cutscene(new Rectangle(1200, pos.Y, 100, size.Height));
            m_Cutscene[1] = new Cutscene(new Rectangle(size.Width / 2 - 50, pos.Y, 100, size.Height));
            m_Cutscene[2] = new Cutscene(new Rectangle(size.Width - buttonSize - 50, pos.Y, 100, size.Height));*/
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.FillRectangle(new SolidBrush(Color.White), m_DrawRect);
            g.DrawRectangle(p, m_DrawRect);

            g.FillRectangle(new SolidBrush(Color.Black), m_SmallDrawRect);
            g.DrawRectangle(p, m_SmallDrawRect);

            g.FillRectangle(new SolidBrush(Color.White), m_LeftButtonRect);
            g.DrawRectangle(p, m_LeftButtonRect);

            g.FillRectangle(new SolidBrush(Color.White), m_RightButtonRect);
            g.DrawRectangle(p, m_RightButtonRect);

            /*for (int i = 0; i < 3; i++)
                m_Cutscene[i].Draw(g);*/
        }

        public void ScrollBarMouseDown(object sender, MouseEventArgs e)
        {
            if(m_SmallDrawRect.Contains(e.Location))
            {
                IsClicked = true;
            }

            if(m_LeftButtonRect.Contains(e.Location))
            {
                BarX = BarX - 1;
                ScrollMoveCallback(Percent);
            }

            if (m_RightButtonRect.Contains(e.Location))
            {
                BarX = BarX + 1;
                ScrollMoveCallback(Percent);
            }

           /* for (int i = 0; i < 3; i++)
                m_Cutscene[i].MouseDown(sender, e);*/
        }

        public void ScrollBarMouseMove(object sender, MouseEventArgs e)
        {
            if(IsClicked)
            {
                BarX = e.X - m_SmallDrawRect.Width / 2;

                /*for (int i = 0; i < 3; i++)
                {
                    if(m_Cutscene[i].BoundingBox.IntersectsWith(m_SmallDrawRect))
                    {
                        int center = m_Cutscene[i].BoundingBox.X + m_Cutscene[i].BoundingBox.Width / 2;
                        if (e.X < center)
                        {
                            BarX = m_Cutscene[i].BoundingBox.X - m_SmallDrawRect.Width;
                        }

                        else if(e.X > center)
                        {
                            BarX = m_Cutscene[i].BoundingBox.X + m_Cutscene[i].BoundingBox.Width;
                        }
                    }
                }*/
                    
                ScrollMoveCallback(Percent);
            }

           /* for (int i = 0; i < 3; i++)
            {
                m_Cutscene[i].MouseMove(sender, e);

                if (m_Cutscene[i].PositionX < m_DrawRect.X)
                    m_Cutscene[i].PositionX = m_DrawRect.X;

                else if (m_Cutscene[i].PositionX + m_Cutscene[i].BoundingBox.Width > m_DrawRect.X + m_DrawRect.Width)
                    m_Cutscene[i].PositionX = m_DrawRect.X + m_DrawRect.Width - m_Cutscene[i].BoundingBox.Width;
            }*/
        }

        public void ScrollBarMouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;

            /*for (int i = 0; i < 3; i++)
                m_Cutscene[i].MouseUp(sender, e);*/
        }

        public float Percent
        {
            get
            {
                if (m_SmallDrawRect.X == 0)
                    return 0;

                return (float)(m_SmallDrawRect.X - m_DrawRect.X) / (m_DrawRect.Width - m_SmallDrawRect.Width);
            }
        }

        public int BarX
        {
            set
            {
                m_SmallDrawRect.X = value;

                if (m_SmallDrawRect.X < m_DrawRect.X)
                    m_SmallDrawRect.X = m_DrawRect.X;

                if (m_SmallDrawRect.X > m_DrawRect.Width + m_DrawRect.X - m_SmallDrawRect.Width)
                    m_SmallDrawRect.X = m_DrawRect.Width + m_DrawRect.X - m_SmallDrawRect.Width;
            }

            get { return m_SmallDrawRect.X; }
        }

        public void PanelResize(Size panelSize)
        {
            Width = panelSize.Width - 20;
            Position = new Vector2(0, panelSize.Height - Height);
        }

        public int Width
        {
            get
            {
                return m_DrawRect.Width;
            }
            set
            {
                m_DrawRect.Width = value;
                m_RightButtonRect.X = value - m_ButtonSize;
            }
        }

        public int Height
        {
            get
            {
                return m_DrawRect.Height;
            }
            set
            {
                m_DrawRect.Height = value;
                m_LeftButtonRect.Height = m_RightButtonRect.Height = value;
            }
        }

        public override Vector2 Position
        {
            get
            {
                return base.Position;
            }

            set
            {
                base.Position = value;
                m_DrawRect.X = (int)value.x + m_ButtonSize;
                m_DrawRect.Y = (int)value.y;

                m_LeftButtonRect.X = (int)value.x;
                m_LeftButtonRect.Y = (int)value.y;

                m_RightButtonRect.X = (int)(value.x + m_DrawRect.Width - m_ButtonSize);
                m_RightButtonRect.Y = (int)value.y;

                float ratio = (float)m_StandardLength / m_MaxLength * m_DrawRect.Width * 20;
                m_SmallDrawRect.Width = (int)ratio;
                m_SmallDrawRect.Y = (int)value.y;
            }
        }
    }
}
