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
            this.checkAttackSpell.Checked = f1.checkAttackSpell.Checked;
            this.checkAttackMissileRune.Checked = f1.checkAttackMissileRune.Checked;
            this.checkAttackAreaRune.Checked = f1.checkAttackAreaRune.Checked;
            IncluiItems();
            this.cbAttackSpell.Text = f1.keySpellAttack;
            this.cbAttackMissile.Text = f1.keyMissileRune;
            this.cbAttackArea.Text = f1.keyAreaRuneSelected;
        }

        private void IncluiItems()
        {
            var ItemRange = new System.Object[12];
            for (int i = 0; i < 12; i++)
            {
                ItemRange[i] = "F" + (i + 1);
            }
            this.cbAttackArea.Items.AddRange(ItemRange);
            this.cbAttackSpell.Items.AddRange(ItemRange);
            this.cbAttackMissile.Items.AddRange(ItemRange);
        }

        private void CbTarget_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbTarget.Checked = this.cbTarget.Checked;
        }

        private void CbAttackSpell_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keySpellAttack = this.cbAttackSpell.Text;
        }

        private void CbAttackMissile_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyMissileRune = this.cbAttackMissile.Text;
        }

        private void CbAttackArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyAreaRuneSelected = this.cbAttackArea.Text;
        }

        private void CheckAttackSpell_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkAttackSpell.Checked = this.checkAttackSpell.Checked;
        }

        private void CbAttackMissileRune_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkAttackMissileRune.Checked = this.checkAttackMissileRune.Checked;
        }

        private void CheckAreaRune_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkAttackAreaRune.Checked = this.checkAttackAreaRune.Checked;
        }

        private void cbFollowMonster_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbFollowMonster.Checked = this.cbFollowMonster.Checked;
        }
    }
}
