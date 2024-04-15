public abstract class Map
{
    protected char[,] Grid { get; set; }
    protected Random rd = new Random();
    public Map()
    {
        // this.PlaceIsland();
    }

    // private void Fill()
    // {
    //     StreamReader sr = new StreamReader("./utils/map.txt");
    //     string line;
    //     // Read and display lines from the file until the end of
    //     // the file is reached.
    //     int i = 0;
    //     while ((line = sr.ReadLine()) != null)
    //     {
    //         for (int j = 0; j < line.Length; j++)
    //         {
    //             Grid[i,j] = line[j];
    //         }
    //         i++;
    //     }
    // }

    public void SetCurrentPosition(Player player, int x, int y)
    {
        Grid[player.PositionX, player.PositionY] = player.Representer;
        Grid[x, y] = '~';
    }

    private void PlaceObjects(List<Object> objects)
    {
    }

    private void PlaceBoat()
    {
    }

    public virtual void Render()
    {
        // for (int i = 0; i < Dimensions[0]; i++)
        // {
        //     for (int j = 0; j < Dimensions[1]; j++)
        //     {
        //         Console.ForegroundColor = (Grid[i, j] == '#') ? ConsoleColor.Green : ((Grid[i, j] == 'O') ? ConsoleColor.Red : ConsoleColor.Blue);
        //         Console.Write($" {Grid[i, j]} ");
        //     }
        //     Console.Write("\n");
        // }
    }

}