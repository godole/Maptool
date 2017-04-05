using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    public class ObjectJudge
    {
        BaseObject m_Object;
        string m_SoundTag;
        public double m_DeltaPosX { get; set; }

        public ObjectJudge(BaseObject obj, string soundtag, double deltapos)
        {
            m_Object = obj;
            m_DeltaPosX = deltapos;
            m_SoundTag = soundtag;
        }

        public void Judge(long curtime)
        {
            double pos = Program.MainMap.PlayerMoveSpeed * curtime / 1000;

            if (pos > m_Object.Position.x + m_DeltaPosX)
            {
                SoundManager.Play(m_SoundTag);
                m_Object.IsPlayed = true;
            }
        }
    }
}
