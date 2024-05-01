public class Object
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int Depth { get; set; }
    public bool state = true; // Booléen pour savoir si l'objet est en jeu
    protected static Random rd = new Random();
    public Object(char symb, string name = "Object")
    {   
        Name = name;
        Depth = rd.Next(0,9);
        Symbol = symb;
    }

    public override string ToString()
    {
        return $"{Name}(Depth: {Depth})";
    }
}