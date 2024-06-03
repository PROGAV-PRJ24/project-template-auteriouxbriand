public class Apple : Object
{
    public Apple() : base('a', "Apple")
    {
        Gain = 1; // Gain sur le score
        Eatable = true; // Objet susceptible d'amener de l'énergie
    }
    public Apple(char symb = 'a', string name = "Apple")
            : base(symb, name)
    {
        Gain = 1;
        Eatable = true;
    }
    public override string ToString()
    {
        return $"Une délicieuse pomme";
    }
}