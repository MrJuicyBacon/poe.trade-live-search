using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace poe.trade_live_search
{
    public partial class NotificationForm : Form
    {

        public NotificationForm()
        {
            //this.Opacity = 0;
            BackColor = Color.Magenta;
            ShowInTaskbar = false;
            TransparencyKey = Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            InitializeComponent();
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        //private const int WS_EX_TOOLWINDOW = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                //createParams.Style |= 0x40000000; // WS_CHILD
                createParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
                return createParams;

            }
        }

        public enum GWL
        {
            ExStyle = -20
        }

        //public enum WS_EX
        //{
        //    Transparent = 0x20,
        //    Layered = 0x80000
        //}

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        //[DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        //public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
            //SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
        }

        public string LabelText
        {
            get { return this.priceLabel.Text; }
            set { this.priceLabel.Text = value; }
        }

        public int LabelWidth
        {
            get { return this.priceLabel.Width; }
            set { this.priceLabel.Width = value; }
        }

        public int FormWidth
        {
            get { return this.Width; }
            set { this.Width = value; }
        }



        public void ShowForm(string labelText)
        {
            this.LabelText = labelText;
            this.FormWidth = this.LabelWidth + 30;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 25 - this.LabelWidth, 10);

            this.Show();

            timer1.Stop();
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
        }
    }
}
