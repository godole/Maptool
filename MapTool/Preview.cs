using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class Preview
    {
        List<IPreview> m_Objects;
        
        //화면 안에 있는 오브젝트
        List<IPreview> m_PlayObject;
        int m_CurObjIndex = 0;
        long m_CurTime = 0;
        float m_StartTime = 0;
        long m_DeltaTime;
        Stopwatch m_StopWatch;

        int m_ScreenSize;
        double m_Speed;

        //정렬되있어야됨
        //speed = pixel per second
        public Preview(int scrsize, double speed)
        {
            IsPlay = false;
            m_ScreenSize = scrsize;
            m_StopWatch = new Stopwatch();
        }

        public void PlayPreview(List<IPreview> previewObject, float starttime, int startpos, double speed)
        {
            IsPlay = true;
            m_Objects = previewObject;
            m_PlayObject = new List<IPreview>();
            m_StartTime = starttime;
            m_Speed = speed;
            LineX = startpos;

            for(int i = 0; i < m_Objects.Count; i++)
            {
                if(m_Objects[i].IsOnScreen())
                {
                    m_PlayObject.Add(m_Objects[i]);
                    m_CurObjIndex = i;
                }
            }

            m_StopWatch.Start();
        }

        public void PreviewUpdate()
        {
            m_DeltaTime = m_StopWatch.ElapsedMilliseconds;
            Time.deltaTime = m_DeltaTime;
            m_StopWatch.Reset();

            for (int i = 0; i < m_Objects.Count; i++)
            {
                m_Objects[i].PlaySound(m_CurTime);

                if(m_Objects[i].IsPlayed)
                    m_Objects.Remove(m_Objects[i]);
            }
            
            m_CurTime += m_DeltaTime;
            LineX += m_DeltaTime * m_Speed / 1000;

            m_StopWatch.Start();
        }

        public void Stop()
        {
            IsPlay = false;
            m_StopWatch.Reset();
        }

        public double LineX { get; set; }
        public double Speed { get { return m_Speed; } set { m_Speed = value; } }
        public bool IsPlay { get; set; }
    }
}
