using System;
using System.Windows.Forms;

namespace BoulderDashUI
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}