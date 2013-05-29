using System;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    public partial class RemoteDuckForm : Form
    {
        readonly Runtime _runtime;
        IdleTimeDetector _idleTimeDetector;

        public RemoteDuckForm()
        {
            InitializeComponent();
            elapsedTimeLabel.Text = "";
            idleTimeLabel.Text = "";
            _runtime = new Runtime();
            TopMost = true;
            timer1.Enabled = true;
            _idleTimeDetector = new IdleTimeDetector();
        }

        void TimerTicked(object sender, EventArgs e)
        {
            elapsedTimeLabel.Text = Formatter.GetElapsedTimeText(_runtime.ElapsedTime);
            idleTimeLabel.Text = Formatter.GetIdleTimeText(_idleTimeDetector.GetIdleTime());
        }
    }
}