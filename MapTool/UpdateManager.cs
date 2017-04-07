using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool
{
    class UpdateManager
    {
        static UpdateManager m_Instance = null;

        public static UpdateManager Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new UpdateManager();

                return m_Instance;
            }
        }

        private List<IUpdate> _UpdateList = new List<IUpdate>();

        public void Update()
        {
            for (int i = 0; i < _UpdateList.Count; i++)
                _UpdateList[i].Update();
        }

        public void AddObject(IUpdate obj)
        {
            _UpdateList.Add(obj);
        }

        public void RemoveObject(IUpdate obj)
        {
            _UpdateList.Remove(obj);
        }

        public void Release()
        {
            _UpdateList.Clear();
        }
    }
}
