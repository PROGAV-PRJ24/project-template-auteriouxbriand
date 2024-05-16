using System.ComponentModel.Design;

public class Game
{
    private enum PlayerType
    {
        Pirate = 1,
        Magicien = 2,
        Licorne = 3,
        JeanNorbert = 4,
        Bot = 1000,
    }
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

        // Launch the game
        this.PrintWelcomeMessage();
        this.PrintGameRules();

        int gameMode = this.getUserGamePreferences();

        int playerType;
        string playerName;
        switch (gameMode)
        {
            case 1:
                // Solo mode
                playerName = this.getPlayerName();
                playerType = this.getPlayerType();
                this.InitializePlayer(1, playerName, playerType);
                break;
            case 2:
                // Multiplayer mode
                string playerName1 = this.getPlayerName("Joueur 1");
                string playerName2 = this.getPlayerName("Joueur 2");
                int playerType1 = this.getPlayerType("Joueur 1");
                int playerType2 = this.getPlayerType("Joueur 2");
                this.InitializePlayers(2, playerName1, playerType1, playerName2, playerType2);
                break;
            case 3:
                // Multiplayer mode against a bot
                playerName = this.getPlayerName();
                playerType = this.getPlayerType();
                this.InitializePlayers(2, playerName, playerType, "Bot", 1000);
                break;
            default:
                Console.WriteLine("Aucun mode de jeu choisi, fin du jeu");
                System.Environment.Exit(0);
                break;
        }

        // Local definitions for the game
        int tourNumber = 0;
        Player currentUser;

        // Game loop
        while (state)
        {
            currentUser = Players![tourNumber % Players.Count];
            this.Tour(currentUser);
            tourNumber++;
        }
    }

    private void PrintWelcomeMessage()
    {
        Console.WriteLine(new string('-', 90));
        Console.WriteLine("Bienvenue dans le jeu de rôle");
        Console.WriteLine(new string('-', 90));
    }

    private void PrintGameRules()
    {
        Console.WriteLine("Règles du jeu :");
        Console.WriteLine(new string('-', 90));
        Console.WriteLine(new string('-', 90));
        Console.WriteLine("Vous êtes un aventurier sur une île remplie de monstres et de trésors.");
        Console.WriteLine("Votre objectif est de survivre le plus longtemps possible.");
        Console.WriteLine("Pour cela, vous pouvez vous déplacer, creuser, attaquer, manger, boire, lâcher des objets et attaquer les monstres.");
        Console.WriteLine("Vous pouvez également vous soigner en mangeant ou en buvant.");
        Console.WriteLine("Pour vous déplacer, utilisez les touches Z, Q, S et D.");
        Console.WriteLine("Pour creuser, appuyez sur Entrée.");
        Console.WriteLine("Pour attaquer, appuyez sur A.");
        Console.WriteLine("Pour lâcher un objet, appuyez sur Espace.");
        Console.WriteLine("Pour manger, appuyez sur M.");
        Console.WriteLine("Pour boire, appuyez sur B.");
        Console.WriteLine("Pour mettre en pause et accéder à nouveau aux règles et aux touches, appuyez sur Echap.");
        Console.WriteLine(new string('-', 90));
        Console.WriteLine(new string('-', 90));
        Console.WriteLine("Bonne chance !");
    }

    private int getUserGamePreferences()
    {
        Console.WriteLine("Choisissez le mode de jeu :");
        Console.WriteLine("1. Mode solo");
        Console.WriteLine("2. Mode multijoueur");
        Console.WriteLine("3. Mode multijoueur contre un bot");

        int gameMode = Convert.ToInt32(Console.ReadLine());
        return gameMode;
    }

    private string getPlayerName(string PlayerId = "Joueur 1")
    {
        Console.WriteLine("Entrez votre nom :");
        string playerName = Console.ReadLine()!;
        Console.WriteLine($"Vous avez choisi le nom {playerName} !");
        return playerName;
    }

    private int getPlayerType(string PlayerId = "Joueur 1")
    {
        Console.WriteLine("Choisissez votre type de joueur :");
        Console.WriteLine("1. Pirate");
        Console.WriteLine("2. Magicien");
        Console.WriteLine("3. Licorne");
        Console.WriteLine("4. Jean Norbert");

        int playerType = Convert.ToInt32(Console.ReadLine()!);
        return playerType;
    }
    private void InitializePlayer(int playersNumber = 1, string playerName1 = "Joueur 1", int playerType1 = 1)
    {
        PlayerType playerType = (PlayerType)playerType1;
        Type SelectedType = playerType switch
        {
            PlayerType.Pirate => typeof(Pirate),
            PlayerType.Magicien => typeof(Magicien),
            PlayerType.Licorne => typeof(Licorne),
            PlayerType.JeanNorbert => typeof(JeanNorbert),
            _ => typeof(Pirate),
        };
        // Ajout des joueurs et des monstres
        object player = Activator.CreateInstance(SelectedType, new object[] { playerName1, 1, CurrentMap })!;
        Players.Add((Player)player);

        this.Initialize();
    }

    private void InitializePlayers(int playersNumber = 1, string playerName1 = "Joueur 1", int playerType1 = 1, string playerName2 = "Joueur 2", int playerType2 = 1)
    {
        // Ajout des joueurs et des monstres
        Players.Add(new Player(playerName1, 1, CurrentMap));
        Players.Add(new Player(playerName2, 1, CurrentMap));

        this.Initialize();
    }
    private void Initialize()
    {
        for (int i = 0; i < 10; i++)
        {
            Monsters.Add(new Monster("Monstre" + i, CurrentMap));
        }

        for (int i = 0; i < 15; i++)
        {
            CurrentMap.AddObject();
        }
    }
    private void ConsoleKeyAction(Player player, ConsoleKeyInfo keyInfo)
    {
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
            case ConsoleKey.M:
                player.Eat();
                break;
            case ConsoleKey.B:
                player.Drink();
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
    }
    private void MonstersActions(Player player)
    {
        foreach (var monster in Monsters)
        {

            foreach (var user in Players)
            {
                player.Message += monster.Attack(user);
            }
            monster.Move(CurrentMap);

        }
    }
    private void Tour(Player player)
    {
        CurrentMap.Render(Players, Monsters); // Affichage de la carte

        ConsoleKeyInfo keyInfo = Console.ReadKey(); // Lecture de la direction de déplacement

        Console.Clear(); // Efface la console avant d'afficher la carte mise à jour

        this.ConsoleKeyAction(player, keyInfo); // Action du joueur
        this.MonstersActions(player); // Action des monstres

        player.DisplayUserState(); // Affichage de l'état du joueur
    }
    public void Pause()
    {
        Console.WriteLine("-----Appuyez sur une touche pour continuer... Appuyez sur Echap pour quitter.-----");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
            Environment.Exit(0);
    }
}