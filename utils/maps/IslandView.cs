public class IslandView : Map
{
    public Object[,] Objects { get; set; }

    public IslandView() : base()
    {
        // Config definition
        this.Dimensions = Config.Instance.LAND_MAP_SIZE;
        this.Height = Dimensions[0];
        this.Width = Dimensions[1];

        // Grid definition
        this.Grid = new char[Height, Width];
        this.Objects = new Object[Height, Width];

        // Filling map with empty cells
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                Grid[i, j] = '.';

        this.BuildGridTerrain(5); // Générer 3 îles
        this.BuildBoat(); // Générer un bateau
    }

    private void BuildGridTerrain(int numIslands)
    {
        Random rand = new Random();

        for (int i = 0; i < numIslands; i++)
        {
            int centerX = rand.Next(5, Width - 5); // Position aléatoire en x pour le centre de l'île
            int centerY = rand.Next(5, Height - 5); // Position aléatoire en y pour le centre de l'île

            int radius = rand.Next(3, 8); // Rayon aléatoire pour l'île

            for (int y = centerY - radius; y <= centerY + radius; y++)
            {
                for (int x = centerX - radius; x <= centerX + radius; x++)
                {
                    if (x >= 0 && x < Width && y >= 0 && y < Height)
                    {
                        double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
                        if (distance <= radius)
                        {
                            Grid[x, y] = '#'; // Remplir la zone de l'île avec des #
                        }
                    }
                }
            }
        }
    }

    public void AddObject(Object obj)
    {
        int x, y;
        do
        {
            x = rd.Next(0, Width);
            y = rd.Next(0, Height);
        }
        while (Grid[x, y] == '.');

        Objects[x, y] = obj;
    }

    public void RemoveObject(int x, int y)
    {
        Objects[x, y].state = false;
    }

    public override void Render(Player player)
    {

        for (int i = 0; i < Height; i++)
        {

            for (int j = 0; j < Width; j++)
            {

                if (player.PositionX == i && player.PositionY == j)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" P ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (Grid[i, j] == 'b')
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" _ ");
                }
                else if (Objects[i, j] != null && Objects[i, j].state)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" X ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = Grid[i, j] == '.' ? ConsoleColor.Blue : (Grid[i, j] == '#' ? ConsoleColor.Yellow : ConsoleColor.Black);
                    Console.Write(" " + Grid[i, j] + " "); // Affiche la carte
                    Console.BackgroundColor = ConsoleColor.Black;
                }


            }
            Console.WriteLine();
        }
    }

}