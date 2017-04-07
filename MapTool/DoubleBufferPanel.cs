using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    public class DoubleBufferPanel : Panel
    {
        delegate void ObjectImageChange(Bitmap bit);
        delegate void PanelResize(Size panelSize);

        Dictionary<string, ObjectImageChange> m_ImageChange;
        PanelResize m_PanelResizeDelegate = null;

        ScrollBar m_ScrollBar;
        Preview m_Preview = null;
        BaseObject m_Object = null;
        Map m_Map = null;
        public Map _Map { get { return m_Map; } }

        bool m_IsGroundDeleteState = false;
        bool _IsDrawingSlideLine = false;
        SlideLine _CurSlideLine = null;

        Vector2 m_PreviewStartPosition;
        List<SlideLine> _SlideLineList = new List<SlideLine>();

        public DoubleBufferPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            m_Map = new Map(120, 180);

            m_ScrollBar = new ScrollBar(1240, (int)m_Map.Size.x, new Point(0, 400), new Size(1200, 50), 30);
            m_ScrollBar.ScrollMoveCallback += (float percent) =>
            {
                m_Map.Position.x = -m_ScrollBar.Percent * m_Map.Size.x;
                Invalidate();
            };
            m_PanelResizeDelegate = new PanelResize(m_ScrollBar.PanelResize);

            m_ImageChange = new Dictionary<string, ObjectImageChange>();

            m_Preview = new Preview(1280, m_Map.PlayerMoveSpeed);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateManager.Instance.Update();

            Graphics g = e.Graphics;
            m_Map.Position.y = AutoScrollPosition.Y;

            try
            {
                m_Map.Draw(g);
            }
            catch(NullReferenceException nre)
            {

            }

            foreach (var obj in ObjectContainer.ObjectList)
            {
                g.Transform = new Matrix();
                obj.Draw(g);
            }

            foreach (var obj in _SlideLineList)
                obj.Draw(g);

            if (m_Preview.IsPlay)
            {
                int x = (int)(m_Preview.LineX + m_Map.Position.x);
                g.DrawLine(new Pen(Color.Black), new Point(x, 0), new Point(x, Size.Height));

                if (x > Size.Width)
                {
                    m_Map.Position.x = -m_Preview.LineX;
                }
            }

            if (m_ScrollBar != null)
            {
                g.Transform = new Matrix();
                m_ScrollBar.Draw(g);
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool isClicked = false;

                m_ScrollBar.ScrollBarMouseDown(this, e);

                isClicked = m_ScrollBar.IsClicked;

                if (m_IsGroundDeleteState)
                {
                    m_Map._Ground.DeleteGroundAtPoint(e.Location - m_Map.Position);
                    isClicked = true;
                    Invalidate();
                }

                else
                {
                    foreach (var obj in ObjectContainer.ObjectList)
                    {
                        obj.MouseDown(this, e);

                        if (obj.IsSelected)
                        {
                            m_Object = obj;
                            isClicked = true;
                            break;
                        }
                    }
                }
                
                if (!isClicked)
                {
                    _CurSlideLine = new SlideLine();
                    _Map.AddChild(_CurSlideLine);
                    _CurSlideLine.WorldPosition = new Vector2(e.Location);
                    _SlideLineList.Add(_CurSlideLine);
                    _IsDrawingSlideLine = true;
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < ObjectContainer.ObjectList.Count; i++)
                {
                    if (ObjectContainer.ObjectList[i].BoundingBox.Contains((Point)(e.Location - m_Map.Position)))
                    {
                        ObjectContainer.ObjectList[i].Release();
                        Invalidate();
                        break;
                    }
                }

                for (int i = 0; i < _SlideLineList.Count; i++)
                {
                    if (_SlideLineList[i].ContainsPoint(new Vector2(e.Location)))
                    {
                        _SlideLineList.RemoveAt(i);
                        Invalidate();
                        break;
                    }
                }
            }

            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (m_Object != null)
            {
                m_Object.MouseMove(this, e);
                Invalidate();
            }

            else if (_IsDrawingSlideLine)
            {
                _CurSlideLine.EndPosition = new Vector2(e.Location);
                Invalidate();
            }

            m_ScrollBar.ScrollBarMouseMove(this, e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (m_Object != null)
            {
                m_Object.MouseUp(this, e);
                m_Object = null;
            }

            else if(_IsDrawingSlideLine)
            {
                _IsDrawingSlideLine = false;
                _CurSlideLine = null;
            }

            m_ScrollBar.ScrollBarMouseUp(this, e);
        }

        public void ChangeState()
        {
            m_IsGroundDeleteState = !m_IsGroundDeleteState;
        }
        
        public void StartPreview()
        {
            List<BaseObject> objlist = ObjectContainer.ObjectList;
            List<IPreview> prevlist = new List<IPreview>();
            m_PreviewStartPosition = -m_Map.Position;

            objlist.Sort(delegate (BaseObject o1, BaseObject o2)
            {
                return o1.Position.x.CompareTo(o2.Position.x);
            });

            foreach (var obj in objlist)
                prevlist.Add(obj);

            var sort = new PreviewSort();
            prevlist.Sort(sort);
            
            m_Preview.PlayPreview(prevlist, 0, 0, m_Map.PlayerMoveSpeed);
        }

        public void StopPreview()
        {
            m_Preview.Stop();
            m_Map.Position.x = 0;
        }

        public BaseObject CreateObject(BaseObject.ObjectType type, Bitmap bit, Vector2 pos)
        {
            BaseObject obj = ObjectFactory.CreateObject(type, pos);

            if (obj != null)
            {
                ObjectImageChange c = (Bitmap b) => {
                    obj.ChangeImage(b);
                };

                if (m_ImageChange.ContainsKey(obj.ObjectName))
                    m_ImageChange[obj.ObjectName] += c;
                else
                    m_ImageChange.Add(obj.ObjectName, c);

                ObjectContainer.ObjectList.Add(obj);
            }
            Invalidate();

            return obj;
        }

        public void AddObject(BaseObject obj)
        {
            if (obj != null)
            {
                ObjectImageChange c = (Bitmap b) => {
                    obj.ChangeImage(b);
                };

                if (m_ImageChange.ContainsKey(obj.ObjectName))
                    m_ImageChange[obj.ObjectName] += c;
                else
                    m_ImageChange.Add(obj.ObjectName, c);

                ObjectContainer.ObjectList.Add(obj);
                m_Map.AddChild(obj);
            }
            Invalidate();
        }

        public void ChangeObjectImage(string objectname, Bitmap bit)
        {
            if (m_ImageChange.ContainsKey(objectname))
                m_ImageChange[objectname](bit);

            Invalidate();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            m_PanelResizeDelegate(Size);

            Invalidate();
        }
    }
}
