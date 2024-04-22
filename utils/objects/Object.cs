public class Object
{
    public char Representer { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Map CurrentMap { get; set; }
    private Random rd = new Random();
    public Object(Map map, char rep)
    {
        CurrentMap = map;
        PositionX = rd.Next(0, Config.Instance.LAND_MAP_SIZE[0]);
        PositionY = rd.Next(0, Config.Instance.LAND_MAP_SIZE[1]);
        Representer = rep;
    }
}