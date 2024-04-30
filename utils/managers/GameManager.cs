public class GameManager
{

    public GameManager()
    {
        Console.WriteLine("Game Manager initialized");
        Console.WriteLine("Game started");
        Sea sea = new Sea();
        sea.GenerateIslands();
        sea.PlaceBoat();
        sea.Render();

        Console.WriteLine("Land map generating");
        Land land = new Land();
        land.GenerateMountains();
        land.GenerateBoat();
        land.Render();

        Console.WriteLine("Pirate generating");
        Pirate pirate = new Pirate("Joe", 5, land);
        Console.WriteLine(pirate);
        land.SetCurrentPosition(pirate, 0);
        land.Render();

        Console.WriteLine("Monster generating");
        Monster monster = new Monster(land);
        land.PlaceMonster(monster, 0);
        land.Render();

        Console.WriteLine("Apples generating");
        Apple apple1 = new Apple(land);
        Apple apple2 = new Apple(land);
        land.PlaceObject(apple1);
        land.PlaceObject(apple2);
        land.Render();


        int direction;
        for (int i = 0; i < 20; i++)
        {
            direction = Convert.ToInt32(Console.ReadLine());
            monster.Move();
            pirate.Move(direction);
            // Console.Clear();
            land.Render();
            Console.WriteLine(pirate);

        }
        // pirate.Move(5);
        // Console.WriteLine(pirate);
        // land.Render();
        // this.Rules();
    }

    private void Rules()
    {
        Console.WriteLine("Vous pouvez choisir une ile parmis les trois iles (1-est, 2-sud, 3-nord)");
        switch (Convert.ToInt32(Console.ReadLine()!))
        {
            case 1:
                Console.WriteLine("est");
                break;
            case 2:
                Console.WriteLine("sud");
                break;
            case 3:
                Console.WriteLine("nord");
                break;
        }
    }
}