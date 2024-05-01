using System.Security.AccessControl;

public class Player
{

    public string Name { get; set; }

    public int Level { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Mana { get; set; }
    public double Protection { get; set; }

    public double Energy { get; set; }

    public int DiggedValue { get; set; }


    public int PositionX { get; private set; }
    public int PositionY { get; private set; }

    public List<Object> Inventory { get; set; }

    public string Message { get; set; }

    public bool IsAlive
    {
        get
        {
            return Health > 0;
        }
        set
        {

        }
    }

    public Player(string name, int level, Map map, int x = 0, int y = 0)
    {
        Message = "";

        this.Spawn(map);

        Name = name;
        Level = level;
        Health = level * 10;
        Mana = level * 5;
        Energy = level * 5;
        Protection = 0;
        Damage = level * 2;
        Inventory = new List<Object>();

    }

    private void Spawn(Map map)
    {
        Health -= 1;
        Energy = Level * 5;
        Mana = Level * 5;
        Random rand = new Random();
        int x = rand.Next(0, map.Width);
        int y = rand.Next(0, map.Height);

        while (map.Grid[x, y] != '#')
        {
            x = rand.Next(0, map.Width);
            y = rand.Next(0, map.Height);
        }

        PositionX = x;
        PositionY = y;
    }

    public void LevelUp()
    {
        Level++;
        Health += 10;
        Mana += 5;
        Damage += 2;
    }

    public void Attack(Player target)
    {
        target.Health -= Damage;
    }

    public void Dig(IslandView map)
    {
        if (Energy <= 0)
        {
            Message = "Vous n'avez plus d'énergie pour creuser";
            return;
        }
        if (map.Objects[PositionX, PositionY] != null && map.Objects[PositionX, PositionY].state == true)
        {
            Message = "Vous creusez à la profondeur: " + DiggedValue;
            DiggedValue += 1;
            Energy -= 0.05;
            if (DiggedValue == map.Objects[PositionX, PositionY].Depth)
            {
                if(Inventory.Count < 3)
                {
                    Inventory.Add(map.Objects[PositionX, PositionY]);
                    Message = "Vous avez trouvé l'objet: " + map.Objects[PositionX, PositionY];
                }
                else
                {
                    Message = "Votre inventaire est plein, vous ne pouvez pas ramasser l'objet: " + map.Objects[PositionX, PositionY] + ". Il reste en surface. Videz votre inventaire sur le bateau.";
                    map.Objects[PositionX, PositionY].Depth = 0;
                }
                map.RemoveObject(PositionX, PositionY);
                DiggedValue = 0;
            }

        }
        else
        {
            Message = "Il n'y a rien à creuser ici";
        }
    }
    public void Move(int dx, int dy, Map map)
    {
        if (Energy <= 0)
        {
            Message = "Vous n'avez plus d'énergie pour vous déplacer, vous vous noyez, vous perdez 1 point de vie";
            this.Spawn(map);
            return;
        }
        int newX = PositionX + dx;
        int newY = PositionY + dy;

        // Vérifie si la nouvelle position est valide et ne contient pas d'obstacle
        if (newX >= 0 && newX < map.Height && newY >= 0 && newY < map.Width)
        {
            PositionX = newX;
            PositionY = newY;
            if (map.Grid[newX, newY] != '#')
            {
                Energy -= 0.5;
            }
        }
        DiggedValue = 0;
    }

    public void DisplayUserState()
    {
        Console.WriteLine(new string('-', 90));
        Console.WriteLine(new string('-', 90));

        if (Message != "")
        {   

                Console.WriteLine("Info :  " + Message);
                Console.WriteLine(new string('-', 90));
                Message="";
        }

        Console.WriteLine("Joueur: " + Name);
        Console.WriteLine("Niveau: " + Level);
        Console.WriteLine("Santé: " + Health);
        Console.WriteLine("Mana: " + Mana);
        Console.WriteLine("Energie: " + Energy);


        Console.Write("Inventaire: : ");
        foreach (Object obj in Inventory)
        {
            Console.Write($"- [{obj}]  ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 90));
        Console.WriteLine(new string('-', 90));
    }

}