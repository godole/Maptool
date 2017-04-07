using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    public class Node :
        IUpdate
    {
        List<Node> m_Children;
        Node m_Parent = null;
        protected Vector2 m_Position;
        Matrix m_LocalMatrix;
        Matrix m_WorldMatrix;
        float m_Angle;

        public virtual Vector2 Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }
        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(WorldMatrix.OffsetX, WorldMatrix.OffsetY);
            }
            set
            {
                if (Parent == null)
                    Position = value;

                else
                {
                    Matrix worldMat = Parent.WorldMatrix;
                    Vector2 deltaPos = value - new Vector2(worldMat.OffsetX, worldMat.OffsetY);
                    Position = deltaPos;
                }
            }
        }
        public virtual Vector2 Size { get; set; }
        public Vector2 Scale { get; set; }
        public Vector2 Anchor { get; set; }

        public Node Parent
        {
            get { return m_Parent; }
        }

        public Matrix WorldMatrix
        {
            get
            {
                if (Parent == null)
                    return LocalMatrix;
                
                return m_WorldMatrix;
            }
        }
        public Matrix LocalMatrix { get { return m_LocalMatrix; } }

        public Node()
        {
            m_Children = new List<Node>();
            m_Position = new Vector2();
            Anchor = new Vector2(0.5, 0.5);
            Scale = new Vector2(1.0, 1.0);
            Size = new Vector2();
            m_LocalMatrix = new Matrix();
            m_WorldMatrix = new Matrix();
            UpdateManager.Instance.AddObject(this);
        }

        public void Release()
        {
            UpdateManager.Instance.RemoveObject(this);
        }

        public void AddChild(Node node)
        {
            m_Children.Add(node);
            node.m_Parent = this;
        }

        public void RemoveChild(Node node)
        {
            m_Children.Remove(node);
        }

        public float Angle
        {
            get { return m_Angle; }
            set
            {
                m_Angle = value;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                Vector2 lefttop = LeftTop;
                return new Rectangle((int)(LeftTop.x), (int)(LeftTop.y), (int)Size.x, (int)Size.y);
            }
        }

        public Rectangle WorldBoundingBox
        {
            get
            {
                Vector2 lefttop = WorldLeftTop;
                return new Rectangle((int)(lefttop.x), (int)(lefttop.y), (int)Size.x, (int)Size.y);
            }
        }

        public bool ContainsPoint(Vector2 point)
        {
            Vector2 reorderVector = Vector2.RotateFrom(point, WorldPosition, -Angle);

            if (WorldBoundingBox.Contains((Point)reorderVector))
                return true;

            else
                return false;
        }

        void UpdateMatrix()
        {
            m_LocalMatrix = new Matrix();

            Matrix trans = new Matrix();
            trans.Translate((float)m_Position.x, (float)m_Position.y);
            m_LocalMatrix.Multiply(trans);

            Matrix rot = new Matrix();
            rot.Rotate(Angle);
            m_LocalMatrix.Multiply(rot);

            Matrix scale = new Matrix();
            scale.Scale((float)Scale.x, (float)Scale.y);
            m_LocalMatrix.Multiply(scale);

            m_WorldMatrix = new Matrix();

            if (Parent != null)
                m_WorldMatrix.Multiply(Parent.WorldMatrix);

            m_WorldMatrix.Multiply(m_LocalMatrix);
        }

        public void Update()
        {
            UpdateMatrix();
        }

        public Vector2 LeftTop
        {
            get { return new Vector2(Position.x - (Anchor.x * Size.x), Position.y - (Anchor.y * Size.y)); }
        }

        public Vector2 RightTop
        {
            get { return new Vector2(Position.x + ((1 - Anchor.x) * Size.x), Position.y - (Anchor.y * Size.y)); }
        }

        public Vector2 LeftBottom
        {
            get { return new Vector2(Position.x - (Anchor.x * Size.x), Position.y + ((1 - Anchor.y) * Size.y)); }
        }

        public Vector2 RightBottom
        {
            get { return new Vector2(Position.x + ((1 - Anchor.x) * Size.x), Position.y + ((1 - Anchor.y) * Size.y)); }
        }

        public Vector2 WorldLeftTop
        {
            get
            {
                Vector2 worldPos = WorldPosition;
                return new Vector2(worldPos.x - (Anchor.x * Size.x), worldPos.y - (Anchor.y * Size.y));
            }
        }

        public Vector2 WorldRightTop
        {
            get
            {
                Vector2 worldPos = WorldPosition;
                return new Vector2(worldPos.x + ((1 - Anchor.x) * Size.x), worldPos.y - (Anchor.y * Size.y));
            }
        }

        public Vector2 WorldLeftBottom
        {
            get
            {
                Vector2 worldPos = WorldPosition;
                return new Vector2(worldPos.x - (Anchor.x * Size.x), worldPos.y + ((1 - Anchor.y) * Size.y));
            }
        }

        public Vector2 WorldRightBottom
        {
            get
            {
                Vector2 worldPos = WorldPosition;
                return new Vector2(worldPos.x + ((1 - Anchor.x) * Size.x), worldPos.y + ((1 - Anchor.y) * Size.y));
            }
        }
    }
}                                                                       
