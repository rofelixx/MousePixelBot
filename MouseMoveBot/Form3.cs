using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using howto_ownerdraw_image_and_text;
using Newtonsoft.Json;

namespace MouseMoveBot
{
    public partial class Form3 : Form
    {
        String path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Resources\\";

        Form1 f1;
        Form2 f2;
        public List<Waypoints> listWaypoints = new List<Waypoints>();
        public Waypoints currentWaypoint = new Waypoints() { bitIcon = null, state = State.Waiting, function = null, name = "" };

        public Form3(Form1 f)
        {
            InitializeComponent();
            this.f1 = f;
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            createCombos();
            loadWaypoints();
            timer1.Start();
            timer1.Interval = 200;
            loadimages();
        }

        private void createCombos()
        {
            loadimages();
            comboBox1.DataSource = Enum.GetValues(typeof(LabelWp));
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "--Label--";
            comboBox4.DataSource = Enum.GetValues(typeof(EnumAction));
            comboBox4.SelectedItem = null;
            comboBox4.SelectedText = "--Action--";
            comboBox2.SelectedItem = null;
            comboBox2.SelectedText = "--Icon--";
            comboBox3.SelectedItem = null;
            comboBox3.SelectedText = "--BitCheck--";
        }

        private void loadimages()
        {
            // Make a font for the item text.
            Font font = new Font("Times New Roman", 12);

            // Make image and text data.
            ImageAndText[] planets =
            {
                new ImageAndText(new Bitmap(path + "iconUp.png"), "iconUp", font),
                new ImageAndText(new Bitmap(path + "iconDown.png"), "iconDown", font),
                new ImageAndText(new Bitmap(path + "iconLeft.png"), "iconLeft", font),
                new ImageAndText(new Bitmap(path + "iconRight.png"), "iconRight", font),
                new ImageAndText(new Bitmap(path + "iconCheck.png"), "iconCheck", font),
                new ImageAndText(new Bitmap(path + "iconBank.png"), "iconBank", font),
                new ImageAndText(new Bitmap(path + "greenUp.png"), "greenUp", font),
                new ImageAndText(new Bitmap(path + "greenDown.png"), "greenDown", font),
            };

            this.comboBox2.DisplayImagesAndText(planets);
            this.comboBox3.DisplayImagesAndText(planets);
        }

