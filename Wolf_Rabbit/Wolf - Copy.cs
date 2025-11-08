using System;
using System.Collections.Generic;
using System.Drawing;

namespace Wolf_Rabbit
{
    public class Wolf: Animal
    {
        
        private float changeToReproduce;
        public Wolf()
        {
            this.PositionX = 0;
            this.PositionY = 0;
            this.Energy = 20;
            this.Age = 1;
            this.AnimalColor = Color.DarkGray;
            this.EnergyToReproduce = 50;
            this.changeToReproduce = (float)0.25;
        }
        //Lenh di chuyen cua Wolf
        public override void Move( List<Animal>[,] grid)
        {
            Rabbit target = null;
            double minDist = -1;
            int cellSize = 10;
            int currCellX = (int)this.PositionX / cellSize;
            int currCellY = (int)this.PositionY / cellSize;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int neighborCellX = currCellX + i;
                    int neighborCellY = currCellY + j;
                    if (neighborCellX >= 0 && neighborCellX < grid.GetLength(0) && neighborCellY >= 0 && neighborCellY < grid.GetLength(1))
                    {
                        foreach (var potentialTartget in grid[neighborCellX, neighborCellY])
                            if ((potentialTartget is Rabbit))
                            {
                                double distance = Math.Sqrt(Math.Pow(this.PositionX - potentialTartget.PositionX, 2) + Math.Pow(this.PositionY - potentialTartget.PositionY, 2));
                                if (minDist == -1 || distance < minDist)
                                {
                                    minDist = distance;
                                    target = (Rabbit)potentialTartget;
                                }
                            }
                    }
                }

            }
            if (target != null && minDist < 500)
            {
                if (minDist <= 50)
                {
                    System.Diagnostics.Debug.WriteLine($"Soi dang an tho");
                    this.PositionX = target.PositionX;
                    this.PositionY = target.PositionY;
                    this.Energy += 20;
                    target.Energy = -1;
                }
                else if (minDist > 50)
                {
                    System.Diagnostics.Debug.WriteLine($"Tho da vao tam truy duoi{minDist}");
                    int wolfSpeed = 30;
                    double direcX = target.PositionX - this.PositionX;
                    double direcY = target.PositionY - this.PositionY;
                    double length = Math.Sqrt(direcX * direcX + direcY * direcY);
                    direcX /= length;
                    direcY /= length;
                    this.PositionX += (int)(direcX * wolfSpeed);
                    this.PositionY += (int)(direcY * wolfSpeed);
                }
            }
            else
            {

                int deltaX = randomGen.Next(-30, 30);
                int deltaY = randomGen.Next(-30, 30);
                this.PositionX += deltaX;
                this.PositionY += deltaY;
                if (this.PositionX < 0) this.PositionX = 0;
                if (this.PositionX > grid.GetLength(0) - 10) this.PositionX = grid.GetLength(0) - 10;
                if (this.PositionY < 0) this.PositionY = 0;
                if (this.PositionY > grid.GetLength(1) - 10) this.PositionY = grid.GetLength(1) - 10;
            }
            this.Energy--;
            this.Age++;
            
        }
      

        public Wolf wolfReproduce()
        {
            if (this.Age >= 5&&this.EnergyToReproduce < this.Energy && randomGen.NextDouble() < this.changeToReproduce) {
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
