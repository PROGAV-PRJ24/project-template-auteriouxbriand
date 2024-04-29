public abstract class Player
{
    public string Name { get; set; }
    public char Representer { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Damage { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public List<Object> Inventaire { get; set; }
    public int capacity { get; set; }
    protected MoveManager Mover;
    public Map CurrentMap { get; set; }

    public bool IsAlive
    {
        get
        {
            return Health > 0;
        }
        set
        {

        }
    }

    public Player(string name, int level, Map map)
    {
        Name = name;
        Level = level;
        Health = level * 10;
        Mana = level * 5;
        Damage = level * 2;
        PositionX = 1;
        PositionY = 4;
        Inventaire = new List<Object>();
        Mover = new MoveManager();
        CurrentMap = map;
    }

    public void LevelUp()
    {
        Level++;
        Health += 10;
        Mana += 5;
        Damage += 2;
    }

    public void Attack(Player target)
    {
        target.Health -= Damage;
    }

    public void Move(int direction)
    {
        Mover.Move(this, direction);
    }

    public override string ToString()
    {
        return "-  -  -  -  -  -  -  -  -  -  -  -  -  -  - \n" + "Name: " + Name + "\nLevel: " + Level + "\nHealth: " + Health + "\nMana: " + Mana + "\nAttack: " + Damage + "\nPosition: " + PositionX + ", " + PositionY + "\n -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
    }

}