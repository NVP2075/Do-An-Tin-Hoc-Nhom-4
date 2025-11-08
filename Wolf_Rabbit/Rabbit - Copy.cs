using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf_Rabbit
{
    internal class Rabbit:Animal
    {
      
        private float reproduceChange;
        public Rabbit()
        {
            this.PositionX = 1;
            this.PositionY = 1;
            this.Energy = 1;
            this.Age = 1;
            this.AnimalColor = Color.White;
            this.EnergyToReproduce = 10;
            this.reproduceChange = (float)0.5;
        }
        //Lenh di chuyen cua Rabbit
        public override void Move(List<Animal>[,] grid)
        {
            int deltaX = randomGen.Next(-10, 10);
            int deltaY = randomGen.Next(-10, 10);
            this.PositionX += deltaX;
            this.PositionY += deltaY;
            if (this.PositionX < 0) this.PositionX = 0;
            if (this.PositionX > grid.GetLength(0) - 10) this.PositionX = grid.GetLength(0) - 10;
            if (this.PositionY < 0) this.PositionY = 0;
            if (this.PositionY > grid.GetLength(1) - 10) this.PositionY = grid.GetLength(1) - 10;
            this.Energy += 2;
            this.Age++;
           
        }
        public Rabbit rabbitReproduce()
        {
            if (this.Age >= 3&&this.Energy >= this.EnergyToReproduce && randomGen.NextDouble() < this.reproduceChange)
            {
                Rabbit babyRabbit = new Rabbit();
                babyRabbit.PositionX = this.PositionX;
                babyRabbit.PositionY = this.PositionY;
                babyRabbit.AnimalColor = Color.LightSkyBlue;
                this.Energy = 1;
                return babyRabbit;
            }
                return null;
        }
    }
}
