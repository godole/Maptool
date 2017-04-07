using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        Thread _UpdateThread;

        int m_ScreenSize;
        double m_Speed;

        int _Metronome = 1;

        //정렬되있어야됨
        //speed = pixel per second
        public Preview(int scrsize, double speed)
        {
            IsPlay = false;
            m_ScreenSize = scrsize;
            m_StopWatch = new Stopwatch();
            _UpdateThread = new Thread(PreviewUpdate);
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

            switch(_UpdateThread.ThreadState)
            {
                case System.Threading.ThreadState.Unstarted:
                    _UpdateThread.Start();
                    break;

                case System.Threading.ThreadState.Aborted:
                    _UpdateThread = new Thread(PreviewUpdate);
                    _UpdateThread.Start();
                    break;
            }
        }

        public void PreviewUpdate()
        {
            m_StopWatch.Start();

            while (true)
            {
                Program.MainForm.ObjectPanel.Invalidate();
                m_DeltaTime = m_StopWatch.ElapsedMilliseconds;

                Time.deltaTime = m_DeltaTime;

                for (int i = 0; i < m_Objects.Count; i++)
                {
                    if (!m_Objects[i].IsPlayed)
                        m_Objects[i].PlaySound(m_DeltaTime);
                }

                /*if (_Metronome * Program.MainMap.LineInterval.x < Program.MainMap.PlayerMoveSpeed * m_DeltaTime / 1000)
                {
                    _Metronome++;
                    SoundManager.Play("spring");
                }*/

                LineX = m_DeltaTime * m_Speed / 1000;
            }
        }

        public void Stop()
        {
            _UpdateThread.Abort();
            IsPlay = false;
            foreach (var obj in m_Objects)
                obj.IsPlayed = false;
            m_CurObjIndex = 0;
            m_CurTime = 0;
            m_StartTime = 0;
            _Metronome = 0;
            m_StopWatch.Reset();
        }

        public double LineX { get; set; }
        public double Speed { get { return m_Speed; } set { m_Speed = value; } }
        public bool IsPlay { get; set; }
    }
}
