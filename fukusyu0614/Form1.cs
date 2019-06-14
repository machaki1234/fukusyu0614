using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukusyu0614
{
    public partial class Form1 : Form
    {
        int[] vx = new int[100];
        int[] vy = new int[100];
        Label[] labels = new Label[100];

        private static Random rand = new Random();

       

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                Controls.Add(labels[i]);
                labels[i].Font = label1.Font;
                labels[i].ForeColor = label1.ForeColor;
                labels[i].Left = rand.Next(ClientSize.Width - label1.Width);
                labels[i].Top = rand.Next(ClientSize.Height - label1.Height);
            }
            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);

            vx[0] = rand.Next(-5, 6);
            vy[0] = rand.Next(-5, 6);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];
            }

            if (label1.Left <= 0)
            {
                vx[0] = Math.Abs(vx[0]);
            }
            if (label1.Top <= 0)
            {
                vy[0] = Math.Abs(vy[0]);
            }
            if (label1.Right > ClientSize.Width)
            {
                vx[0] = -Math.Abs(vx[0]);
            }
            if (label1.Bottom > ClientSize.Height)
            {
                vy[0] = -Math.Abs(vy[0]);
            }

            Point p = PointToClient(MousePosition);
            if((label1.Left<=p.X)
               &&(label1.Top<=p.Y)
               &&(label1.Bottom>=p.Y)
               &&(label1.Right>=p.X))
            {
                timer1.Enabled = false;
            }
            
        }
    }
}
