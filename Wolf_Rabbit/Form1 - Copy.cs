using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wolf_Rabbit
{
    public partial class Form1 : Form
    {
        private Ecosystem ecosystem;
        //FormLoad
        
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ecosystem = new Ecosystem(World.Width,World.Height, 10);
        }



        //Start
        private void button1_Click(object sender, EventArgs e)
        {

            
            timer1.Start();
            ecosystem.Update();
            World.BackColor = Color.Green;
        }

        //Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
            ecosystem.Update();
            if (ecosystem != null)
            {
                
                World.Invalidate();
            }

        }
        //public void wolfImage(PaintEventArgs e)
        //{
        //    Image newImage =  Image.FromFile("download.jpg");
        //    float x = 30.0F;
        //    float y = 30.0F;
        //    RectangleF rectangleF = new RectangleF(50.0F, 50.0F, 100.0F, 100.0F);
        //    GraphicsUnit graphicsUnit = GraphicsUnit.Pixel;
        //    e.Graphics.DrawImage(newImage, x, y, rectangleF, graphicsUnit);
        //}
        //World
        private void World_Paint(object sender, PaintEventArgs e)
        {
            if (ecosystem != null)
            {
                foreach (var animal in ecosystem.Animals)
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
       
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ecosystem.Reset();
            World.Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           timer1.Stop();
        }

        
    }





}
