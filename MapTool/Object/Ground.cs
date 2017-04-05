using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    public class Ground :
        Node
    {
        List<Image> m_Images;
        Vector2 m_NodeSize;

        public bool IsEmpty { get { return m_Images.Count == 0; } }

        public Vector2 NodeSize
        {
            get { return m_NodeSize; }
            set
            {
                m_NodeSize = value;

                for(int i = 0; i < m_Images.Count; i++)
                {
                    if(m_Images[i] != null)
                    {
                        m_Images[i].Size = value;
                        m_Images[i].Position.x = value.x * i;
                    }
                }
            }
        }

        public Ground(int count)
        {
            m_Images = new List<Image>();
            Position = new Vector2(0, Map.GroundPositionY);
            m_NodeSize = new Vector2();

            for (int i = 0; i < count; i++)
                AddImage(new Vector2(NodeSize.x * i, 0));
        }

        public Ground(GroundObjectData data)
        {
            m_Images = new List<Image>();
            NodeSize = new Vector2(Program.MainMap.LineInterval.x, 100);
            int count = (int)Program.MainMap.Size.x / (int)Program.MainMap.LineInterval.x;
            Position = new Vector2(0, Map.GroundPositionY);
            int holeindex = 0;

            for (int i = 0; i < count; i++)
            {
                if(data.HoleList.Count > 0)
                {
                    if (i == data.HoleList[holeindex])
                    {
                        holeindex++;
                        if (holeindex > data.HoleList.Count - 1)
                            holeindex = data.HoleList.Count - 1;
                        continue;
                    }
                }

                AddImage(new Vector2(NodeSize.x * i, 0));
            }
        }

        public void Draw(Graphics g)
        {
            for(int i = 0; i < m_Images.Count; i++)
            {
                if (m_Images[i] == null)
                    continue;

                //Vector2 objWorldPos = m_Images[i].WorldPosition;
                //if (-m_Images[i].Size.x <= objWorldPos.x && objWorldPos.x < Program.MainForm.ObjectPanel.Size.Width)
                    m_Images[i].Draw(g);
            }
        }

        public void DeleteGroundAtPoint(Vector2 p)
        {
            int index = getGroundIndex(p);

            if (index == -1)
                return;

            m_Images[getGroundIndex(p)] = null;
        }

        public void CreateGroundAtPoint(Vector2 p)
        {
            int index = getGroundIndex(p);
            if (m_Images[index] == null)
            {
                AddImage(index);
            }
        }

        public void Clear()
        {
            m_Images.Clear();
        }

        public int getGroundIndex(Vector2 p)
        {
            if (p.x > Program.MainMap.Size.x || p.x < 0)
                return -1;

            return (((int)p.x) / (int)NodeSize.x);
        }

        public void Save(ref MapData mapdata)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                    continue;

                NormalObjectlData data = new NormalObjectlData();
                data.PositionX = (int)list[i].Position.x;
                data.PositionY = (int)list[i].Position.y;
                data.Width = (int)list[i].Size.x;

                try
                {
                    for (Image img = list[i]; list[i + 1] != null; img = list[++i])
                    {
                        data.Width += (int)img.Size.x;
                    }
                }
                catch (ArgumentException e)
                {

                }

                mapdata.GroundObjectList.Add(data);
            }

            for(int i = 0; i < list.Count; i++)
            {
                if (list[i] == null)
                    mapdata.GroundData.HoleList.Add(i);
            }
        }

        public List<Image> list { get { return m_Images; } }

        Image AddImage(Vector2 pos)
        {
            var g = new Image("ground");
            g.Position = pos;
            g.Size = NodeSize;
            g.Anchor = new Vector2(0, 0);
            m_Images.Add(g);
            AddChild(g);

            return g;
        }

        Image AddImage(int index)
        {
            if (m_Images[index] != null)
                return null;

            var g = new Image("ground");
            g.Position = new Vector2(index * NodeSize.x, 0);
            g.Size = NodeSize;
            g.Anchor = new Vector2(0, 0);
            m_Images[index] = g;
            AddChild(g);

            return g;
        }
    }
}
