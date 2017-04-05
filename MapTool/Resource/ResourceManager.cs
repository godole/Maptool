using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class ResourceManager
    {
        private static ResourceManager m_Instance;

        public static ResourceManager Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ResourceManager();

                return m_Instance;
            }
        }

        Dictionary<string, Bitmap> m_BitmapDictionary;

        private ResourceManager()
        {
            m_BitmapDictionary = new Dictionary<string, Bitmap>();
        }

        public static void AddBitmap(string filename, Bitmap bit)
        {
            Instance.m_BitmapDictionary.Add(filename, bit);
        }

        public static Bitmap GetBitmap(string filename)
        {
            if (Instance.m_BitmapDictionary.ContainsKey(filename))
                return Instance.m_BitmapDictionary[filename];

            else
                return null;
        }

        public static void ChangeBitmap(string filename, Bitmap bit)
        {
            Instance.m_BitmapDictionary[filename] = bit;
        }
    }
}
