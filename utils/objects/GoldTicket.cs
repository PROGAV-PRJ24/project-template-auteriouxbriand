public class GoldTicket : Object
{
    public int Value { get; private set; }

    public GoldTicket(char symb = 'X', string name = "GoldTicket")
    : base(symb, name)
    {
        Value = rd.Next(1, 10);
    }
    public override string ToString()
    {
        return $"Ticket d'or qui vaut super cher";
    }
}