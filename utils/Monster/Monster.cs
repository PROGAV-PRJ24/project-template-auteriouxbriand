public class Monster : Entity
{
    public int Level { get; set; }
    public Monster(string name, Island map, int level = 1, int x = 0, int y = 0) : base(name, map)
    {
        Level = level;
        Health = level * 10;
        Damage = level * 2;
        Spawn(map);
    }

    public string Attack(Player player)
    {
        if (player.PositionX == PositionX && player.PositionY == PositionY)
        {
            player.Health -= Damage;
            return $"\n {Name} attaque {player.Name} et lui inflige {Damage} points de dégâts";
        }
        return $"";
    }

    public void Move(Map map)
    {
        int x, y;
        do
        {
            x = PositionX + rd.Next(-1, 2);
            y = PositionY + rd.Next(-1, 2);
        } while (x >= 0 && x < map.Width && y >= 0 && y < map.Height && map.Grid[x, y] == '.');
        PositionX = x;
        PositionY = y;
    }

}