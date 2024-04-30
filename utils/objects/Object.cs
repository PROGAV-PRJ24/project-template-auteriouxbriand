public class Object
{
    public char Representer { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Benefit { get; set; } //nombre de points de santé qu'il rapporte au joueur


    public Map CurrentMap { get; set; }
    private Random rd = new Random();
    public Object(Map map, char rep, int benefit)
    {
        CurrentMap = map;
        PositionX = rd.Next(0, Config.Instance.LAND_MAP_SIZE[0]);
        PositionY = rd.Next(0, Config.Instance.LAND_MAP_SIZE[1]);
        Representer = rep;
        Benefit = benefit;
    }
}