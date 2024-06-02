

public abstract class Map
{
    protected int[] Dimensions { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public char[,] Grid { get; set; }
    protected static Random rd = new Random();

    public Map()
    {
        this.Dimensions = Config.Instance.LAND_MAP_SIZE;
        this.Grid = new char[Height, Width];
    }

    public void BuildBoat()
    {
        int startX = 0;
        int startY = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Grid[startX + i, startY + j] = 'b';
            }
        }
    }

    public virtual void Render(List<Player> players, List<Monster> monster) { }

}