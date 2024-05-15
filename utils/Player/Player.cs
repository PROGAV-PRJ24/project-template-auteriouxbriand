
public class Player : Entity
{
    public int Level { get; set; }
    private double _health;
    public double Health
    {
        get => _health;
        set
        {
            _health = value / Protection;
        }
    }
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

    public Player(string name, int level, Island map, int x = 0, int y = 0) : base(name, map)
    {
        Message = new string("");

        this.Spawn(map);

        Name = name;
        Protection = 1;
        Level = level;
        Health = level * 10;
        Mana = level * 2;
        Energy = level * 5;
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
        monster.Health -= Damage * Mana;
        this.Energy -= 0.5;
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
                this.Score += item.Gain;
            }
            Inventory.Clear();
            Message = "Vous avez déposé votre inventaire dans le coffre, vous avez désormais " + this.Score + " points de score";
        }
    }
    public void Dig(Island map)
    {
        if (Energy <= 0)
        {
            Message = "Vous n'avez plus d'énergie pour creuser";
            return;
        }
        if (map.Objects[PositionX][PositionY] != null && map.Objects[PositionX][PositionY].state == true)
        {
            Message = "Vous creusez à la profondeur: " + DiggedValue;
            DiggedValue += 1;
            Energy -= 0.05;
            if (DiggedValue == map.Objects[PositionX][PositionY].Depth)
            {

                List<Object> rest = new List<Object>(); //stockage des items qui ne rentrent pas dans l'inventaire
                List<Object> found = new List<Object>(); //stockage des items qui vont dans l'inventaire
                foreach (var item in map.Objects[PositionX][PositionY].Loot())
                {
                    if (item != null)
                    {
                        if (Inventory.Count < 5)
                        {
                            Console.WriteLine(item.Name);
                            Inventory.Add(item);

                            found.Add(item);
                            map.RemoveObject(PositionX, PositionY);
                        }
                        else
                        {
                            rest.Add(item);
                            map.Objects[PositionX][PositionY].Depth = 0;
                        }

                    }
                }
                if (rest.Count() == 0) //si tous les objets sont rentrés dans l'inventaire
                {
                    string msg = "";
                    foreach (var item in found)
                    {
                        msg = msg + item + ", ";
                    }
                    Message = "Vous avez trouvé les objets : " + msg;
                }
                else if (found.Count() == 0) //si aucun objet est rentré dans l'inventaire
                {
                    string msg = "";
                    foreach (var item in rest)
                    {
                        msg = msg + item + ", ";
                    }
                    Message = "Votre inventaire est plein, vous ne pouvez pas ramasser les objets : " + msg;
                }
                else
                {
                    string msg1 = "";
                    string msg2 = "";
                    foreach (var item in found)
                    {
                        msg1 = msg1 + item + ", ";
                        map.RemoveObject(PositionX, PositionY);

                    }
                    foreach (var item in rest)
                    {
                        msg2 = msg2 + item + ", ";
                    }
                    Message = "Vous avez trouver : " + msg1 + "\n Cependant votre inventaire est plein, vous ne pouvez pas ramasser : " + msg2 + "\n Videz votre inventaire sur le bateau, les objets restent en surface.";

                }
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
        if (Energy < 1)
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
            if (map.Grid[newX, newY] != '#' && map.Grid[newX, newY] != 'b')
            {
                Energy -= 0.25;
            }
        }
        DiggedValue = 0;
    }
    public bool isNearby(Player player, int distance)
    {
        return Math.Abs(player.PositionX - this.PositionX) <= distance && Math.Abs(player.PositionY - this.PositionY) <= distance;
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