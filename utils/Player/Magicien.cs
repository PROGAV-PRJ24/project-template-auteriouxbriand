public class Magicien : Player
{
    public Magicien(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'W';
        this.Color = ConsoleColor.DarkCyan;
    }
}