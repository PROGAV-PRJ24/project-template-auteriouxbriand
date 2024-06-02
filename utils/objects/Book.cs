public class Book : Object
{
    public string Title;
    public Book() : base('B', "Livre")
    {
        Title = "Le livre des pirates";
        Gain = 3;
    }
    public Book(String title = "Le livre des pirates") : base('B', "Livre")
    {
        Title = title;
        Gain = 3;
    }

    public override string ToString()
    {
        return $"Livre de pirate";
    }
}