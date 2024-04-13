public class Pirate : Player
{
    public Pirate(string name, int level) : base(name, level)
    {
        Representer = 'P';
    }

    new public void Attack(Player target)
    {
        base.Attack(target);
        Health += pAttack / 10;
    }

    public void Steal(Player target)
    {
        this.Inventaire = target.Inventaire;
        target.Inventaire = new List<Object>();
    }
}