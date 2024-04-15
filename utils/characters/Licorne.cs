public class Licorne : Player
{

    public Licorne(string name, int level, Map currentMap) : base(name, level, currentMap)
    {
        Representer = 'L';
    }

    public void Heal(Player target)
    {
        target.Health += pAttack / 2;
    }

    public void Buff(Player target)
    {
        target.pAttack += pAttack / 2;
    }
    public void Jump(int x, int y)
    {
        this.Mover.Jump(this, CurrentMap, x, y);
    }


}