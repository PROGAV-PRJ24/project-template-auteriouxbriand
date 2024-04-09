public abstract class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int AP { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public List<Object> Inventaire {get;set;}
    public int capacity {get; set;}
    private MoveManager mover;

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
        Health = level*10;
        Mana = level*5;
        AP = level*2;
        PositionX = 0;
        PositionY = 0;
        Inventaire = new List<Object>();
        mover = new MoveManager();
    }

    public void LevelUp()
    {
        Level++;
        Health += 10;
        Mana += 5;
        AP += 2;
    }

    public void Attack(Player target)
    {
        target.Health -= AP;
    }

    public void Move(int direction)
    {
        mover.Move(this, direction);
    }

    public void Jump(int x, int y)
    {
        mover.Jump(this, x, y);
    }

    public override string ToString()
    {
        return "Name: " + Name + "\nLevel: " + Level + "\nHealth: " + Health + "\nMana: " + Mana + "\nAttack: " + AP + "\nPosition: " + PositionX + ", " + PositionY;
    }

}