        private void loadWaypoints()
        {
            listView1.Items.Clear();

            foreach (var item in f1.listWaypointsToHunt)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsInHunt)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsToReffil)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsInReffil)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

        private void getCurrentWp()
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].SubItems[4].Text = "";
            }
            loadWaypoints();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LabelWp myStatus;
            Enum.TryParse(this.listView1.SelectedItems[0].SubItems[1].Text, out myStatus);

            switch (myStatus)
            {
                case LabelWp.WayToCave:
                    f1.listWaypoints = f1.listWaypointsToHunt;
                    break;
                case LabelWp.InCave:
                    f1.listWaypoints = f1.listWaypointsInHunt;
                    break;
                case LabelWp.WayToReffil:
                    f1.listWaypoints = f1.listWaypointsToReffil;
                    break;
                case LabelWp.Reffil:
                    f1.listWaypoints = f1.listWaypointsInReffil;
                    break;
                default:
                    break;
            }

            var newWp = f1.listWaypoints.Where(w => w.name == this.listView1.SelectedItems[0].SubItems[0].Text).ToList();

            if (this.listView1.SelectedItems[0].SubItems[3].Text != "-")
            {
                EnumAction actionWp;
                Enum.TryParse(this.listView1.SelectedItems[0].SubItems[3].Text, out actionWp);
                newWp = newWp.Where(w => w.function != null && w.function.action == actionWp).ToList();
            }

            f1.currentWaypoint = newWp.FirstOrDefault();
            getCurrentWp();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "--Label--")
            {
                LabelWp myStatus;
                Enum.TryParse(this.comboBox1.Text, out myStatus);

                ImageAndText icon = (ImageAndText)this.comboBox2.SelectedItem;

                var newWp = new Waypoints()
                {
                    bitIcon = new Bitmap(icon.Picture),
                    state = State.Waiting,
                    function = null,
                    name = icon.Text
                };

                if (this.comboBox4.Text != "--Action--")
                {
                    var bitcheck = (ImageAndText)this.comboBox3.SelectedItem;
                    EnumAction myAction;
                    Enum.TryParse(this.comboBox4.Text, out myAction);
                    newWp.function = new Function()
                    {
                        action = myAction,
                        bitCheck = bitcheck != null ? new Bitmap(bitcheck.Picture) : null
                    };
                }

                switch (myStatus)
                {
                    case LabelWp.WayToCave:
                        newWp.label = LabelWp.WayToCave;
                        f1.listWaypointsToHunt.Add(newWp);
                        f1.listWaypoints = f1.listWaypointsToHunt;
                        break;
                    case LabelWp.InCave:
                        newWp.label = LabelWp.InCave;
                        f1.listWaypointsInHunt.Add(newWp);
                        f1.listWaypoints = f1.listWaypointsInHunt;
                        break;
                    case LabelWp.WayToReffil:
                        newWp.label = LabelWp.WayToReffil;
                        f1.listWaypointsToReffil.Add(newWp);
                        f1.listWaypoints = f1.listWaypointsToReffil;
                        break;
                    case LabelWp.Reffil:
                        newWp.label = LabelWp.Reffil;
                        f1.listWaypointsInReffil.Add(newWp);
                        f1.listWaypoints = f1.listWaypointsInReffil;
                        break;
                    default:
                        break;
                }
                getCurrentWp();
                createCombos();
            }
            else
            {
                MessageBox.Show("Escolha os itens");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            LabelWp label;
            Enum.TryParse(this.listView1.SelectedItems[0].SubItems[1].Text, out label);

            var newWp = f1.listWaypoints.Where(w => w.name == this.listView1.SelectedItems[0].SubItems[0].Text && w.label == label).ToList();

            if (this.listView1.SelectedItems[0].SubItems[3].Text != "-")
            {
                EnumAction actionWp;
                Enum.TryParse(this.listView1.SelectedItems[0].SubItems[3].Text, out actionWp);
                newWp = newWp.Where(w => w.function.action == actionWp).ToList();
            }

            switch (label)
            {
                case LabelWp.WayToCave:
                    f1.listWaypointsToHunt.Remove(newWp.FirstOrDefault());
                    f1.listWaypoints = f1.listWaypointsToHunt;
                    break;
                case LabelWp.InCave:
                    f1.listWaypointsInHunt.Remove(newWp.FirstOrDefault());
                    f1.listWaypoints = f1.listWaypointsInHunt;
                    break;
                case LabelWp.WayToReffil:
                    f1.listWaypointsToReffil.Remove(newWp.FirstOrDefault());
                    f1.listWaypoints = f1.listWaypointsToReffil;
                    break;
                case LabelWp.Reffil:
                    f1.listWaypointsInReffil.Remove(newWp.FirstOrDefault());
                    f1.listWaypoints = f1.listWaypointsInReffil;
                    break;
                default:
                    break;
            }
            getCurrentWp();
            createCombos();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            f1.listWaypointsInHunt = new List<Waypoints>();
            f1.listWaypointsInReffil = new List<Waypoints>();
            f1.listWaypointsToHunt = new List<Waypoints>();
            f1.listWaypointsToReffil = new List<Waypoints>();
            f1.listWaypoints = new List<Waypoints>();
            getCurrentWp();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            foreach (var item in f1.listWaypointsToHunt)
            {
                item.exportBitmap = ToBase64String(item.bitIcon, ImageFormat.Png);
                item.bitIcon = null;
            }

            foreach (var item in f1.listWaypointsInHunt)
            {
                item.exportBitmap = ToBase64String(item.bitIcon, ImageFormat.Png);
                item.bitIcon = null;
            }

            foreach (var item in f1.listWaypointsToReffil)
            {
                item.exportBitmap = ToBase64String(item.bitIcon, ImageFormat.Png);
                item.bitIcon = null;
            }

            foreach (var item in f1.listWaypointsInReffil)
            {
                item.exportBitmap = ToBase64String(item.bitIcon, ImageFormat.Png);
                item.bitIcon = null;
            }

            var AllLists = new List<List<Waypoints>>()
            {
                new List<Waypoints>(f1.listWaypointsInHunt),
                new List<Waypoints>(f1.listWaypointsInReffil),
                new List<Waypoints>(f1.listWaypointsToHunt),
                new List<Waypoints>(f1.listWaypointsToReffil),
            };

            string json = JsonConvert.SerializeObject(AllLists.ToArray());


            string dummyFileName = "waypoints.txt";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);
                System.IO.File.WriteAllText(sf.FileName, json);
            }
        }

        private string ToBase64String(Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;

            return base64String;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Selecionar Fotos";
            openFileDialog1.InitialDirectory = @"C:\Users\ALM4CT\Desktop";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                string json = File.ReadAllText(openFileDialog1.FileName);

                var allLists = JsonConvert.DeserializeObject<List<List<Waypoints>>>(json);

                f1.listWaypointsInHunt = allLists[0];
                f1.listWaypointsInReffil = allLists[1];
                f1.listWaypointsToHunt = allLists[2];
                f1.listWaypointsToReffil = allLists[3];

                foreach (var item in f1.listWaypointsToHunt)
                {
                    item.bitIcon = Base64StringToBitmap(item.exportBitmap);
                    string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                    var lvItem = new ListViewItem(row);
                    listView1.Items.Add(lvItem);
                }

                foreach (var item in f1.listWaypointsInHunt)
                {
                    item.bitIcon = Base64StringToBitmap(item.exportBitmap);
                    string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                    var lvItem = new ListViewItem(row);
                    listView1.Items.Add(lvItem);
                }

                foreach (var item in f1.listWaypointsToReffil)
                {
                    item.bitIcon = Base64StringToBitmap(item.exportBitmap);
                    string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                    var lvItem = new ListViewItem(row);
                    listView1.Items.Add(lvItem);
                }

                foreach (var item in f1.listWaypointsInReffil)
                {
                    item.bitIcon = Base64StringToBitmap(item.exportBitmap);
                    string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.currentWaypoint == item ? "true" : "" };
                    var lvItem = new ListViewItem(row);
                    listView1.Items.Add(lvItem);
                }
            }
        }

        private static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }

        private void HealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2 = new Form2(f1);
            this.Hide();
            f2.ShowDialog();
        }
    }
}
