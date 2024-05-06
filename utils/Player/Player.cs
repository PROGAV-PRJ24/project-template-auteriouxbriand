
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

    public int Score { get; set; }

    public int PositionX { get; private set; }
    public int PositionY { get; private set; }

    public List<Object> Inventory { get; set; }

    public List<Object> Chest { get; set; }

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
        Chest = new List<Object>();

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
        if (target.PositionX == this.PositionX + 1 || target.PositionX == this.PositionX - 1 || target.PositionY == this.PositionY + 1 || target.PositionY == this.PositionY - 1)
        {
            target.Health -= Damage;
            Message = "Vous avez attaqué enlevé " + Damage + " points de vie à " + target.Name;
        }
        else
        {
            Message = "La cible est trop loin pour être attaquée";
        }
    }
    public void Attack(Monster monster)
    {
        if (monster.PositionX == this.PositionX + 1 || monster.PositionX == this.PositionX - 1 || monster.PositionY == this.PositionY + 1 || monster.PositionY == this.PositionY - 1)
        {
            monster.Health -= Damage;
        }
        else
        {
            Message = "La cible est trop loin pour être attaquée";
        }
    }
    public void Drop(Island map)
    {
        if (Inventory.Count < 0)
        {
            Message = "Votre inventaire est vide";
        }
        else if (map.Grid[PositionX, PositionY] != 'b')
        {
            Message = "Vous ne pouvez pas déposer d'objet ici";
        }

        {
            foreach (var item in Inventory)
            {
                this.Chest.Add(item);
            }
            Inventory.Clear();
            Message = "Vous avez déposé votre inventaire dans le coffre";
        }
    }
    public void Dig(Island map)
    {
        if (Energy <= 0)
        {
            Message = "Vous n'avez plus d'énergie pour creuser";
            return;
        }
        if (map.Tresors[PositionX, PositionY] != null && map.Tresors[PositionX, PositionY].state == true)
        {
            Message = "Vous creusez à la profondeur: " + DiggedValue;
            DiggedValue += 1;
            Energy -= 0.05;
            if (DiggedValue == map.Tresors[PositionX, PositionY].Depth)
            {
                foreach (var item in map.Tresors[PositionX, PositionY].Objects)
                {
                    if (Inventory.Count < 3)
                    {
                        Inventory.Add(item);
                        Message = "Vous avez trouvé l'objet: " + item;
                    }
                    else
                    {
                        Message = "Votre inventaire est plein, vous ne pouvez pas ramasser l'objet: " + item + ". Il reste en surface. Videz votre inventaire sur le bateau.";
                        //item.Depth = 0; je sais pas comment faire ici
                    }
                }

                map.RemoveTresor(PositionX, PositionY);
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
                Energy -= 0.05;
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
            Message = "";
        }

        Console.WriteLine("Joueur: " + Name);
        Console.WriteLine("Niveau: " + Level);
        Console.WriteLine("Santé: " + Health);
        Console.WriteLine("Mana: " + Mana);
        Console.WriteLine("Energie: " + Math.Round(Energy));


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