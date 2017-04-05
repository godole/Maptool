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
    public partial class NewFile : Form
    {
        string m_SoundName;

        public delegate void NewCallback(string sound, int bpm, int length);

        public NewCallback CreateCallback;

        public NewFile()
        {
            InitializeComponent();
        }

        private void Btn_bgmSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Select Sound";
            dialog.InitialDirectory = @"c:\";
            dialog.Filter = "Wav Files (*.wav)|*.wav";
            dialog.FilterIndex = 3;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_SoundName = dialog.FileName;
                label1.Text = dialog.FileName;
            }
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            CreateCallback(m_SoundName, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
