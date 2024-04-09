public class Config
{
    public int[] MAP_SIZE { get; }

    private static Config instance = null;
    public static Config Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    private Config()
    {
        MAP_SIZE = {10, 10};
    }
}