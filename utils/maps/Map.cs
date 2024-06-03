// Classe abstraite Map, qui représente une carte de jeu.
public abstract class Map
{
    // Propriété protégée représentant les dimensions de la carte (largeur et hauteur).
    protected int[] Dimensions { get; set; }

    // Propriété publique représentant la largeur de la carte.
    public int Width { get; set; }

    // Propriété publique représentant la hauteur de la carte.
    public int Height { get; set; }

    // Propriété publique représentant la grille de la carte, un tableau 2D de caractères.
    public char[,] Grid { get; set; }

    // Générateur de nombres aléatoires partagé par toutes les instances de la classe.
    protected static Random rd = new Random();

    // Constructeur de la classe Map.
    public Map()
    {
        // Initialise les dimensions de la carte en utilisant les valeurs de configuration globales.
        this.Dimensions = Config.Instance.LAND_MAP_SIZE;

        // Initialise la grille avec des dimensions basées sur les propriétés Height et Width.
        this.Grid = new char[Height, Width];
    }

    // Méthode publique pour construire un bateau sur la carte.
    public void BuildBoat()
    {
        // Position de départ du bateau.
        int startX = 0;
        int startY = 0;

        // Boucles imbriquées pour remplir une zone de 3x3 avec le caractère 'b' représentant un bateau.
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Grid[startX + i, startY + j] = 'b';
            }
        }
    }

    // Méthode virtuelle pour rendre la carte, qui peut être redéfinie par les classes dérivées.
    // Elle prend en paramètre une liste de joueurs et une liste de monstres.
    public virtual void Render(List<Player> players, List<Monster> monster) { }
}
