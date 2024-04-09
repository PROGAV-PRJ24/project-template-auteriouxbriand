public abstract class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Attack { get; set; }
    public int positionX { get; set; }
    public int positionY { get; set; }

    private MoveManager mover;

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
        Health = level*10;
        Mana = level*5;
        Attack = attack*2;
        positionX = 0;
        positionY = 0;
        mover = new MoveManager();
    }

    public void LevelUp()
    {
        Level++;
        Health += 10;
        Mana += 5;
        Attack += 2;
    }

    public void Attack(Player target)
    {
        target.Health -= Attack;
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
        return "Name: " + Name + "\nLevel: " + Level + "\nHealth: " + Health + "\nMana: " + Mana + "\nAttack: " + Attack + "\nPosition: " + positionX + ", " + positionY;
    }

}