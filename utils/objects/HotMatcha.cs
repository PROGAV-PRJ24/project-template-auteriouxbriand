public class HotMatcha : Object
{
    public HotMatcha() : base('U', "HotMatchaLatte")
    {
        Gain = -40 / 100;
        Drinkable = true;
    }
    public HotMatcha(char symb = 'U', string name = "HotMatchaLatte", int temperature = 40)
    : base(symb, name)
    {
        Gain = -temperature / 100;
        Drinkable = true;
    }

    public override string ToString()
    {
        return $"Matcha Latte au lait de coco chaud";
    }
}