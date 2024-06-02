public class Licorne : Player
{

    public Licorne(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'L';
        this.Spread = 2; // La licorne peut attaquer de 4 cases de distances.
        this.Color = ConsoleColor.Magenta;
    }
    public override void Move(int dx, int dy, Map map) // Le comportement de mouvement de la licorne est différent, elle peut se déplacer de 3 cases une fois sur 5.
    {
        if (rd.Next(0, 5) == 0)
        {
            dx = 3 * dx;
            dy = 3 * dy;
        }
        else if (rd.Next(0, 5) == 1)
        {
            Heal();
        }
        base.Move(dx, dy, map);

    }
    public void Heal()
    {
        Health += 3;
    }

}