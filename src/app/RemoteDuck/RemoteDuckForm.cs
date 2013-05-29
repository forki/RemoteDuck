using System;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    public partial class RemoteDuckForm : Form
    {
        readonly Runtime _runtime;

        public RemoteDuckForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "";
            _runtime = new Runtime();
            TopMost = true;
            timer1.Enabled = true;
        }

        void TimerTicked(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _runtime.GetElapsedTimeText();
        }
    }
}