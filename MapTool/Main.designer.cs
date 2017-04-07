namespace MapTool
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadTheme = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로만들기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.테마ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.테마불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.테마저장하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.배경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.바닥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.미리보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.미리보기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.미리보기정지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Rope = new System.Windows.Forms.PictureBox();
            this.Btn_DJump = new System.Windows.Forms.PictureBox();
            this.Btn_Niddle = new System.Windows.Forms.PictureBox();
            this.Btn_Platform = new System.Windows.Forms.PictureBox();
            this.Btn_Spring = new System.Windows.Forms.PictureBox();
            this.Btn_Fever = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button16 = new System.Windows.Forms.Button();
            this.Btn_SelectSpringSound = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.button14 = new System.Windows.Forms.Button();
            this.Btn_SelectFeverSound = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button12 = new System.Windows.Forms.Button();
            this.Btn_SelectRopeSound = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_DeleteAllGround = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button18 = new System.Windows.Forms.Button();
            this.Btn_SelectDoubleSound = new System.Windows.Forms.Button();
            this.Btn_DeleteGround = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new MapTool.DoubleBufferPanel();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Rope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_DJump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Niddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Spring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Fever)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_DeleteGround)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadTheme);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // LoadTheme
            // 
            this.LoadTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTheme.Location = new System.Drawing.Point(6, 20);
            this.LoadTheme.Name = "LoadTheme";
            this.LoadTheme.Size = new System.Drawing.Size(149, 88);
            this.LoadTheme.TabIndex = 0;
            this.LoadTheme.Text = "테마 불러오기";
            this.LoadTheme.UseVisualStyleBackColor = true;
            this.LoadTheme.Click += new System.EventHandler(this.LoadTheme_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.테마ToolStripMenuItem,
            this.미리보기ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로만들기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.불러오기ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 새로만들기ToolStripMenuItem
            // 
            this.새로만들기ToolStripMenuItem.Name = "새로만들기ToolStripMenuItem";
            this.새로만들기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.새로만들기ToolStripMenuItem.Text = "새로 만들기";
            this.새로만들기ToolStripMenuItem.Click += new System.EventHandler(this.새로만들기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 불러오기ToolStripMenuItem
            // 
            this.불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            this.불러오기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.불러오기ToolStripMenuItem.Text = "불러오기";
            this.불러오기ToolStripMenuItem.Click += new System.EventHandler(this.불러오기ToolStripMenuItem_Click);
            // 
            // 테마ToolStripMenuItem
            // 
            this.테마ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.테마불러오기ToolStripMenuItem,
            this.테마저장하기ToolStripMenuItem,
            this.배경ToolStripMenuItem,
            this.바닥ToolStripMenuItem});
            this.테마ToolStripMenuItem.Name = "테마ToolStripMenuItem";
            this.테마ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.테마ToolStripMenuItem.Text = "테마";
            // 
            // 테마불러오기ToolStripMenuItem
            // 
            this.테마불러오기ToolStripMenuItem.Name = "테마불러오기ToolStripMenuItem";
            this.테마불러오기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.테마불러오기ToolStripMenuItem.Text = "테마 불러오기";
            // 
            // 테마저장하기ToolStripMenuItem
            // 
            this.테마저장하기ToolStripMenuItem.Name = "테마저장하기ToolStripMenuItem";
            this.테마저장하기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.테마저장하기ToolStripMenuItem.Text = "테마 저장하기";
            // 
            // 배경ToolStripMenuItem
            // 
            this.배경ToolStripMenuItem.Name = "배경ToolStripMenuItem";
            this.배경ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.배경ToolStripMenuItem.Text = "배경";
            // 
            // 바닥ToolStripMenuItem
            // 
            this.바닥ToolStripMenuItem.Name = "바닥ToolStripMenuItem";
            this.바닥ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.바닥ToolStripMenuItem.Text = "바닥";
            // 
            // 미리보기ToolStripMenuItem
            // 
            this.미리보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.미리보기ToolStripMenuItem1,
            this.미리보기정지ToolStripMenuItem});
            this.미리보기ToolStripMenuItem.Name = "미리보기ToolStripMenuItem";
            this.미리보기ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.미리보기ToolStripMenuItem.Text = "미리보기";
            // 
            // 미리보기ToolStripMenuItem1
            // 
            this.미리보기ToolStripMenuItem1.Name = "미리보기ToolStripMenuItem1";
            this.미리보기ToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.미리보기ToolStripMenuItem1.Text = "미리보기 시작";
            this.미리보기ToolStripMenuItem1.Click += new System.EventHandler(this.미리보기ToolStripMenuItem1_Click);
            // 
            // 미리보기정지ToolStripMenuItem
            // 
            this.미리보기정지ToolStripMenuItem.Name = "미리보기정지ToolStripMenuItem";
            this.미리보기정지ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.미리보기정지ToolStripMenuItem.Text = "미리보기 정지";
            this.미리보기정지ToolStripMenuItem.Click += new System.EventHandler(this.미리보기정지ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Rope, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_DJump, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Niddle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Platform, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Spring, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Fever, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_DeleteGround, 0, 1);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1061, 94);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Btn_Rope
            // 
            this.Btn_Rope.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Rope.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Rope.Image")));
            this.Btn_Rope.Location = new System.Drawing.Point(655, 37);
            this.Btn_Rope.Name = "Btn_Rope";
            this.Btn_Rope.Size = new System.Drawing.Size(50, 50);
            this.Btn_Rope.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Rope.TabIndex = 12;
            this.Btn_Rope.TabStop = false;
            this.Btn_Rope.Click += new System.EventHandler(this.Btn_Rope_Click);
            // 
            // Btn_DJump
            // 
            this.Btn_DJump.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_DJump.Image = ((System.Drawing.Image)(resources.GetObject("Btn_DJump.Image")));
            this.Btn_DJump.Location = new System.Drawing.Point(504, 37);
            this.Btn_DJump.Name = "Btn_DJump";
            this.Btn_DJump.Size = new System.Drawing.Size(50, 50);
            this.Btn_DJump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_DJump.TabIndex = 11;
            this.Btn_DJump.TabStop = false;
            this.Btn_DJump.Click += new System.EventHandler(this.Btn_DJump_Click);
            // 
            // Btn_Niddle
            // 
            this.Btn_Niddle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Niddle.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Niddle.Image")));
            this.Btn_Niddle.Location = new System.Drawing.Point(353, 37);
            this.Btn_Niddle.Name = "Btn_Niddle";
            this.Btn_Niddle.Size = new System.Drawing.Size(50, 50);
            this.Btn_Niddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Niddle.TabIndex = 10;
            this.Btn_Niddle.TabStop = false;
            this.Btn_Niddle.Click += new System.EventHandler(this.Btn_Niddle_Click);
            // 
            // Btn_Platform
            // 
            this.Btn_Platform.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Platform.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Platform.Image")));
            this.Btn_Platform.Location = new System.Drawing.Point(202, 37);
            this.Btn_Platform.Name = "Btn_Platform";
            this.Btn_Platform.Size = new System.Drawing.Size(50, 50);
            this.Btn_Platform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Platform.TabIndex = 9;
            this.Btn_Platform.TabStop = false;
            this.Btn_Platform.Click += new System.EventHandler(this.Btn_Platform_Click);
            // 
            // Btn_Spring
            // 
            this.Btn_Spring.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Spring.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Spring.Image")));
            this.Btn_Spring.Location = new System.Drawing.Point(958, 37);
            this.Btn_Spring.Name = "Btn_Spring";
            this.Btn_Spring.Size = new System.Drawing.Size(50, 50);
            this.Btn_Spring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Spring.TabIndex = 8;
            this.Btn_Spring.TabStop = false;
            this.Btn_Spring.Click += new System.EventHandler(this.Btn_Spring_Click);
            // 
            // Btn_Fever
            // 
            this.Btn_Fever.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Fever.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Fever.Image")));
            this.Btn_Fever.Location = new System.Drawing.Point(806, 37);
            this.Btn_Fever.Name = "Btn_Fever";
            this.Btn_Fever.Size = new System.Drawing.Size(50, 50);
            this.Btn_Fever.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_Fever.TabIndex = 7;
            this.Btn_Fever.TabStop = false;
            this.Btn_Fever.Click += new System.EventHandler(this.Btn_Fever_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.button16, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.Btn_SelectSpringSound, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(907, 1);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(153, 30);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // button16
            // 
            this.button16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button16.BackgroundImage")));
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button16.Location = new System.Drawing.Point(66, 5);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(20, 20);
            this.button16.TabIndex = 2;
            this.button16.Text = "Play";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // Btn_SelectSpringSound
            // 
            this.Btn_SelectSpringSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_SelectSpringSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_SelectSpringSound.BackgroundImage")));
            this.Btn_SelectSpringSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_SelectSpringSound.Location = new System.Drawing.Point(15, 5);
            this.Btn_SelectSpringSound.Name = "Btn_SelectSpringSound";
            this.Btn_SelectSpringSound.Size = new System.Drawing.Size(20, 20);
            this.Btn_SelectSpringSound.TabIndex = 1;
            this.Btn_SelectSpringSound.Text = "Play";
            this.Btn_SelectSpringSound.UseVisualStyleBackColor = true;
            this.Btn_SelectSpringSound.Click += new System.EventHandler(this.Btn_SelectSpringSound_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Controls.Add(this.button14, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Btn_SelectFeverSound, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(756, 1);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // button14
            // 
            this.button14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button14.BackgroundImage")));
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button14.Location = new System.Drawing.Point(65, 5);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(20, 20);
            this.button14.TabIndex = 2;
            this.button14.Text = "Play";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // Btn_SelectFeverSound
            // 
            this.Btn_SelectFeverSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_SelectFeverSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_SelectFeverSound.BackgroundImage")));
            this.Btn_SelectFeverSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_SelectFeverSound.Location = new System.Drawing.Point(15, 5);
            this.Btn_SelectFeverSound.Name = "Btn_SelectFeverSound";
            this.Btn_SelectFeverSound.Size = new System.Drawing.Size(20, 20);
            this.Btn_SelectFeverSound.TabIndex = 1;
            this.Btn_SelectFeverSound.Text = "Play";
            this.Btn_SelectFeverSound.UseVisualStyleBackColor = true;
            this.Btn_SelectFeverSound.Click += new System.EventHandler(this.Btn_SelectFeverSound_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.button12, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.Btn_SelectRopeSound, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(605, 1);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.Location = new System.Drawing.Point(65, 5);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(20, 20);
            this.button12.TabIndex = 2;
            this.button12.Text = "Play";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // Btn_SelectRopeSound
            // 
            this.Btn_SelectRopeSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_SelectRopeSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_SelectRopeSound.BackgroundImage")));
            this.Btn_SelectRopeSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_SelectRopeSound.Location = new System.Drawing.Point(15, 5);
            this.Btn_SelectRopeSound.Name = "Btn_SelectRopeSound";
            this.Btn_SelectRopeSound.Size = new System.Drawing.Size(20, 20);
            this.Btn_SelectRopeSound.TabIndex = 1;
            this.Btn_SelectRopeSound.Text = "Play";
            this.Btn_SelectRopeSound.UseVisualStyleBackColor = true;
            this.Btn_SelectRopeSound.Click += new System.EventHandler(this.Btn_SelectRopeSound_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Btn_DeleteAllGround, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Btn_DeleteAllGround
            // 
            this.Btn_DeleteAllGround.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_DeleteAllGround.BackColor = System.Drawing.Color.White;
            this.Btn_DeleteAllGround.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_DeleteAllGround.BackgroundImage")));
            this.Btn_DeleteAllGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_DeleteAllGround.Location = new System.Drawing.Point(115, 5);
            this.Btn_DeleteAllGround.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_DeleteAllGround.Name = "Btn_DeleteAllGround";
            this.Btn_DeleteAllGround.Size = new System.Drawing.Size(20, 20);
            this.Btn_DeleteAllGround.TabIndex = 0;
            this.Btn_DeleteAllGround.Text = "Play";
            this.Btn_DeleteAllGround.UseVisualStyleBackColor = false;
            this.Btn_DeleteAllGround.Click += new System.EventHandler(this.Btn_DeleteAllGround_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(152, 1);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(303, 1);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.button18, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.Btn_SelectDoubleSound, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(454, 1);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // button18
            // 
            this.button18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button18.BackgroundImage")));
            this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button18.Location = new System.Drawing.Point(115, 5);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(20, 20);
            this.button18.TabIndex = 2;
            this.button18.Text = "Play";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // Btn_SelectDoubleSound
            // 
            this.Btn_SelectDoubleSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_SelectDoubleSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_SelectDoubleSound.BackgroundImage")));
            this.Btn_SelectDoubleSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_SelectDoubleSound.Location = new System.Drawing.Point(65, 5);
            this.Btn_SelectDoubleSound.Name = "Btn_SelectDoubleSound";
            this.Btn_SelectDoubleSound.Size = new System.Drawing.Size(20, 20);
            this.Btn_SelectDoubleSound.TabIndex = 1;
            this.Btn_SelectDoubleSound.Text = "Play";
            this.Btn_SelectDoubleSound.UseVisualStyleBackColor = true;
            this.Btn_SelectDoubleSound.Click += new System.EventHandler(this.Btn_SelectDoubleSound_Click);
            // 
            // Btn_DeleteGround
            // 
            this.Btn_DeleteGround.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_DeleteGround.Image = ((System.Drawing.Image)(resources.GetObject("Btn_DeleteGround.Image")));
            this.Btn_DeleteGround.Location = new System.Drawing.Point(51, 37);
            this.Btn_DeleteGround.Name = "Btn_DeleteGround";
            this.Btn_DeleteGround.Size = new System.Drawing.Size(50, 50);
            this.Btn_DeleteGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Btn_DeleteGround.TabIndex = 6;
            this.Btn_DeleteGround.TabStop = false;
            this.Btn_DeleteGround.Click += new System.EventHandler(this.Btn_GroundDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(170, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1073, 120);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "3/4";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(92, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "4/4";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "BPM : 120";
            this.label1.DoubleClick += new System.EventHandler(this.BPMLabel_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "오브젝트 수 : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(328, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 56);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Location = new System.Drawing.Point(3, 130);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 56);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "박자";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(196, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(116, 56);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "BPM";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 199);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(0, 760);
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 449);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Godole";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Rope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_DJump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Niddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Spring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Fever)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_DeleteGround)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadTheme;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로만들기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 테마ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 테마불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 테마저장하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 배경ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 바닥ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_DeleteAllGround;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button Btn_SelectRopeSound;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button Btn_SelectSpringSound;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button Btn_SelectFeverSound;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button Btn_SelectDoubleSound;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox Btn_DeleteGround;
        private System.Windows.Forms.PictureBox Btn_Rope;
        private System.Windows.Forms.PictureBox Btn_DJump;
        private System.Windows.Forms.PictureBox Btn_Niddle;
        private System.Windows.Forms.PictureBox Btn_Platform;
        private System.Windows.Forms.PictureBox Btn_Spring;
        private System.Windows.Forms.PictureBox Btn_Fever;
        private System.Windows.Forms.ToolStripMenuItem 미리보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 미리보기ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 미리보기정지ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private DoubleBufferPanel panel1;
    }
}

