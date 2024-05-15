public class Apple : Object
{
    public Apple() : base('a', "Apple")
    {
        Gain = 1;
    }
    public Apple(char symb = 'a', string name = "Apple")
            : base(symb, name)
    {
        Gain = 1;
    }
    public override string ToString()
    {
        return $"Une délicieuse pomme";
    }
}