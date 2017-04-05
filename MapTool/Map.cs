using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    public class Map : 
        Node
    {
        public const int GroundPositionY = 620;

        public enum BitMode
        {
            _4per4,
            _3per4
        }

        Vector2 m_LineInterval;
        public Vector2 LineInterval { get { return m_LineInterval; } }
        double m_PlayerMoveSpeed;
        public double PlayerMoveSpeed { get { return m_PlayerMoveSpeed; } }
        int m_BPM;
        int m_MapTime;
        BitMode m_BitMode;
        Ground m_Ground = null;
        public Ground _Ground { get { return m_Ground; } }
        Image[] m_BackgroundImages;
        public Image BackgroundImage { get { return m_BackgroundImages[0]; } }

        public Map(int bpm, int mapTime)
        {
            Init(bpm, mapTime);
        }

        public void Init(int bpm, int mapTime)
        {
            m_BPM = bpm;
            m_MapTime = mapTime;
            m_LineInterval = new Vector2();

            Update();

            m_Ground = new Ground((int)Size.x / (int)m_LineInterval.x);
            m_Ground.NodeSize = new Vector2(m_LineInterval.x, 100);
            AddChild(m_Ground);

            m_BackgroundImages = new Image[(int)(Size.x / 10000) + 1];

            for(int i = 0; i < m_BackgroundImages.Length; i++)
            {
                m_BackgroundImages[i] = new Image("background");
                m_BackgroundImages[i].Anchor = new Vector2(0, 0);
                m_BackgroundImages[i].Position = new Vector2(i * 10000, 0);
                AddChild(m_BackgroundImages[i]);
            }
        }

        public void ResetGround()
        {
            m_Ground = new Ground((int)Size.x / (int)m_LineInterval.x);
            m_Ground.NodeSize = new Vector2(m_LineInterval.x, 100);
            AddChild(m_Ground);
        }

        public void ResetGround(int count)
        {
            m_Ground = new Ground(count);
            m_Ground.NodeSize = new Vector2(m_LineInterval.x, 100);
            AddChild(m_Ground);
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < m_BackgroundImages.Length; i++)
                m_BackgroundImages[i].Draw(g);

            g.Transform = new Matrix();
            if(m_Ground != null)
                m_Ground.Draw(g);
            g.Transform = new Matrix();

            DrawVerticalSnapLine(g);
            DrawHorizonSnapLine(g);
        }

        void Update()
        {
            m_PlayerMoveSpeed = Math.Pow((m_BPM / 60.0f), 2.0f) * 200;
            m_LineInterval = new Vector2(60.0 / m_BPM * PlayerMoveSpeed, 155);
            Size = new Vector2(m_BPM / 60.0f * m_MapTime * 4 * LineInterval.x, 720);
        }

        void DrawVerticalSnapLine(Graphics g)
        {
            Pen HighPen = new Pen(Color.Black, 4);
            Pen NormalPen = new Pen(Color.Black, 2);
            HighPen.DashStyle = DashStyle.Solid;
            NormalPen.DashStyle = DashStyle.Dash;

            int startX = (int)(Position.x);
            int count = 0;
            int highlight = 0;

            switch (m_BitMode)
            {
                case BitMode._4per4:
                    highlight = 4;
                    break;
                case BitMode._3per4:
                    highlight = 3;
                    break;
                default:
                    highlight = 1;
                    break;
            }

            int width = Program.MainForm.ObjectPanel == null ? 1280 : Program.MainForm.ObjectPanel.Size.Width;

            while (startX < -Position.x + width)
            {
                if (0 < startX)
                {
                    g.DrawLine(count % highlight == 0 ? HighPen : NormalPen, new Point(startX, (int)(Position.y)),
                    new Point(startX, (int)Size.y));
                }

                count++;
                startX += (int)LineInterval.x;
            }
        }

        void DrawHorizonSnapLine(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);

            for (int i = 1; i < 5; i++)
                g.DrawLine(p, new Point(0, (int)(Position.y + LineInterval.y * i)), 
                    new Point(Program.MainForm.ObjectPanel.Size.Width, (int)(Position.y + LineInterval.y * i)));
        }

        public void Save(ref MapData data)
        {
            data.BPM = m_BPM;
            data.MapLength = m_MapTime;

            m_Ground.Save(ref data);
        }

        public void Load(MapData data)
        {
            m_Ground = new Ground(data.GroundData);
            m_BPM = data.BPM;
            m_MapTime = data.MapLength;

            Update();

            m_Ground.NodeSize = new Vector2(m_LineInterval.x, 100);
            AddChild(m_Ground);
        }
    }
}
