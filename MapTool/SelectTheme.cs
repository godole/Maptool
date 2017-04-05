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
    public partial class SelectTheme : Form
    {
        List<string> _ThemeList;
        public SelectTheme(List<string> themeList)
        {
            InitializeComponent();

            _ThemeList = themeList;

            foreach (var item in _ThemeList)
                comboBox1.Items.Add(item);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string resourcePath = @".\\theme\\" + comboBox1.SelectedItem.ToString() + "\\";

            try
            {
                Background.Image = new Bitmap(resourcePath + @"background.png");
                GroundPrev.Image = new Bitmap(resourcePath + @"ground.png");
                PlatformPrev.Image = new Bitmap(resourcePath + @"platform.png");
                NiddlePrev.Image = new Bitmap(resourcePath + @"niddle.png");
                DoublePrev.Image = new Bitmap(resourcePath + @"double.png");
                RopePrev.Image = new Bitmap(resourcePath + @"rope.png");
                FeverPrev.Image = new Bitmap(resourcePath + @"fever.png");
                SpringPrev.Image = new Bitmap(resourcePath + @"spring.png");
            }
            catch(Exception exc)
            {

            }
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            ImageManager.ChangeBitmap("background", new Bitmap(Background.Image));
            ImageManager.ChangeBitmap("ground", new Bitmap(GroundPrev.Image));
            ImageManager.ChangeBitmap("platform", new Bitmap(PlatformPrev.Image));
            ImageManager.ChangeBitmap("niddle", new Bitmap(NiddlePrev.Image));
            ImageManager.ChangeBitmap("double", new Bitmap(DoublePrev.Image));
            ImageManager.ChangeBitmap("rope", new Bitmap(RopePrev.Image));
            ImageManager.ChangeBitmap("fever", new Bitmap(FeverPrev.Image));
            ImageManager.ChangeBitmap("spring", new Bitmap(SpringPrev.Image));

            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
