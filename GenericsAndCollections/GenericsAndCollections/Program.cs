using GenericsAndCollections;
using static Zoo;

namespace GenericsAndCollections
{
    class Program
    {
        enum Species { Tiger, Lion, Parrot, Peacock, Rainbowfish, Zebrafish};

        static void Main(string[] args)
        {
            ArrayCollec<int> collec = new ArrayCollec<int>();
            for (int i = 0; i < 5; i++)
            {
                collec.Add(i+1);
            }

            try
            {
                Console.WriteLine(collec.ToString());
                Console.WriteLine(collec.GetByIndex(2));
                collec.SetByIndex(4, 10);
                Console.WriteLine(collec.ToString());
                collec.SwapByIndex(0, 4);
                Console.WriteLine(collec.ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Zoo zoo = new Zoo();
            zoo.AddAnimal(new Peacock { Name = "Alice", Speed = 134 });
            zoo.AddAnimal(new Tiger { Name = "Fred", Speed = 330 });
            zoo.AddAnimal(new Lion { Name = "Alma", Speed = 410 });
            zoo.AddAnimal(new Zebrafish { Name = "Dory", Speed = 450 });
            zoo.AddAnimal(new Parrot { Name = "Pirrie", Speed = 210 });
            zoo.AddAnimal(new Rainbowfish { Name = "Nemo", Speed = 368 });

            List<Animal> animals = zoo.GetAnimals();

            foreach(int i in Enum.GetValues(typeof(Species)))
            {
                if (Enum.GetName(typeof(Species), i).Equals(animals[3].GetType().Name)){
                    Console.WriteLine(i);
                }
            }

            zoo.GenerateIdDictionary();
            zoo.PrintIdDictionary();
        }
    }
}