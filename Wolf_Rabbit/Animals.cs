using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf_Rabbit
{
    public abstract class Animal //Trừu tượng hóa lớp Animal
    {
        private int positionX;
        private int positionY;
        private int energy;
        private int energyToReproduce;
        private int age;
        private int ageToReproduce;
        private Color animalColor;
        private float changeToReproduce;
        private int visionRange;
        private int moveSpeed;
        public int PositionX
        {
            get { return this.positionX; }
            set { this.positionX = value; }
        }
        public int PositionY
        {
            get { return this.positionY; }
            set { this.positionY = value; }
        }
        public int Energy
        {
            get { return this.energy; }
            set { this.energy = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }   
        }
        public int AgeToReproduce
        {
            get { return this.ageToReproduce; }
            set { this.ageToReproduce = value; }
        }
        public Color AnimalColor
        {
            get { return this.animalColor; }
            set { this.animalColor = value; }
        }
        public int EnergyToReproduce
        {
            get { return this.energyToReproduce; }
            set { this.energyToReproduce = value; }
        }
        public float ChangeToReproduce
        {
            get { return this.changeToReproduce; }
            set {  changeToReproduce = value; }
        }
        public int VisionRange
        {
            get { return this.visionRange; }
            set { this.visionRange = value; }
        }
        public int MoveSpeed
        {
            get { return this.moveSpeed; }
            set { this.moveSpeed = value; }
        }
        protected static Random randomGen = new Random(); //protected dùng để mở rộng quyền truy cập cho các lớp
                                                          //con kế thừa từ lớp Animal
        public virtual void Move(List<Animal>[,] grid,int worldWidth,int worldHeight)
        {
            return;
        }
    }
}
