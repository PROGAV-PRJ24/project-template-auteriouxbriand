public class Config
{
    public int[] MAP_SIZE { get; set;} = { 30 , 90 };

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