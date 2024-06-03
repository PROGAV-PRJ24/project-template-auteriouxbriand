using System;
public class Tests
{
    public Tests()
    {
        try
        {
            // Test de la création d'une carte
            Island map = new Island();
            Console.WriteLine("Map created successfully.");

            // Test de la création d'un joueur
            Player player = new Player("Alice", 1, map);
            Console.WriteLine($"Player {player.Name} created successfully.");

            // Test du déplacement du joueur
            Console.WriteLine("Testing player movement:");
            player.Move(1, 0, map);
            Console.WriteLine($"Player moved to position ({player.PositionX}, {player.PositionY}).");

            // Test de la collecte d'un objet
            Apple obj = new Apple();
            map.AddObject(obj);
            Console.WriteLine($"Object {obj.Name} placed at position (2, 2).");
            player.Dig(map);
            Console.WriteLine($"Player's inventory after digging: {string.Join(", ", player.Inventory)}");

            // Test de l'affichage de l'état du joueur
            Console.WriteLine("Displaying player state:");
            player.DisplayUserState();

            // Test de l'attaque du joueur
            Console.WriteLine("Testing player attack:");
            Monster monster = new Monster("Monster", map);
            player.Attack(monster);
            Console.WriteLine($"Monster health after player attack: {monster.Health}");

            // Test de la mort du joueur
            Console.WriteLine("Testing player death:");
            player.Health = 0;
            Console.WriteLine($"Is player alive? {player.Alive}");

            // Test du respawn du joueur
            Console.WriteLine("Testing player respawn:");
            player.Respawn(map);
            Console.WriteLine($"Player respawned at position ({player.PositionX}, {player.PositionY}).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
