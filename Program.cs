public class Program
{
    public static void Main(string[] args)
    {
        Map map = new Map();
        for(int i = 0;i<100;i++){
            Console.Clear();
            Console.WriteLine(map);
            System.Threading.Thread.Sleep(50);
        }
    }
}
