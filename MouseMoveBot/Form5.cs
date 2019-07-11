﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MouseMoveBot
{
    public partial class Form5 : Form
    {
        Image<Bgr, byte> imgInput;
        Rectangle rect;
        Point StartLocation;
        Point EndLcation;
        bool IsMouseDown = false;
        Form1 f1;

        public Form5(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLcation = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {

                Graphics.FromHwnd(IntPtr.Zero).DrawRectangle(Pens.Red, GetRectangle());
            }
        }

        private Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLcation.X);
            rect.Y = Math.Min(StartLocation.Y, EndLcation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLcation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLcation.Y);

            return rect;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLcation = e.Location;
                IsMouseDown = false;
                if (rect != null)
                {
                    imgInput.ROI = rect;
                    Image<Bgr, byte> temp = imgInput.CopyBlank();
                    imgInput.CopyTo(temp);
                    imgInput.ROI = Rectangle.Empty;
                    pictureBox2.Image = temp.Bitmap;
                }
            }
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imgInput.Bitmap;
            }
        }
    }
}
