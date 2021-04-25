using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WaTor_2
{
    public partial class Simulation : Form
    {
        // TODO:
        // Add Method to "sense" nearby Fish

        // Initial Values
        public static int NumberOfFish = 400;
        public static int NumberOfSharks = 250;
        public static IField[,] Field = new IField[50, 50];

        public static List<PlayerPosition> PosList = new List<PlayerPosition> { };
        public static List<PlayerPosition> PosToAdd = new List<PlayerPosition> { };

        public static Random rnd = new Random();
        public static readonly int ArrX = Field.GetLength(0);
        public static readonly int ArrY = Field.GetLength(1);

        // Golden Ratios
        private static int CellSize = 50 / (ArrX / 10);
        private static int delayTime = 0;

        public Simulation()
        {
            InitializeComponent();
            InitializeArray();

            Size = new Size((ArrX * CellSize + 15), (ArrY * CellSize + 39));
            Paint += new PaintEventHandler(Paint_Field);
        }

        public void InitializeArray()
        {
            int sharkCount = 0;
            int fishCount = 0;
            int rnd1, rnd2;

            // Distribute Sharks & Save Positions
            while (sharkCount < NumberOfSharks)
            {
                do
                {
                    rnd1 = rnd.Next(0, (ArrX - 1));
                    rnd2 = rnd.Next(0, (ArrY - 1));
                } while (Field[rnd1, rnd2] != null);

                Field[rnd1, rnd2] = new Shark(rnd1, rnd2);
                
                PosList.Add(new PlayerPosition { Type = "shark", X = rnd1, Y = rnd2 });
                sharkCount++;
            }

            // Distribute Fish & Save Positions
            while (fishCount < NumberOfFish)
            {
                do
                {
                    rnd1 = rnd.Next(0, (ArrX - 1));
                    rnd2 = rnd.Next(0, (ArrY - 1));
                } while (Field[rnd1, rnd2] != null);

                Field[rnd1, rnd2] = new Fish(rnd1, rnd2);
                PosList.Add(new PlayerPosition { Type = "fish", X = rnd1, Y = rnd2 });
                fishCount++;
            }

            // Fill remaining Cells
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == null)
                    {
                        Field[i, j] = new Cell(i, j);
                    }
                }
            }
        }

        public void Paint_Field(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            for (int i = 0; i < ArrX; i++)
            {
                for (int j = 0; j < ArrY; j++)
                {
                    Brush b = new SolidBrush(Field[i, j].CellColor);
                    Rectangle r = new Rectangle((Field[i, j].PosX * CellSize), (Field[i, j].PosY * CellSize), CellSize, CellSize);
                    g.FillRectangle(b,r);
                }
            }
        }

        public void GameLoop()
        {
            Rectangle r = new Rectangle(0, 0, 1, 1);

            MessageBox.Show("Start");

            while (NumberOfFish > 0 && NumberOfSharks > 0)
            {
                PosToAdd = new List<PlayerPosition>();

                foreach (PlayerPosition p in PosList)
                {
                    if (p.Type == "fish")
                    {
                        Fish fish = (Fish)Field[p.X, p.Y];
                        fish.Move(ref Field, ref PosToAdd, p);
                    }
                }

                UpdatePositions();

                foreach (PlayerPosition p in PosList)
                {
                    if (p.Type == "shark")
                    {
                        Shark shark = (Shark)Field[p.X, p.Y];
                        shark.Move(ref Field, ref PosToAdd, p);
                    }
                }

                UpdatePositions();
                
                Invalidate(r);
                Update();
                Task.Delay(delayTime).Wait();
            }

            MessageBox.Show($"{Winner()} win!");
        }

        private void UpdatePositions()
        {
            PosList.RemoveAll(p => p.Type == "dead");
            PosList.AddRange(PosToAdd);

            fishNumLabel.Text = NumberOfFish.ToString();
            sharkNumLabel.Text = NumberOfSharks.ToString();
        }

        public static void Killed(int PosX, int PosY) => PosList.First(p => p.Type != "dead" && p.X == PosX && p.Y == PosY).Type = "dead";

        private static string Winner() => NumberOfFish > NumberOfSharks ? "Fish" : "Sharks";

        private void Simulation_Shown(object sender, EventArgs e) => GameLoop();
    }
}
