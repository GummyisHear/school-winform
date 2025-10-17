using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormElements
{
    public partial class VictoryMessageBox : Form
    {
        private Button buttonClose;
        private Button buttonReturnToMenu;
        private PictureBox pictureBox;

        public event EventHandler ReturnToMenuClicked;

        public VictoryMessageBox()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            Text = "???";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(400, 300);
            MaximizeBox = false;
            MinimizeBox = false;

            var warningLabel = new Label();
            warningLabel.Text = "DON'T click the cat.";
            warningLabel.ForeColor = Color.Red;
            warningLabel.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
            warningLabel.AutoSize = true;

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(200, 150);
            pictureBox.Location = new Point((ClientSize.Width - pictureBox.Width) / 2, 60);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Properties.Resources.stare;
            pictureBox.Click += (sender, args) => 
            {
                pictureBox.Image = Properties.Resources.evil;
                warningLabel.Text = "Bad things will happen.";
                warningLabel.Location = new Point((ClientSize.Width - warningLabel.Width) / 2, 20);

                buttonClose.Text = "???";
                buttonClose.ForeColor = Color.Red;
                buttonClose.Enabled = false;

                buttonReturnToMenu.Text = "?";
                buttonReturnToMenu.ForeColor = Color.Red;
                buttonReturnToMenu.Enabled = false;

                ControlBox = false;
            };

            buttonClose = new Button();
            buttonClose.Text = "Close";
            buttonClose.Size = new Size(100, 30);
            buttonClose.Location = new Point(ClientSize.Width / 4 - buttonClose.Width / 2, pictureBox.Bottom + 30);
            buttonClose.Click += ButtonClose_Click;

            buttonReturnToMenu = new Button();
            buttonReturnToMenu.Text = "Return to Menu";
            buttonReturnToMenu.Size = new Size(150, 30);
            buttonReturnToMenu.Location = new Point(ClientSize.Width * 3 / 4 - buttonReturnToMenu.Width / 2, pictureBox.Bottom + 30);
            buttonReturnToMenu.Click += ButtonReturnToMenu_Click;

            Controls.Add(pictureBox);
            Controls.Add(warningLabel);
            Controls.Add(buttonClose);
            Controls.Add(buttonReturnToMenu);

            warningLabel.Location = new Point((ClientSize.Width - warningLabel.Width) / 2, 20);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonReturnToMenu_Click(object sender, EventArgs e)
        {
            ReturnToMenuClicked?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}