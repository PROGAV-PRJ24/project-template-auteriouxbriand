public class Pirate : Player
{
    public Pirate(string name, int level, Island map) : base(name, level, map)
    {
        this.Symbol = 'P';
        this.Color = ConsoleColor.DarkRed;
    }
    public override void Attack(Player target)
    {
        if (target.Alive && this.isNearby(target, this.Spread))
        {
            target.Health -= Damage * Mana;
            this.Energy -= 1.5;
            this.Message += $"\n Vous avez attaqué le joueur {target.Name}, il lui reste {target.Health} points de vie.";
            this.Mana -= 1;
        }
        else
        {
            this.Message += $"\n Aucun joueur à attaquer à proximité.";
        }
    }
    public override void Attack(Monster monster)
    {
        monster.Health -= Damage * Mana;
        this.Energy -= 2;
    }
}