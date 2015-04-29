using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stop
{
    public partial class frmStop : Form
    {
        public frmStop()
        {
            InitializeComponent();
        }
            DateTime startTime;
            DateTime endTime;
            TimeSpan elapsedTime;
        private void frmStop_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTime = new DateTime();
            startTime = DateTime.Now;
            txtStart.Text = startTime.ToLongTimeString();
            txtEnding.Text = "";
            txtElapsed.Text = "";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            endTime = new DateTime();
            endTime = DateTime.Now;
            txtEnding.Text = endTime.ToLongTimeString();
            elapsedTime = endTime.Subtract(startTime);
            txtElapsed.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }
    }
}
