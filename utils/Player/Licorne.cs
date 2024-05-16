public class Licorne : Player
{
    public Licorne(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'L';
        this.Color = ConsoleColor.Magenta;
    }
}