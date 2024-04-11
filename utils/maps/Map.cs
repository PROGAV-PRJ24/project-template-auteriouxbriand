public class Map
{
    private int[] Dimensions = Config.Instance.MAP_SIZE;
    private int[,] Grid { get; set; }
    private List<Object> Objects { get; set; }
    private Random rd = new Random();
    public Map()
    {
        Grid = new int[Dimensions[0], Dimensions[1]];
        this.Fill();
        Console.WriteLine("Map initialized");
    }

    private void Fill()
    {
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Grid[i, j] = 0;
            }
        }
    }

    public string Render()
    {
        string chain = "";
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                chain += (Grid[i, j] == 1) ? "     " : "  #  ";
            }
            chain += "\n";
        }
        return chain;
    }

    public void setCurrentPosition(Player player,int x,int y)
    {
        Grid[player.PositionX, player.PositionY] = 1;
        Grid[x,y] = 0;
    }
}

