public class Pirate : Player
{
    public Pirate(string name, int level, Map currentMap) : base(name, level, currentMap)
    {
        Representer = 'P';
    }

    new public void Attack(Player target)
    {
        base.Attack(target);
        Health += Damage / 10;
    }

    public void Steal(Player target)
    {
        this.Inventaire = target.Inventaire;
        target.Inventaire = new List<Object>();
    }
}