using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormElements
{
    public class CustomForm : Form
    {
        private static Random Random = new Random();

        public const int WindowWidth = 1200;
        public const int WindowHeight = 800;

        public PictureBox PictureBox;
        public Label Label;

        public int Score;

        public CustomForm()
        {
            InitForm();
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
            Controls.Clear();

            SuspendLayout();

            // Play button
            var playBtn = new Button();
            playBtn.Text = "Play!";
            playBtn.Width = 125;
            playBtn.Height = 50;
            playBtn.Click += (sender, e) => InitGame();

            // Theme color radio buttons
            var dark = new RadioButton();
            dark.Text = "Must";
            dark.Font = new Font(FontFamily.GenericSansSerif, 12);
            dark.Click += (sender, e) => BackColor = dark.Checked ? Color.Black : Color.White;

            var light = new RadioButton();
            light.Font = new Font(FontFamily.GenericSansSerif, 12);
            light.Text = "Valge";
            light.Click += (sender, e) => BackColor = light.Checked ? Color.White : Color.White;

            var blue = new RadioButton();
            blue.Font = new Font(FontFamily.GenericSansSerif, 12);
            blue.Text = "Sinine";
            blue.Click += (sender, e) => BackColor = blue.Checked ? Color.Blue : Color.White;

            var green = new RadioButton();
            green.Font = new Font(FontFamily.GenericSansSerif, 12);
            green.Text = "Roheline";
            green.Click += (sender, e) => BackColor = green.Checked ? Color.Green : Color.White;

            var buttonGroup = new GroupBox();
            buttonGroup.Text = "Vali teem:";
            buttonGroup.AutoSize = true;
            buttonGroup.Padding = new Padding(10);

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

            // Hello
            var check1 = new CheckBox();
            check1.Text = "Hi!";
            check1.Font = new Font(FontFamily.GenericSansSerif, 12);
            check1.Location = new Point(50, 50);
            check1.Click += (sender, e) => MessageBox.Show("Hi!");

            var check2 = new CheckBox();
            check2.Text = "Hai!";
            check2.Font = new Font(FontFamily.GenericSansSerif, 12);
            check2.Location = new Point(170, 50);
            check2.Click += (sender, e) => MessageBox.Show("Hai!");

            var check3 = new CheckBox();
            check3.Text = "Tere!";
            check3.Font = new Font(FontFamily.GenericSansSerif, 12);
            check3.Location = new Point(50, 100);
            check3.Click += (sender, e) => MessageBox.Show("Tere!");

            var check4 = new CheckBox();
            check4.Text = "Hello!";
            check4.Font = new Font(FontFamily.GenericSansSerif, 12);
            check4.Location = new Point(170, 100);
            check4.Click += (sender, e) => MessageBox.Show("Hello!");

            Controls.Add(playBtn);
            Controls.Add(buttonGroup);
            Controls.Add(check1);
            Controls.Add(check2);
            Controls.Add(check3);
            Controls.Add(check4);

            playBtn.Location = new Point(CenterX(playBtn.Width), CenterY(playBtn.Height));
            buttonGroup.Location = new Point(CenterX(buttonGroup.Width), playBtn.Location.Y + 70);

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

            Controls.Add(Label);
            Controls.Add(PictureBox);

            Label.Location = new Point(CenterX(Label.Width), 100);

            ResumeLayout(true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Width = (int)(pictureBox.Width * 0.95);
            pictureBox.Height = (int)(pictureBox.Height * 0.95);
            pictureBox.Location = new Point(Random.Next(0, WindowWidth - pictureBox.Width), Random.Next(0, WindowHeight - pictureBox.Height));
            Score++;
            UpdateScore();
        }

        private void UpdateScore()
        {
            Label.Text = $"{Score} Clicks";
        }

        private int CenterY(int height) => WindowHeight / 2 - height / 2;
        private int CenterX(int width) => WindowWidth / 2 - width / 2;
    }
}
