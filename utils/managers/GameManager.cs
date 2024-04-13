public class GameManager{
    
    public GameManager(){
        Console.WriteLine("Game Manager initialized");
        Console.WriteLine("Game started");
        Map map = new Map();
        this.Rules();
    }

    private void Rules(){
        Console.WriteLine("Vous pouvez choisir une ile parmis les trois iles (1-est, 2-sud, 3-nord)");
        switch(Convert.ToInt32(Console.ReadLine()!))
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