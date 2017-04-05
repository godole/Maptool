using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    static class Program
    {
        static Main m_Instance;
        static Map m_MapInstance;

        public static Main MainForm
        {
            get
            {
                return m_Instance;
            }
        }

        public static Map MainMap
        {
            get
            {
                return m_MapInstance;
            }
        }
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_Instance = new Main();
            m_MapInstance = m_Instance.ObjectPanel._Map;
            Application.Run(m_Instance);
        }
    }
}
