public class Monster : Entity
{
    public int Level { get; set; } // Niveau du monstre

    // Constructeur de la classe Monster
    public Monster(string name, Island map, int level = 1, int x = 0, int y = 0) : base(name, map)
    {
        Level = level;
        Health = level * 10; // Santé du monstre en fonction de son niveau
        Damage = level * 2; // Dégâts infligés par le monstre en fonction de son niveau
        Spawn(map); // Positionner le monstre sur la carte
    }

    // Méthode pour attaquer un joueur
    public string Attack(Player player)
    {
        // Vérifier si le monstre et le joueur sont sur la même position
        if (player.PositionX == PositionX && player.PositionY == PositionY)
        {
            player.Health -= Damage; // Réduire la santé du joueur
            return $"\n {Name} attaque {player.Name} et lui inflige {Damage} points de dégâts";
        }
        return $"";
    }

    // Méthode pour déplacer le monstre sur la carte
    public void Move(Map map)
    {
        int x, y;
        do
        {
            x = PositionX + rd.Next(-1, 2); // Déplacer en x de manière aléatoire (-1, 0, 1)
            y = PositionY + rd.Next(-1, 2); // Déplacer en y de manière aléatoire (-1, 0, 1)
        } while (x >= 0 && x < map.Width && y >= 0 && y < map.Height && map.Grid[x, y] == '.'); // Vérifier que la nouvelle position est valide et n'est pas une cellule vide
        PositionX = x; // Mettre à jour la position x du monstre
        PositionY = y; // Mettre à jour la position y du monstre
    }
}
