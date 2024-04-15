
public class Sea : Map
{
    private int[] Dimensions = Config.Instance.SEA_MAP_SIZE;
    public Sea() : base()
    {
        Grid = new char[Dimensions[0], Dimensions[1]];
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Grid[i, j] = '~';
            }
        }
    }

    public void GenerateIslands()
    {
        GenerateIsland(this.rd.Next(8, 10), this.rd.Next(6, 7));

        GenerateIsland(this.rd.Next(3, 5), this.rd.Next(22, 23));

        GenerateIsland(this.rd.Next(20, 23), this.rd.Next(10, 15));

    }
    private void GenerateIsland(int x, int y)
    {
        int length = 0;

        for (int p = 0; p < 5; p++)
        {
            length = (length == this.rd.Next(4)) ? length + 1 : this.rd.Next(2, 5);

            for (int i = 0; i < length; i++)
            {
                Grid[x, y + i] = '#';
                Grid[x, y - i] = '#';
            }
            x++;
        }
    }
    public void PlaceBoat()
    {
        int currentX = 15;
        int currentY = 15;
        while (Grid[currentX, currentY] == '#')
        {
            currentX++;
            currentY++;
        }
        Grid[currentX, currentY] = 'O';
    }

    public override void Render()
    {
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Console.ForegroundColor = (Grid[i, j] == '#') ? ConsoleColor.Green : ((Grid[i, j] == 'O') ? ConsoleColor.Red : ConsoleColor.Blue);
                Console.Write($" {Grid[i, j]} ");
            }
            Console.Write("\n");
        }
    }

}