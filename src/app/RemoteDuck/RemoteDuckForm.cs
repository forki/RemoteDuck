using System;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    public partial class RemoteDuckForm : Form
    {
        readonly IdleTimeDetector _idleTimeDetector;

        public RemoteDuckForm()
        {
            InitializeComponent();
            idleTimeLabel.Text = "";
            TopMost = true;
            timer1.Enabled = true;
            _idleTimeDetector = new IdleTimeDetector();
            CheckIdleTime();
        }

        void TimerTicked(object sender, EventArgs e)
        {
            CheckIdleTime();
        }

        void CheckIdleTime()
        {
            idleTimeLabel.Text = Formatter.GetIdleTimeText(_idleTimeDetector.GetIdleTime());
        }
    }
}