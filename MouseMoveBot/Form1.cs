using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Emgu.CV;
using Emgu.CV.Structure;
using WindowsInput;
using WindowsInput.Native;
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

        List<Point> listLootRange = new List<Point>()
        {
            new Point(784, 433),
            new Point(806, 379),
            new Point(871, 378),
            new Point(935, 382),
            new Point(928, 452),
            new Point(937, 512),
            new Point(871, 509),
            new Point(806, 514),
        };

        List<Waypoints> listWaypoints = new List<Waypoints>();

        Form2 newform;

        Task taskHealerLife;
        Task taskHealerMana;
        Task taskCavebot;
        Task taskAttack;
        Task taskAttackSd;
        Task taskTimer;
        Task checkArriveWp;
        Task TaskCheckCap;
        Task TaskCheckBattleList;

        bool battleIsNormal = false;

        Waypoints currentWaypoint = new Waypoints() { bitIcon = null, state = State.Waiting, precision = false };
        Color iconTibia;
        Color iconColor;

        String path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Resources\\";

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
                path + "iconRight.png",
                path + "iconDown.png",
                path + "iconUp.png",
                path + "greenUp.png",
                path + "greenDown.png",
                path + "iconBank.png",
            };
            foreach (var item in sequenceIcons)
            {
                listWaypoints.Add(new Waypoints()
                {
                    bitIcon = new Bitmap(item),
                    state = State.Waiting,
                });
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
            //g.CopyFromScreen(Cursor.Position.X - pictureBox1.Width / (zoom * 2), Cursor.Position.Y - pictureBox1.Height / (zoom * 2), 0, 0, pictureBox1.Size, CopyPixelOperation.SourceCopy);
            pictureBox1.Image = bit;
        }

        public static System.Drawing.Color GetPixelAtCursor()
        {
            System.Drawing.Point p = Cursor.Position;
            return System.Drawing.Color.FromArgb(GetPixel(DesktopDC, p.X, p.Y));
        }

        public void ManageFunction()
        {
            //var iconGoogle = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 830, 291));
            //var iconGoogleColor = Color.FromArgb(0, 244, 133, 66);           

            taskHealerLife = Task.Factory.StartNew(() =>
            {
                do
                {
                    checkIconTibia();
                    if (this.cbHealerLife.Checked && iconTibia == iconColor)
                    {
                        checkHealer();
                    }

                    Task.Delay(100).Wait();
                } while (true);
            });

            taskHealerMana = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (this.cbHealerMana.Checked && iconTibia == iconColor)
                    {
                        checkMana();
                    }

                    Task.Delay(1000).Wait();
                } while (true);
            });

            TaskCheckBattleList = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (this.cbCavebot.Checked && iconTibia == iconColor)
                    {
                        checkBattleList();
                    }

                    Task.Delay(200).Wait();
                } while (true);
            });           

            taskCavebot = Task.Factory.StartNew(() =>
            {
                do
                {
                    //var corBattle = Color.FromArgb(255, 71, 71, 71);
                    //var corPixelBattle = GetColorAt(new Point(1755, 417));

                    if (cbCavebot.Checked && currentWaypoint.state == State.Attacking && iconTibia == iconColor)
                    {
                        looting();
                        Task.Delay(500).Wait();
                    }

                    if (cbCavebot.Checked && currentWaypoint.state == State.Walking && !battleIsNormal && iconTibia == iconColor)
                        SendKeys.SendWait("{Esc}");

                    if (cbCavebot.Checked && battleIsNormal && iconTibia == iconColor)
                    {
                        if (currentWaypoint.state == State.Attacking && battleIsNormal)
                            currentWaypoint.state = State.Waiting;

                        // Attacking
                        if (currentWaypoint.state == State.Attacking)
                        {
                            Task.Delay(300).Wait();
                            continue;
                        }

                        // Walking
                        if (currentWaypoint != null && currentWaypoint.state == State.Walking)
                        {
                            checkArrivedWaypoint();
                            continue;
                        }

                        // waiting
                        if (currentWaypoint.state == State.Waiting)
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
                } while (true);
            });

            taskAttack = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (cbTarget.Checked && iconTibia == iconColor)
                    {
                        checkAttack();
                    }
                } while (true);
            });

            taskAttackSd = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (cbAttackSd.Checked && iconTibia == iconColor)
                    {
                        checkAttackSd();
                    }
                } while (true);
            });

            checkArriveWp = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (cbCavebot.Checked && iconTibia == iconColor && currentWaypoint.bitIcon != null && currentWaypoint.state != State.Attacking)
                    {
                        checkArrivedWaypoint();
                    }
                    Task.Delay(500).Wait();
                } while (true);
            });

            taskTimer = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (cbCavebot.Checked && iconTibia == iconColor && currentWaypoint.state == State.Walking && !battleIsNormal)
                    {
                        checkIfStopped();
                    }
                } while (true);
            });
        }

        private void checkBattleList()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "battleClear.png");
            battleIsNormal = CheckFindBattle(myPic, screenCapture);
        }

        private void checkCap()
        {
            //Rectangle rect = new Rectangle(1826, 264, 18, 9);
        }

        private void checkIfStopped()
        {
            Color c1 = GetColorAt(new Point(808, 434));
            Task.Delay(3000);
            Color c2 = GetColorAt(new Point(808, 434));

            if (c1 == c2)
            {
                currentWaypoint.state = State.Waiting;
                Console.WriteLine("Estava parado.");
            }
        }

        private void checkIconTibia()
        {
            iconTibia = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 10, 10));
            iconColor = Color.FromArgb(0, 0, 24, 213);
        }

        private void checkArrivedWaypoint()
        {
            var arrived = false;

            var p1 = new Point(1780, 70);
            var p2 = new Point(1820, 95);

            Rectangle rect = new Rectangle(1800, 75, 12, 12);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            arrived = CheckFindBattle(currentWaypoint.bitIcon, areaIcon);

            if (arrived)
            {
                currentWaypoint.state = State.Concluded;
            }
        }

        private void walk()
        {
            if (currentWaypoint.state != State.Attacking)
            {
                if (currentWaypoint.bitIcon == null)
                {
                    currentWaypoint = listWaypoints.FirstOrDefault();
                }

                moveMouseWaypointEmgu(currentWaypoint.bitIcon);
                Task.Delay(200).Wait();
                DoMouseClick();
                Task.Delay(200).Wait();
                Console.WriteLine("Moveu mouse");
                Cursor.Position = new Point(1700, 80);
                Task.Delay(200).Wait();
                currentWaypoint.state = State.Walking;
            }
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
            var corPainelBattle = new Color();
            var corBixoBattle = new Color();
            var bixoSelecionado = new Color();
            var white = new Color();
            bixoSelecionado = GetColorAt(new Point(1756, 412));

            corBixoBattle = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1757, 421));

            corPainelBattle = Color.FromArgb(0, 65, 65, 65);
            white = Color.FromArgb(255, 255, 255, 255);
            var red = Color.FromArgb(255, 255, 0, 0);
            var bixoSelecionadoRed = GetColorAt(new Point(1756, 412));

            //var foundIconColor = System.Drawing.Color.FromArgb(GetPixel(DesktopDC, 1000, 280));
            //Color iconColor = Color.FromArgb(0, 197, 120, 14);

            this.Invoke((MethodInvoker)delegate
            {
                if ((corPainelBattle != corBixoBattle && corBixoBattle != white) && bixoSelecionadoRed != red)
                {
                    checkFollowMonster();
                    InputSimulator sim = new InputSimulator();
                    // Press M key
                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                    //SendKeys.SendWait("{Esc}");
                    //Cursor.Position = new Point(1757, 421);
                    //DoMouseClick();
                    //Cursor.Position = new Point(1650, 421);
                    currentWaypoint.state = State.Attacking;
                    Console.WriteLine("Atacando");
                }
            });
            Task.Delay(300).Wait();
        }

        private void checkFollowMonster()
        {
            var follow = Color.FromArgb(255, 85, 255, 85);
            var followMonster = GetColorAt(new Point(1902, 173));

            if (followMonster != follow && cbFollowMonster.Checked)
            {
                Cursor.Position = new Point(1902, 173);
                DoMouseClick();
            }

        }

        private void looting()
        {
            InputSimulator sim = new InputSimulator();
            foreach (var item in listLootRange)
            {
                Cursor.Position = item;
                sim.Keyboard.KeyDown(VirtualKeyCode.LMENU);
                sim.Mouse.LeftButtonClick();
                sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
                if (sim.InputDeviceState.IsKeyDown(VirtualKeyCode.LMENU))
                    sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            }
            if (sim.InputDeviceState.IsKeyDown(VirtualKeyCode.LMENU))
                sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }

        private void checkAttackSd()
        {
            var red = Color.FromArgb(255, 255, 0, 0);
            var bixoSelecionadoRed = GetColorAt(new Point(1756, 412));

            if (this.cbAttackSd.Checked && keySdSelected != null && bixoSelecionadoRed == red)
            {
                SendKeys.SendWait("{" + keySdSelected + "}");
                Console.WriteLine("Key sd Pressed.");
                Task.Delay(1500).Wait();
            }
        }

        public void checkLoot()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Image<Bgr, Byte> source = new Image<Bgr, Byte>(screenCapture);
            Image<Bgr, byte> template = new Image<Bgr, byte>("C:\\Users\\Guigo\\Desktop\\lootBody.png"); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.95)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                    Console.WriteLine(minLocations[0]);
                    Console.WriteLine(maxLocations[0]);
                    Console.WriteLine("Achou");
                    var pMin = minLocations[0];
                    var pMax = maxLocations[0];

                    var meioQuad = pMin.Y - pMax.Y;
                    var centerPosition = new Point((maxLocations[0].X + meioQuad), minLocations[0].Y);
                    Console.WriteLine("Center: " + centerPosition);
                    Cursor.Position = new Point(maxLocations[0].X, maxLocations[0].Y);
                    DoMouseClick();
                }
            }
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

        private void moveMouseWaypointEmgu(Bitmap myPic)
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Image<Bgr, Byte> source = new Image<Bgr, Byte>(screenCapture);
            Image<Bgr, byte> template = new Image<Bgr, byte>(myPic); // Image A
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.95)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                    //Console.WriteLine(minLocations[0]);
                    //Console.WriteLine(maxLocations[0]);
                    Console.WriteLine("Achou");
                    //var pMin = minLocations[0];
                    //var pMax = maxLocations[0];

                    //var meioQuad = pMin.Y - pMax.Y;
                    //var centerPosition = new Point((maxLocations[0].X + meioQuad), minLocations[0].Y);
                    //Console.WriteLine("Center: " + centerPosition);
                    Cursor.Position = new Point(maxLocations[0].X, maxLocations[0].Y);
                }
                else
                {
                    Console.WriteLine("Não Achou");
                }

            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = trackBar1.Value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "battleClear.png");
            var contain = CheckFindBattle(myPic, screenCapture);
            if (contain)
                MessageBox.Show("Battle Normal");
            else
                MessageBox.Show("Battle with monster");
        }

        private bool FindBattle()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "battleClear.png");
            return compareTwoImages(screenCapture, myPic);
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

            //Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Graphics g = Graphics.FromImage(screenCapture);

            //g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
            //                 Screen.PrimaryScreen.Bounds.Y,
            //                 0, 0,
            //                 screenCapture.Size,
            //                 CopyPixelOperation.SourceCopy);

            //Bitmap myPic = new Bitmap("C:\\Users\\ALM4CT\\Desktop\\teste.png");

            //List<Point> isInCapture = Find(screenCapture, myPic);
            //if (isInCapture.Count > 0)
            //    foreach (var item in isInCapture)
            //    {
            //        Cursor.Position = item;
            //        Thread.Sleep(1000);
            //    }


            var arrived = false;

            var p1 = new Point(1780, 70);
            var p2 = new Point(1810, 95);

            Rectangle rect = new Rectangle(1780, 70, 30, 25);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            arrived = CheckFindBattle(currentWaypoint.bitIcon, areaIcon);

            if (arrived)
                MessageBox.Show("Achou");
            else
                MessageBox.Show("Nao Achou");

        }

        private bool compareTwoImages(Bitmap img1, Bitmap img2)
        {
            string img1_ref, img2_ref;
            int count1 = 0;
            int count2 = 0;
            bool flag = true;
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            flag = false;
                            break;
                        }
                        count1++;
                    }
                }
            }
            if (flag == false)
                Console.WriteLine("Sorry, Images are not same , " + count2 + " wrong pixels found");
            else
                Console.WriteLine(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");

            return flag;
        }

        private bool IsInCapture(Bitmap searchFor, Bitmap searchIn)
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
                        return true;
                }
            }
            return false;
        }

        public bool CheckFindBattle(Bitmap searchFor, Bitmap searchIn)
        {
            Image<Bgr, Byte> source = new Image<Bgr, Byte>(searchIn);
            Image<Bgr, byte> template = new Image<Bgr, byte>(searchFor);
            Image<Bgr, byte> imageToShow = source.Copy();

            using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.95)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], template.Size);
                    imageToShow.Draw(match, new Bgr(Color.Red), 3);
                    Console.WriteLine("Achou");
                    //var pMin = minLocations[0];
                    //var pMax = maxLocations[0];

                    //var meioQuad = pMin.Y - pMax.Y;
                    //var centerPosition = new Point((maxLocations[0].X + meioQuad), minLocations[0].Y);
                    //Console.WriteLine("Center: " + centerPosition);
                    return true;
                }
                return false;
            }
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
