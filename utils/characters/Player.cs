public abstract class Player
{
    public char Representer { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int pAttack { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public List<Object> Inventaire {  get;  set;  }
    public int capacity {  get; set;  }
    protected MoveManager Mover;
    public Map? CurrentMap { get; set; }

    public bool IsAlive
    {
        get
        {
            return Health > 0;
        }
        set{
            
        }
    }

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
        Health = level * 10;
        Mana = level * 5;
        pAttack = level * 2;
        PositionX = 0;
        PositionY = 0;
        Inventaire = new List<Object>();
        Mover = new MoveManager();
    }

    public void LevelUp()
    {
        Level++;
        Health += 10;
        Mana += 5;
        pAttack += 2;
    }

    public void Attack(Player target)
    {
        target.Health -= pAttack;
    }

    public void Move(int direction)
    {
        Mover.Move(this, CurrentMap, direction);
    }

    public override string ToString()
    {
        return "Name: " + Name + "\nLevel: " + Level + "\nHealth: " + Health + "\nMana: " + Mana + "\nAttack: " + pAttack + "\nPosition: " + PositionX + ", " + PositionY;
    }

}