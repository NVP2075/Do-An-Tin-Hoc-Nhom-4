using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wolf_Rabbit
{
    public partial class Form1 : Form
    {
        private int tickCount =0;
        private Ecosystem ecosystem;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ecosystem = new Ecosystem(World.Width,World.Height, 10);
            timer1.Interval = int.Parse(txtTick.Text);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Mô Phỏng Hệ Sinh Thái";
            ecosystem.Update();
            if (ecosystem != null)
            {
                World.Invalidate();
            }
        }
       
        private void World_Paint(object sender, PaintEventArgs e)
        {
            if (ecosystem != null)
            {
                foreach (var animal in ecosystem.Animal)
                {

                    if (animal is Rabbit rabbit)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(animal.AnimalColor), animal.PositionX, animal.PositionY, 5, 5);
                    }
                    else
                        e.Graphics.FillRectangle(new SolidBrush(animal.AnimalColor),animal.PositionX,animal.PositionY, 10, 10);
                  
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ecosystem.Update();
            World.BackColor = Color.Green;
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ecosystem.Reset();
            World.Invalidate();
            timer1.Interval = int .Parse(txtTick.Text);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }   
    }





}
