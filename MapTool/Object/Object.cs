using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace MapTool
{
    public abstract class BaseObject :
        Node,
        IPreview
    {
        public enum ObjectType
        {
            Platform,
            Niddle,
            Fire,
            Double,
            Fever,
            Rope,
            Ground,
            Spring
        }

        public ObjectJudge Judge { get; set; }

        public int Border { get; set; }

        public string ObjectName { get; set; }

        public BaseObject()
        {
            Judge = null;
            Border = 10;
        }

        public abstract void Draw(Graphics g);

        public virtual void AutoSnap(MouseEventArgs e)
        {
            WorldPosition = CalculateNormalSnap(new Vector2(e.Location));
        }

        public virtual void Release()
        {
            ObjectContainer.ObjectList.Remove(this);
        }

        public abstract void MouseDown(object sender, MouseEventArgs e);

        public abstract void MouseMove(object sender, MouseEventArgs e);

        public abstract void MouseUp(object sender, MouseEventArgs e);

        public abstract bool IsSelected
        {
            get;
        }

        public abstract void Save(ref MapData mapdata);

        public virtual void PlaySound(long curtime)
        {
            if (Judge != null)
                Judge.Judge(curtime);
        }

        public bool IsOnScreen()
        {
            double deltax = WorldPosition.x;

            if (deltax > 0 && deltax < 1280)
                return true;

            else
                return false;
        }

        public bool IsPlayed { get; set; }

        public abstract void ChangeImage(Bitmap bit);

        public Vector2 CalculateNormalSnap(Vector2 scrPos)
        {
            Vector2 p = scrPos;
            Vector2 lineInterval = Program.MainMap.LineInterval;
            Vector2 delta = new Vector2(lineInterval.x + (Program.MainMap.Position.x % lineInterval.x),
                    lineInterval.y + (Program.MainMap.Position.y % lineInterval.y));

            p.x = Util.Round((int)(p.x - lineInterval.x * (3 / 4.0)), (int)lineInterval.x / 2) + delta.x;
            p.y = Util.Round((int)(p.y - lineInterval.y * (3 / 4.0)), (int)lineInterval.y / 2) + delta.y;

            if (p.y > Map.GroundPositionY - Size.y)
                p.y = Map.GroundPositionY - Size.y;

            return p;
        }
    }
}
