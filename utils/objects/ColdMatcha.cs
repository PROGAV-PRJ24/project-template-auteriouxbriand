public class ColdMatcha : Object
{
    public ColdMatcha() : base('U', "ColdMatchaLatte")
    {
        Gain = 10;
        Drinkable = true;
    }
    public ColdMatcha(char symb = 'U', string name = "ColdMatchaLatte")
            : base(symb, name)
    {
        Gain = 10;
        Drinkable = true;
    }
    public override string ToString()
    {
        return $"Matcha Latte au lait de coco froid";
    }
}