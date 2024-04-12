public class Config
{
    public int[] MAP_SIZE { get; } = { 15, 15 };

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