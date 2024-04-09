public class MoveManager
{
    public void Jump(Player player, int x, int y)
    {
        if (x >= 0 && x < Config.Instance.MAP_SIZE[0] && y >= 0 && y < Config.Instance.MAP_SIZE[1])
        {
            player.positionX = x;
            player.positionY = y;
        }
    }
    public void Move(Player player, int direction)
    {
        switch (direction)
        {
            case 8:
                if(positionY == 0)
                {
                    positionY++;
                    direction = 2;
                }
                else
                {
                    positionY--;
                }
                break;
            case 6:
                if(positionX == Config.Instance.MAP_SIZE[0])
                {
                    positionX--;
                    direction = 4;
                }
                else
                {
                    positionX++;
                }
                break;
            case 2:
                if(positionY == Config.Instance.MAP_SIZE[1])
                {
                    positionY--;
                    direction = 8;
                }
                else
                {
                    positionY++;
                }
            case 4:
                if(positionX == 0)
                {
                    positionX++;
                    direction = 6;
                }
                else
                {
                    positionX--;
                }
                break;
        }
    }
}