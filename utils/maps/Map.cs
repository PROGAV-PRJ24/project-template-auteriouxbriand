public class Map
{
    private int[] Dimensions = Config.Instance.MAP_SIZE;
    private char[,] Grid { get; set; }
    private List<Object>? Objects { get; set; }
    private Random rd = new Random();
    public Map()
    {
        Grid = new char[Dimensions[0], Dimensions[1]];
        this.Fill();
        // this.PlaceIsland();
    }

    private void Fill()
    {
        StreamReader sr = new StreamReader("./utils/map.txt");
        string line;
        // Read and display lines from the file until the end of
        // the file is reached.
        int i = 0;
        while ((line = sr.ReadLine()) != null)
        {
            for (int j = 0; j < line.Length; j++)
            {
                Grid[i,j] = line[j];
            }
            i++;
        }
    }

    public void SetCurrentPosition(Player player,int x, int y)
    {
        Grid[player.PositionX, player.PositionY] = 'x';
        Grid[x,y] = '~';
    }

    private void PlaceObjects(List<Object> objects)
    {
    }

    private void PlaceBoat()
    {
    }

    public void Render()
    {
        string chain = "";
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                chain += $"{Grid[i, j]}";
            }
            chain += "\n";
        }
        Console.WriteLine(chain);
    }

}