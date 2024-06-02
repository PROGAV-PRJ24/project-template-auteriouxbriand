public class JeanNorbert : Player
{
    public JeanNorbert(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'J';
        this.Color = ConsoleColor.Black;
        Health = 5;
    }
}