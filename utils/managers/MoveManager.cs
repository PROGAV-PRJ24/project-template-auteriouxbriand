public class MoveManager
{
    public void Jump(Player player, Map currentMap, int x, int y)
    {
        if (x >= 0 && x < Config.Instance.LAND_MAP_SIZE[0] && y >= 0 && y < Config.Instance.LAND_MAP_SIZE[1])
        {
            player.PositionX = x;
            player.PositionY = y;
        }
        // currentMap.SetCurrentPosition(player, x, y);

    }
    public void Move(Player player, int direction)
    {
        switch (direction)
        {
            case 8:
                if (player.PositionX == Config.Instance.LAND_MAP_SIZE[0] - 1)
                {
                    player.PositionX++;
                    direction = 2;
                }
                else
                {
                    player.PositionX--;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                break;
            case 6:
                if (player.PositionY == Config.Instance.LAND_MAP_SIZE[1] - 1)
                {
                    player.PositionY--;
                    direction = 4;


                }
                else
                {
                    player.PositionY++;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                break;
            case 2:
                if (player.PositionX == 0)
                {
                    player.PositionX++;
                    direction = 8;

                }
                else
                {
                    player.PositionX--;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                break;
            case 4:
                if (player.PositionY == 0)
                {
                    player.PositionY++;
                    direction = 6;

                }
                else
                {
                    player.PositionY--;
                    player.CurrentMap.SetCurrentPosition(player, direction);
                }
                break;
        }
    }
}