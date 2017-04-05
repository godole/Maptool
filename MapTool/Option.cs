using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    public partial class Option : Form
    {
        public delegate void SendMsgDele(int bpm);
        public event SendMsgDele SendMsg;

        public Option()
        {
            InitializeComponent();
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            int bpm;

            try
            {
                bpm = Convert.ToInt32(textBox1.Text);
                SendMsg(bpm);
                Close();
            }
            catch(System.FormatException ex)
            {
                MessageBox.Show("정수를 입력하세요");
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
