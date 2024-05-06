public class Game
{
    private bool state = true; // Booléen pour savoir si le jeu est en cours
    public List<Player> Players { get; set; }
    public List<Monster> Monsters { get; set; }
    public Island CurrentMap { get; set; }

    public Game()
    {
        // Init actors of the game
        Players = new List<Player>();
        Monsters = new List<Monster>();
        CurrentMap = new Island();

        // Local definitions for the game
        int tourNumber = 0;
        Player currentUser;

        // Game initialization
        this.Initialize();

        // Game loop
        while (state)
        {
            currentUser = Players![tourNumber % Players.Count];
            this.Tour(currentUser);
            tourNumber++;
        }
    }

    private void Initialize()
    {
        // Ajout des joueurs et des monstres
        Players.Add(new Player("Joueur 1", 1, CurrentMap));
        Players.Add(new Player("Joueur 2", 1, CurrentMap));

        Monsters.Add(new Monster("Monstre 1", CurrentMap));

        // Ajout des trésors avec des matcha froids (bonus)
        for (int i = 0; i < 5; i++)
        {
            List<Object> objects = new List<Object>();
            objects.Add(new ColdMatcha());
            objects.Add(new GoldTicket());
            CurrentMap.AddObject(new Tresor(objects));
        }

        // Ajout des trésors avec des matcha chauds (malus)
        for (int i = 0; i < 5; i++)
        {
            List<Object> objects = new List<Object>();
            objects.Add(new HotMatcha());
            objects.Add(new GoldTicket());
            CurrentMap.AddObject(new Tresor(objects));
        }
    }

    private void Tour(Player player)
    {
        CurrentMap.Render(Players, Monsters); // Affichage de la carte

        ConsoleKeyInfo keyInfo = Console.ReadKey(); // Lecture de la direction de déplacement

        Console.Clear(); // Efface la console avant d'afficher la carte mise à jour

        switch (keyInfo.Key)
        {
            case ConsoleKey.Q:
                player.Move(0, -1, CurrentMap); // Déplacement vers le haut
                break;
            case ConsoleKey.D:
                player.Move(0, 1, CurrentMap); // Déplacement vers le bas
                break;
            case ConsoleKey.Z:
                player.Move(-1, 0, CurrentMap); // Déplacement vers la gauche
                break;
            case ConsoleKey.S:
                player.Move(1, 0, CurrentMap); // Déplacement vers la droite
                break;
            case ConsoleKey.LeftArrow:
                player.Move(0, -1, CurrentMap); // Déplacement vers le haut
                break;
            case ConsoleKey.RightArrow:
                player.Move(0, 1, CurrentMap); // Déplacement vers le bas
                break;
            case ConsoleKey.UpArrow:
                player.Move(-1, 0, CurrentMap); // Déplacement vers la gauche
                break;
            case ConsoleKey.DownArrow:
                player.Move(1, 0, CurrentMap); // Déplacement vers la droite
                break;
            case ConsoleKey.Enter:
                player.Dig(CurrentMap); // Creuser
                break;
            case ConsoleKey.Escape:
                this.Pause(); // Mettre en pause le jeu
                break;
            case ConsoleKey.Spacebar:
                player.Drop(CurrentMap); // Lâcher un objet
                break;
            case ConsoleKey.A:
                Console.WriteLine("Attaque");
                // Player1.Attack(Player2); // Attaquer le joueur
                break;

        }
        // Monster1.Move(CurrentMap);
        player.DisplayUserState();
    }

    public void Pause()
    {
        Console.WriteLine("-----Appuyez sur une touche pour continuer... Appuyez sur Echap pour quitter.-----");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
            Environment.Exit(0);
    }
}