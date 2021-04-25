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

        public Shark(int posX, int posY, int energy = 5, string caller = "shark") : base(posX, posY, caller)
        {
            Energy = energy;
        }

        public Shark() { }

        public override void Move(ref IField[,] field, ref List<PlayerPosition> playerPos, PlayerPosition player)
        {
            Field = field;

            // Check chosen field for availability
            if (!PickDirection(out int newPosX, out int newPosY))
                return;

            if (Field[newPosX, newPosY] is Fish)
            {
                Kill(newPosX, newPosY);
            }

            if (Breed(Energy, EnergyToBreed))
            {
                Field[newPosX, newPosY] = new Shark(newPosX, newPosY, Energy/2);
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

            Tick();

            if (Energy <= 0)
            {
                Die(newPosX, newPosY);
                Field[newPosX, newPosY] = new Cell(newPosX, newPosY);
            }
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

        protected override bool PickCondition(int x, int y) => Field[x, y].IsEmpty || Field[x, y] is Fish;

        protected override void Tick() => Energy--;
    }
}
