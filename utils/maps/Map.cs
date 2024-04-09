public class Map
{
    private int[] Dimensions = Config.Instance.MAP_SIZE;
    private int[,] map;
    private Random rd = new Random();
    public Map()
    {
        map = new int[Dimensions[0],Dimensions[1]];
        this.Fill();
        Console.WriteLine("Map initialized");
    }

    private void Fill()
    {
        for(int i=0;i<Dimensions[0];i++)
        {
            for(int j=0;j<Dimensions[1];j++)
            {
                map[i,j] = 0;
            }
        }
    }

    public override string ToString()
    {   
        string chain = "";
        for(int i=0;i<Dimensions[0];i++)
        {
            for(int j=0;j<Dimensions[1];j++)
            {
                chain += (map[i,j]==1)? "     " : "  #  ";
            }
            chain += "\n";
        }
        map[rd.Next(Dimensions[0]),rd.Next(Dimensions[1])] = 1;
        return chain;
    }
}

