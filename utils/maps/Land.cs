public class Land : Map
{
    protected int[] Dimensions = Config.Instance.LAND_MAP_SIZE;
    private List<Object>? Objects { get; set; }
    public Land() : base()
    {
        Grid = new char[Dimensions[0], Dimensions[1]];
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Grid[i, j] = '#';
            }
        }
    }

    private void GenerateMountain(int x, int y)
    {
        int length = 0;

        for (int p = 0; p < 3; p++)
        {
            length++;

            for (int i = 0; i < length; i++)
            {
                Grid[x, y + i] = '^';
                Grid[x, y - i] = '^';
            }
            x++;
        }
    }

    public void GenerateMountains()
    {
        GenerateMountain(this.rd.Next(7, 10), this.rd.Next(4, 6));

        GenerateMountain(this.rd.Next(3, 5), this.rd.Next(7, 10));

    }

    public void GenerateBoat()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Grid[i, j] = 'O';
            }
        }
        Grid[1, 4] = 'O';
    }

    public void PlaceObjects()
    {

    }

    public override void Render()
    {
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Console.ForegroundColor = (Grid[i, j] == '^') ? ConsoleColor.DarkYellow : (Grid[i, j] == 'O') ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($" {Grid[i, j]} ");
            }
            Console.Write("\n");
        }
    }

}