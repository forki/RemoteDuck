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
            timer1.Enabled = true;
            Text = "The RemoteDuckForm says: Don't quack with this session!";
            userTextBox.Text = "Unknown";
            messageTextBox.Text = "This session is taken! Please contact the user above.";
        }

        void TimerTicked(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _runtime.GetElapsedTimeText();
        }
    }
}