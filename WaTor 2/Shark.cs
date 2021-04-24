using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaTor_2
{
    class Shark : Player
    {
        private int Energy { get; set; }

        public Shark(int posX, int posY, int energy = 7, string caller = "shark") : base(posX, posY, caller)
        {
            Energy = energy;
        }

        public Shark() { }

        public override void Move(ref IField[,] field, ref List<PlayerPosition> playerPos, PlayerPosition player)
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
            } while (!Field[newPosX, newPosY].IsEmpty && Field[newPosX, newPosY] is Shark);

            //// Move or Breed. Add Positions to List
            //if (Breed(Age, AgeToBreed))
            //{
            //    Field[newPosX, newPosY] = new Shark(newPosX, newPosY);
            //    playerPos.Add(new PlayerPosition { Type = "shark", X = newPosX, Y = newPosY });
            //    Age = 0;
            //    Simulation.NumberOfSharks++;
            //}
            if (Field[newPosX, newPosY] is Fish)
            {
                Kill(newPosX, newPosY);
                if (Energy >= EnergyToBreed)
                {
                    Field[newPosX, newPosY] = new Shark(newPosX, newPosY, Energy / 2);
                    playerPos.Add(new PlayerPosition { Type = "shark", X = newPosX, Y = newPosY });
                    Energy /= 2;
                    Simulation.NumberOfSharks++;
                }
                else
                {
                    Field[newPosX, newPosY] = Field[PosX, PosY];
                    Field[PosX, PosY] = new Cell(PosX, PosY);
                    PosX = player.X = newPosX;
                    PosY = player.Y = newPosY;
                }
            }
            else
            {
                Field[newPosX, newPosY] = Field[PosX, PosY];
                Field[PosX, PosY] = new Cell(PosX, PosY);
                PosX = player.X = newPosX;
                PosY = player.Y = newPosY;
            }

            if (Energy <= 0)
            {
                Field[PosX, PosY] = new Cell(PosX, PosY);
                Die(PosX, PosY);
            }

            Tick();
        }

        public void Kill(int fishX, int fishY)
        {
            Killed(fishX, fishY);
            Energy += 3;
            Simulation.NumberOfFish--;
        }

        public void Die(int sharkX, int sharkY)
        {
            Killed(sharkX, sharkY);
            Simulation.NumberOfSharks--;
        }

        protected override void Tick() => Energy--;
    }
}
