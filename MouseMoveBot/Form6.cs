using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseMoveBot
{
    public partial class Form6 : Form
    {
        Form1 f1;
        Form2 f2;
        Form3 f3;

        public Form6(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbTrainer.Checked = this.cbTrainer.Checked;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void healerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2 = new Form2(f1);
            this.Hide();
            f2.ShowDialog();
        }

        private void cavebotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(f1);
            this.Hide();
            f3.ShowDialog();
        }
    }
}
