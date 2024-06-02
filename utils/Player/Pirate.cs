public class Pirate : Player
{
    public Pirate(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'P';
        this.Color = ConsoleColor.DarkRed;
    }
}