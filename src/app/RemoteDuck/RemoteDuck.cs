using System;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    public partial class RemoteDuck : Form
    {
        readonly Runtime _runtime;

        public RemoteDuck()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "";
            _runtime = new Runtime();
            timer1.Enabled = true;
        }

        void TimerTicked(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _runtime.GetElapsedTimeText();
        }
    }
}