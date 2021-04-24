using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaTor_2
{
    delegate void PositionHandler(int a, int b);

    class Player : Cell
    {
        protected static PositionHandler Killed;

        protected static Random Rnd { get; set; }
        
        protected static IField[,] Field { get; set; }

        protected static int AgeToBreed { get; set; }

        protected static int EnergyToBreed { get; set; }

        protected int Age { get; set; }

        public Player(int posX, int posY, string caller) :base (posX, posY, caller) { }

        public Player() { }

        static Player()
        {
            Rnd = Simulation.rnd;
            Killed = Simulation.Killed;

            AgeToBreed = 5;
            EnergyToBreed = 8;
        }

        public virtual void Move(ref IField[,] field, ref List<PlayerPosition> playerPos, PlayerPosition player)
        {
            Field = field;
            int newPosX, newPosY;
            int stuckCount = 0;
            int stuckMax = 4;

            // Check chosen field for availability
            do
            {
                PickDirection(out newPosX, out newPosY);
                if (++stuckCount >= stuckMax)
                    return;
            } while (!Field[newPosX, newPosY].IsEmpty);

            // Move or Breed. Add Positions to List
            if (Breed(Age, AgeToBreed))
            {
                Field[newPosX, newPosY] = new Fish (newPosX, newPosY);
                playerPos.Add(new PlayerPosition { Type = "fish", X = newPosX, Y = newPosY });
                Age = 0;
                Simulation.NumberOfFish++;
            }
            else
            {
                Field[newPosX, newPosY] = Field[PosX, PosY];
                Field[PosX, PosY] = new Cell(PosX, PosY);
                PosX = player.X = newPosX;
                PosY = player.Y = newPosY;
            }

            Tick();
        }

        protected virtual void Tick() => Age++;

        public bool Breed(int number, int condition) => number >= condition;

        protected void PickDirection(out int newPosX, out int newPosY)
        {
            int arrX = Simulation.ArrX;
            int arrY = Simulation.ArrY;

            switch (Rnd.Next(1, 5))
            {
                //Up
                case 1:
                    newPosX = PosX;

                    if (PosY == 0) { newPosY = PosY + arrX - 1; }
                    else { newPosY = PosY - 1; }
                    break;
                //Right
                case 2:
                    newPosY = PosY;

                    if (PosX == arrY - 1) { newPosX = 0; }
                    else { newPosX = PosX + 1; }
                    break;
                //Down
                case 3:
                    newPosX = PosX;

                    if (PosY == arrX - 1) { newPosY = 0; }
                    else { newPosY = PosY + 1; }
                    break;
                //Left
                case 4:
                    newPosY = PosY;

                    if (PosX == 0) { newPosX = PosX + arrY - 1; }
                    else { newPosX = PosX - 1; }
                    break;
                default:
                    newPosX = 0;
                    newPosY = 0;
                    break;
            }
        }
    }
}
