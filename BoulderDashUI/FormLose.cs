using System;
using System.Windows.Forms;

namespace BoulderDashUI
{
    public partial class FormLose : Form
    {
        public FormLose()
        {
            InitializeComponent();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}