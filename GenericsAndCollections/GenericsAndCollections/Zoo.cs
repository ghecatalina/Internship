public class Zoo
{
    private List<Animal> animals = new List<Animal>();
    private Dictionary<Animal, string> identifierMap = new Dictionary<Animal, string>();

    public void GenerateIdDictionary()
    {
        int code = 234;
        foreach (Animal animal in animals)
        {
            string id = "" + animal.Name + code++ + animal.GetType().Name;
            identifierMap.Add(animal, id);
        }
    }

    public void PrintIdDictionary()
    {
        foreach (KeyValuePair<Animal, string> identifier in identifierMap)
        {
            Console.WriteLine($"Id code for {identifier.Key.Name} is {identifier.Value}");
        }
    }

    public void AddAnimal(Animal animal)
    {
        this.animals.Add(animal);
    }

    public int GetCount()
    {
        return animals.Count;
    }

    public List<Animal> GetAnimals()
    {
        return animals;
    }
    public override string ToString()
    {
        string output = "Animals in Zoo:\n";
        foreach (Animal animal in animals)
        {
            output += animal.GetType().Name + " " + animal.Name + "\n";
        }
        return output;
    }

    public abstract class Animal
    {
        public string? Name { get; set; }

        public abstract void DoEat();
        public abstract void DoMove();

    }

    public abstract class Mammal : Animal
    {
        private bool _canProduceMilk = true;
        private int _speed;
        public bool CanProduceMilk { get { return _canProduceMilk; } }

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value > 500)
                    _speed = 500;
                if (value < 0)
                    _speed = 0;
                else
                    _speed = value;
            }
        }

        public override void DoEat()
        {
            Console.WriteLine($"The mammal {this.Name} is eating.");
        }

        public override void DoMove()
        {
            Console.WriteLine($"The mammal {this.Name} is running.");
        }
    }

    public abstract class Bird : Animal
    {
        private bool _canFly = true;
        private int _speed;
        public bool CanFly { get { return _canFly; } }

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value > 300)
                    _speed = 300;
                if (value < 0)
                    _speed = 0;
                else
                    _speed = value;
            }
        }

        public override void DoMove()
        {
            Console.WriteLine($"The bird {this.Name} is flying.");
        }

        public override void DoEat()
        {
            Console.WriteLine($"The bird {this.Name} is eating.");
        }
    }

    public abstract class Fish : Animal
    {
        private bool _canBreatheUnderwater = true;
        private int _speed;
        public bool CanBreatheUnderwater { get { return _canBreatheUnderwater; } }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value > 400)
                    _speed = 400;
                if (value < 0)
                    _speed = 0;
                else
                    _speed = value;
            }
        }
        public override void DoEat()
        {
            Console.WriteLine($"The fish {this.Name} is eating.");
        }

        public override void DoMove()
        {
            Console.WriteLine($"The fish {this.Name} is swimming.");
        }

        public abstract void ShowOffColor();
    }

    public class Lion : Mammal
    {
        public void Roar()
        {
            Console.WriteLine($"Lion {this.Name} roars.");
        }

        public void Roar(int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Lion {this.Name} roars.");
        }
    }

    public class Tiger : Mammal
    {
        public void Growl()
        {
            Console.WriteLine($"Tiger {this.Name} growls");
        }

        public void Growl(int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Tiger {this.Name} growls");
        }
    }

    public class Parrot : Bird
    {
        public void Imitate()
        {
            Console.WriteLine($"Parrot {this.Name} imitates humans.");
        }
    }

    public class Peacock : Bird
    {
        public void SpreadTail()
        {
            Console.WriteLine($"Peacock {this.Name} spreads its tail");
        }
    }

    public class Rainbowfish : Fish, ICloneable
    {
        public object Clone()
        {
            return new Rainbowfish { Name = this.Name, Speed = this.Speed };
        }

        public override void ShowOffColor()
        {
            Console.WriteLine($"Rainbowfish {this.Name} shows off its rainbow colors.");
        }
    }

    public class Zebrafish : Fish
    {
        public override void ShowOffColor()
        {
            Console.WriteLine($"Zebrafish {this.Name} shows off its zebra pattern.");
        }
    }
}