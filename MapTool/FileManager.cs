using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTool
{
    class FileManager
    {
        string m_MapPath;

        public FileManager(string rootpath)
        {
            m_MapPath = null;
            
            ImageManager.AddBitmap("platform", new Bitmap(rootpath + @"\img\platform.png"));
            ImageManager.AddBitmap("fever", new Bitmap(rootpath + @"\img\fever.png"));
            ImageManager.AddBitmap("double", new Bitmap(rootpath + @"\img\double.png"));
            ImageManager.AddBitmap("fire", new Bitmap(rootpath + @"\img\fire.png"));
            ImageManager.AddBitmap("niddle", new Bitmap(rootpath + @"\img\niddle.png"));
            ImageManager.AddBitmap("spring", new Bitmap(rootpath + @"\img\spring.png"));
            ImageManager.AddBitmap("ropeline", new Bitmap(rootpath + @"\img\ropeline.png"));
            ImageManager.AddBitmap("ropehitbox", new Bitmap(rootpath + @"\img\ropehitbox.png"));
            ImageManager.AddBitmap("rope", new Bitmap(rootpath + @"\img\rope.png"));

            ImageManager.AddBitmap("background", new Bitmap(rootpath + @"\img\background.png"));
            ImageManager.AddBitmap("ground", new Bitmap(rootpath + @"\img\ground.png"));

            SoundManager.AddSound("double", rootpath + @"\sound\double.mp3");
            SoundManager.AddSound("rope", rootpath + @"\sound\rope.mp3");
            SoundManager.AddSound("fever", rootpath + @"\sound\fever.mp3");
            SoundManager.AddSound("spring", rootpath + @"\sound\spring.mp3");
        }

        public void Save()
        {
            if(!SoundManager.Instance.IsSetBackground)
            {
                MessageBox.Show("배경음악이 설정되지 않았습니다");
                return;
            }

            if(m_MapPath == null)
            {
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = @"c:\";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    m_MapPath = dialog.FileName;
                    DirectoryInfo di = new DirectoryInfo(dialog.FileName);

                    if (di.Exists == false)
                        di.Create();

                    SaveMapData(dialog.FileName);
                    SaveResource(dialog.FileName);
                }
            }

            else
            {
                SaveMapData(m_MapPath);
            }
        }

        void SaveMapData(string rootpath)
        {
            var mapdata = new MapData();
            mapdata.MapName = rootpath;

            foreach (BaseObject obj in ObjectContainer.ObjectList)
            {
                obj.Save(ref mapdata);
            }

            Program.MainMap.Save(ref mapdata);

            string jsonWithConverter = JsonConvert.SerializeObject(mapdata);

            FileStream fs = File.Create(rootpath + @"\data.txt");
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(jsonWithConverter);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        void SaveResource(string rootpath)
        {
            var png = System.Drawing.Imaging.ImageFormat.Png;

            var di = new DirectoryInfo(rootpath + @"\obj");
            di.Create();
            di = new DirectoryInfo(rootpath + @"\theme");
            di.Create();
            di = new DirectoryInfo(rootpath + @"\sound");
            di.Create();

            try
            {
                ImageManager.GetBitmap("platform").Save(rootpath + @"\obj\platform.png", png);
                ImageManager.GetBitmap("niddle").Save(rootpath + @"\obj\niddle.png", png);
                ImageManager.GetBitmap("rope").Save(rootpath + @"\obj\rope.png", png);
                ImageManager.GetBitmap("fever").Save(rootpath + @"\obj\fever.png", png);
                ImageManager.GetBitmap("spring").Save(rootpath + @"\obj\spring.png", png);
                ImageManager.GetBitmap("double").Save(rootpath + @"\obj\double.png", png);

                ImageManager.GetBitmap("background").Save(rootpath + @"\theme\background.png", png);
                ImageManager.GetBitmap("ground").Save(rootpath + @"\theme\ground.png", png);
            }
            catch(NullReferenceException e)
            {
                MessageBox.Show("Resource Save Error!");
            }

            SaveSound("fever", rootpath + @"\sound\");
            SaveSound("spring", rootpath + @"\sound\");
            SaveSound("double", rootpath + @"\sound\");
            SaveSound("rope", rootpath + @"\sound\");

            FileInfo fi = new FileInfo(SoundManager.GetBackgroundFilePath());

            if (fi.Exists)
            {
                fi.CopyTo(rootpath + @"\sound\background.mp3");
            }
        }

        void SaveSound(string objecttype, string path)
        {
            string filepath = SoundManager.GetSoundFilePath(objecttype);

            if (filepath == null)
                return;

            FileInfo fi = new FileInfo(filepath);

            if (fi.Exists)
            {
                fi.CopyTo(path + objecttype + ".mp3");
            }
        }

        public void Load(string filename, string safefilename)
        {
            string path = filename;
            string name = safefilename;
            string rootpath = filename.Replace(safefilename, "");

            m_MapPath = rootpath;

            ObjectContainer.Clear();

            LoadResource(rootpath);
            LoadMapData(path);
        }

        void LoadResource(string rootpath)
        {
            ImageManager.AddBitmap("background", new Bitmap(rootpath + @"\theme\background.png"));
            ImageManager.AddBitmap("ground", new Bitmap(rootpath + @"\theme\ground.png"));

            ImageManager.AddBitmap("platform", new Bitmap(rootpath + @"\obj\platform.png"));
            ImageManager.AddBitmap("double", new Bitmap(rootpath + @"\obj\double.png"));
            ImageManager.AddBitmap("fever", new Bitmap(rootpath + @"\obj\fever.png"));
            ImageManager.AddBitmap("niddle", new Bitmap(rootpath + @"\obj\niddle.png"));
            ImageManager.AddBitmap("rope", new Bitmap(rootpath + @"\obj\rope.png"));
            ImageManager.AddBitmap("spring", new Bitmap(rootpath + @"\obj\spring.png"));

            SoundManager.AddSound("double", rootpath + @"\sound\double.mp3");
            SoundManager.AddSound("rope", rootpath + @"\sound\rope.mp3");
            SoundManager.AddSound("fever", rootpath + @"\sound\fever.mp3");
            SoundManager.AddSound("spring", rootpath + @"\sound\spring.mp3");
            SoundManager.SetBackground(rootpath + @"\sound\background.mp3");
        }

        void LoadMapData(string filepath)
        {
            string data = File.ReadAllText(filepath);
            MapData mapdata = JsonConvert.DeserializeObject<MapData>(data);

            Program.MainMap.Load(mapdata);

            foreach (var node in mapdata.NormalObjectList)
            {
                BaseObject obj = null;

                switch (node.ObjectType)
                {
                    case "platform":
                        obj = new Platform(node);
                        ObjectContainer.PlatformList.Add(obj);
                        Program.MainForm.ObjectPanel.AddObject(obj);
                        break;

                    case "double":
                        obj = new Double(node);
                        Program.MainForm.ObjectPanel.AddObject(obj);
                        break;

                    case "fever":
                        obj = new Fever(node);
                        Program.MainForm.ObjectPanel.AddObject(obj);
                        break;
                }
            }

            foreach (var node in mapdata.NiddleObjectList)
                Program.MainForm.ObjectPanel.AddObject(new Niddle(node));

            foreach (var node in mapdata.RopeObjectList)
                Program.MainForm.ObjectPanel.AddObject(new Rope(node));

            foreach (var node in mapdata.SpringObjectList)
                Program.MainForm.ObjectPanel.AddObject(new Spring(node));
        }
    }
}
