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

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("User32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        private static readonly IntPtr DesktopDC = GetWindowDC(IntPtr.Zero);

        int zoom = 2;

        String keyHealerSelected;
        String keyManaSelected;
        String keySdSelected;

        System.Object[] ItemRange;

        Graphics g;

        List<Point> listMoves = new List<Point>()
        {
            new Point(467,1060),
            new Point(1462,15),
            new Point(826,413)
        };

        List<Waypoints> listWaypoints = new List<Waypoints>();

        Form2 newform;
        Task taskHealers; Task taskCavebot; Task taskAttack; Task taskLoot;
        Waypoints currentWaypoint = new Waypoints() { bitIcon = null, delay = 2000, state = State.Waiting };
        public Form1()
        {
            InitializeComponent();
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
            timer1.Interval = 1;
            CriaComboBox();
            createWaypoints();
            ManageFunction();
        }

        private void createWaypoints()
        {
            listWaypoints = new List<Waypoints>();

            var sequenceIcons = new List<String>()
            {
                "C:\\Users\\ALM4CT\\Desktop\\iconG.png",
                "C:\\Users\\ALM4CT\\Desktop\\iconO.png",
                "C:\\Users\\ALM4CT\\Desktop\\iconL.png"
            };
            var x = 286;
            foreach (var path in sequenceIcons)
            {
                listWaypoints.Add(new Waypoints()
                {
                    bitIcon = new Bitmap(path),
                    delay = 1000,
                    state = State.Waiting,
                    point = new Point(833, x)
                });
                x = x + 50;
            }

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
            this.comboBoxLifeKey.Items.AddRange(ItemRange);
            this.comboBoxManaKey.Items.AddRange(ItemRange);
            this.comboBoxSdKey.Items.AddRange(ItemRange);
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
        }

        public static System.Drawing.Color GetPixelAtCursor()
        {
            System.Drawing.Point p = Cursor.Position;
            return System.Drawing.Color.FromArgb(GetPixel(DesktopDC, p.X, p.Y));
        }

        public void ManageFunction()
        {
            var iconTibia = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 10, 10));
            Color iconColor = Color.FromArgb(0, 0, 24, 213);

            var iconGoogle = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 830, 291));
            var iconGoogleColor = Color.FromArgb(0, 244, 133, 66);

            {
                taskHealers = Task.Factory.StartNew(() =>
                {
                    do
                    {
                        if (this.cbHealerLife.Checked)
                        {
                            checkHealer();
                        }

                        if (this.cbHealerMana.Checked)
                        {
                            checkMana();
                        }

                        Task.Delay(500).Wait();
                    } while (true);
                });

                taskCavebot = Task.Factory.StartNew(() =>
                {
                    do
                    {
                        if (cbCavebot.Checked)
                        {
                            // Attacking
                            if (this.cbTarget.Checked)
                            {
                                Task.Delay(10).Wait();
                                continue;
                            }

                            // Walking
                            if (currentWaypoint != null && currentWaypoint.state == State.Walking)
                            {
                                checkArrivedWaypoint();
                                Task.Delay(1).Wait();
                                continue;
                            }

                            // waiting
                            if (currentWaypoint.state == State.Waiting || currentWaypoint.state == State.Attacking)
                            {
                                walk();
                            }

                            if (currentWaypoint.state == State.Concluded)
                            {
                                var index = listWaypoints.IndexOf(currentWaypoint) >= listWaypoints.Count - 1 ? listWaypoints.IndexOf(currentWaypoint) : listWaypoints.IndexOf(currentWaypoint) + 1;
                                if (index == (listWaypoints.Count - 1) && listWaypoints[index].state == State.Concluded)
                                {
                                    createWaypoints();
                                    index = 0;
                                    Console.WriteLine("Resetou waypoints");
                                }
                                currentWaypoint = listWaypoints[index];
                                currentWaypoint.state = State.Waiting;
                            }
                        }
                        Task.Delay(1000).Wait();
                    } while (true);
                });

                taskAttack = Task.Factory.StartNew(() =>
                {
                    do
                    {
                        if (cbCavebot.Checked)
                        {
                            checkAttack();
                        }
                    } while (true);
                });

                //task4 = Task.Factory.StartNew(() => checkLoot());
            }
        }

        private void checkArrivedWaypoint()
        {
            Task.Delay(10000).Wait();
            currentWaypoint.state = State.Concluded;
        }

        private void walk()
        {
            if (currentWaypoint.bitIcon == null)
            {
                currentWaypoint = listWaypoints.FirstOrDefault();
            }

            moveMouseWaypoint(currentWaypoint.bitIcon);
            DoMouseClick();
            Console.WriteLine("Moveu mouse");
            currentWaypoint.state = State.Walking;
        }

        public Color GetColorAt(Point location)
        {
            Bitmap screenPixel = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        public void checkHealer()
        {
            Color lifeBar = new Color();
            lifeBar = GetColorAt(new Point(620, 33));
            Color iconColor = Color.FromArgb(255, 0, 190, 0);

            if (keyHealerSelected != null && iconColor != lifeBar)
            {
                SendKeys.SendWait("{" + keyHealerSelected + "}");
                Console.WriteLine("Key Healer Pressed.");
            }
            Console.WriteLine("Healer.");

        }

        public void checkMana()
        {
            Color manaBar = new Color();
            manaBar = GetColorAt(new Point(1213, 30));
            Color iconColor = Color.FromArgb(255, 39, 39, 39);

            if (keyManaSelected != null && iconColor == manaBar)
            {
                SendKeys.SendWait("{" + keyManaSelected + "}");
                Console.WriteLine("Key Mana Pressed.");
            }
            Console.WriteLine("Mana.");

        }

        public void checkAttack()
        {
            //var corPainelBattle = new Color();
            //var corBixoBattle = new Color();
            //var bixoSelecionado = new Color();
            //var white = new Color();
            //bixoSelecionado = GetColorAt(new Point(1756, 412));

            //corBixoBattle = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1757, 421));

            //corPainelBattle = Color.FromArgb(0, 65, 65, 65);
            //white = Color.FromArgb(255, 255, 0, 0);
            //var red = Color.FromArgb(255, 255, 0, 0);
            //var bixoSelecionadoRed = GetColorAt(new Point(1756, 412));
            //if (corPainelBattle != corBixoBattle && bixoSelecionado != white)

            var foundIconColor = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1000, 280));
            Color iconColor = Color.FromArgb(0, 197, 120, 14);

            this.Invoke((MethodInvoker)delegate
            {
                if (foundIconColor == iconColor)
                {
                    this.cbTarget.Checked = true;
                    currentWaypoint.state = State.Attacking;
                    Console.WriteLine("Atacando");
                }
                else
                {
                    this.cbTarget.Checked = false;
                }

                //if (this.checkBox6.Checked && bixoSelecionadoRed == red)
                //    checkAttackSd();
            });
        }

        private void checkAttackSd()
        {
            if (this.cbAttackSd.Checked && keySdSelected != null)
            {
                SendKeys.SendWait("{" + keySdSelected + "}");
                Console.WriteLine("Key sd Pressed.");
            }
        }

        public void checkLoot()
        {
        }

        private void moveMouseWaypoint(Bitmap myPic)
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Point? isInCapture = FindLife(screenCapture, myPic);
            if (isInCapture != null)
                Cursor.Position = isInCapture.Value;

            //Cursor.Position = currentWaypoint.point;
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

            Bitmap myPic = new Bitmap("C:\\Users\\ALM4CT\\Desktop\\teste.png");

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
            keyHealerSelected = this.comboBoxLifeKey.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            keyManaSelected = this.comboBoxManaKey.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            keySdSelected = this.comboBoxSdKey.SelectedItem.ToString();
        }

    }
}
