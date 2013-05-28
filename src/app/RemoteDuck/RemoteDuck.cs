using System;
using System.Windows.Forms;

namespace RemoteDuck
{
    public partial class RemoteDuck : Form
    {
        readonly DateTime _startTime;

        public RemoteDuck()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "";
            _startTime = DateTime.Now;
            timer1.Enabled = true;
        }

        void TimerTicked(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Runtime: {0}s", Math.Round((DateTime.Now - _startTime).TotalSeconds));
        }
    }
}