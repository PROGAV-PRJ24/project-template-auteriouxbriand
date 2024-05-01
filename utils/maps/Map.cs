

public abstract class Map
{
    protected int[] Dimensions { get; set;}
    public int Width { get; set; }
    public int Height { get; set; }
    public char[,] Grid { get; set; }
    protected static Random rd = new Random();

    public Map() { }

    public void BuildBoat() {
        int startX = 0;
        int startY = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Grid[startX + i, startY + j] = 'b';
            }
        }
        for (int i = 3; i > 0; i--)
        {
            // Dessiner les #
            for (int k = 0; k < i * 2 - 1; k++)
            {
                Grid[i,k] = '_';
            }
        }
        

    }

    public virtual void Render(Player player) {}

}