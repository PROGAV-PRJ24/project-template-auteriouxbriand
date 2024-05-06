public class ColdMatcha : Object
{
    public int Gain { get; set; }
    public ColdMatcha(char symb = 'U', string name = "ColdMatchaLatte", int gain = 1)
    : base(symb, name)
    {
        Gain = gain;
    }
    public override string ToString()
    {
        return $"Matcha Latte au lait de coco froid";
    }
}