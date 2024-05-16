public abstract class Object
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int Gain { get; protected set; }
    public bool Eatable { get; protected set; }
    public bool Drinkable { get; protected set; }
    public int Depth { get; set; }
    public bool state = true; // Booléen pour savoir si l'objet est en jeu
    protected static Random rd = new Random();
    public Object(char symb, string name = "Object")
    {
        Name = name;
        Symbol = symb;
        Depth = new Random().Next(1, 9);
    }

    public virtual List<Object> Loot()
    {
        return new List<Object> { this };
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}