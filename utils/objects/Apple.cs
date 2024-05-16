public class Apple : Object
{
    public Apple() : base('a', "Apple")
    {
        Gain = 1;
        Eatable = true;
    }
    public Apple(char symb = 'a', string name = "Apple")
            : base(symb, name)
    {
        Gain = 1;
        Eatable = true;
    }
    public override string ToString()
    {
        return $"Une délicieuse pomme";
    }
}