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
    public partial class Form3 : Form
    {

        Form1 f1;
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
            loadWaypoints();
            timer1.Start();
            timer1.Interval = 200;
        }

        private void loadWaypoints()
        {
            listView1.Items.Clear();

            foreach (var item in f1.listWaypointsToHunt)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.listWaypointsToHunt.IndexOf(f1.currentWaypoint) == -1 ? "" : "true" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsInHunt)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.listWaypointsInHunt.IndexOf(f1.currentWaypoint) == -1 ? "" : "true" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsToReffil)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.listWaypointsToReffil.IndexOf(f1.currentWaypoint) == -1 ? "" : "true" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            foreach (var item in f1.listWaypointsInReffil)
            {
                string[] row = { item.name.ToString(), item.label.ToString(), item.state.ToString(), item.function == null ? "-" : item.function.action.ToString(), f1.listWaypointsInReffil.IndexOf(f1.currentWaypoint) == -1 ? "" : "true" };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            getCurrentWp();
        }

        private void getCurrentWp()
        {
            var x = listView1.Items;
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
                newWp = newWp.Where(w => w.function.action == actionWp).ToList();
            }

            f1.currentWaypoint = newWp.FirstOrDefault();
            this.listView1.SelectedItems[0].SubItems[4].Text = "true";
        }
    }
}
