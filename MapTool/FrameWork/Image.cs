using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    public class Image :
        Node
    {
        string m_ResourceTag = null;

        public Image(string resourceTag)
        {
            m_ResourceTag = resourceTag;

            try
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF r = ImageManager.GetBitmap(resourceTag).GetBounds(ref unit);

                Size = new Vector2(r.Width, r.Height);
            }
            
            catch(NullReferenceException e)
            {
                m_ResourceTag = null;
                //MessageBox.Show("Create Image Error : " + resourceTag);
            }
        }

        public void Draw(Graphics g)
        {
            if (m_ResourceTag == null)
                return;

            g.Transform = new Matrix();
            g.Transform = WorldMatrix;
            
            g.DrawImage(ImageManager.GetBitmap(m_ResourceTag), new Rectangle((int)(-Anchor.x * Size.x), (int)(-Anchor.y * Size.y), (int)Size.x, (int)Size.y));
            g.Transform = new Matrix();
        }

        public bool ContainsPoint(Vector2 p)
        {
            Vector2 WorldPos = WorldPosition;
            Rectangle r = new Rectangle((int)(WorldPos.x - Anchor.x * Size.x), (int)(WorldPos.y - Anchor.y * Size.y), (int)Size.x, (int)Size.y);

            return r.Contains((Point)p);
        }
    }
}
