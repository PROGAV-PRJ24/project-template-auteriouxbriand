using System.Security.Cryptography.X509Certificates;

public class Game
{
    private bool state = true; // Booléen pour savoir si le jeu est en cours
                               // Création de la carte
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public IslandView CurrentMap { get; set; }
    public Game()
    {  
        this.Initialize();
        
        while (state)
        {   
            this.Tour();
        }
    }

    private void Initialize()
    {
        CurrentMap = new IslandView();
        this.Player1 = new Player("Joueur 1", 1, CurrentMap);
        
        for (int i = 0; i < 10; i++)
        {
            CurrentMap.AddObject(new Object('X', "Trésor"));
        }
        
    }

    private void Tour()
    {  
        CurrentMap.Render(Player1); // Affichage de la carte
        Player1.DisplayUserState(); // Affichage de l'état du joueur
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(); // Lecture de la direction de déplacement

        Console.Clear(); // Efface la console avant d'afficher la carte mise à jour

        switch (keyInfo.Key)
        {
            case ConsoleKey.Q:
                Player1.Move(0, -1, CurrentMap); // Déplacement vers le haut
                break;
            case ConsoleKey.D:
                Player1.Move(0, 1, CurrentMap); // Déplacement vers le bas
                break;
            case ConsoleKey.Z:
                Player1.Move(-1, 0, CurrentMap); // Déplacement vers la gauche
                break;
            case ConsoleKey.S:
                Player1.Move(1, 0, CurrentMap); // Déplacement vers la droite
                break;
            case ConsoleKey.Enter:
                Player1.Dig(CurrentMap); // Creuser
                break;
            case ConsoleKey.Escape:
                this.Pause(); // Mettre en pause le jeu
                break;
        }

        

    }

    public void Pause()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer... Appuyez sur Echap pour quitter.");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
            Environment.Exit(0);
    }
}