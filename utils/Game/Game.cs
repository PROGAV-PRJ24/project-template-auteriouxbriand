public class Game
{
    // Déclaration d'une énumération pour les types de joueurs avec leurs valeurs respectives
    private enum PlayerType
    {
        Pirate = 1,
        Magicien = 2,
        Licorne = 3,
        JeanNorbert = 4,
        Bot = 1000,
    }

    // Booléen pour savoir si le jeu est en cours
    private bool state = true;

    // Listes des joueurs et des monstres
    public List<Player> Players { get; set; }
    public List<Monster> Monsters { get; set; }

    // Carte actuelle du jeu
    public Island CurrentMap { get; set; }

    // Constructeur de la classe Game
    public Game()
    {
        // Initialisation des joueurs, des monstres et de la carte
        Players = new List<Player>();
        Monsters = new List<Monster>();
        CurrentMap = new Island();

        // Lancement du jeu
        this.PrintWelcomeMessage();
        this.PrintGameRules();

        // Récupération des préférences de jeu de l'utilisateur
        int gameMode = this.getUserGamePreferences();

        int playerType;
        string playerName;

        // Sélection du mode de jeu
        switch (gameMode)
        {
            case 1:
                // Mode solo
                playerName = this.getPlayerName();
                playerType = this.getPlayerType();
                this.InitializePlayer(1, playerName, playerType);
                break;
            case 2:
                // Mode multijoueur
                string playerName1 = this.getPlayerName("Joueur 1");
                string playerName2 = this.getPlayerName("Joueur 2");
                int playerType1 = this.getPlayerType("Joueur 1");
                int playerType2 = this.getPlayerType("Joueur 2");
                this.InitializePlayers(2, playerName1, playerType1, playerName2, playerType2);
                break;
            case 3:
                // Mode multijoueur contre un bot
                playerName = this.getPlayerName();
                playerType = this.getPlayerType();
                this.InitializePlayers(2, playerName, playerType, "Bot", 1000);
                break;
            default:
                // Si aucun mode de jeu n'est choisi, le jeu se termine
                Console.WriteLine("Aucun mode de jeu choisi, fin du jeu");
                System.Environment.Exit(0);
                break;
        }

        // Définition locale pour la boucle de jeu
        int tourNumber = 0;
        Player currentUser;

        // Boucle de jeu principale
        while (state || CurrentMap.isEmpty)
        {
            // Détermine le joueur actuel en fonction du numéro du tour
            currentUser = Players![tourNumber % Players.Count];
            this.Tour(currentUser);
            tourNumber++;
            if (currentUser.Alive == false)
            {
                // Si le joueur actuel est mort, le jeu se termine
                Console.WriteLine($"{currentUser.Name} perd cette partie !");
                state = false;
                EndGame();
            }
            else if (currentUser.Winner)
            {
                // Si le joueur actuel a gagné, le jeu se termine
                Console.WriteLine($"{currentUser.Name} a gagné cette partie avec un score de {currentUser.Score} !");
                state = false;
                EndGame();
            }
        }
    }

    // Affiche le message de bienvenue
    private void PrintWelcomeMessage()
    {
        Console.WriteLine(new string('-', 90));
        Console.WriteLine("Bienvenue dans le jeu HILE");
        Console.WriteLine(new string('-', 90));
    }

    // Affiche les règles du jeu
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

    // Récupère les préférences de jeu de l'utilisateur
    private int getUserGamePreferences()
    {
        Console.WriteLine("Choisissez le mode de jeu :");
        Console.WriteLine("1. Mode solo");
        Console.WriteLine("2. Mode multijoueur");
        Console.WriteLine("3. Mode multijoueur contre un bot");

        try
        {
            int gameMode = Convert.ToInt32(Console.ReadLine()!);
            return gameMode;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erreur lors de la saisie du mode de jeu" + e.Message);
            Console.Clear();
            new Game();
            return 0;
        }
    }

    // Récupère le nom du joueur
    private string getPlayerName(string PlayerId = "Joueur 1")
    {
        Console.WriteLine("Entrez votre nom :");
        string playerName = Console.ReadLine()!;
        Console.WriteLine($"Vous avez choisi le nom {playerName} !");
        return playerName;
    }

    // Récupère le type de joueur
    private int getPlayerType(string PlayerId = "Joueur 1")
    {
        Console.WriteLine("Choisissez votre type de joueur :");
        Console.WriteLine("1. Pirate");
        Console.WriteLine("2. Magicien");
        Console.WriteLine("3. Licorne");
        Console.WriteLine("4. Jean Norbert");

        try
        {
            int playerType = Convert.ToInt32(Console.ReadLine()!);
            return playerType;
        }
        catch (Exception e)
        {
            Console.WriteLine("Erreur lors de la saisie du type de joueur", e.Message);
            Console.Clear();
            new Game();
            return 0;
        }
    }

    // Initialise un joueur
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
        // Ajout du joueur à la liste des joueurs
        object player = Activator.CreateInstance(SelectedType, new object[] { playerName1, 1, CurrentMap })!;
        Players.Add((Player)player);

        this.Initialize();
    }

    // Initialise plusieurs joueurs
    private void InitializePlayers(int playersNumber = 2, string playerName1 = "Joueur 1", int playerType1 = 1, string playerName2 = "Joueur 2", int playerType2 = 1000)
    {
        PlayerType firstplayerType = (PlayerType)playerType1;
        PlayerType secondplayerType = (PlayerType)playerType2;

        Type SelectedType = firstplayerType switch
        {
            PlayerType.Pirate => typeof(Pirate),
            PlayerType.Magicien => typeof(Magicien),
            PlayerType.Licorne => typeof(Licorne),
            PlayerType.JeanNorbert => typeof(JeanNorbert),
            PlayerType.Bot => typeof(Bot),
            _ => typeof(Bot),
        };
        // Ajout du premier joueur à la liste des joueurs
        object player1 = Activator.CreateInstance(SelectedType, new object[] { playerName1, 1, CurrentMap })!;
        Players.Add((Player)player1);

        SelectedType = secondplayerType switch
        {
            PlayerType.Pirate => typeof(Pirate),
            PlayerType.Magicien => typeof(Magicien),
            PlayerType.Licorne => typeof(Licorne),
            PlayerType.JeanNorbert => typeof(JeanNorbert),
            _ => typeof(Bot),
        };
        // Ajout du deuxième joueur à la liste des joueurs
        object player2 = Activator.CreateInstance(SelectedType, new object[] { playerName2, 1, CurrentMap })!;
        Players.Add((Player)player2);

        this.Initialize();
    }

    // Initialisation des monstres et des objets sur la carte
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
        CurrentMap.AddObject(new Book("Cognitique: Science et pratique des relations à la machine à penser"));
    }

    // Gère les actions du joueur en fonction des touches appuyées
    private void ConsoleKeyAction(Player player, ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Q:
                player.Move(0, -1, CurrentMap); // Déplacement vers la gauche
                break;
            case ConsoleKey.D:
                player.Move(0, 1, CurrentMap); // Déplacement vers la droite
                break;
            case ConsoleKey.Z:
                player.Move(-1, 0, CurrentMap); // Déplacement vers le haut
                break;
            case ConsoleKey.S:
                player.Move(1, 0, CurrentMap); // Déplacement vers le bas
                break;
            case ConsoleKey.LeftArrow:
                player.Move(0, -1, CurrentMap); // Déplacement vers la gauche
                break;
            case ConsoleKey.RightArrow:
                player.Move(0, 1, CurrentMap); // Déplacement vers la droite
                break;
            case ConsoleKey.UpArrow:
                player.Move(-1, 0, CurrentMap); // Déplacement vers le haut
                break;
            case ConsoleKey.DownArrow:
                player.Move(1, 0, CurrentMap); // Déplacement vers le bas
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
                this.ManageAttack(player);
                break;
        }
    }

    // Gère les attaques du joueur
    private void ManageAttack(Player player)
    {
        bool hasAttacked = false;
        Monster? affectedMonster = null;

        // Attaque le joueur adverse si en mode multijoueur
        if (this.Players.Count != 1)
        {
            if (Players[0] == player)
                player.Attack(Players[1]); // Attaque le joueur 2 si le joueur 1 est le joueur actuel
            else
                player.Attack(Players[0]); // Attaque le joueur 1 si le joueur actuel est le joueur 2
        }

        // Attaque les monstres à proximité
        foreach (var monster in Monsters)
        {
            if (monster.isNearby(player, player.Spread) && monster.Alive)
            {
                player.Attack(monster);
                hasAttacked = true;
                affectedMonster = monster;
                break;
            }
        }
        player.Message += (hasAttacked) ? $"\n Vous avez attaqué le monstre {affectedMonster}, il lui reste {affectedMonster!.Health}" : "\n Aucun monstre à attaquer";
    }

    // Gère les actions des monstres
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

    // Tour de jeu d'un joueur
    private void Tour(Player player)
    {
        CurrentMap.Render(Players, Monsters); // Affichage de la carte

        ConsoleKeyInfo keyInfo = Console.ReadKey(); // Lecture de la direction de déplacement
        Console.Clear(); // Efface la console avant d'afficher la carte mise à jour

        if (player.GetType() == typeof(Bot))
            ((Bot)player).Move(CurrentMap);
        else
            this.ConsoleKeyAction(player, keyInfo); // Action du joueur

        this.MonstersActions(player); // Action des monstres

        player.Mana++; // Régénération de la mana du joueur
        player.DisplayUserState(); // Affichage de l'état du joueur
    }

    // Met le jeu en pause
    public void Pause()
    {
        Console.WriteLine("-----Appuyez sur une touche pour continuer... Appuyez sur Echap pour quitter.-----");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
            Environment.Exit(0);
    }

    // Termine le jeu
    public void EndGame()
    {
        Console.WriteLine("Fin du jeu");
        Console.WriteLine(new string('-', 90));
        Console.WriteLine("Merci d'avoir joué !");
        Console.WriteLine("Appuyez sur R pour rejouer ou sur une autre touche pour quitter.");
        if (Console.ReadKey().Key != ConsoleKey.R)
        {
            Environment.Exit(0);
        }
        Console.Clear();
        new Game();
    }
}
