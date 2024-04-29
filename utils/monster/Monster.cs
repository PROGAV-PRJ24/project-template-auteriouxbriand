public class Monster
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Monster()
    {
        Health = 100;
        Damage = 10;
        PositionX = 1;
        PositionY = 1;
    }
}