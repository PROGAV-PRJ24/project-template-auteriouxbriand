public abstract class Map
{
    protected char[,] InvisibleGrid { get; set; }
    protected char[,] Grid { get; set; }
    protected Random rd = new Random();

    public Map() { }
    public void SetCurrentPosition(Player player, int direction)
    {
        Grid[player.PositionX, player.PositionY] = player.Representer;
        switch (direction)
        {
            case 8:
                Grid[player.PositionX + 1, player.PositionY] = InvisibleGrid[player.PositionX + 1, player.PositionY];
                break;
            case 6:
                Grid[player.PositionX, player.PositionY - 1] = InvisibleGrid[player.PositionX, player.PositionY - 1];
                break;
            case 2:
                Grid[player.PositionX - 1, player.PositionY] = InvisibleGrid[player.PositionX - 1, player.PositionY];
                break;
            case 4:
                Grid[player.PositionX, player.PositionY + 1] = InvisibleGrid[player.PositionX, player.PositionY + 1];
                break;
        }
    }
    public void PlaceObject(Object obj)
    {
        Grid[obj.PositionX, obj.PositionY] = obj.Representer;
    }

    public virtual void PlaceBoat() { }

    public virtual void Render() { }

}