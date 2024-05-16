public class Potion : Object
{
    public Potion() : base('U', "Potion")
    {
        Gain = 10;
        Drinkable = true;
    }
    public Potion(char symb = 'U', string name = "Potion")
    : base(symb, name)
    {
        Gain = 10;
        Drinkable = true;
    }

    public override string ToString()
    {
        return $"Potion magique";
    }
}