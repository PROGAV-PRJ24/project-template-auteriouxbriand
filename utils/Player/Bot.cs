public class Bot : Player
{
    public Bot(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'R';
        this.Color = ConsoleColor.DarkYellow;
    }
    public void Move(Map map)
    {
        int dx = rd.Next(-1, 2);
        int dy = rd.Next(-1, 2);

        base.Move(dx, dy, map);

        int dig = rd.Next(0, 5);
        if (dig == 0)
        {
            Dig((Island)map);
        }
    }
}