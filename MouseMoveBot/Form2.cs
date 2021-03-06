﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace MouseMoveBot
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("gdi32")]
        private static extern int GetPixel(IntPtr hdc, int x, int y);
        [DllImport("User32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        private static readonly IntPtr DesktopDC = GetWindowDC(IntPtr.Zero);

        List<Point> listMoves = new List<Point>()
        {
            new Point(467,1060),
            new Point(1462,15),
            new Point(826,413)
        };

        Form1 f1;
        Form3 f3;
        Form4 f4;

        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f1 = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.cbHealthHealer.Checked = f1.cbHealerLife.Checked;
            this.comboBoxHealthMax.Text = f1.textboxMaxHealth.Text;
            this.comboBoxHealthMid.Text = f1.textboxMidHealth.Text;
            this.comboBoxHealthMin.Text = f1.textboxMinHealth.Text;
            this.comboBoxMana.Text = f1.comboBoxManaKey.Text;
            this.cbManaHealer.Checked = f1.cbHealerMana.Checked;
            this.checkHungry.Checked = f1.checkHungry.Checked;
            this.checkPoisoned.Checked = f1.checkPoisoned.Checked;
            this.cbCurePoison.Text = f1.keyCurePoison;
            this.cbEatFood.Text = f1.keyEatFood;
            this.cbCureParalyze.Text = f1.keyCureParalyze;
            this.checkParalyze.Checked = f1.checkParalyze.Checked;
            this.checkUseEnergyRing.Checked = f1.checkUseEnergyRing.Checked;
            this.cbUseEnergyRing.Text = f1.keyUseEnergyRing;
            CriaComboBox();
        }

        private void CriaComboBox()
        {
            System.Object[] ItemRange = new System.Object[12];
            for (int i = 0; i < 12; i++)
            {
                ItemRange[i] = "F" + (i + 1);
            }
            this.comboBoxHealthMax.Items.AddRange(ItemRange);
            this.comboBoxHealthMid.Items.AddRange(ItemRange);
            this.comboBoxHealthMin.Items.AddRange(ItemRange);
            this.cbCurePoison.Items.AddRange(ItemRange);
            this.cbEatFood.Items.AddRange(ItemRange);
            this.comboBoxMana.Items.AddRange(ItemRange);
            this.cbCureParalyze.Items.AddRange(ItemRange);
            this.cbUseEnergyRing.Items.AddRange(ItemRange);
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void CavebotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(f1);
            this.Hide();
            f3.ShowDialog();
        }

        private void TargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4 = new Form4(f1);
            this.Hide();
            f4.ShowDialog();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbHealerLife.Checked = this.cbHealthHealer.Checked;
        }

        private void CbManaHealer_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbHealerMana.Checked = this.cbManaHealer.Checked;
        }

        private void ComboBoxHealthMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMaxHealth.Text = this.comboBoxHealthMax.Text;
            f1.keyMaxHealerSelected = this.comboBoxHealthMax.Text;
        }

        private void ComboBoxHealthMid_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMidHealth.Text = this.comboBoxHealthMid.Text;
            f1.keyMidHealerSelected = this.comboBoxHealthMid.Text;
        }

        private void ComboBoxHealthMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMinHealth.Text = this.comboBoxHealthMin.Text;
            f1.keyMinHealerSelected = this.comboBoxHealthMin.Text;
        }

        private void ComboBoxMana_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.comboBoxManaKey.Text = this.comboBoxMana.Text;
            f1.keyManaSelected = this.comboBoxMana.Text;
        }

        private void cbCurePoison_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyCurePoison = this.cbCurePoison.Text;
        }

        private void checkHungry_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkHungry.Checked = this.checkHungry.Checked;
        }

        private void cbEatFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyEatFood = this.cbEatFood.Text;
        }

        private void checkPoisoned_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkPoisoned.Checked = this.checkPoisoned.Checked;
        }

        private void cbCureParalyze_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyCureParalyze = this.cbCureParalyze.Text;
        }

        private void checkParalyze_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkParalyze.Checked = this.checkParalyze.Checked;
        }

        private void cbUseEnergyRing_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.keyUseEnergyRing = this.cbUseEnergyRing.Text;            
        }

        private void checkUseEnergyRing_CheckedChanged(object sender, EventArgs e)
        {
            f1.checkUseEnergyRing.Checked = this.checkUseEnergyRing.Checked;
        }
    }
}
