using System.Reflection.Metadata.Ecma335;

public class Tresor
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int Depth { get; set; }
    public bool state = true; // Booléen pour savoir si le tresor est en jeu
    public List<Object?> Objects { get; set; }
    protected static Random rd = new Random();
    public Tresor(List<Object> objects, char symb = 'X', string name = "Trésor")
    {
        Objects = objects;
        Depth = rd.Next(0, 9);
        Name = name;
        Symbol = symb;
    }

    public override string ToString()
    {
        return $"{Name}(Depth: {Depth})";
    }
}