public abstract class Entity
{
    // Utilitaires
    protected static Random rd = new Random(); // Générateur de nombres aléatoires

    // Identité
    public string Name { get; set; } // Nom de l'entité
    public ConsoleColor Color { get; set; } // Couleur de l'entité
    public char Symbol { get; set; } // Symbole représentant l'entité

    // Statistiques
    public int Damage { get; set; } // Dommages infligés par l'entité
    protected double _health; // Santé de l'entité
    public double Health
    {
        get { return _health; } // Accès à la santé de l'entité
        set { _health = value; Alive = _health > 0; } // Mise à jour de la santé et du statut de vie de l'entité
    }
    public bool Alive { get; set; } // Statut de vie de l'entité

    // Position
    public int PositionX { get; protected set; } // Position en X de l'entité
    public int PositionY { get; protected set; } // Position en Y de l'entité

    // Constructeur de la classe Entity
    public Entity(string name, Island map)
    {
        Name = name; // Assigner le nom de l'entité
        Alive = true; // Définir l'entité comme vivante
        Spawn(map); // Positionner l'entité sur la carte
    }

    // Méthode protégée pour positionner l'entité sur la carte
    protected virtual void Spawn(Map map)
    {
        Random rand = new Random(); // Générateur de nombres aléatoires
        int x = rand.Next(0, map.Width); // Position aléatoire en X
        int y = rand.Next(0, map.Height); // Position aléatoire en Y

        // Tant que la position n'est pas sur une case d'île
        while (map.Grid[x, y] != '#')
        {
            x = rand.Next(0, map.Width); // Nouvelle position aléatoire en X
            y = rand.Next(0, map.Height); // Nouvelle position aléatoire en Y
        }

        PositionX = x; // Assigner la position en X
        PositionY = y; // Assigner la position en Y
    }

    // Méthode pour vérifier si un joueur est à proximité de l'entité dans une certaine distance
    public bool isNearby(Player player, int distance)
    {
        // Vérifier si la différence en X et en Y entre l'entité et le joueur est inférieure ou égale à la distance spécifiée
        return Math.Abs(player.PositionX - this.PositionX) <= distance && Math.Abs(player.PositionY - this.PositionY) <= distance;
    }
}
