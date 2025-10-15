using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormElements
{
    public class CatClicker : Form
    {
        private static Random Random = new Random();

        public const int WindowWidth = 1200;
        public const int WindowHeight = 800;

        public PictureBox PictureBox;
        public Label Label;

        private TabControl _tabControl;
        private TabPage _tabPage1;
        private TabPage _tabPage2;

        private ProgressBar _progressBar;
        private Timer _timer;
        private int _timerMaxValue = 1000;
        private int _timerInterval = 50;
        private int _timeLeft;

        public int Score;

        public CatClicker()
        {
            InitForm();
            AddTabs();
            InitMenu();
        }

        private void InitForm()
        {
            ClientSize = new Size(WindowWidth, WindowHeight);
            Name = "CustomForm";
            Text = "Cat Clicker";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
        }

        private void InitMenu()
        {
            _tabPage1.Controls.Clear();

            SuspendLayout();

            // Play button
            var playBtn = new Button();
            playBtn.Text = "Play!";
            playBtn.Width = 125;
            playBtn.Height = 50;
            playBtn.Click += (sender, e) => InitGame();

            _tabPage1.Controls.Add(playBtn);

            playBtn.Location = new Point(CenterX(playBtn.Width), CenterY(playBtn.Height));

            ResumeLayout(true);
        }

        private void AddTabs()
        {
            _tabControl = new TabControl();
            _tabControl.Dock = DockStyle.Fill;

            _tabPage1 = new TabPage("Mängi");
            _tabPage2 = new TabPage("Seaded");

            _tabControl.TabPages.Add(_tabPage1);
            _tabControl.TabPages.Add(_tabPage2);

            _tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            Controls.Add(_tabControl);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tabControl.SelectedTab == _tabPage1)
            {
                InitMenu();
            }
            else if (_tabControl.SelectedTab == _tabPage2)
            {
                InitTab2();
            }
        }

        private void InitTab2()
        {
            _tabPage2.Controls.Clear();
            SuspendLayout();

            // ListBox
            ListBox listBox = new ListBox();
            listBox.Size = new Size(200, 100);
            listBox.Location = new Point(CenterX(200), 20);
            listBox.Items.Add("Apple");
            listBox.Items.Add("Banana");
            listBox.Items.Add("Cherry");
            listBox.Items.Add("Date");
            listBox.Items.Add("Elderberry");

            _tabPage2.Controls.Add(listBox);

            // Theme color radio buttons
            var dark = new RadioButton();
            dark.Text = "Must";
            dark.Font = new Font(FontFamily.GenericSansSerif, 12);
            dark.Location = new Point(20, 140);
            dark.Click += (sender, e) => BackColor = dark.Checked ? Color.Black : Color.White;

            var light = new RadioButton();
            light.Text = "Valge";
            light.Font = new Font(FontFamily.GenericSansSerif, 12);
            light.Location = new Point(120, 140);
            light.Click += (sender, e) => BackColor = light.Checked ? Color.White : Color.White;

            var blue = new RadioButton();
            blue.Text = "Sinine";
            blue.Font = new Font(FontFamily.GenericSansSerif, 12);
            blue.Location = new Point(20, 180);
            blue.Click += (sender, e) => BackColor = blue.Checked ? Color.Blue : Color.White;

            var green = new RadioButton();
            green.Text = "Roheline";
            green.Font = new Font(FontFamily.GenericSansSerif, 12);
            green.Location = new Point(120, 180);
            green.Click += (sender, e) => BackColor = green.Checked ? Color.Green : Color.White;

            var buttonGroup = new GroupBox();
            buttonGroup.Text = "Vali teem:";
            buttonGroup.AutoSize = true;
            buttonGroup.Padding = new Padding(10);
            buttonGroup.Location = new Point(10, 130);

            var layout = new TableLayoutPanel();
            layout.ColumnCount = 2;
            layout.RowCount = 2;
            layout.AutoSize = true;
            layout.Dock = DockStyle.Fill;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(dark, 0, 0);
            layout.Controls.Add(light, 1, 0);
            layout.Controls.Add(blue, 0, 1);
            layout.Controls.Add(green, 1, 1);

            buttonGroup.Controls.Add(layout);

            _tabPage2.Controls.Add(buttonGroup);

            // Checkboxes
            var check1 = new CheckBox();
            check1.Text = "Hi!";
            check1.Font = new Font(FontFamily.GenericSansSerif, 12);
            check1.Location = new Point(20, 250);
            check1.Click += (sender, e) => MessageBox.Show("Hi!");

            var check2 = new CheckBox();
            check2.Text = "Hai!";
            check2.Font = new Font(FontFamily.GenericSansSerif, 12);
            check2.Location = new Point(140, 250);
            check2.Click += (sender, e) => MessageBox.Show("Hai!");

            var check3 = new CheckBox();
            check3.Text = "Tere!";
            check3.Font = new Font(FontFamily.GenericSansSerif, 12);
            check3.Location = new Point(20, 290);
            check3.Click += (sender, e) => MessageBox.Show("Tere!");

            var check4 = new CheckBox();
            check4.Text = "Hello!";
            check4.Font = new Font(FontFamily.GenericSansSerif, 12);
            check4.Location = new Point(140, 290);
            check4.Click += (sender, e) => MessageBox.Show("Hello!");

            _tabPage2.Controls.Add(check1);
            _tabPage2.Controls.Add(check2);
            _tabPage2.Controls.Add(check3);
            _tabPage2.Controls.Add(check4);

            ResumeLayout(true);
        }


        private void InitGame()
        {
            Controls.Clear();
            
            SuspendLayout();

            // 
            // pictureBox1
            // 
            PictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(PictureBox)).BeginInit();
            PictureBox.Image = Properties.Resources.tamm_cat;
            PictureBox.Name = "pictureBox1";
            PictureBox.Size = new Size(497, 442);
            PictureBox.Location = new Point(CenterX(PictureBox.Width), CenterY(PictureBox.Height));
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            PictureBox.Click += new EventHandler(pictureBox1_Click);
            ((System.ComponentModel.ISupportInitialize)(PictureBox)).EndInit();

            //
            // Label
            //
            Label = new Label();
            Label.Text = "Click the Cat!";
            Label.Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Regular);
            Label.AutoSize = true;

            // Progress bar
            _progressBar = new ProgressBar();
            _progressBar.Maximum = _timerMaxValue;
            _progressBar.Value = _timerMaxValue;
            _progressBar.Step = _timerInterval;
            _progressBar.Size = new Size(200, 20);
            _progressBar.Location = new Point(WindowWidth - _progressBar.Width - 20, 20);
            _progressBar.Style = ProgressBarStyle.Continuous;

            // Timer setup
            _timer = new Timer();
            _timer.Interval = _timerInterval; // 50 ms for smooth progress
            _timer.Tick += Timer_Tick;
            _timeLeft = _timerMaxValue;
            _timer.Start();

            Controls.Add(_progressBar);
            Controls.Add(Label);
            Controls.Add(PictureBox);

            Label.Location = new Point(CenterX(Label.Width), 100);

            ResumeLayout(true);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeLeft -= _timerInterval;
            _progressBar.Value = Math.Max(0, _timeLeft);

            if (_timeLeft <= 0)
            {
                _timer.Stop();
                ShowFailWindow();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Width = (int)(pictureBox.Width * 0.95);
            pictureBox.Height = (int)(pictureBox.Height * 0.95);
            pictureBox.Location = new Point(Random.Next(0, WindowWidth - pictureBox.Width), Random.Next(0, WindowHeight - pictureBox.Height));
            Score++;
            UpdateScore();

            _timerMaxValue -= 20;
            _timerMaxValue = Math.Max(400, _timerMaxValue);
            _timeLeft = _timerMaxValue;
            _progressBar.Value = _timerMaxValue;

            if (Random.NextDouble() < 0.05)
            {
                _timer.Stop();

                var customMsgBox = new VictoryMessageBox();
                customMsgBox.ReturnToMenuClicked += (s, ev) =>
                {
                    Score = 0;
                    Controls.Clear();
                    AddTabs();
                    _tabControl.SelectedTab = _tabPage1;
                    InitMenu();
                };
                customMsgBox.ShowDialog();

                _timer.Start();
            }
        }

        private void ShowFailWindow()
        {
            _timer.Stop();

            MessageBox.Show($"Sa kaotasid! Finaalne skoor on: {Score}", "Kaotas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Score = 0;
            Controls.Clear();
            AddTabs();
            _tabControl.SelectedTab = _tabPage1;
            InitMenu();
        }

        private void UpdateScore()
        {
            Label.Text = $"{Score} Clicks";
        }

        private int CenterY(int height) => WindowHeight / 2 - height / 2;
        private int CenterX(int width) => WindowWidth / 2 - width / 2;
    }
}
