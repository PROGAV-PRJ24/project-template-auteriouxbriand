public abstract class Object
{
    // Propriétés de la classe Object
    public string Name { get; set; } // Nom de l'objet
    public char Symbol { get; set; } // Symbole représentant l'objet
    public int Gain { get; protected set; } // Gain associé à l'objet
    public bool Eatable { get; protected set; } // Indique si l'objet est comestible
    public bool Drinkable { get; protected set; } // Indique si l'objet est buvable
    public int Depth { get; set; } // Profondeur à laquelle l'objet se trouve
    public bool state = true; // Booléen pour savoir si l'objet est en jeu
    protected static Random rd = new Random(); // Générateur de nombres aléatoires

    // Constructeur de la classe Object
    public Object(char symb, string name = "Object")
    {
        Name = name; // Assigne le nom de l'objet
        Symbol = symb; // Assigne le symbole de l'objet
        Depth = new Random().Next(1, 9); // Assigne une profondeur aléatoire entre 1 et 8
    }

    // Méthode virtuelle pour obtenir le butin de l'objet
    public virtual List<Object> Loot()
    {
        return new List<Object> { this }; // Retourne l'objet lui-même comme butin
    }

    // Méthode override pour obtenir la représentation en chaîne de caractères de l'objet
    public override string ToString()
    {
        return $"{Name}"; // Retourne le nom de l'objet
    }
}
