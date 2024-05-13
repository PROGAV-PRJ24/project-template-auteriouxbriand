public abstract class Entity
{   // Utils
    protected static Random rd = new Random();

    // Identity 
    public string Name { get; set; }
    public char Symbol { get; set; }

    // Stats
    public int Damage { get; set; }

    // Position
    public int PositionX { get; protected set; }
    public int PositionY { get; protected set; }

    public Entity(string name, Island map)
    {
        Name = name;

        Spawn(map);
    }

    protected virtual void Spawn(Map map)
    {
        Random rand = new Random();
        int x = rand.Next(0, map.Width);
        int y = rand.Next(0, map.Height);

        while (map.Grid[x, y] != '#')
        {
            x = rand.Next(0, map.Width);
            y = rand.Next(0, map.Height);
        }

        PositionX = x;
        PositionY = y;
    }

    public bool isNearby(Player player, int distance)
    {
        return Math.Abs(player.PositionX - this.PositionX) <= distance && Math.Abs(player.PositionY - this.PositionY) <= distance;
    }
}