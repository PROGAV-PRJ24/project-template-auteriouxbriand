public class InteractionManager
{
    public void Eat(Player player, List<Object> food)
    {
        foreach (var item in food)
        {
            if (player.PositionX == item.PositionX && player.PositionY == item.PositionY)
            {
                player.Health = player.Health + item.Benefit;
            }
        }
    }
}