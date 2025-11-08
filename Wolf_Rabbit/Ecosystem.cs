using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wolf_Rabbit
{
    public class Ecosystem
    {
        private List<Animal> animals;//Tạo một danh sách các Animal
        private List<Animal>[,] grid; //Tạo một mảng 2 chiều chứa danh sách các Animal trong mỗi ô
        private int cellSize = 10; //Khởi tạo độ rộng của mỗi một ô
        private int worldWidth;
        private int worldHeight;
        private Random random = new Random();
        public List<Animal> Animal => animals; //Danh sách chỉ đọc của List<Animal> để duyệt foreach trong
                                               //class form
   
        public Ecosystem(int width, int height, int cellSize) {
            animals =new List<Animal>();
            this.worldWidth = width;
            this.worldHeight = height;
            this.cellSize = cellSize;
            InitializeGrid();
            Reset();
        }
        public void Reset() 
        {
            animals.Clear(); //Xóa danh sách cũ
            //Khởi tạo danh sách mới
            int numRabbit = 15;
            int numWolf = 5;
            for(int i= 0; i < numRabbit; i++)
            {
                int randomX = random.Next(0, this.worldWidth);
                int randomY = random.Next(0, this.worldHeight);
                animals.Add(new Rabbit() { PositionX = randomX, PositionY = randomY });
            }
            for (int i = 0; i < numWolf; i++)
            {
                int randomX = random.Next(0, this.worldWidth);
                int randomY = random.Next(0, this.worldHeight);
                animals.Add(new Wolf() { PositionX = randomX, PositionY = randomY });
            }
        }
        public void InitializeGrid() //Khởi tạo mảng 2 chiều(lưới)
        {
            int columns = worldWidth / cellSize+1;
            int rows = worldHeight / cellSize+1;
            grid = new List<Animal>[columns, rows];
            for(int i=0;i<columns;i++)
            {
                for (int j = 0; j < rows; j++)
                    grid[i, j] = new List<Animal>();
            }
        }
        public void UpdateGrid()
        {
            //Làm mới lưới
            for(int i =0; i< grid.GetLength(0); i++)
            {
                for(int j =0; j < grid.GetLength(1); j++)
                    grid[i,j].Clear();
            }
            //Thêm Animal vào lưới
            foreach (var animal in animals)
            {
                int cellX = animal.PositionX / cellSize;
                int cellY = animal.PositionY / cellSize;
                if (cellX >= 0 && cellX < grid.GetLength(0) && cellY >= 0 && cellY < grid.GetLength(1))
                    grid[cellX, cellY].Add(animal);
            }
        }
        public void Update() //Cập nhật lại hệ sinh thái với mỗi một frame
        {
            const int RABBITMAXAGE = 10;
            const int WOLFMAXAGE = 30;
            UpdateGrid();
            List<Animal> baby = new List<Animal>(); //Danh sách các con của Animnal
            foreach(var animal in animals)
            {
               
                if (animal is Rabbit rabbit)
                {
                    Rabbit offspring = rabbit.rabbitReproduce();
                    if (offspring != null)
                        baby.Add(offspring);
                    if (rabbit.Age == 3) rabbit.AnimalColor = Color.White;
                    rabbit.Move(grid,worldWidth,worldHeight);
                }
                if (animal is Wolf wolf)
                {
                    Wolf offspring = wolf.wolfReproduce();
                    if (offspring != null)
                        baby.Add(offspring);
                    if (wolf.Age == 5) wolf.AnimalColor = Color.DarkGray;
                    wolf.Move(grid,worldWidth,worldHeight);
                }
            }
            //Thêm con mới sinh vào danh sách Animal
            if (baby !=null )
                animals.AddRange(baby);
            //Khai tử các con vật hết năng lượng hoặc đến tuổi tối đa
            for (int i = animals.Count - 1; i >= 0; i--) //Duyệt ngược để không bị lỗi danh sách rỗng
            {
                if (animals[i] is Rabbit rabbit)
                {
                    if (rabbit.Energy <= 0 || rabbit.Age >= RABBITMAXAGE)
                        animals.RemoveAt(i);
                }
                else if (animals[i] is Wolf wolf)
                {
                    if (wolf.Energy <= 0 || wolf.Age >= WOLFMAXAGE)
                        animals.RemoveAt(i);
                }
            }   
        }
    }
}
