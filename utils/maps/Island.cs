public class Island : Map
{
    Randomizer Rand = new Randomizer(); // Initialiser un générateur d'objets aléatoires
    public List<List<Object>> Objects { get; set; } // Liste d'objets sur l'île

    // Propriété pour vérifier si l'île est vide (toutes les cellules sont null)
    public bool isEmpty
    {
        get
        {
            return Objects.TrueForAll(row => row.TrueForAll(cell => cell == null));
        }
    }

    // Constructeur de la classe Island
    public Island() : base()
    {
        // Définition de la configuration
        this.Dimensions = Config.Instance.LAND_MAP_SIZE;
        this.Height = Dimensions[0];
        this.Width = Dimensions[1];

        // Définition de la grille
        this.Grid = new char[Height, Width];
        this.Objects = new List<List<Object>>();
        for (int i = 0; i < Height; i++)
        {
            List<Object> row = new List<Object>();
            for (int j = 0; j < Width; j++)
            {
                row.Add(null!); // Ajouter des objets null pour chaque cellule
            }
            Objects.Add(row);
        }

        // Remplissage de la carte avec des cellules vides
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                Grid[i, j] = '.';

        this.BuildGridTerrain(5); // Générer 5 îles
        this.BuildBoat(); // Générer un bateau
    }

    // Méthode pour construire le terrain de la grille
    private void BuildGridTerrain(int numIslands)
    {
        Random rand = new Random();

        for (int i = 0; i < numIslands; i++)
        {
            int centerX = rand.Next(5, Width - 5); // Position aléatoire en x pour le centre de l'île
            int centerY = rand.Next(5, Height - 5); // Position aléatoire en y pour le centre de l'île

            int radius = rand.Next(3, 8); // Rayon aléatoire pour l'île

            for (int y = centerY - radius; y <= centerY + radius; y++)
            {
                for (int x = centerX - radius; x <= centerX + radius; x++)
                {
                    if (x >= 0 && x < Width && y >= 0 && y < Height)
                    {
                        double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
                        if (distance <= radius)
                        {
                            Grid[x, y] = '#'; // Remplir la zone de l'île avec des #
                        }
                    }
                }
            }
        }
    }

    // Méthode pour ajouter un objet à une position aléatoire sur la carte
    public void AddObject()
    {
        int x, y;
        do
        {
            x = rd.Next(0, Width);
            y = rd.Next(0, Height);
        }
        while (Grid[x, y] == '.' || Grid[x, y] == 'b'); // Trouver une position qui n'est ni vide ni un bateau
        Objects[x][y] = Rand.Object(); // Ajouter un objet généré aléatoirement
    }

    // Surcharge de la méthode AddObject pour ajouter un objet spécifique
    public void AddObject(Object obj)
    {
        int x, y;
        do
        {
            x = rd.Next(0, Width);
            y = rd.Next(0, Height);
        }
        while (Grid[x, y] == '.' || Grid[x, y] == 'b'); // Trouver une position qui n'est ni vide ni un bateau
        Objects[x][y] = obj; // Ajouter l'objet spécifique
    }

    // Méthode pour retirer un objet de la carte
    public void RemoveObject(int x, int y)
    {
        if (Objects[x][y] != null)
            Objects[x][y].state = false; // Marquer l'objet comme inactif
    }

    // Méthode pour afficher la carte avec les joueurs et les monstres
    public override void Render(List<Player> players, List<Monster> monsters)
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                bool playerFound = false;
                foreach (var player in players)
                {
                    if (player.PositionX == i && player.PositionY == j)
                    {
                        Console.BackgroundColor = player.Color;
                        Console.Write($" {player.Symbol} "); // Afficher le joueur
                        Console.ResetColor();
                        playerFound = true;
                        break;
                    }
                }
                if (!playerFound)
                {
                    bool monsterFound = false;
                    foreach (var monster in monsters)
                    {
                        if (monster.PositionX == i && monster.PositionY == j && monster.Alive)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" M "); // Afficher le monstre
                            Console.ResetColor();
                            monsterFound = true;
                            break;
                        }
                    }
                    if (!monsterFound)
                    {
                        if (Grid[i, j] == 'b')
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" + "); // Afficher le bateau
                            Console.ResetColor();
                        }
                        else if (Objects[i][j] != null && Objects[i][j].state)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(" X "); // Afficher l'objet
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = Grid[i, j] == '.' ? ConsoleColor.Cyan : (Grid[i, j] == '#' ? ConsoleColor.Yellow : ConsoleColor.Black);
                            Console.Write(" " + Grid[i, j] + " "); // Afficher la carte
                            Console.ResetColor();
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
