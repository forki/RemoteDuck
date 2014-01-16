using System;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    public partial class RemoteDuckForm : Form
    {
        readonly IdleTimeDetector _idleTimeDetector;

        private readonly uint _executionState;

        public RemoteDuckForm()
        {
            InitializeComponent();
            idleTimeLabel.Text = "";
            versionLabel.Text = "Version: 0.3";
            TopMost = true;
            timer1.Enabled = true;
            _idleTimeDetector = new IdleTimeDetector();
            CheckIdleTime();

            // Set new state to prevent system sleep
            _executionState = NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);          
        }

        void TimerTicked(object sender, EventArgs e)
        {
            CheckIdleTime();
        }

        void CheckIdleTime()
        {
            idleTimeLabel.Text = Formatter.GetIdleTimeText(_idleTimeDetector.GetIdleTime());
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            NativeMethods.SetThreadExecutionState(_executionState);
        }

        private void OnFirstShown(object sender, EventArgs e)
        {
            Top = Screen.PrimaryScreen.Bounds.Height - Height - 100 ;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 30;
        }
    }
}