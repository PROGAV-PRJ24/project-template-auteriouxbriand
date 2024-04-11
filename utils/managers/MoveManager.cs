public class MoveManager
{
    public void Jump(Player player, Map currentMap, int x, int y)
    {
        if (x >= 0 && x < Config.Instance.MAP_SIZE[0] && y >= 0 && y < Config.Instance.MAP_SIZE[1])
        {
            player.PositionX = x;
            player.PositionY = y;
        }
        currentMap.setCurrentPosition(player, x,y);

    }
    public void Move(Player player, Map currentMap, int direction)
    {
        switch (direction)
        {
            case 8:
                if (player.PositionY == 0)
                {
                    player.PositionY++;
                    direction = 2;
                }
                else
                {
                    player.PositionY--;
                }
                break;
            case 6:
                if (player.PositionX == Config.Instance.MAP_SIZE[0] - 1)
                {
                    player.PositionX--;
                    direction = 4;
                }
                else
                {
                    player.PositionX++;
                }
                break;
            case 2:
                if (player.PositionY == Config.Instance.MAP_SIZE[1] - 1)
                {
                    player.PositionY--;
                    direction = 8;
                }
                else
                {
                    player.PositionY++;
                }
                break;
            case 4:
                if (player.PositionX == 0)
                {
                    player.PositionX++;
                    direction = 6;
                }
                else
                {
                    player.PositionX--;
                }
                break;
        }
        currentMap.setCurrentPosition(player, player.PositionX, player.PositionY);
    }
}