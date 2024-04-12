public class Map
{
    private int[] Dimensions = Config.Instance.MAP_SIZE;
    private char[,] Grid { get; set; }
    private List<Object> Objects { get; set; }
    private Random rd = new Random();
    public Map()
    {
        Grid = new char[Dimensions[0], Dimensions[1]];
        this.Fill();
        this.PlaceIsland();
        Console.WriteLine("Map initialized");
    }

    private void Fill()
    {
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                Grid[i, j] = '~';
            }
        }
    }


    private void SetCurrentPosition(Player player)
    {
        Grid[player.PositionX, player.PositionY] = 'x';
    }

    private void PlaceObjects(List<Object> objects)
    {
    }

    private void PlaceBoat()
    {
    }

    private void PlaceIsland()
    {
        int[,] island = new int[,] { { 12, 2 }, { 5, 4 }, { 1, 7 }, { 14, 7 }, { 2, 8 }, { 8, 9 }, { 12, 10 }, { 11, 10 }, { 13, 11 }, { 10, 11 }, { 14, 11 }, { 2, 12 }, { 13, 12 }, { 3, 13 }, { 0, 13 }, { 10, 13 }, { 11, 13 }, { 3, 14 }, { 9, 14 }, { 5, 14 }, { 6, 14 }, { 7, 14 }, { 2, 3 }, { 4, 9 }, { 9, 10 }, { 7, 12 }, { 6, 9 }, { 12, 12 }, { 3, 9 }, { 1, 9 }, { 10, 12 }, { 11, 7 }, { 8, 7 }, { 0, 9 }, { 8, 4 }, { 7, 2 }, { 13, 7 }, { 11, 6 }, { 14, 8 }, { 13, 14 }, { 1, 10 }, { 4, 3 }, { 6, 10 }, { 4, 12 }, { 14, 2 }, { 12, 11 }, { 2, 14 } };

        for (int i = 0; i < island.Length / 2; i++)
        {
            Grid[island[i, 0], island[i, 1]] = 'O';
        }
    }

    public void Render()
    {
        string chain = "";
        for (int i = 0; i < Dimensions[0]; i++)
        {
            for (int j = 0; j < Dimensions[1]; j++)
            {
                chain += $" {Grid[i, j]} ";
            }
            chain += "\n";
        }
        Console.WriteLine(chain);
    }

    // public void Render()
    // {
    //     string chain = "";
    //     int[,] island = new int[,]; 
    // island= ((2, 10), (2, 11), (2, 12), (2, 13), (2, 14), (2, 15), (2, 16),
    // (3, 10), (3, 11), (3, 12), (3, 13), (3, 14), (3, 15), (3, 16),
    // (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (4, 7), (4, 8), (4, 9),
    // (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7), (5, 8), (5, 9),
    // (6, 2), (6, 3), (6, 4), (6, 5), (6, 6), (6, 7), (6, 8), (6, 9),
    // (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7), (7, 8), (7, 9),
    // (8, 2), (8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8), (8, 9),
    // (9, 2), (9, 3), (9, 4), (9, 5), (9, 6), (9, 7), (9, 8), (9, 9),
    // (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (10, 7), (10, 8), (10, 9));


    //     for (int i = 0; i < 3; i++)
    //     {
    //         for (int j = 0; j < 4; j++)
    //         {
    //             Grid[i, j] = 'b';
    //         }
    //     }
    //     for (int i = 0; i < 2; i++)
    //     {
    //         for (int j = 0; j < Dimensions[1]; j++)
    //         {
    //             Grid[i, j] = 'e';
    //         }
    //     }
    //     for (int i = 0; i < Dimensions[0]; i++)
    //     {
    //         for (int j = 0; j < Dimensions[1]; j++)
    //         {
    //             if (Grid[i, j] == 'b')
    //             {
    //                 chain += "    ";
    //             }
    //             else if (Grid[i, j] == 'e')
    //             {
    //                 chain += " ~~ ";
    //             }
    //             else
    //             {
    //                 chain += " ** ";
    //             }
    //             // chain += (Grid[i, j] == ' ') ? " ** " : "    ";
    //         }
    //         chain += "\n";
    //     }
    //     Console.WriteLine(chain);
    // }
}

// def generate_map():
//     map_width = 15
//     map_height = 15
//     map = [['~' for _ in range(map_width)] for _ in range(map_height)]

//     # Placer les îles en utilisant des motifs de `**`
//     islands = [
//         (2, 10), (2, 11), (2, 12), (2, 13), (2, 14), (2, 15), (2, 16),
//         (3, 10), (3, 11), (3, 12), (3, 13), (3, 14), (3, 15), (3, 16),
//         (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (4, 7), (4, 8), (4, 9),
//         (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7), (5, 8), (5, 9),
//         (6, 2), (6, 3), (6, 4), (6, 5), (6, 6), (6, 7), (6, 8), (6, 9),
//         (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7), (7, 8), (7, 9),
//         (8, 2), (8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8), (8, 9),
//         (9, 2), (9, 3), (9, 4), (9, 5), (9, 6), (9, 7), (9, 8), (9, 9),
//         (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (10, 7), (10, 8), (10, 9)
//     ]

//     for (x, y) in islands:
//         map[x][y] = '**'

//     # Convertir la liste de listes en une chaîne de caractères représentant la carte
//     map_str = '\n'.join([''.join(row) for row in map])
//     return map_str

// # Générer la carte et l'afficher
// map_string = generate_map()
// print(map_string)