public class Magicien : Player
{
    public Magicien(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'W';
        this.Color = ConsoleColor.DarkCyan;
        this.Spread = 5; // La licorne peut attaquer de 4 cases de distances.
        this.Mana = level * 10;
    }
    public override void Move(int dx, int dy, Map map) // Le comportement de mouvement de la licorne est différent, elle peut se déplacer de 3 cases une fois sur 5.
    {
        if (rd.Next(0, 5) == 0)
        {
            dx = 3 * dx;
            dy = 3 * dy;
        }
        base.Move(dx, dy, map);
    }
}