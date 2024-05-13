public class Randomizer
{

    private static Random rd = new Random();

    public Object Object()
    {
        List<Type> objectTypes = new List<Type> { typeof(ColdMatcha), typeof(HotMatcha), typeof(GoldTicket), typeof(Potion), typeof(Tresor) };

        // Générateur de nombres aléatoires
        Random random = new Random();

        // Index aléatoire pour choisir le type d'objet
        int randomIndex = random.Next(objectTypes.Count);

        // Type d'objet sélectionné aléatoirement
        Type selectedType = objectTypes[randomIndex];

        // Instanciation de l'objet sélectionné
        Object newObject = (Object)Activator.CreateInstance(selectedType)!;

        return newObject;
    }
    public Object Object(Object? excluder)
    {
        List<Type> objectTypes = new List<Type> { typeof(ColdMatcha), typeof(HotMatcha), typeof(GoldTicket), typeof(Potion), typeof(Tresor) };

        // Générateur de nombres aléatoires
        Random random = new Random();

        // Index aléatoire pour choisir le type d'objet
        int randomIndex;
        do
        {
            randomIndex = random.Next(objectTypes.Count);
        } while (objectTypes[randomIndex] == excluder!.GetType());
        // Type d'objet sélectionné aléatoirement
        Type selectedType = objectTypes[randomIndex];

        // Instanciation de l'objet sélectionné
        Object newObject = (Object)Activator.CreateInstance(selectedType)!;

        return newObject;
    }

}