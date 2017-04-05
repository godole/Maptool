using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    public interface IPreview
    {
        void PlaySound(long curtime);
        bool IsPlayed { get; set; }
        bool IsOnScreen();
        Vector2 Position { get; }
    }

    public class PreviewSort : IComparer<IPreview>
    {
        public int Compare(IPreview x, IPreview y)
        {
            return x.Position.x.CompareTo(y.Position.y);
        }
    }
}
