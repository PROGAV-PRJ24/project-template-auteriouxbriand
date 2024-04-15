public class Poulpe : Player
{
    private int Tentacles { get; set; }
    private int Hearts { get; set; }

    new public int Health
    {
        get
        {
            return Health;
        }
        set
        {
            if (Hearts == 0)
            {
                IsAlive = false;
            }
            else
            {
                if (value < Health)
                {
                    Hearts--;
                }
                Health = value;
            }
        }
    }

    public Poulpe(string name, int level, Map currentMap) : base(name, level, currentMap)
    {
        Representer = 'J';
        Hearts = 3;
    }

}