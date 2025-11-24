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
        public Rabbit()
        {
            this.PositionX = 1;
            this.PositionY = 1;
            this.Energy = 1;
            this.Age = 1;
            this.AnimalColor = Color.White;
            this.EnergyToReproduce = 10;
            this.ChangeToReproduce = (float)0.5;
            this.AgeToReproduce = 3;
            this.VisionRange = 200;
            this.MoveSpeed = 10;
        }
        //Phương thức di chuyển của Rabbit
        public override void Move(List<Animal>[,] grid, int worldWidth, int worldHeight)
        {
            int indexX = randomGen.Next(-this.MoveSpeed, this.MoveSpeed);
            int indexY = randomGen.Next(-this.MoveSpeed, this.MoveSpeed);
            this.PositionX += indexX;
            this.PositionY += indexY;
            if(PositionX <0) this.PositionX = 0;
            if(PositionX > worldWidth -10) this.PositionX = worldWidth -10;
            if(PositionY<0) this.PositionY = 0;
            if(PositionY > worldHeight -10) this.PositionY = worldHeight -10;
            this.Energy += 2;
            this.Age++;
           
        }
        public Rabbit rabbitReproduce()
        {
            if (this.Age >= AgeToReproduce&&this.Energy >= this.EnergyToReproduce && randomGen.NextDouble() < this.ChangeToReproduce)
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
