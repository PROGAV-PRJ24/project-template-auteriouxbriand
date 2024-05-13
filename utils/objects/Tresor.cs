public class Tresor : Object
{
    Randomizer Rand = new Randomizer();
    public List<Object> Loots { get; set; } = new List<Object>();

    public Tresor() : base('T', "Tresor")
    {
        GenerateLoots();
    }
    public Tresor(char symb = 'T', string name = "Trésor") : base(symb, name)
    {
        GenerateLoots();
    }
    private void GenerateLoots()
    {
        int nbLoots = rd.Next(1, 4);
        for (int i = 0; i < nbLoots; i++)
        {
            Loots.Add(Rand.Object(this));
        }
    }
    public override List<Object> Loot()
    {
        return Loots;
    }

}