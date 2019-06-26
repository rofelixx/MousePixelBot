using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class Form1 : Form
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

        int zoom = 2;

        String keyHealerSelected;
        System.Object[] ItemRange;

        Graphics g;

        List<Point> listMoves = new List<Point>()
        {
            new Point(467,1060),
            new Point(1462,15),
            new Point(826,413)
        };

        Form2 newform;
        Task task1; Task task2; Task task3; Task task4;
        Thread t1;
        Thread t2;
        Thread t3;

        public Form1()
        {
            InitializeComponent();
            //Cursor.Position = new Point(500, 400);
        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 500;
            CriaComboBox();
        }

        private void CriaComboBox()
        {
            IncluiItems();
        }

        private void IncluiItems()
        {
            ItemRange = new System.Object[12];
            for (int i = 0; i < 12; i++)
            {
                ItemRange[i] = "F" + (i + 1);
            }
            this.comboBox1.Items.AddRange(ItemRange);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Cursor.Position.X.ToString();
            textBox2.Text = Cursor.Position.Y.ToString();
            System.Drawing.Color c = GetPixelAtCursor();
            textBox3.Text = c.B.ToString();
            textBox4.Text = c.G.ToString();
            textBox5.Text = c.R.ToString();
            Bitmap bit = new Bitmap(pictureBox1.Width / zoom, pictureBox1.Height / zoom, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(bit);
            g.CopyFromScreen(Cursor.Position.X - pictureBox1.Width / (zoom * 2), Cursor.Position.Y - pictureBox1.Height / (zoom * 2), 0, 0, pictureBox1.Size, CopyPixelOperation.SourceCopy);
            pictureBox1.Image = bit;
            ManageFunction();
        }

        public static System.Drawing.Color GetPixelAtCursor()
        {
            System.Drawing.Point p = Cursor.Position;
            return System.Drawing.Color.FromArgb(GetPixel(DesktopDC, p.X, p.Y));
        }

        public void ManageFunction()
        {
            //Console.WriteLine(this.checkBox1.Checked + ", " + this.checkBox2.Checked + ", " + this.checkBox3.Checked + ", " + this.checkBox4.Checked);
            var foundIconColor = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 830, 310));
            Color iconColor = Color.FromArgb(0, 244, 133, 66);
            if (foundIconColor == iconColor)
            {
                if (t1 == null || t1.ThreadState != ThreadState.Running)
                    t1 = new Thread(() =>
                    {
                        checkHealer();
                    });

                if (t2 == null || t2.ThreadState != ThreadState.Running)
                    t2 = new Thread(() =>
                    {
                        checkCavebot();
                    });

                if (t3 == null || t3.ThreadState != ThreadState.Running)
                    t3 = new Thread(() =>
                    {
                        checkAttack();
                    });

                t1.Start();
                t2.Start();
                t3.Start();

                //task1 = Task.Factory.StartNew(() => checkHealer());
                //task2 = Task.Factory.StartNew(() => checkCavebot(source.Token), source.Token);
                //task3 = Task.Factory.StartNew(() => checkAttack(source.Token));
                //task4 = Task.Factory.StartNew(() => checkLoot());
            }
        }

        public void checkHealer()
        {
            if (this.checkBox1.Checked)
            {
                var foundIconColor = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1254, 29));
                Color iconColor = Color.FromArgb(0, 173, 78, 0);

                if (keyHealerSelected != null && iconColor != foundIconColor)
                {
                    SendKeys.SendWait("{" + keyHealerSelected + "}");
                    Console.WriteLine("Key Pressed.");
                }

                //Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                //Graphics g = Graphics.FromImage(screenCapture);

                //g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                //                 Screen.PrimaryScreen.Bounds.Y,
                //                 0, 0,
                //                 screenCapture.Size,
                //                 CopyPixelOperation.SourceCopy);

                //Bitmap myPic = new Bitmap("C:\\Users\\ALM4CT\\Desktop\\life.png");

                //Point? find = FindLife(myPic, screenCapture);

                //if (find != null)
                //    MessageBox.Show("Achou", "");
                //else
                //    MessageBox.Show("Não Achou", "");
            }
            Console.WriteLine("Healer.");

        }

        public void checkCavebot()
        {
            if (this.checkBox2.Checked && !this.checkBox3.Checked && !this.checkBox4.Checked)
            {
                foreach (var item in listMoves)
                {
                    if (this.checkBox2.Checked && !this.checkBox3.Checked && !this.checkBox4.Checked)
                    {
                        Cursor.Position = item;
                        Thread.Sleep(10000);
                        //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)item.X, (uint)item.Y, 0, 0);
                        Console.WriteLine("Moveu mouse");
                    }
                    else
                    {
                        t1.Abort();
                        break;
                    }
                }
            }
        }

        public void checkAttack()
        {
            var foundIconColor = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1127, 778));
            Color iconColor = Color.FromArgb(0, 143, 231, 255);

            this.Invoke((MethodInvoker)delegate
            {
                if (iconColor == foundIconColor)
                {
                    t1.Abort();
                    this.checkBox3.Checked = true;
                    this.checkBox2.Checked = false;
                    this.checkBox4.Checked = false;

                    // Attack
                }
                else
                {
                    this.checkBox3.Checked = false;
                    this.checkBox2.Checked = true;
                    this.checkBox4.Checked = false;
                }
            });
        }

        public void checkLoot()
        {
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = trackBar1.Value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //foreach (var item in listMoves)
            //{
            //    Cursor.Position = item;
            //    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)item.X, (uint)item.Y, 0, 0);
            //    Thread.Sleep(1000);
            //}
            //SendKeys.SendWait("{R}");
            checkHealer();
        }

        private void HealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newform = new Form2(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap("C:\\Users\\ALM4CT\\Desktop\\lootbody.png");

            List<Point> isInCapture = Find(screenCapture, myPic);
            if (isInCapture.Count > 0)
                foreach (var item in isInCapture)
                {
                    Cursor.Position = item;
                    Thread.Sleep(1000);
                }

            //Point isInCapture = IsInCapture(myPic, screenCapture);
            //Cursor.Position = isInCapture;
        }

        private Point IsInCapture(Bitmap searchFor, Bitmap searchIn)
        {
            for (int x = 0; x < searchIn.Width; x++)
            {
                for (int y = 0; y < searchIn.Height; y++)
                {
                    bool invalid = false;
                    int k = x, l = y;
                    for (int a = 0; a < searchFor.Width; a++)
                    {
                        l = y;
                        for (int b = 0; b < searchFor.Height; b++)
                        {
                            if (searchFor.GetPixel(a, b) != searchIn.GetPixel(k, l))
                            {
                                invalid = true;
                                break;
                            }
                            else
                                l++;
                        }
                        if (invalid)
                            break;
                        else
                            k++;
                    }
                    if (!invalid)
                        return new Point(x, y);
                }
            }
            return new Point(0, 0);
        }

        public List<Point> Find(Bitmap haystack, Bitmap needle)
        {
            List<Point> list = new List<Point>();
            if (null == haystack || null == needle)
            {
                return null;
            }
            if (haystack.Width < needle.Width || haystack.Height < needle.Height)
            {
                return null;
            }

            var haystackArray = GetPixelArray(haystack);
            var needleArray = GetPixelArray(needle);

            foreach (var firstLineMatchPoint in FindMatch(haystackArray.Take(haystack.Height - needle.Height), needleArray[0]))
            {
                if (IsNeedlePresentAtLocation(haystackArray, needleArray, firstLineMatchPoint, 1))
                {
                    list.Add(firstLineMatchPoint);
                }
            }

            return list;
        }

        public Point? FindLife(Bitmap haystack, Bitmap needle)
        {
            if (null == haystack || null == needle)
            {
                return null;
            }
            if (haystack.Width < needle.Width || haystack.Height < needle.Height)
            {
                return null;
            }

            var haystackArray = GetPixelArray(haystack);
            var needleArray = GetPixelArray(needle);

            foreach (var firstLineMatchPoint in FindMatch(haystackArray.Take(haystack.Height - needle.Height), needleArray[0]))
            {
                if (IsNeedlePresentAtLocation(haystackArray, needleArray, firstLineMatchPoint, 1))
                {
                    return firstLineMatchPoint;
                }
            }

            return null;
        }

        private int[][] GetPixelArray(Bitmap bitmap)
        {
            var result = new int[bitmap.Height][];
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int y = 0; y < bitmap.Height; ++y)
            {
                result[y] = new int[bitmap.Width];
                Marshal.Copy(bitmapData.Scan0 + y * bitmapData.Stride, result[y], 0, result[y].Length);
            }

            bitmap.UnlockBits(bitmapData);

            return result;
        }

        private IEnumerable<Point> FindMatch(IEnumerable<int[]> haystackLines, int[] needleLine)
        {
            var y = 0;
            foreach (var haystackLine in haystackLines)
            {
                for (int x = 0, n = haystackLine.Length - needleLine.Length; x < n; ++x)
                {
                    if (ContainSameElements(haystackLine, x, needleLine, 0, needleLine.Length))
                    {
                        yield return new Point(x, y);
                    }
                }
                y += 1;
            }
        }

        private bool ContainSameElements(int[] first, int firstStart, int[] second, int secondStart, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                if (first[i + firstStart] != second[i + secondStart])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNeedlePresentAtLocation(int[][] haystack, int[][] needle, Point point, int alreadyVerified)
        {
            //we already know that "alreadyVerified" lines already match, so skip them
            for (int y = alreadyVerified; y < needle.Length; ++y)
            {
                if (!ContainSameElements(haystack[y + point.Y], point.X, needle[y], 0, needle.Length))
                {
                    return false;
                }
            }
            return true;
        }

        public static int Distance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            return (int)Math.Round(distance, MidpointRounding.AwayFromZero);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyHealerSelected = this.comboBox1.SelectedItem.ToString();
        }
    }
}
