using System;
using System.Drawing;
using System.Windows.Forms;


namespace DeskPlate
{
    public partial class PlateForm : Form
    {
        SettingsForm settings = new SettingsForm();

        public PlateForm()
        {
            //start with form invisible
            this.Visible = false;
            //always on top
            this.TopMost = true;
            // background color is black
            this.BackColor = Color.Black;
            // set form size
            this.Size = new Size(600, 200);    
            // set form location to center of the display
            this.Location = new Point(400, 200);
            // set form style to no border
            this.FormBorderStyle = FormBorderStyle.None;
            // set form opacity to 0.5
            this.Opacity = 0.5;

            InitializeComponent();

            // do not show the form when first time to be shown
            this.Shown += new EventHandler(HidePlate);
            // get virtual desktop name
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //set the form click-through
                cp.ExStyle |= 0x00000020;  // WS_EX_TRANSPARENT
                return cp;
            }
        }

        // hide when 1st time to shown
        private void PlateForm_Shown(object sender, EventArgs e)
        {
            this.HidePlate();
        }

        // function to notify
        public void notify(int time,string text)
        {
            // replace message 
            this.MessageLabel.Text = text;
            // show form
            this.ShowPlate();
            // wait for time using timer event
            Timer timer = new Timer();
            timer.Interval = time;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                if (this.Visible)
                {
                    this.HidePlate();
                }
            };
            timer.Start();
        }

        // function to show
        public void ShowPlate()
        {
            this.Show();
        }

        public void OpenSettings()
        {
            this.settings.Show();
        }

        // function to hide
        void HidePlate(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void HidePlate()
        {
            this.Hide();
        }
    }
}
