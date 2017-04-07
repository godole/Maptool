using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace MapTool
{
    public partial class Main : Form
    {
        Option m_BPMOption;
        FileManager m_FileManager;

        public DoubleBufferPanel ObjectPanel
        {
            get { return panel1; }
        }

        public Main()
        {
            /*m_DrawTimer = new Timer();
            m_DrawTimer.Interval = 1000;
            m_DrawTimer.Tick += new EventHandler(TimerEvent);
            m_DrawTimer.Start();*/

            m_FileManager = new FileManager(Application.StartupPath);

            InitializeComponent();
        }

        public void CreateNewMap(int bpm, int maptime)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
            this.DoubleBuffered = true;
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Btn_GroundDelete_Click(object sender, EventArgs e)
        {
            panel1.ChangeState();
        }

        private void Btn_Platform_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Platform, (Bitmap)((PictureBox)sender).Image, new Vector2(100, 100));
        }

        private void Btn_Niddle_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Niddle, (Bitmap)((PictureBox)sender).Image,
                new Vector2(100, 100));
        }

        private void Btn_Spring_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Spring, (Bitmap)((PictureBox)sender).Image,
                new Vector2(100, 100));
        }

        private void Btn_DJump_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Double, (Bitmap)((PictureBox)sender).Image,
                new Vector2(100, 100));
        }

        private void Btn_Rope_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Rope, (Bitmap)((PictureBox)sender).Image,
                new Vector2(100, 100));
        }

        private void Btn_Fever_Click(object sender, EventArgs e)
        {
            panel1.CreateObject(BaseObject.ObjectType.Fever, (Bitmap)((PictureBox)sender).Image,
                new Vector2(100, 100));
        }

        private void Btn_DeleteAllGround_Click(object sender, EventArgs e)
        {
            if (!panel1._Map._Ground.IsEmpty)
                panel1._Map._Ground.Clear();

            else
                panel1._Map.ResetGround();
        }

        private void BPMLabel_DoubleClick(object sender, EventArgs e)
        {
            m_BPMOption = new MapTool.Option();
            m_BPMOption.SendMsg += (int bpm) =>
            {
                /*label1.Text = "BPM : " + bpm.ToString();
                double prevlength = GlobalOption.MapLength;
                GlobalOption.BPM = bpm;
                double curlength = GlobalOption.MapLength;
                double delta = curlength / prevlength;
                delta = Math.Sqrt(delta);

                for(int i = 0; i < ObjectContainer.ObjectList.Count; i++)
                {
                    double x = ObjectContainer.ObjectList[i].Position.x * delta;
                    ObjectContainer.ObjectList[i].Position = new Vector2(x, ObjectContainer.ObjectList[i].Position.y);
                }*/
            };
            m_BPMOption.Show();
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile newfile = new NewFile();
            newfile.Show();

            newfile.CreateCallback += (string sound, int bpm, int maptime) =>
            {
                SoundManager.SetBackground(sound);
                Program.MainMap.Init(bpm, maptime);
                ObjectContainer.Clear();
            };
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FileManager.Save();
        }

        private void Btn_SelectPlatform_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("platform", Btn_Platform);
        }

        private void Btn_SelectNiddle_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("niddle", Btn_Niddle);
        }

        private void Btn_SelectDouble_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("double", Btn_DJump);
        }

        private void Btn_SelectRope_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("rope", Btn_Rope);
        }

        private void Btn_SelectFever_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("fever", Btn_Fever);
        }

        private void Btn_SelectSpring_Click(object sender, EventArgs e)
        {
            ChangeButtonImage("spring", Btn_Spring);
        }

        private void ChangeButtonImage(string objname, PictureBox btn)
        {
            Bitmap bit = OpenObjectImageDialog();

            if (bit != null)
            {
                ImageManager.ChangeBitmap(objname, bit);
                panel1.ChangeObjectImage(objname, bit);

                btn.Image = bit;
            }
        }

        private Bitmap OpenObjectImageDialog()
        {
            Bitmap bit = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "png";
            openFile.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
            {
                bit = new Bitmap(openFile.FileName);
            }

            return bit;
        }

        private string OpenObjectSoundDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "mp3";
            openFile.Filter = "Sound Files(*.mp3; *.wav)|*.mp3;*.wav";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
                return openFile.FileName;

            else
                return null;
        }

        private void 미리보기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SoundManager.PlayBackground();
            panel1.StartPreview();
        }

        private void Btn_SelectDoubleSound_Click(object sender, EventArgs e)
        {
            string file = OpenObjectSoundDialog();
            SoundManager.AddSound("double", file);
        }

        private void Btn_SelectRopeSound_Click(object sender, EventArgs e)
        {
            string file = OpenObjectSoundDialog();
            SoundManager.AddSound("rope", file);
        }

        private void Btn_SelectFeverSound_Click(object sender, EventArgs e)
        {
            string file = OpenObjectSoundDialog();
            SoundManager.AddSound("fever", file);
        }

        private void Btn_SelectSpringSound_Click(object sender, EventArgs e)
        {
            string file = OpenObjectSoundDialog();
            SoundManager.AddSound("spring", file);
        }

        private void 미리보기정지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundManager.StopBackground();
            panel1.StopPreview();
        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "txt";
            openFile.Filter = "Mapdata File(*.txt)|*.txt";
            openFile.ShowDialog();

            if (openFile.FileName.Length > 0)
                m_FileManager.Load(openFile.FileName, openFile.SafeFileName);

            Btn_Platform.Image = ImageManager.GetBitmap("platform");
            Btn_Niddle.Image = ImageManager.GetBitmap("niddle");
            Btn_DJump.Image = ImageManager.GetBitmap("double");
            Btn_Fever.Image = ImageManager.GetBitmap("fever");
            Btn_Rope.Image = ImageManager.GetBitmap("rope");
            Btn_Spring.Image = ImageManager.GetBitmap("spring");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bitmap = OpenObjectImageDialog();
            ImageManager.ChangeBitmap("background", bitmap);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bitmap = OpenObjectImageDialog();
            ImageManager.ChangeBitmap("ground", bitmap);
        }

        private void LoadTheme_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(".\\theme");
            List<string> itemList = new List<string>();

            foreach (var item in dirInfo.GetDirectories())
            {
                itemList.Add(item.Name);
            }

            SelectTheme selectTheme = new SelectTheme(itemList, ()=>
            {
                Btn_Platform.Image = ImageManager.GetBitmap("platform");
                Btn_Niddle.Image = ImageManager.GetBitmap("niddle");
                Btn_DJump.Image = ImageManager.GetBitmap("double");
                Btn_Fever.Image = ImageManager.GetBitmap("fever");
                Btn_Rope.Image = ImageManager.GetBitmap("rope");
                Btn_Spring.Image = ImageManager.GetBitmap("spring");
            });
            selectTheme.ShowDialog();
        }
    }
}
