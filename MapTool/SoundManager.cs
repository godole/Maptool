using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer;

namespace MapTool
{
    class SoundManager
    {
        Dictionary<string, MediaPlayerClass> m_Sounds;
        MediaPlayerClass m_Background;
        static SoundManager m_Instance = null;
        public bool IsSetBackground { get { return m_Background != null; } }

        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        private SoundManager()
        {
            m_Sounds = new Dictionary<string, MediaPlayerClass>();
        }

        public static SoundManager Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SoundManager();

                return m_Instance;
            }
        }

        public static void AddSound(string tag, string filepath)
        {
            if(Instance.m_Sounds.ContainsKey(tag))
            {
                Instance.m_Sounds[tag].FileName = filepath;
            }
            else
            {
                MediaPlayerClass _player = new MediaPlayerClass();
                _player.FileName = filepath;
                Instance.m_Sounds.Add(tag, _player);
            }
        }

        public static string GetSoundFilePath(string tag)
        {
            if (Instance.m_Sounds.ContainsKey(tag))
                return Instance.m_Sounds[tag].FileName;
            else
                return null;
        }

        public static void SetBackground(string filename)
        {
            Instance.m_Background = new MediaPlayerClass();
            Instance.m_Background.FileName = filename;
            Instance.m_Background.Stop();
        }

        public static string GetBackgroundFilePath()
        {
            if (Instance.m_Background != null)
                return Instance.m_Background.FileName;

            else
                return null;
        }

        public static void Play(string tag)
        {
            if (tag == null)
                return;

            if(Instance.m_Sounds.ContainsKey(tag))
            {
                if(Instance.m_Sounds[tag].PlayState == MPPlayStateConstants.mpPlaying)
                {
                    Instance.m_Sounds[tag].Stop();
                }
                Instance.m_Sounds[tag].Play();
            }
        }

        public static void PlayBackground()
        {
            if(Instance.m_Background != null)
                Instance.m_Background.Play();
        }

        public static void StopBackground()
        {
            if (Instance.m_Background != null)
                Instance.m_Background.Stop();
        }
    }
}
