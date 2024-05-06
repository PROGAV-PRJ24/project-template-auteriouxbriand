public class Monster
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public int PositionX { get; private set; }
    public int PositionY { get; private set; }

    private static Random rd = new Random();

    public bool IsAlive
    {
        get
        {
            return Health > 0;
        }
        set
        {

        }
    }

    public Monster(string name, Island map, int level = 1, int x = 0, int y = 0)
    {
        Name = name;
        Level = level;
        Health = level * 10;
        Damage = level * 2;
        Spawn(map);
    }

    private void Spawn(Map map)
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
    // public void Move(IslandView map)
    // {
    //     int dx = 0;
    //     int dy = 0;

    //     do
    //     {
    //         do
    //         {
    //             dx = rd.Next(-this.Level, this.Level);
    //             dy = rd.Next(-this.Level, this.Level);
    //         } while (PositionX + dx < map.Height && PositionX + dx > 0 && PositionY + dy < map.Width && PositionY + dy > 0);
    //     } while (map.Grid[PositionX + dx, PositionY + dy] != '#');
    // }

    // Spawn déja fait sur une autre version non commitée, ne pas toucher à cette classe


}