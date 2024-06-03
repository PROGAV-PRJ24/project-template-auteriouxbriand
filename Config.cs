public class Config
{
    // Propriété publique représentant la taille de la carte du jeu. 
    // Elle est initialisée avec un tableau contenant deux valeurs : 30 pour la largeur et 30 pour la hauteur.
    public int[] LAND_MAP_SIZE { get; set; } = { 30, 30 };

    // Variable privée et statique de type Config. 
    // Elle va contenir l'instance unique de la classe Config (implémentation du pattern Singleton).
    private static Config? instance = null;

    // Propriété publique et statique permettant d'accéder à l'instance unique de Config.
    public static Config Instance
    {
        get
        {
            // Si l'instance n'existe pas encore, on la crée.
            if (instance == null)
            {
                instance = new Config();
            }
            // Retourne l'instance unique de Config.
            return instance;
        }
    }
}
