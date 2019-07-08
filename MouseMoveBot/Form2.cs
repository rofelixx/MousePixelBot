using System;
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

        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f1 = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = f1.cbHealerLife.Checked;
            this.comboBoxHealthMax.Text = f1.textboxMaxHealth.Text;
            this.comboBoxHealthMid.Text = f1.textboxMidHealth.Text;
            this.comboBoxHealthMin.Text = f1.textboxMinHealth.Text;
            this.comboBoxMana.Text = f1.comboBoxManaKey.Text;
            this.cbManaHealer.Checked = f1.cbHealerMana.Checked;
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
            this.comboBoxMana.Items.AddRange(ItemRange);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbHealerLife.Checked = this.checkBox1.Checked;
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    
        private void ComboBoxHealthMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMinHealth.Text = this.comboBoxHealthMin.Text;
            f1.keyMinHealerSelected = this.comboBoxHealthMin.Text;
        }

        private void ComboBoxHealthMid_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMidHealth.Text = this.comboBoxHealthMid.Text;
            f1.keyMidHealerSelected = this.comboBoxHealthMid.Text;
        }

        private void ComboBoxHealthMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.textboxMaxHealth.Text = this.comboBoxHealthMax.Text;
            f1.keyMaxHealerSelected = this.comboBoxHealthMax.Text;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            f1.cbHealerMana.Checked = this.cbManaHealer.Checked;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.comboBoxManaKey.Text = this.comboBoxMana.Text;
            f1.keyManaSelected = this.comboBoxMana.Text;
        }
    }
}
