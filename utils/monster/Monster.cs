public class Monster
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public char Representeur { get; set; }
    public Map CurrentMap { get; set; }
    protected MoveManager Mover;
    private Random rd = new Random();

    public Monster(Land map)
    {
        Health = 100;
        Damage = 10;
        Representeur = 'M';
        PositionX = rd.Next(0, Config.Instance.LAND_MAP_SIZE[0] - 1);
        PositionY = rd.Next(0, Config.Instance.LAND_MAP_SIZE[0] - 1);
        // pb Positions : il ne faut pas que le monstre pop sur le bateau, il ne doit pas pouvoir y accéder
        // meme pb pour le placement des objets
        CurrentMap = map;
        Mover = new MoveManager();
    }

    public void Move()
    {
        Mover.MoveMonster(this);
    }
}