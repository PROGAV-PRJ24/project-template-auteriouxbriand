public class Config
{
    public int[] SEA_MAP_SIZE { get; set; } = { 30, 30 };
    public int[] LAND_MAP_SIZE { get; set; } = { 30, 30 };

    private static Config? instance = null;
    public static Config Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Config();
            }
            return instance;
        }
    }

    private Config()
    {

    }
}