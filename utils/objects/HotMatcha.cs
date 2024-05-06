public class HotMatcha : Object
{
    public int Damage { get; set; }

    public HotMatcha(char symb = 'U', string name = "HotMatchaLatte", int damage = 1)
    : base(symb, name)
    {
        Damage = damage;
    }

    public override string ToString()
    {
        return $"Matcha Latte au lait de coco chaud";
    }
}