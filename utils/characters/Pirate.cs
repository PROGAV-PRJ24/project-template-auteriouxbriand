public class Pirate : Player
{
    public Pirate(string name, int level) : base(name, level)
    {
        Representer = 'P';
    }

    public void Attack(Player target)
    {
        base.Attack(target);
        Health += pAttack / 2;
    }

    public void Steal(Player target)
    {
        target.Inventaire
        Health += pAttack;
    }
}