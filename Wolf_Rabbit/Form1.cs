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
            ecosystem = new Ecosystem(World.Width, World.Height, 10);
            InitializeChart();
            
        }
        //Vẽ biểu đồ
        private void InitializeChart()
        {
            chartSoLuong.Series.Clear();
            chartSoLuong.ChartAreas.Clear();
            //Cấu hình trục x và y cho biễu đồ
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Thời gian(ngày)";
            chartArea.AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Format = "0";
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.Title = "Số Lượng";
            chartArea.AxisX.LabelStyle.IsStaggered = false;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.TitleFont = new Font("Arial",10,FontStyle.Bold);
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartSoLuong.ChartAreas.Add(chartArea);
            //Tạo và cấu hình chart dạng line cho thỏ
            Series rabbit = new Series("Rabbit");
            rabbit.ChartType = SeriesChartType.Line;
            rabbit.Color = Color.LightBlue;
            rabbit.BorderWidth = 2;
            chartSoLuong.Series.Add(rabbit);
            //Và sói
            Series wolf = new Series("Wolf");
            wolf.ChartType = SeriesChartType.Line;
            wolf.Color = Color.Gray;
            wolf.BorderWidth = 2;
            chartSoLuong.Series.Add(wolf);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Mô Phỏng Hệ Sinh Thái";
            ecosystem.Update();
            if (ecosystem != null)
            {
                World.Invalidate();
            }
            int rabbitCount = 0;
            int wolfCount = 0;
            foreach(Animal a in ecosystem.Animal )
            {
                if (a is Rabbit) rabbitCount++;
                else if(a is Wolf) wolfCount++;
            }
            chartSoLuong.Series["Rabbit"].Points.AddXY(tickCount, rabbitCount);
            chartSoLuong.Series["Wolf"].Points.AddXY(tickCount, wolfCount);
            if (chartSoLuong.Series["Rabbit"].Points.Count > 10)
            {
                chartSoLuong.Series["Rabbit"].Points.RemoveAt(0);
                chartSoLuong.Series["Wolf"].Points.RemoveAt(0);
                chartSoLuong.ChartAreas[0].AxisX.Minimum = tickCount - 10;
                chartSoLuong.ChartAreas[0].AxisX.Maximum = tickCount;
            }
            txtSoLuongTho.Text = rabbitCount.ToString();
            txtSoLuongSoi.Text = wolfCount.ToString();
            txtThoiGian.Text = tickCount.ToString();
            tickCount++;
            if(rabbitCount==0&&wolfCount==0) MessageBox.Show("Mô phỏng kết thúc","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            tickCount = 0;
            foreach(var series in chartSoLuong.Series)
            {
                series.Points.Clear();
                
            }
            chartSoLuong.ChartAreas[0].AxisX.Minimum = 0;
            chartSoLuong.ChartAreas[0].AxisX.Maximum = 10;
            World.Invalidate();

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void txtThoat_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }
    }





}
