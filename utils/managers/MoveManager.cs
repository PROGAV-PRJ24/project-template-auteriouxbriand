using System.Linq.Expressions;

public class MoveManager
{
    private Random rd = new Random();
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
                if (player.PositionX == 0)
                {
                    player.PositionX++;
                    direction = 2;
                    player.CurrentMap.SetCurrentPosition(player, direction);
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
                    player.CurrentMap.SetCurrentPosition(player, direction);


                }
                else
                {
                    player.PositionY++;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                break;
            case 2:
                if (player.PositionX == Config.Instance.LAND_MAP_SIZE[0] - 1)
                {
                    player.PositionX--;
                    direction = 8;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                else
                {
                    player.PositionX++;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                break;
            case 4:
                if (player.PositionY == 0)
                {
                    player.PositionY++;
                    direction = 6;
                    player.CurrentMap.SetCurrentPosition(player, direction);

                }
                else
                {
                    player.PositionY--;
                    player.CurrentMap.SetCurrentPosition(player, direction);
                }
                break;
        }
        player.Health--;
    }

    public void MoveMonster(Monster monster)
    {
        int[] directions = new int[] { 2, 4, 6, 8 };
        int indDir = rd.Next(0, 3);
        int direction = directions[indDir];
        switch (direction)
        {
            case 8:
                if (monster.PositionX == 0)
                {
                    monster.PositionX++;
                    direction = 2;
                    monster.CurrentMap.PlaceMonster(monster, direction);
                }
                else
                {
                    monster.PositionX--;
                    monster.CurrentMap.PlaceMonster(monster, direction);

                }
                break;
            case 6:
                if (monster.PositionY == Config.Instance.LAND_MAP_SIZE[1] - 1)
                {
                    monster.PositionY--;
                    direction = 4;
                    monster.CurrentMap.PlaceMonster(monster, direction);


                }
                else
                {
                    monster.PositionY++;
                    monster.CurrentMap.PlaceMonster(monster, direction);

                }
                break;
            case 2:
                if (monster.PositionX == Config.Instance.LAND_MAP_SIZE[0] - 1)
                {
                    monster.PositionX--;
                    direction = 8;
                    monster.CurrentMap.PlaceMonster(monster, direction);

                }
                else
                {
                    monster.PositionX++;
                    monster.CurrentMap.PlaceMonster(monster, direction);

                }
                break;
            case 4:
                if (monster.PositionY == 0)
                {
                    monster.PositionY++;
                    direction = 6;
                    monster.CurrentMap.PlaceMonster(monster, direction);

                }
                else
                {
                    monster.PositionY--;
                    monster.CurrentMap.PlaceMonster(monster, direction);
                }
                break;
        }

    }
}