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
        this.Initialize(1);

        // Game loop
        while (state)
        {
            currentUser = Players![tourNumber % Players.Count];
            this.Tour(currentUser);
            tourNumber++;
        }
    }

    private void Initialize(int playersNumber = 1)
    {
        // Ajout des joueurs et des monstres
        for (int i = 0; i < playersNumber; i++)
        {
            Players.Add(new Player("Joueur " + i, 1, CurrentMap));
        }

        Monsters.Add(new Monster("Monstre 1", CurrentMap));
        Monsters.Add(new Monster("Monstre 2", CurrentMap));

        for (int i = 0; i < 10; i++)
        {
            CurrentMap.AddObject();
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
                bool hasAttacked = false;
                Monster? affectedMonster = null;
                if (this.Players.Count != 1)
                {
                    if (Players[0] == player)
                        player.Attack(Players[1]); // Attaque le joueur 2 si le joueur 1 est le joueur actuel
                    else
                        player.Attack(Players[0]); // Attaque le joueur 1
                }
                foreach (var monster in Monsters)
                {
                    if (monster.isNearby(player, 2)) // Attaque les monstres présent dans une zone de 2 cases
                    {
                        player.Attack(monster);
                        hasAttacked = true;
                        affectedMonster = monster;
                        break;
                    }
                }
                player.Message = (hasAttacked) ? $"Vous avez attaqué le monstre {affectedMonster}, il lui reste {affectedMonster!.Health}" : "Aucun monstre à attaquer";
                break;

        }
        foreach (var monster in Monsters)
        {

            foreach (var user in Players)
            {
                player.Message += monster.Attack(user);
            }
            monster.Move(CurrentMap);

        }
        player.DisplayUserState();
    }

    public void Pause()
    {
        Console.WriteLine("-----Appuyez sur une touche pour continuer... Appuyez sur Echap pour quitter.-----");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
            Environment.Exit(0);
    }
}