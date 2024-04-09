public class Config
{
    public int[] MAP_SIZE { get; } = {10, 10};

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