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
    public partial class Form4 : Form
    {
        Form2 f2;
        Form1 f1;
        Form3 f3;

        public Form4(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void HealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2 = new Form2(f1);
            this.Hide();
            f2.ShowDialog();
        }

        private void CavebotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(f1);
            this.Hide();
            f3.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.cbTarget.Checked = f1.cbTarget.Checked;
        }

        private void CbTarget_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbTarget.Checked = this.cbTarget.Checked;
        }
    }
}
