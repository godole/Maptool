using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class ObjectContainer
    {
        private static ObjectContainer m_Instance = null;

        public static ObjectContainer Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ObjectContainer();

                return m_Instance;
            }
        }

        List<BaseObject> m_ObjectList;
        List<BaseObject> m_PlatformList;

        private ObjectContainer()
        {
            m_ObjectList = new List<BaseObject>();
            m_PlatformList = new List<BaseObject>();
        }

        public static List<BaseObject> ObjectList
        {
            get { return Instance.m_ObjectList; }
        }

        public static List<BaseObject> PlatformList
        {
            get { return Instance.m_PlatformList; }
        }

        public static void Clear()
        {
            Instance.m_ObjectList.Clear();
            Instance.m_PlatformList.Clear();
        }
    }
}
