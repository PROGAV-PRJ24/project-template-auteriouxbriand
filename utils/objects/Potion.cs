public class Potion : Object
{
    public Potion() : base('U', "Potion")
    {
        Gain = 50;
    }
    public Potion(char symb = 'U', string name = "Potion")
    : base(symb, name)
    {
        Gain = 50;
    }

    public override string ToString()
    {
        return $"Potion magique";
    }
}