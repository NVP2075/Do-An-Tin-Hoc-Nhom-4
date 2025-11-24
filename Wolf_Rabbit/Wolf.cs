using System;
using System.Collections.Generic;
using System.Drawing;

namespace Wolf_Rabbit
{
    public class Wolf: Animal
    {
        
        
        public Wolf()
        {
            this.PositionX = 0;
            this.PositionY = 0;
            this.Energy = 20;
            this.Age = 1;
            this.AnimalColor = Color.DarkGray;
            this.EnergyToReproduce = 50;
            this.ChangeToReproduce = (float)0.25;
            this.AgeToReproduce = 5;
            this.VisionRange = 500;
            this.MoveSpeed = 50;
        }
        //Phương thức di chuyển và săn mồi của sói
        public override void Move(List<Animal>[,] grid, int worldWidth,int worldHeight)
        {
            Rabbit target = null;
            double minDist = -1;
            int cellSize = 10;
            int currCellX = this.PositionX / cellSize;
            int currCellY = this.PositionY / cellSize;
            for (int i = -1; i <= 1; i++)       //Tìm mục tiêu trong 9 ô xung quanh sói
            {
                for (int j = -1; j <= 1; j++)   //Tìm mục tiêu trong 9 ô xung quanh sói
                {
                    int neighborCellX = currCellX + i;
                    int neighborCellY = currCellY + j;
                    //Kiểm tra ô cận kề có hợp lệ không 
                    if (neighborCellX >= 0 && neighborCellX < grid.GetLength(0) && neighborCellY >= 0 && neighborCellY < grid.GetLength(1))
                    { 
                        foreach (var closeAnimal in grid[neighborCellX, neighborCellY]) //Khởi tạo biến con vật gần nhất và
                                                                                        //duyệt trong lưới 9 ô xung
                                                                                        //quanh danh sách con vật ở gần 
                            if ((closeAnimal is Rabbit))
                            {
                                //Tính khoảng cách giữa sói và thỏ theo công thức pytago
                                double distance = Math.Sqrt(Math.Pow(closeAnimal.PositionX- this.PositionX , 2) + Math.Pow(closeAnimal.PositionY- this.PositionY , 2));
                                if (minDist == -1 || distance < minDist) //kiểm tra lại min distant nếu có mục tiêu gần hơn
                                {
                                    minDist = distance;
                                    target = (Rabbit)closeAnimal;
                                }
                            }
                    }
                }

            }
            if (target != null && minDist < this.VisionRange)
            {
                if (minDist <= 50) //Nếu mục tiêu có khoảng cách <=50 ô pixel(trong panel) thì nhảy tới mục tiêu và ăn
                {
                    this.PositionX = target.PositionX;
                    this.PositionY = target.PositionY;
                    this.Energy += 20;
                    target.Energy = -1;
                    
                }
                else
                {
                    //Di chuyển theo hướng của con mồi
                    if (target.PositionX > this.PositionX && target.PositionY > this.PositionY)
                    {
                        this.PositionX += this.MoveSpeed;
                        this.PositionY += this.MoveSpeed;
                    }
                    else if (target.PositionX < this.PositionX && target.PositionY < this.PositionY)
                    {
                        this.PositionX -= this.MoveSpeed;
                        this.PositionY -= this.MoveSpeed;
                    }                 
                }
            }
            else //Khoảng cách lớn hơn 500 thì di chuyển ngẫu nhiên
            {

                int deltaX = randomGen.Next(-this.MoveSpeed, this.MoveSpeed);
                int deltaY = randomGen.Next(-this.MoveSpeed, this.MoveSpeed);
                this.PositionX += deltaX;
                this.PositionY += deltaY;
                if (this.PositionX < 0) this.PositionX = 0;
                if (this.PositionX > worldWidth - 10) this.PositionX = worldWidth - 10;
                if (this.PositionY < 0) this.PositionY = 0;
                if (this.PositionY > worldHeight - 10) this.PositionY = worldHeight - 10;
            }
            this.Age++;
        }
      

        public Wolf wolfReproduce()
        {
            
            if (this.Age >= AgeToReproduce&&this.EnergyToReproduce < this.Energy && randomGen.NextDouble() < this.ChangeToReproduce) {
                Wolf baby = new Wolf();
                baby.PositionX = this.PositionX;
                baby.PositionY = this.PositionY;
                baby.AnimalColor = Color.Gray;
                this.Energy = 20;
                return baby;
            }
            return null;
        }
            
    }
}
