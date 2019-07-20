using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using IronOcr;
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

        [DllImport("User32", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("User32")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        int zoom = 2;

        public String keyMaxHealerSelected;
        public String keyMidHealerSelected;
        public String keyMinHealerSelected;

        public String keyManaSelected;
        public String keyMissileRune;
        public String keyAreaRuneSelected;
        public String keySpellAttack;
        public String keyCurePoison;
        public String keyEatFood;
        public String keyCureParalyze;
        public String keyUseEnergyRing;

        System.Object[] ItemRange;

        Graphics g;

        List<Point> listLootRange = new List<Point>()
        {
            new Point(785,380),
            new Point(785,520),
            new Point(715,450),
            new Point(850,450),
            new Point(850,510),
            new Point(850,380),
            new Point(720,380),
            new Point(720,510),
        };

        public List<Waypoints> listWaypoints = new List<Waypoints>();
        public List<Waypoints> listWaypointsToHunt = new List<Waypoints>();
        public List<Waypoints> listWaypointsInHunt = new List<Waypoints>();
        public List<Waypoints> listWaypointsToReffil = new List<Waypoints>();
        public List<Waypoints> listWaypointsInReffil = new List<Waypoints>();

        Form2 f2;
        Form3 f3;
        Form4 f4;
        Form5 f5;

        Task taskHealerLife;
        Task taskHealerMana;
        Task taskCavebot;
        Task taskAttack;
        Task taskAttackRune;
        Task taskTimer;
        Task checkArriveWp;
        Task TaskCheckBattleList;
        Task taskCheckTibiaAreInFront;
        Task taskCheckPoison;
        Task taskCheckEatFood;
        Task taskCheckParalyze;
        Task taskCheckUseEnergyRing;

        bool battleIsNormal = false;

        public Waypoints currentWaypoint = new Waypoints() { bitIcon = null, state = State.Waiting, function = null };

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
            listWaypointsToHunt = new List<Waypoints>();
            listWaypointsInHunt = new List<Waypoints>();
            listWaypointsToReffil = new List<Waypoints>();
            listWaypointsInReffil = new List<Waypoints>();

            #region waypoints Ek

            //#region WayToHut

            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToCave,
            //    name = "iconUp.png"
            //});
            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToCave,
            //    name = "greenUp.png"
            //});
            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenDown.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.MapZoomMax,
            //        bitCheck = new Bitmap(path + "greenDown.png")
            //    },
            //    label = LabelWp.WayToCave,
            //    name = "greenDown.png"
            //});
            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.MapZoomMin,
            //        bitCheck = new Bitmap(path + "iconBank.png")
            //    },
            //    label = LabelWp.WayToCave,
            //    name = "iconBank.png"
            //});
            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.ShovelToUp,
            //        bitCheck = new Bitmap(path + "iconRight.png")
            //    },
            //    label = LabelWp.WayToCave,
            //    name = "iconBank.png"
            //});
            //listWaypointsToHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconRight.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.CheckWp,
            //        bitCheck = new Bitmap(path + "iconRight.png")
            //    },
            //    label = LabelWp.WayToCave,
            //    name = "iconRight.png"
            //});

            //#endregion

            //#region InHunt

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconRight.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "iconRight.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconDown.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "iconDown.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "iconUp.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "greenUp.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenDown.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "greenDown.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "iconBank.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconRight.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.InCave,
            //    name = "iconRight.png"
            //});

            //listWaypointsInHunt.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconRight.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.CheckRefill,
            //        bitCheck = new Bitmap(path + "iconRight.png")
            //    },
            //    label = LabelWp.InCave,
            //    name = "iconRight.png"
            //});

            //#endregion

            //#region ToReffil
            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconRight.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.RopeCenter,
            //        bitCheck = new Bitmap(path + "iconBank.png")
            //    },
            //    label = LabelWp.WayToReffil,
            //    name = "iconRight.png"
            //});

            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenDown.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToReffil,
            //    name = "greenDown.png"
            //});

            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "greenUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToReffil,
            //    name = "greenUp.png"
            //});

            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconUp.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToReffil,
            //    name = "iconUp.png"
            //});

            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconDown.png"),
            //    state = State.Waiting,
            //    function = null,
            //    label = LabelWp.WayToReffil,
            //    name = "iconDown.png"
            //});

            //listWaypointsToReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconDown.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.Depot,
            //    },
            //    label = LabelWp.WayToReffil,
            //    name = "iconDown.png"
            //});

            //#endregion

            //#region InReffil

            //listWaypointsInReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.Walk,
            //        bitCheck = new Bitmap(path + "iconBank.png")
            //    },
            //    label = LabelWp.Reffil,
            //    name = "iconBank.png"
            //});

            //listWaypointsInReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.BuyPots
            //    },
            //    label = LabelWp.Reffil,
            //    name = "iconBank.png"
            //});

            //listWaypointsInReffil.Add(new Waypoints()
            //{
            //    bitIcon = new Bitmap(path + "iconBank.png"),
            //    state = State.Waiting,
            //    function = new Function()
            //    {
            //        action = EnumAction.CheckWp
            //    },
            //    label = LabelWp.Reffil,
            //    name = "iconBank.png"
            //});

            //#endregion

            #endregion

            #region WaypointsMs


            #region InHunt

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconDown.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.InCave,
                name = "iconDown.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconDown.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.InCave,
                name = "iconDown.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconUp.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.InCave,
                name = "iconUp.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconRight.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconRight.png")
                },
                label = LabelWp.InCave,
                name = "iconRight.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "greenUp.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "greenUp.png")
                },
                label = LabelWp.InCave,
                name = "greenUp.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconBank.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconBank.png")
                },
                label = LabelWp.InCave,
                name = "iconBank.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "greenDown.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "greenDown.png")
                },
                label = LabelWp.InCave,
                name = "greenDown.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconCheck.png")
                },
                label = LabelWp.InCave,
                name = "iconCheck.png"
            });

            listWaypointsInHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.CheckRefill,
                    bitCheck = new Bitmap(path + "iconCheck.png")
                },
                label = LabelWp.InCave,
                name = "iconCheck.png"
            });

            #endregion

            #region ToReffil

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.ToRight,
                    bitCheck = new Bitmap(path + "iconBank.png")
                },
                label = LabelWp.WayToReffil,
                name = "iconCheck.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconLeft.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToReffil,
                name = "iconLeft.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconLeft.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.ToLeft
                },
                label = LabelWp.WayToReffil,
                name = "iconCheck.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconBank.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToReffil,
                name = "iconBank.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconBank.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Conversation,
                    bitCheck = new Bitmap(path + "greenDown.png")
                },
                label = LabelWp.WayToReffil,
                name = "iconBank.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconUp.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToReffil,
                name = "iconUp.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "greenUp.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToReffil,
                name = "greenUp.png"
            });

            listWaypointsToReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "greenUp.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.CheckWp,
                    bitCheck = new Bitmap(path + "greenUp.png")
                },
                label = LabelWp.WayToReffil,
                name = "greenUp.png"
            });

            #endregion

            #region InReffil

            listWaypointsInReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "greenUp.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Depot,
                    bitCheck = new Bitmap(path + "greenUp.png")
                },
                label = LabelWp.Reffil,
                name = "greenUp.png"
            });

            listWaypointsInReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconCheck.png")
                },
                label = LabelWp.Reffil,
                name = "iconCheck.png"
            });

            listWaypointsInReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.BuyPots
                },
                label = LabelWp.Reffil,
                name = "iconCheck.png"
            });

            listWaypointsInReffil.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.CheckWp
                },
                label = LabelWp.Reffil,
                name = "iconCheck.png"
            });

            #endregion

            #region WayToHut

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconUp.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToCave,
                name = "iconUp.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconRight.png"),
                state = State.Waiting,
                function = null,
                label = LabelWp.WayToCave,
                name = "iconRight.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconRight.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Conversation,
                    bitCheck = new Bitmap(path + "iconCheck.png"),
                },
                label = LabelWp.WayToCave,
                name = "iconRight.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconDown.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconDown.png"),
                },
                label = LabelWp.WayToCave,
                name = "iconDown.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconLeft.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconLeft.png"),
                },
                label = LabelWp.WayToCave,
                name = "iconLeft.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconLeft.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.ToLeft,
                    bitCheck = null
                },
                label = LabelWp.WayToCave,
                name = "iconLeft.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconBank.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.Walk,
                    bitCheck = new Bitmap(path + "iconBank.png"),
                },
                label = LabelWp.WayToCave,
                name = "iconBank.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconBank.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.ToLeft,
                    bitCheck = new Bitmap(path + "iconCheck.png"),
                },
                label = LabelWp.WayToCave,
                name = "iconBank.png"
            });

            listWaypointsToHunt.Add(new Waypoints()
            {
                bitIcon = new Bitmap(path + "iconCheck.png"),
                state = State.Waiting,
                function = new Function()
                {
                    action = EnumAction.CheckWp
                },
                label = LabelWp.WayToCave,
                name = "iconCheck.png"
            });

            #endregion

            #endregion

            listWaypoints = listWaypointsToHunt;
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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Cursor.Position.X.ToString();
            textBox2.Text = Cursor.Position.Y.ToString();
            System.Drawing.Color c = GetPixelAtCursor();
            textBox3.Text = c.B.ToString();
            textBox4.Text = c.G.ToString();
            textBox5.Text = c.R.ToString();
            //Bitmap bit = new Bitmap(pictureBox1.Width / zoom, pictureBox1.Height / zoom, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //g = Graphics.FromImage(bit);
            //g.CopyFromScreen(Cursor.Position.X - pictureBox1.Width / (zoom * 2), Cursor.Position.Y - pictureBox1.Height / (zoom * 2), 0, 0, pictureBox1.Size, CopyPixelOperation.SourceCopy);
            //pictureBox1.Image = bit;
        }

        private void paint()
        {
            Graphics.FromHwnd(IntPtr.Zero).DrawRectangle(Pens.Red, GetRectangle());
        }

        private Rectangle GetRectangle()
        {
            var rect = new Rectangle(Cursor.Position.X, Cursor.Position.Y, 21, 17);
            return rect;
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

            taskCheckTibiaAreInFront = Task.Factory.StartNew(() =>
            {
                do
                {
                    checkIconTibia();
                    if (checkMaximized.Checked)
                        checkTibiaAreInFront();

                    Task.Delay(100).Wait();
                } while (true);
            });

            taskHealerLife = Task.Factory.StartNew(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                do
                {
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
                    if (iconTibia == iconColor)
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
                        Task.Delay(1000).Wait();
                    }

                    if (cbCavebot.Checked && currentWaypoint.state == State.Walking && (!battleIsNormal && currentWaypoint.label == LabelWp.InCave) && iconTibia == iconColor)
                        SendKeys.SendWait("{Esc}");

                    if (cbCavebot.Checked && iconTibia == iconColor && currentWaypoint != null)
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
                        if (currentWaypoint.state == State.Walking)
                        {
                            checkArrivedWaypoint();
                            continue;
                        }

                        // waiting
                        if (currentWaypoint.state == State.Waiting)
                        {
                            walk();
                        }

                        // Special Movement
                        if (currentWaypoint.state == State.SpecialMovement)
                        {
                            checkFunctionToDo();
                            continue;
                        }

                        if (currentWaypoint.state == State.Concluded)
                        {
                            var index = listWaypoints.IndexOf(currentWaypoint) >= listWaypoints.Count - 1 ? listWaypoints.IndexOf(currentWaypoint) : listWaypoints.IndexOf(currentWaypoint) + 1;

                            if (index == (listWaypoints.Count - 1) && listWaypoints[index].state == State.Concluded)
                            {
                                resetStateWaypoints();
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
                    if (cbTarget.Checked && iconTibia == iconColor && currentWaypoint.label == LabelWp.InCave)
                    {
                        checkAttack();
                    }
                } while (true);
            });

            taskAttackRune = Task.Factory.StartNew((Action)(() =>
            {
                do
                {
                    if ((this.checkAttackSpell.Checked || this.checkAttackMissileRune.Checked || this.checkAttackAreaRune.Checked) && iconTibia == iconColor && currentWaypoint.label == LabelWp.InCave)
                    {
                        checkAttackRunes();
                    }
                } while (true);
            }));

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
                    if (cbCavebot.Checked && iconTibia == iconColor && currentWaypoint.state == State.Walking && (battleIsNormal || !battleIsNormal) && currentWaypoint.label != LabelWp.Reffil)
                    {
                        checkIfStopped();
                    }
                } while (true);
            });

            taskCheckPoison = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (iconTibia == iconColor)
                    {
                        CheckArePoisoned();
                    }
                    Task.Delay(1000).Wait();
                } while (true);
            });

            taskCheckParalyze = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (iconTibia == iconColor)
                    {
                        checkAreParalyzed();
                    }
                    Task.Delay(1100).Wait();
                } while (true);
            });

            taskCheckEatFood = Task.Factory.StartNew(() =>
            {
                do
                {
                    if (iconTibia == iconColor)
                    {
                        CheckAreHungry();
                    }
                    Task.Delay(1200).Wait();
                } while (true);
            });

            //taskCheckUseEnergyRing = Task.Factory.StartNew(() =>
            //{
            //    do
            //    {
            //        if (iconTibia == iconColor && currentWaypoint.label == LabelWp.InCave)
            //        {
            //            checkEquipEnergyRing();
            //        }
            //    } while (true);
            //});
        }

        private void checkEquipEnergyRing()
        {
            var countMonster = countMonsterInBattle();

            Rectangle rect = new Rectangle(1752, 313, 108, 13);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            var manaShield = CheckFindBattle(new Bitmap(path + "manaShield.png"), areaIcon);

            if (this.checkUseEnergyRing.Checked && countMonster > 3 && !manaShield)
            {
                SendKeys.SendWait("{" + keyUseEnergyRing + "}");
                Console.WriteLine("Use energy ring.");
                Task.Delay(1000).Wait();
            }



            if (manaShield && countMonster < 3)
            {
                SendKeys.SendWait("{" + keyUseEnergyRing + "}");
                Console.WriteLine("Use energy ring.");
                Task.Delay(200).Wait();
            }
        }

        private void checkAreParalyzed()
        {
            Rectangle rect = new Rectangle(1752, 313, 108, 13);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            var paralyzed = CheckFindBattle(new Bitmap(path + "paralyzed.png"), areaIcon);

            if (battleIsNormal && paralyzed && keyCureParalyze != null)
            {
                SendKeys.SendWait("{" + keyCureParalyze + "}");
                Console.WriteLine("Cure Paralyze.");
                Task.Delay(200).Wait();
            }
        }

        private void CheckArePoisoned()
        {

            Rectangle rect = new Rectangle(1752, 313, 108, 13);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            var poisoned = CheckFindBattle(new Bitmap(path + "poisoned.png"), areaIcon);

            if (battleIsNormal && poisoned && keyCurePoison != null)
            {
                SendKeys.SendWait("{" + keyCurePoison + "}");
                Console.WriteLine("Cure Poison.");
                Task.Delay(200).Wait();
            }
        }

        private void CheckAreHungry()
        {

            Rectangle rect = new Rectangle(1752, 313, 108, 13);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            var hungry = CheckFindBattle(new Bitmap(path + "hungry.png"), areaIcon);

            if (battleIsNormal && hungry && keyEatFood != null)
            {
                SendKeys.SendWait("{" + keyEatFood + "}");
                Console.WriteLine("Eat Food.");
                Task.Delay(200).Wait();
            }
        }

        private void checkAttackRunes()
        {
            var countMonster = countMonsterInBattle();

            var areAttacking = checkAreAttacking();

            if (this.checkAttackAreaRune.Checked && this.checkAttackSpell.Checked)
            {
                if (countMonster >= 2 && keyAreaRuneSelected != null && areAttacking)
                {
                    SendKeys.SendWait("{" + keyAreaRuneSelected + "}");
                    Console.WriteLine("Key area rune Pressed.");
                    Task.Delay(2100).Wait();
                }
                else if (countMonster < 2 && keySpellAttack != null && areAttacking)
                {
                    SendKeys.SendWait("{" + keySpellAttack + "}");
                    Console.WriteLine("spell key.");
                    Task.Delay(2100).Wait();
                }
            }
            else if (!this.checkAttackAreaRune.Checked && this.checkAttackSpell.Checked)
            {
                if (keySpellAttack != null && areAttacking)
                {
                    SendKeys.SendWait("{" + keySpellAttack + "}");
                    Console.WriteLine("spell key.");
                    Task.Delay(2100).Wait();
                }
            }
            else if (!this.checkAttackAreaRune.Checked && !this.checkAttackSpell.Checked && this.checkAttackMissileRune.Checked)
            {
                if (keyMissileRune != null && areAttacking)
                {
                    SendKeys.SendWait("{" + keyMissileRune + "}");
                    Console.WriteLine("spell key.");
                    Task.Delay(2100).Wait();
                }
            }

            //if (this.checkAttackMissileRune.Checked && this.checkAttackSpell.Checked)
            //{
            //    if (countMonster >= 2 && keyAreaRuneSelected != null && bixoSelecionadoRed == red)
            //    {
            //        SendKeys.SendWait("{" + keyAreaRuneSelected + "}");
            //        Console.WriteLine("Key area rune Pressed.");
            //        Task.Delay(2100).Wait();
            //    }
            //    else if (countMonster < 2 && keySpellAttack != null && bixoSelecionadoRed == red)
            //    {
            //        SendKeys.SendWait("{" + keySpellAttack + "}");
            //        Console.WriteLine("spell key.");
            //        Task.Delay(2100).Wait();
            //    }
            //}
            //else if (!this.checkAttackAreaRune.Checked && this.checkAttackSpell.Checked)
            //{
            //    if (keySpellAttack != null && bixoSelecionadoRed == red)
            //    {
            //        SendKeys.SendWait("{" + keySpellAttack + "}");
            //        Console.WriteLine("spell key.");
            //        Task.Delay(2100).Wait();
            //    }
            //}
        }

        private int countMonsterInBattle()
        {
            var blackColor = Color.FromArgb(255, 0, 0, 0);
            var countMonster = 0;
            for (int i = 457; i < 600; i = i + 22)
            {
                var colorFound = GetColorAt(new Point(1770, i));
                if (colorFound == blackColor)
                    countMonster++;
            }
            return countMonster; 
        }

        private void checkFunctionToDo()
        {
            switch (currentWaypoint.function.action)
            {
                case EnumAction.MapZoomMax:
                case EnumAction.MapZoomMin:
                    changeMapZoom();
                    break;
                case EnumAction.RopeCenter:
                case EnumAction.RopeToUp:
                case EnumAction.RopeToDown:
                case EnumAction.RopeToRight:
                case EnumAction.RopeToLeft:
                    useRope();
                    break;
                case EnumAction.ShovelToUp:
                case EnumAction.ShovelToDown:
                case EnumAction.ShovelToRight:
                case EnumAction.ShovelToLeft:
                    useShovel();
                    break;
                case EnumAction.ToUp:
                case EnumAction.ToDown:
                case EnumAction.ToLeft:
                case EnumAction.ToRight:
                    moveTo();
                    break;
                case EnumAction.CheckRefill:
                    checkPotAndCap();
                    break;
                case EnumAction.Depot:
                    findDepotAndDeposit();
                    break;
                case EnumAction.CheckWp:
                    checkWpList();
                    break;
                case EnumAction.BuyPots:
                    buyPots();
                    break;
                case EnumAction.Conversation:
                    conversation();
                    break;
                case EnumAction.ActiveTarget:
                    activeTarget();
                    break;
                default:
                    break;
            }

            Task.Delay(200).Wait();

            if (currentWaypoint.function.bitCheck != null)
            {
                var arrived = checkArrivedWpSpecialMovement();

                if (arrived)
                {
                    currentWaypoint.state = State.Concluded;
                }
            }
            else
            {
                currentWaypoint.state = State.Concluded;
            }
        }

        private void activeTarget()
        {
            if (cbTarget.Checked)
            {
                this.cbTarget.Checked = false;
            }
            else
            {
                this.cbTarget.Checked = true;
            }
            return;
        }

        private void conversation()
        {
            Task.Delay(1000).Wait();
            InputSimulator sim = new InputSimulator();
            SendKeys.SendWait("hi");
            Task.Delay(500).Wait();
            SendKeys.SendWait("{ENTER}");
            Task.Delay(1000).Wait();
            SendKeys.SendWait("passage");
            Task.Delay(500).Wait();
            SendKeys.SendWait("{ENTER}");
            Task.Delay(1000).Wait();
            SendKeys.SendWait("yes");
            Task.Delay(500).Wait();
            SendKeys.SendWait("{ENTER}");
            Task.Delay(1000).Wait();
        }

        private void buyPots()
        {
            InputSimulator sim = new InputSimulator();
            Cursor.Position = new Point(610, 840);
            Task.Delay(1000).Wait();
            sim.Mouse.LeftButtonClick();
            Task.Delay(1500).Wait();
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();

            Cursor.Position = new Point(1730, 783);
            Task.Delay(500).Wait();
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();
            Cursor.Position = new Point(1630, 783);
            Task.Delay(500).Wait();
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();
            Cursor.Position = new Point(1670, 905);
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();
            Cursor.Position = new Point(1715, 945);
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();
        }

        private void findDepotAndDeposit()
        {
            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "emptyDepot.png");
            var depot = CheckFindDepot(myPic, screenCapture);
            Cursor.Position = depot.Value;
            DoMouseClick();
            Task.Delay(1000).Wait();
            DepositItems();
            currentWaypoint.state = State.Concluded;
        }

        private void DepositItems()
        {
            var listaItems = new List<Bitmap>()
            {
                new Bitmap(path + "ropebelt.png"),
                new Bitmap(path + "cultRobe.png"),
                new Bitmap(path + "boneEye.png"),
                new Bitmap(path + "egg.png"),
                new Bitmap(path + "spiderSilk.png"),
                new Bitmap(path + "frostHeart.png"),
                new Bitmap(path + "vialUp.png"),
            };

            foreach (var item in listaItems)
            {
                InputSimulator sim = new InputSimulator();

                Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                Graphics g = Graphics.FromImage(screenCapture);

                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 screenCapture.Size,
                                 CopyPixelOperation.SourceCopy);

                var contain = CheckFindDepot(item, screenCapture);
                if (contain != null)
                {
                    Cursor.Position = contain.Value;
                    sim.Mouse.RightButtonClick();
                    Task.Delay(500).Wait();
                    stowItem();
                }
                Task.Delay(500).Wait();
            }
            pickItemsFromDepot();
        }

        private void pickItemsFromDepot()
        {
            InputSimulator sim = new InputSimulator();
            Cursor.Position = new Point(785, 380);
            sim.Mouse.LeftButtonClick();
            Task.Delay(500).Wait();

            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "depot.png");
            var contain = CheckFindDepot(myPic, screenCapture);
            Task.Delay(500).Wait();

            if (contain != null)
            {
                Cursor.Position = contain.Value;
                sim.Mouse.LeftButtonClick();
            }
            else
            {
                Task.Delay(1000).Wait();
                sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                Task.Delay(1000).Wait();
                Cursor.Position = new Point(785, 520);
                sim.Mouse.LeftButtonClick();

                Bitmap screenCapture2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                Graphics g2 = Graphics.FromImage(screenCapture2);

                g2.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 screenCapture2.Size,
                                 CopyPixelOperation.SourceCopy);

                Bitmap myPic2 = new Bitmap(path + "depot.png");
                var contain2 = CheckFindDepot(myPic2, screenCapture2);

                if (contain2 != null)
                {
                    Cursor.Position = contain.Value;
                    sim.Mouse.LeftButtonClick();
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Task.Delay(500).Wait();
                Cursor.Position = new Point(1770, 860);
                DoMouseClick();
                Task.Delay(500).Wait();
                Cursor.Position = new Point(1770, 860);
                sim.Mouse.LeftButtonClick();
                Task.Delay(500).Wait();
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Task.Delay(500).Wait();
                Cursor.Position = new Point(1770, 800);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Task.Delay(500).Wait();
            }
        }

        private void stowItem()
        {
            InputSimulator sim = new InputSimulator();

            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            Bitmap myPic = new Bitmap(path + "menuStowAll.png");
            var contain = CheckFindDepot(myPic, screenCapture);
            if (contain != null)
            {
                Cursor.Position = contain.Value;
                sim.Mouse.LeftButtonClick();
            }
        }

        private void checkWpList()
        {
            switch (currentWaypoint.label)
            {
                case LabelWp.WayToReffil:
                    listWaypoints = listWaypointsInReffil;
                    break;
                case LabelWp.WayToCave:
                    listWaypoints = listWaypointsInHunt;
                    break;
                case LabelWp.InCave:
                    listWaypoints = listWaypointsToReffil;
                    break;
                case LabelWp.Reffil:
                    listWaypoints = listWaypointsToHunt;
                    break;
            }
        }

        private void changeMapZoom()
        {
            InputSimulator sim = new InputSimulator();

            if (currentWaypoint.function.action == EnumAction.MapZoomMax)
            {
                Cursor.Position = new Point(1880, 105);
                sim.Mouse.LeftButtonClick();
                Task.Delay(200).Wait();
                //sim.Mouse.LeftButtonClick();
                //Task.Delay(200).Wait();
            }
            else
            {
                Cursor.Position = new Point(1880, 85);
                sim.Mouse.LeftButtonClick();
                Task.Delay(200).Wait();
                //sim.Mouse.LeftButtonClick();
                //Task.Delay(200).Wait();
            }
        }

        private void checkPotAndCap()
        {
            var casa1 = false;
            var casa2 = false;
            var casa3 = false;

            Rectangle rect = new Rectangle(40, 849, 7, 8);
            Bitmap areaIcon = null;
            Graphics g = null;

            var n1 = 0;
            var n2 = 0;
            var n3 = 0;

            var listNumbers = new List<Bitmap>()
            {
                new Bitmap(path + "0.png"),
                new Bitmap(path + "1.png"),
                new Bitmap(path + "2.png"),
                new Bitmap(path + "3.png"),
                new Bitmap(path + "4.png"),
                new Bitmap(path + "5.png"),
                new Bitmap(path + "6.png"),
                new Bitmap(path + "7.png"),
                new Bitmap(path + "8.png"),
                new Bitmap(path + "9.png"),
            };

            foreach (var item in listNumbers)
            {
                if (!casa1)
                {
                    rect = new Rectangle(34, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa1 = CheckFindBattle(item, areaIcon);
                    n1 = casa1 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa2)
                {
                    rect = new Rectangle(40, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa2 = CheckFindBattle(item, areaIcon);
                    n2 = casa2 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa3)
                {
                    rect = new Rectangle(45, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);
                    casa3 = CheckFindBattle(item, areaIcon);
                    n3 = casa3 ? listNumbers.IndexOf(item) : 0;
                }
            }

            var totalHp = (n1 * 100) + (n2 * 10) + n3;

            var totalRunes = checkTotalRunes();

            if (totalHp < 50 || ((this.checkAttackAreaRune.Checked || this.checkAttackMissileRune.Checked) && totalRunes < 100))
                listWaypoints = listWaypointsToReffil;
            else
            {
                resetStateWaypoints();
                listWaypoints = listWaypointsInHunt;
            }
        }

        private int checkTotalRunes()
        {
            var casa1 = false;
            var casa2 = false;
            var casa3 = false;

            Rectangle rect = new Rectangle(40, 849, 7, 8);
            Bitmap areaIcon = null;
            Graphics g = null;

            var n1 = 0;
            var n2 = 0;
            var n3 = 0;

            var listNumbers = new List<Bitmap>()
            {
                new Bitmap(path + "0.png"),
                new Bitmap(path + "1.png"),
                new Bitmap(path + "2.png"),
                new Bitmap(path + "3.png"),
                new Bitmap(path + "4.png"),
                new Bitmap(path + "5.png"),
                new Bitmap(path + "6.png"),
                new Bitmap(path + "7.png"),
                new Bitmap(path + "8.png"),
                new Bitmap(path + "9.png"),
            };

            foreach (var item in listNumbers)
            {
                if (!casa1)
                {
                    rect = new Rectangle(358, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa1 = CheckFindBattle(item, areaIcon);
                    n1 = casa1 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa2)
                {
                    rect = new Rectangle(364, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa2 = CheckFindBattle(item, areaIcon);
                    n2 = casa2 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa3)
                {
                    rect = new Rectangle(369, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);
                    casa3 = CheckFindBattle(item, areaIcon);
                    n3 = casa3 ? listNumbers.IndexOf(item) : 0;
                }
            }

            var totalRunes = (n1 * 100) + (n2 * 10) + n3;

            return totalRunes;
        }

        private void resetStateWaypoints()
        {
            listWaypointsInHunt.Select(c => { c.state = State.Waiting; return c; }).ToList();
            listWaypointsInReffil.Select(c => { c.state = State.Waiting; return c; }).ToList();
            listWaypointsToHunt.Select(c => { c.state = State.Waiting; return c; }).ToList();
            listWaypointsToReffil.Select(c => { c.state = State.Waiting; return c; }).ToList();
        }

        private void moveTo()
        {
            InputSimulator sim = new InputSimulator();

            //// Center of xar 785, 450 in screen 
            if (currentWaypoint.function.action == EnumAction.ToUp)
            {
                //Cursor.Position = new Point(870, 410);
                //DoMouseClick();
                sim.Keyboard.KeyPress(VirtualKeyCode.UP);
                return;
            }

            if (currentWaypoint.function.action == EnumAction.ToDown)
            {
                //Cursor.Position = new Point(870, 530);
                //DoMouseClick();
                sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                return;
            }

            if (currentWaypoint.function.action == EnumAction.ToLeft)
            {
                //Cursor.Position = new Point(800, 470);
                //DoMouseClick();
                sim.Keyboard.KeyPress(VirtualKeyCode.LEFT);

                return;
            }

            if (currentWaypoint.function.action == EnumAction.ToRight)
            {
                //Cursor.Position = new Point(930, 470);
                //DoMouseClick();
                sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                return;
            }
        }

        private void useShovel()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.F11);

            //// Center of xar 870, 470 in screen            
            if (currentWaypoint.function.action == EnumAction.ShovelToUp)
            {
                Cursor.Position = new Point(785, 380);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.ShovelToDown)
            {
                Cursor.Position = new Point(785, 520);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.ShovelToLeft)
            {
                Cursor.Position = new Point(715, 450);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.ShovelToRight)
            {
                Cursor.Position = new Point(850, 450);
                sim.Mouse.LeftButtonClick();
                return;
            }
        }

        private void useRope()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(VirtualKeyCode.F12);

            //// Center of xar 785, 450 in screen 
            if (currentWaypoint.function.action == EnumAction.RopeCenter)
            {
                Cursor.Position = new Point(785, 450);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.RopeToUp)
            {
                Cursor.Position = new Point(785, 380);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.RopeToDown)
            {
                Cursor.Position = new Point(785, 520);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.RopeToLeft)
            {
                Cursor.Position = new Point(715, 450);
                sim.Mouse.LeftButtonClick();
                return;
            }

            if (currentWaypoint.function.action == EnumAction.RopeToRight)
            {
                Cursor.Position = new Point(850, 450);
                sim.Mouse.LeftButtonClick();
                return;
            }
        }

        private bool checkArrivedWpSpecialMovement()
        {
            var arrived = false;

            Rectangle rect = new Rectangle(1800, 75, 12, 12);
            Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(areaIcon);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            arrived = CheckFindBattle(currentWaypoint.function.bitCheck, areaIcon);

            return arrived ? true : false;
        }

        private void checkTibiaAreInFront()
        {
            Process process = Process.GetProcesses().FirstOrDefault(f => f.ProcessName.Equals("client"));

            if (process != null)
            {
                process.WaitForInputIdle();
                IntPtr s = process.MainWindowHandle;
                SetForegroundWindow(s);
            }
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

        private void checkIfStopped()
        {
            Color c1 = GetColorAt(new Point(808, 434));
            Task.Delay(2000).Wait();
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
                if (currentWaypoint.function != null)
                    currentWaypoint.state = State.SpecialMovement;
                else
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


            Color healthColor = Color.FromArgb(255, 167, 51, 51);

            var percent90 = GetColorAt(new Point(1845, 145)) == healthColor;
            var percent70 = GetColorAt(new Point(1840, 145)) == healthColor;
            var percent30 = GetColorAt(new Point(1795, 145)) == healthColor;

            if (!percent90 && percent70 && percent30 && keyMaxHealerSelected != null)
            {
                SendKeys.SendWait("{" + keyMaxHealerSelected + "}");
                Console.WriteLine("Key Healer Pressed.");
            }

            if (!percent70 && percent30 && keyMidHealerSelected != null)
            {
                SendKeys.SendWait("{" + keyMidHealerSelected + "}");
                Console.WriteLine("Key Healer Pressed.");
            }

            if (!percent30 && keyMinHealerSelected != null)
            {
                SendKeys.SendWait("{" + keyMinHealerSelected + "}");
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
            checkFollowMonster();

            var areAttacking = checkAreAttacking();

            InputSimulator sim = new InputSimulator();

            this.Invoke((MethodInvoker)delegate
            {
                if (!battleIsNormal && !areAttacking)
                {
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

        private bool checkAreAttacking()
        {
            var red = Color.FromArgb(255, 255, 0, 0);

            for (int i = 440; i < 600; i = i + 22)
            {
                var colorFound = GetColorAt(new Point(1767, i));
                if (colorFound == red)
                    return true;
            }
            return false;
        }

        private void checkFollowMonster()
        {
            var follow = Color.FromArgb(255, 85, 255, 85);
            var followMonster = GetColorAt(new Point(1902, 201));

            if (followMonster != follow && cbFollowMonster.Checked)
            {
                SendKeys.SendWait("{Esc}");
                Cursor.Position = new Point(1902, 201);
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
            var bixoSelecionadoRed = GetColorAt(new Point(1756, 440));

            if (this.checkAttackMissileRune.Checked && keyMissileRune != null && bixoSelecionadoRed == red)
            {
                SendKeys.SendWait("{" + keyMissileRune + "}");
                Console.WriteLine("Key sd Pressed.");
                Task.Delay(2000).Wait();
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
            f2 = new Form2(this);
            this.Hide();
            f2.ShowDialog();
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


            //var arrived = false;

            //var p1 = new Point(1780, 70);
            //var p2 = new Point(1810, 95);

            //Rectangle rect = new Rectangle(1780, 70, 30, 25);
            //Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Graphics g = Graphics.FromImage(areaIcon);
            //g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            //arrived = CheckFindBattle(currentWaypoint.bitIcon, areaIcon);

            //if (arrived)
            //    MessageBox.Show("Achou");
            //else
            //    MessageBox.Show("Nao Achou");
            //checkTibiaAreInFront();
            //checkPotAndCap();



            //var casa1 = false;
            //var casa2 = false;
            //var casa3 = false;

            //Rectangle rect = new Rectangle(40, 849, 7, 8);
            //Bitmap areaIcon = null;
            //Graphics g = null;

            //var n1 = 0;
            //var n2 = 0;
            //var n3 = 0;

            //var listNumbers = new List<Bitmap>()
            //{
            //    new Bitmap(path + "0.png"),
            //    new Bitmap(path + "1.png"),
            //    new Bitmap(path + "2.png"),
            //    new Bitmap(path + "3.png"),
            //    new Bitmap(path + "4.png"),
            //    new Bitmap(path + "5.png"),
            //    new Bitmap(path + "6.png"),
            //    new Bitmap(path + "7.png"),
            //    new Bitmap(path + "8.png"),
            //    new Bitmap(path + "9.png"),
            //};

            //foreach (var item in listNumbers)
            //{
            //    if (!casa2)
            //    {
            //        rect = new Rectangle(40, 849, 7, 8);
            //        areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //        g = Graphics.FromImage(areaIcon);
            //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            //        casa2 = CheckFindBattle(item, areaIcon);
            //        n2 = casa2 ? listNumbers.IndexOf(item) : 0;
            //    }

            //    if (!casa3)
            //    {
            //        rect = new Rectangle(45, 849, 7, 8);
            //        areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //        g = Graphics.FromImage(areaIcon);
            //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);
            //        casa3 = CheckFindBattle(item, areaIcon);
            //        n3 = casa3 ? listNumbers.IndexOf(item) : 0;
            //    }
            //}

            //MessageBox.Show(n1 + "" + n2 + "" + n3);

            //var countMonster = 0;
            //var blackColor = Color.FromArgb(255, 0, 0, 0);
            //for (int i = 456; i < 550; i = i + 22)
            //{
            //    var colorFound = GetColorAt(new Point(1770, i));
            //    if (colorFound == blackColor)
            //        countMonster++;
            //}

            //MessageBox.Show(countMonster.ToString());

            //Rectangle rect = new Rectangle(1752, 313, 108, 13);
            //Bitmap areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Graphics g = Graphics.FromImage(areaIcon);
            //g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            //var poisoned = CheckFindBattle(new Bitmap(path + "poisoned.png"), areaIcon);

            //if (poisoned)
            //    MessageBox.Show("Poisoned");
            //else
            //    MessageBox.Show("Sem Poison");


            // ----------------------- Check Cap --------------------

            //var casa1 = false;
            //var casa2 = false;
            //var casa3 = false;

            //Rectangle rect = new Rectangle(40, 849, 7, 8);
            //Bitmap areaIcon = null;
            //Graphics g = null;

            //var n1 = 0;
            //var n2 = 0;
            //var n3 = 0;

            //var listNumbers = new List<Bitmap>()
            //{
            //    new Bitmap(path + "0.png"),
            //    new Bitmap(path + "1Cap.png"),
            //    new Bitmap(path + "2.png"),
            //    new Bitmap(path + "3Cap.png"),
            //    new Bitmap(path + "4.png"),
            //    new Bitmap(path + "5Cap.png"),
            //    new Bitmap(path + "6.png"),
            //    new Bitmap(path + "7.png"),
            //    new Bitmap(path + "8.png"),
            //    new Bitmap(path + "9.png"),
            //};

            //foreach (var item in listNumbers)
            //{
            //    if (!casa1)
            //    {
            //        rect = new Rectangle(1835, 203, 5, 8);
            //        areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //        g = Graphics.FromImage(areaIcon);
            //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            //        casa1 = CheckFindBattle(item, areaIcon);
            //        n1 = casa1 ? listNumbers.IndexOf(item) : 0;
            //    }

            //    if (!casa2)
            //    {
            //        rect = new Rectangle(1841, 203, 5, 8);
            //        areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //        g = Graphics.FromImage(areaIcon);
            //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

            //        casa2 = CheckFindBattle(item, areaIcon);
            //        n2 = casa2 ? listNumbers.IndexOf(item) : 0;
            //    }

            //    if (!casa3)
            //    {
            //        rect = new Rectangle(1847, 203, 5, 8);
            //        areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //        g = Graphics.FromImage(areaIcon);
            //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);
            //        casa3 = CheckFindBattle(item, areaIcon);
            //        n3 = casa3 ? listNumbers.IndexOf(item) : 0;
            //    }
            //}

            //MessageBox.Show(n1 + "" + n2 + "" + n3);

            // ------------------------ Check Runes 

            var casa1 = false;
            var casa2 = false;
            var casa3 = false;

            Rectangle rect = new Rectangle(40, 849, 7, 8);
            Bitmap areaIcon = null;
            Graphics g = null;

            var n1 = 0;
            var n2 = 0;
            var n3 = 0;

            var listNumbers = new List<Bitmap>()
            {
                new Bitmap(path + "0.png"),
                new Bitmap(path + "1.png"),
                new Bitmap(path + "2.png"),
                new Bitmap(path + "3.png"),
                new Bitmap(path + "4.png"),
                new Bitmap(path + "5.png"),
                new Bitmap(path + "6.png"),
                new Bitmap(path + "7.png"),
                new Bitmap(path + "8.png"),
                new Bitmap(path + "9.png"),
            };

            foreach (var item in listNumbers)
            {
                if (!casa1)
                {
                    rect = new Rectangle(358, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa1 = CheckFindBattle(item, areaIcon);
                    n1 = casa1 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa2)
                {
                    rect = new Rectangle(364, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);

                    casa2 = CheckFindBattle(item, areaIcon);
                    n2 = casa2 ? listNumbers.IndexOf(item) : 0;
                }

                if (!casa3)
                {
                    rect = new Rectangle(369, 849, 7, 8);
                    areaIcon = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    g = Graphics.FromImage(areaIcon);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, areaIcon.Size, CopyPixelOperation.SourceCopy);
                    casa3 = CheckFindBattle(item, areaIcon);
                    n3 = casa3 ? listNumbers.IndexOf(item) : 0;
                }
            }

            var totalHp = (n1 * 100) + (n2 * 10) + n3;

            MessageBox.Show(totalHp.ToString());
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

        public Point? CheckFindDepot(Bitmap searchFor, Bitmap searchIn)
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
                    Console.WriteLine("Achou depot");
                    //var pMin = minLocations[0];
                    //var pMax = maxLocations[0];

                    //var meioQuad = pMin.Y - pMax.Y;
                    //var centerPosition = new Point((maxLocations[0].X + meioQuad), minLocations[0].Y);
                    //Console.WriteLine("Center: " + centerPosition);
                    return maxLocations[0];
                }
                return null;
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
            keyMaxHealerSelected = this.comboBoxLifeKey.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            keyManaSelected = this.comboBoxManaKey.SelectedItem.ToString();
        }

        private void CavebotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(this);
            this.Hide();
            f3.ShowDialog();
        }

        private void TargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4 = new Form4(this);
            this.Hide();
            f4.ShowDialog();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5 = new Form5(this);
            this.Hide();
            f5.ShowDialog();
        }

        private void cbTarget_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
