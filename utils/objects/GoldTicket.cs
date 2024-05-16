public class GoldTicket : Object
{

    public GoldTicket() : base('X', "GoldTicket")
    {
        this.Gain = rd.Next(1, 10);
    }
    public GoldTicket(char symb = 'X', string name = "GoldTicket")
    : base(symb, name)
    {
        this.Gain = rd.Next(1, 10);
    }
    public override string ToString()
    {
        return $"Gold ticket";
    }
}